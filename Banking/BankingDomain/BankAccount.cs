using System.Reflection.Metadata.Ecma335;

namespace BankingDomain;

public class BankAccount
{
    private decimal _balance = 5000M;
    private readonly INotifyOfOverdrafts _overdraftNotifier;
    private readonly ILogger _logger;

    public BankAccount(INotifyOfOverdrafts overdraftNotifier, ILogger logger)
    {
        _overdraftNotifier = overdraftNotifier;
        _logger = logger;
    }

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {        
        if (_balance < amountToWithdraw)
        {
            // WTCYWYH (Write the code you wish you had)
            try
            {
                _overdraftNotifier.NotifyOfOverdraftAttempt(this, amountToWithdraw);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("The Notification API Is Down - Overdraft", amountToWithdraw);
            }
            
            throw new AccountOverdraftException();
        }
        else
        {
            _balance -= amountToWithdraw;
        }        
    }
}