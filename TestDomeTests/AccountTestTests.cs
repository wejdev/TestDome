using JetBrains.Annotations;
using TestDome;

namespace TestDomeTests;

[TestSubject(typeof(AccountTest))]
public class AccountTestTests
{
    [Fact]
    public void DepositRejectsNegativeNumberTest()
    {
        const int overdraftLimit = 100;
        const int depositAmount = -5;
        var accountTest = new AccountTest(overdraftLimit);

        var balancePrior = accountTest.Balance;
        var succeeded = accountTest.Deposit(depositAmount);
        var balanceAfter = accountTest.Balance;

        Assert.False(succeeded);
        Assert.Equal(0, balancePrior);
        Assert.Equal(0, balanceAfter);
    }

    [Fact]
    public void WithdrawRejectsNegativeNumbersTest()
    {
        const int overdraftLimit = 100;
        const int withdrawlAmount = -5;
        var accountTest = new AccountTest(overdraftLimit);

        var balancePrior = accountTest.Balance;
        var succeeded = accountTest.Withdraw(withdrawlAmount);
        var balanceAfter = accountTest.Balance;

        Assert.False(succeeded);
        Assert.Equal(0, balancePrior);
        Assert.Equal(0, balanceAfter);
    }

    [Fact]
    public void DepositCorrectAmountTest()
    {
        const int overdraftLimit = 100;
        const int depositAmount = 50;
        var accountTest = new AccountTest(overdraftLimit);

        var balancePrior = accountTest.Balance;
        var succeeded = accountTest.Deposit(depositAmount);
        var balanceAfter = accountTest.Balance;

        Assert.True(succeeded);
        Assert.Equal(0, balancePrior);
        Assert.Equal(depositAmount, balanceAfter);
    }

    [Fact]
    public void WithdrawCorrectAmountTest()
    {
        const int overdraftLimit = 100;
        const int depositAmount = 50;
        const int withdrawlAmount = 10;
        var accountTest = new AccountTest(overdraftLimit);

        var depositSucceeded = accountTest.Deposit(depositAmount);
        var balanceAfter = accountTest.Balance;
        Assert.True(depositSucceeded);
        Assert.Equal(depositAmount, balanceAfter);

        var withdrawlSucceeded = accountTest.Withdraw(withdrawlAmount);
        balanceAfter = accountTest.Balance;
        Assert.True(withdrawlSucceeded);
        Assert.Equal(depositAmount - withdrawlAmount, balanceAfter);
    }

    [Fact]
    public void AccountCannotOverstepOverdraftLimitTest()
    {
        const int overdraftLimit = 100;
        const int depositAmount = 50;
        const int withdrawlAmount = 10;
        const int bigWithdrawAmount = 100;
        const int smallWithdrawAmount = 50;
        var accountTest = new AccountTest(overdraftLimit);

        var depositSucceeded = accountTest.Deposit(depositAmount);
        var balanceAfter = accountTest.Balance;
        Assert.True(depositSucceeded);
        Assert.Equal(depositAmount, balanceAfter);

        var withdrawlSucceeded = accountTest.Withdraw(withdrawlAmount);
        balanceAfter = accountTest.Balance;
        Assert.True(withdrawlSucceeded);
        Assert.Equal(depositAmount - withdrawlAmount, balanceAfter);

        withdrawlSucceeded = accountTest.Withdraw(bigWithdrawAmount);
        balanceAfter = accountTest.Balance;
        Assert.True(withdrawlSucceeded);
        Assert.Equal(depositAmount - withdrawlAmount - bigWithdrawAmount, balanceAfter);

        withdrawlSucceeded = accountTest.Withdraw(smallWithdrawAmount);
        balanceAfter = accountTest.Balance;
        Assert.False(withdrawlSucceeded); // Exceeds withdrawl amount
        Assert.Equal(depositAmount - withdrawlAmount - bigWithdrawAmount, balanceAfter);
    }

    [Fact]
    public void AccountCannotHaveNegativeOverdraftLimitTest()
    {
        var accountTest = new AccountTest(-123);
        var balance = accountTest.Balance;

        Assert.Equal(0, balance);
    }
}
