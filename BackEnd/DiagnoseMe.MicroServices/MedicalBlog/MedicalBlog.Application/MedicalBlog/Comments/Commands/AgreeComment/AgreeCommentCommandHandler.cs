using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.AgreeComment;


public class AgreeCommentCommandHandler : IRequestHandler<AgreeCommentCommand, ErrorOr<CommandResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly ICommentAgreementRepository _commentAgreementRepository;
    private readonly IUserRepository _userRepository;

    public AgreeCommentCommandHandler(
        ICommentRepository commentRepository,
        ICommentAgreementRepository commentAgreementRepository,
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _commentAgreementRepository = commentAgreementRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AgreeCommentCommand command, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(command.CommentId);
        if (comment == null)
        {
            return Errors.Comment.NotFound;
        }
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
        {
            // TODO: Check for user in Auth service
            return Errors.User.NotFound;
        }
        var commentAgreement = (await _commentAgreementRepository.Get(
            x => x.CommentId == command.CommentId && x.UserId == command.UserId))
            .FirstOrDefault();

        

        if (commentAgreement == null)
        {
            commentAgreement = new CommentAgreement
            {
                CommentId = command.CommentId,
                UserId = command.UserId,
                IsAgreed = true
            };
            await _commentAgreementRepository.AddAsync(commentAgreement);
        }
        else
        {
            commentAgreement.IsAgreed = !commentAgreement.IsAgreed;
            await _commentAgreementRepository.Edit(commentAgreement);
        }

        if (await _commentAgreementRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Comment.AgreementFailed;
                
        return new CommandResponse(
            true,
            "Comment agreement changed successfully",
            $"comments/{command.CommentId}"
        );
    }
}