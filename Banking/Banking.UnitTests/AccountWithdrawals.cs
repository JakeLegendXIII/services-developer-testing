
using BankingDomain;

namespace Banking.UnitTests;

public class AccountWithdrawals
{
    [Fact]
    public void WithdrawingMoneyDecreasesTheBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 100M;

        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact(Skip = "Working on it")]
    public void WithdrawingAllMoney()
    {

    }

    [Fact(Skip = "Working on it")]
    public void Overdraft()
    {

    }
}
