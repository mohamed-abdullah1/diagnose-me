using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Common;

public record AnswerResponse(
    string Id,
    string QuestionId,
    string AnswerString,
    DoctorData AnsweringDoctor,
    string CreatedOn,
    string? ModifiedOn,
    int AgreementCount,
    int DisagreementCount,
    QuestionResponse? Question
);