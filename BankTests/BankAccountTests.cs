using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
       

        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Henrique", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Débito não ocorreu corretamente.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Henrique", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(()=>account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 14.99;
            BankAccount account = new BankAccount("Henrique", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

    }
}
