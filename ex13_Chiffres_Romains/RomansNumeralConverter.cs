namespace ex13_Chiffres_Romains
{
    public class RomansNumeralConverter
    {
        public int ConvertToInt(string number)
        {
            if (string.IsNullOrEmpty(number)) throw new Exception("Nombre incorrect");

            var result = 0;
            char[] numberArray = number.ToCharArray();

            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i < numberArray.Length - 1 && Combinate(string.Concat(numberArray[i], numberArray[i + 1])) != -1)
                {

                    result += Combinate(string.Concat(numberArray[i], numberArray[i + 1]));
                    i++;
                }
                else
                {
                    result += numberArray[i] switch
                    {
                        'I' => 1,
                        'V' => 5,
                        'X' => 10,
                        'L' => 50,
                        'C' => 100,
                        'D' => 500,
                        'M' => 1000,
                        _ => throw new Exception("Valeur incorrecte")
                    };
                }
            }

            return result;
        }

        public string ConvertToRomanNumeral(int number)
        {
            if (number <= 0) throw new Exception("Nombre incorrect");

            var result = string.Empty;
            var remains = number;

            while(number != 0)
            {
                result += GetRomanNumber(ref number);
            }

            return result;
        }

        private string GetRomanNumber(ref int number)
        {
            var result = string.Empty;
            switch (number)
            {
                case >= 1000:
                    result = new string('M', number / 1000);
                    number = number % 1000;
                    break;
                case >= 900:
                    result = "CM";
                    number = number % 900;
                    break;
                case >= 500:
                    result = new string('D', number / 500);
                    number = number % 500;
                    break;
                case >= 400:
                    result = "CD";
                    number = number % 400;
                    break;
                case >= 100:
                    result = new string('C', number / 100);
                    number = number % 100;
                    break;
                case >= 50:
                    result = new string('L', number / 50);
                    number = number % 50;
                    break;
                case >= 40:
                    result = "XL";
                    number = number % 40;
                    break;
                case >= 10:
                    result = new string('X', number / 10);
                    number = number % 10;
                    break;
                case 9:
                    result = "IX";
                    number = number % 9;
                    break;
                case >= 5:
                    result = new string('V', number / 5);
                    number = number % 5;
                    break;
                case 4:
                    result = "IV";
                    number = number % 4;
                    break;
                case >= 1:
                    result = new string('I', number);
                    number = 0;
                    break;
                default:
                    throw new Exception("Valeur incorrecte");
            }

            return result;
        }

        private int Combinate(string number)
        {
            return number switch
            {
                "IV" => 4,
                "IX" => 9,
                "XL" => 40,
                "CD" => 400,
                "CM" => 900,
                _ => -1
            };
        }
    }
}
