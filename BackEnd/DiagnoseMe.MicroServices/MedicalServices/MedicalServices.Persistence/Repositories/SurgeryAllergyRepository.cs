using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;
public class SurgeryAllergyRepository : BaseRepo<SurgeryAllergy>, ISurgeryAllergyRepository
{
    public SurgeryAllergyRepository(DbContext context) : base(context)
    {
    }
}