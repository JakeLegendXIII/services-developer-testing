namespace Banking.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // "Create the world anew" - Given (Arrange)
        int a = 10, b = 20, answer;
        // Poke at it - WHen (Act)
        answer = a + b; // "Unit" we are testing here (SUT) addition 
        // Observer the results - Then (Assert)
        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(5, 10, 15)]
    [InlineData(2, 2, 4)]
    public void CanAddAnyTwoIntegers(int a , int b, int expected)
    {
        int answer = a + b;

        Assert.Equal(expected, answer);
    }
}