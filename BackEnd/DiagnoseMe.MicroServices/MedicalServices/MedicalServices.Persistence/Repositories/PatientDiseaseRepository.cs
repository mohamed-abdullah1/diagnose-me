using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class PatientDiseaseRepository : BaseRepo<PatientDisease>, IPatientDiseaseRepository
{
    public PatientDiseaseRepository(DbContext context) : base(context)
    {
    }
}