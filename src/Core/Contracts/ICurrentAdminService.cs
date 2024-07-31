using Core.Entities;

namespace Core.Contracts;

public interface ICurrentAdminService
{
    public Admin? Admin { get; }
}