using BloodDonation.Domain.Common.BloodTypes;
using FluentValidation;

namespace BloodDonation.Application.BloodDonation.Commands.RequestDonation;


public class RequestDonationCommandValidator : AbstractValidator<RequestDonationCommand>
{
    public RequestDonationCommandValidator()
    {
        RuleFor(x => x.BloodType).NotEmpty()
            .WithMessage("Blood type is required")
            .Must(x => BloodTypes.All.Contains(x));
        RuleFor(x => x.Location).NotEmpty()
            .WithMessage("Location is required");
        RuleFor(x => x.Reason).NotEmpty()
            .WithMessage("Reason is required");
        RuleFor(x => x.RequesterId).NotNull()
            .WithMessage("RequesterId is required");
    }
}