using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class DiseaseRepository : BaseRepo<Disease>, IDiseaseRepository
{
    public DiseaseRepository(DbContext context) : base(context)
    {
    }
}