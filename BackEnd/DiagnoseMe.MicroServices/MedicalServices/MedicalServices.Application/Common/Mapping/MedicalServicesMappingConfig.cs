
using Mapster;
using MedicalServices.Application.MedicalServcies.Clinics.Common;
using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Api.Common.Mapping;

public class MedicalServicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Clinic, ClinicResponse>().
        Map(dest => dest.DoctorsCount, src => src.Doctors.Count).
        Map(dest => dest.ClinicAddressesCount, src => src.ClinicAddresses.Count).
        Map(dest => dest, src => src);
        config.NewConfig<Doctor, DoctorResponse>().
        Map(dest => dest, src => src.User).
        Map(dest => dest, src => src);
        config.NewConfig<ClinicAddress, ClinicAddressResponse>().
        Map(dest => dest.OpenTime, src => src.OpenTime.ToString("hh:mm")).
        Map(dest => dest.CloseTime, src => src.CloseTime.ToString("hh:mm")).
        Map(dest => dest, src => src);

    }
}