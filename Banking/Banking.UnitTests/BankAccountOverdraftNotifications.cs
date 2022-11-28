namespace Banking.UnitTests;

public class BankAccountOverdraftNotifications
{
    [Fact]
    public void ApiIsNotifiedUponOverdraft()
    {
        // Given
        var mockedNotifier = new Mock<INotifyOfOverdrafts>();
        var account = new BankAccount(mockedNotifier.Object, new Mock<ILogger>().Object);
        var amountToWithDraw = account.GetBalance() + .01M;

        // When I overdraft
        try
        {
            account.Withdraw(amountToWithDraw); // Cause an overdraft
        }
        catch (Exception)
        {
            // Nothing
        }

        // Verify the notifier was called with the account and the amount
        mockedNotifier.Verify(m => m.NotifyOfOverdraftAttempt(account, amountToWithDraw), Times.Once);

    }

    [Fact]
    public void ApiIsNotNotifiedWhenNoOverdraft()
    {
        // Given
        var mockedNotifier = new Mock<INotifyOfOverdrafts>();
        var account = new BankAccount(mockedNotifier.Object, new Mock<ILogger>().Object);
        var amountToWithDraw = 1M;

        // When I overdraft
        try
        {
            account.Withdraw(amountToWithDraw); // Cause an overdraft
        }
        catch (Exception)
        {
            // Nothing
        }

        // Verify the notifier was NOT called with the account and the amount
        mockedNotifier.Verify(m => m.NotifyOfOverdraftAttempt(account, amountToWithDraw), Times.Never);
    }

    [Fact]
    public void IfApiThrowsWriteToTheLogger()
    {
        // Given
        var stubbedNotifier = new Mock<INotifyOfOverdrafts>();
        var mockedLogger = new Mock<ILogger>();
        var account = new BankAccount(stubbedNotifier.Object, mockedLogger.Object);
        var amountToWithDraw = account.GetBalance() + .01M;
        stubbedNotifier.Setup(m => m.NotifyOfOverdraftAttempt(It.IsAny<BankAccount>(), It.IsAny<decimal>()))
            .Throws(new HttpRequestException());

        // When
        try
        {
            account.Withdraw(amountToWithDraw);
        }
        catch (AccountOverdraftException)
        {
            // was expecing this
        }
        // Then...
        mockedLogger.Verify(m => m.LogError("The Notification API Is Down - Overdraft", amountToWithDraw));
    }
}
