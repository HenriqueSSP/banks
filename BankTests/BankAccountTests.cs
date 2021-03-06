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
            Assert.AreEqual(expected, actual, "D�bito n�o ocorreu corretamente.");
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
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Henrique", beginningBalance);

            // Act and assert
            //removi-> Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Novo Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credito_QuandoOCreditoForNegativo_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningCredit = 11.99;
            double creditAmount = -19.0;
            BankAccount account = new BankAccount("Henrique", beginningCredit);

            //Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [TestMethod]
        public void Credito_QuandoOCreditoSoma_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningCredit = 12.0;
            double creditAmount = 5.0;
            double expected = 17.0;
            BankAccount account = new BankAccount("Henrique", beginningCredit);

            //Act
            account.Credit(creditAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Cr�dito ocorreu sem problemas.");
        }

    }
}
