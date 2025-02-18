using ex13_Chiffres_Romains;

namespace ex13_Chiffres_RomainsTests
{
    [TestClass]
    public sealed class RomansNumeralConverterTests_ConvertToRomanNumeral
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void T01_ConvertToRomanNumeral_NumberIsNullOrEmpty_ThrowException(int number)
        {
            var converter = new RomansNumeralConverter();

            var ex = Assert.ThrowsException<Exception>(() => converter.ConvertToRomanNumeral(number));

            Assert.IsNotNull(ex);
            Assert.AreEqual("Nombre incorrect", ex.Message);
        }

        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(5, "V")]
        [DataRow(10, "X")]
        [DataRow(50, "L")]
        [DataRow(100, "C")]
        [DataRow(500, "D")]
        [DataRow(1000, "M")]
        public void T02_ConvertToRomanNumeral_baseNumber_ReturnOk(int number, string value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToRomanNumeral(number);
            
            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(3, "III")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(7, "VII")]
        [DataRow(8, "VIII")]
        [DataRow(10, "X")]
        public void T03_ConvertToRomanNumeral_Without_IVandIX_ReturnOk(int number, string value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToRomanNumeral(number);

            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(40, "XL")]
        [DataRow(400, "CD")]
        [DataRow(900, "CM")]
        public void T04_ConvertToRomanNumeral_SpecialCombinations_IV_IX_XL_XC_CD_CM_ReturnOk(int number, string value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToRomanNumeral(number);

            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(7, "VII")]
        [DataRow(10, "X")]
        [DataRow(49, "XLIX")]
        [DataRow(847, "DCCCXLVII")]
        [DataRow(1053, "MLIII")]
        [DataRow(1776, "MDCCLXXVI")]
        [DataRow(2018, "MMXVIII")]
        public void T05_ConvertToRomanNumeral_FinalTest_ReturnOk(int number, string value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToRomanNumeral(number);

            Assert.AreEqual(value, result);
        }
    }
}
