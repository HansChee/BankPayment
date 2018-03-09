using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace BankPayment.Test
{
    [TestClass]
    public class TestFunction
    {
        [TestMethod]
        public void TestRegExpression()
        {
            string expression = @"^\d{3}-\d{3}$";

            Regex reg = new Regex(expression);
            string input = "312-345";
            input = "fdsea";
            input = "43254";
            Assert.AreEqual(true, reg.Match(input).Success);
        }
    }
}
