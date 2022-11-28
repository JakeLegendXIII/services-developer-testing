namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // GIVEN
        // dummy objects are usually created in the constructor
        // of the SUT with the NEW keyword
        // They 
        var account = new BankAccount(new Mock<INotifyOfOverdrafts>().Object, new Mock<ILogger>().Object);
        var expectedBalance = 5000M;

        // WHEN
        decimal actualBalance = account.GetBalance();

        // THEN
        Assert.Equal(expectedBalance, actualBalance);
    }
}


