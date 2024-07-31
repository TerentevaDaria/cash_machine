using Core.Models;

namespace Core.Abstractions;

public interface IAdminRepository
{
    public Task<AdminInfo> GetById(long id);
}