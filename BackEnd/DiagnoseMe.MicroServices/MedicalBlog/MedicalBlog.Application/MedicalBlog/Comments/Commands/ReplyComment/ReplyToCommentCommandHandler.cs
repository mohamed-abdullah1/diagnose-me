using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Comments.Commands.ReplyComment;

public class ReplyToCommentCommandHandler : IRequestHandler<ReplyToCommentCommand, ErrorOr<CommandResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    public ReplyToCommentCommandHandler(
        ICommentRepository commentRepository,
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(ReplyToCommentCommand command, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(command.PostId);
        if (post == null)
        {
            return Errors.Post.NotFound;
        }
        var author = await _userRepository.GetByIdAsync(command.AuthorId);
        if (author == null)
        {
            return Errors.User.NotFound;
        }
        var parent = await _commentRepository.GetByIdAsync(command.ParentId);
        if (parent == null)
        {
            return Errors.Comment.ParentNotFound;
        }
        var comment = new Comment{
            Id = Guid.NewGuid().ToString(),
            Content = command.Content,
            AuthorId = command.AuthorId,
            PostId = command.PostId,
            ParentId = command.ParentId,
        };

        await _commentRepository.AddAsync(comment);
        if (await _commentRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Comment.AddFailed;
            
        return new CommandResponse(
            true,
            "Comment added successfully",
            $"posts/{command.PostId}"
        );
    }
}