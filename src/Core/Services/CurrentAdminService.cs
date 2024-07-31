using Core.Contracts;
using Core.Entities;

namespace Core.Services;

public class CurrentAdminService : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}