using Core.Abstractions;
using Core.Exceptions;
using Core.Models;
using Core.Services;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankAccountManagerTest
{
    [Fact]
    public void ChangeBalanceSuccess()
    {
        // Arrange
        long id = 1;
        long start = 15;
        long change = -5;
        IBankAccountRepository repository = Substitute.For<IBankAccountRepository>();
        IBankAccountManager manager = new BankAccountManager(repository);
        repository.GetById(id).Returns(new BankAccount(id, 123, start));

        // Act
        manager.ChangeBalance(id, change);

        // Assert
        repository.Received().Update(Arg.Is<BankAccount>(x => x is BankAccount && x.Id == id && x.Balance == start + change));
    }

    [Fact]
    public void ChangeBalanceFail()
    {
        // Arrange
        long id = 1;
        long start = 15;
        long change = -50;
        IBankAccountRepository repository = Substitute.For<IBankAccountRepository>();
        IBankAccountManager manager = new BankAccountManager(repository);
        repository.GetById(id).Returns(new BankAccount(id, 123, start));

        // Act && Assert
        Assert.ThrowsAsync<InsufficientBalanceException>(() => manager.ChangeBalance(id, change));
    }

    [Fact]
    public void PositiveChangeBalanceSuccess()
    {
        // Arrange
        long id = 1;
        long start = 15;
        long change = 5;
        IBankAccountRepository repository = Substitute.For<IBankAccountRepository>();
        IBankAccountManager manager = new BankAccountManager(repository);
        repository.GetById(id).Returns(new BankAccount(id, 123, start));

        // Act
        manager.ChangeBalance(id, change);

        // Assert
        repository.Received().Update(Arg.Is<BankAccount>(x => x is BankAccount && x.Id == id && x.Balance == start + change));
    }
}