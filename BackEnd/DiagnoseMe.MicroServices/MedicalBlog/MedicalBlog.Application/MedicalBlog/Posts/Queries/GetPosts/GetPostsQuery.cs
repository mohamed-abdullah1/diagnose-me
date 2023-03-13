using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Posts.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Queries.GetPosts;

public record GetPostsQuery(
    int PageNumber,
    string UserId) : IRequest<ErrorOr<List<PostResponse>>>;