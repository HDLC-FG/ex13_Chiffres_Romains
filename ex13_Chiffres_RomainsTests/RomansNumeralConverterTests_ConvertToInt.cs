using ex13_Chiffres_Romains;

namespace ex13_Chiffres_RomainsTests
{
    [TestClass]
    public sealed class RomansNumeralConverterTests_ConvertToInt
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void T01_ConvertToInt_NumberIsNullOrEmpty_ThrowException(string number)
        {
            var converter = new RomansNumeralConverter();

            var ex = Assert.ThrowsException<Exception>(() => converter.ConvertToInt(number));
            
            Assert.IsNotNull(ex);
            Assert.AreEqual("Nombre incorrect", ex.Message);
        }

        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("V", 5)]
        [DataRow("X", 10)]
        [DataRow("L", 50)]
        [DataRow("C", 100)]
        [DataRow("D", 500)]
        [DataRow("M", 1000)]
        public void T02_ConvertToInt_IVXLCDM_ReturnOk(string number, int value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToInt(number);

            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("II", 2)]
        [DataRow("III", 3)]
        [DataRow("V", 5)]
        [DataRow("VI", 6)]
        [DataRow("VII", 7)]
        [DataRow("VIII", 8)]
        [DataRow("X", 10)]
        public void T03_ConvertToInt_IToX_Without_IVandIX_ReturnOk(string number, int value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToInt(number);

            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow("IV", 4)]
        [DataRow("IX", 9)]
        [DataRow("XL", 40)]
        [DataRow("CD", 400)]
        [DataRow("CM", 900)]
        public void T04_ConvertToInt_SpecialCombinations_IV_IX_XL_XC_CD_CM_ReturnOk(string number, int value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToInt(number);

            Assert.AreEqual(value, result);
        }

        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("VII", 7)]
        [DataRow("X", 10)]
        [DataRow("XLIX", 49)]
        [DataRow("DCCCXLVII", 847)]
        [DataRow("MLIII", 1053)]
        [DataRow("MDCCLXXVI", 1776)]
        [DataRow("MMXVIII", 2018)]
        public void T05_ConvertToInt_FinalTest_ReturnOk(string number, int value)
        {
            var converter = new RomansNumeralConverter();

            var result = converter.ConvertToInt(number);

            Assert.AreEqual(value, result);
        }
    }
}
