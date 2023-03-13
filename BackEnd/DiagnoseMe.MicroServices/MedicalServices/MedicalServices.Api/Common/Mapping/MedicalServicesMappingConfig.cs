using Mapster;
using MedicalServices.Application.MedicalServcies.Clinics.Commands.AddClinicAddress;
using MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicAddress;
using MedicalServices.Contracts.Clinics;

namespace MedicalServices.Api.Common.Mapping;

public class MedicalServicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(AddClinicAddressRequest request, string OwnerId),AddClinicAddressCommand>().
                    Map(dest => dest.OwnerId, src => src.OwnerId).
                    Map(dest => dest, src => src.request);
        config.NewConfig<(UpdateClinicAddressRequest request, string DoctorId),UpdateClinicAddressCommand>().
                    Map(dest => dest.DoctorId, src => src.DoctorId).
                    Map(dest => dest, src => src.request);
    }
}
