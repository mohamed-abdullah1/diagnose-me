using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.Doctors.Commands.UpdateDoctor;


public record UpdateDoctorCommand(
    string Id,
    string ddd,
    float Rating) :IRequest<ErrorOr<CommandResponse>>;