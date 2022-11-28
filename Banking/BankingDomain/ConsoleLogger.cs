
namespace BankingDomain;

public class ConsoleLogger : ILogger
{
    public void LogError(string message, decimal amountToWithdraw)
    {
        Console.Write($"{message} {amountToWithdraw}");
    }
}
