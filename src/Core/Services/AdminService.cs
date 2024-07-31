using Core.Abstractions;
using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using Core.Models;

namespace Core.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IBankAccountRepository _accountRepository;
    private readonly CurrentAdminService _currentAdmin;

    public AdminService(IAdminRepository repository, CurrentAdminService currentAdmin, IBankAccountRepository accountRepository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));
        currentAdmin = currentAdmin ?? throw new ArgumentNullException(nameof(currentAdmin));
        accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));

        _repository = repository;
        _currentAdmin = currentAdmin;
        _accountRepository = accountRepository;
    }

    public async Task Login(long id, string password)
    {
        AdminInfo admin;
        try
        {
            admin = await _repository.GetById(id);
        }
        catch (RepositoryException)
        {
            throw new LoginFailedException("admin " + id + " not found");
        }

        if (password != admin.Password) throw new LoginFailedException("wrong password");

        _currentAdmin.Admin = new Admin(_accountRepository, admin.Id, admin.Password);
    }

    public void Logout()
    {
        _currentAdmin.Admin = null;
    }
}