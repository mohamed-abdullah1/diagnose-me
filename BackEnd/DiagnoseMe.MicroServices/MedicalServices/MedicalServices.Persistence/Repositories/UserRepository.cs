using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class UserRepository : BaseRepo<User>,IUserRepository
{
    public UserRepository(DbContext db) : base(db)
    {
    }   
}