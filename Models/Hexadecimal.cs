namespace Slimepen.Models
{
    public static class Hexadecimal
    {
        public static string DecimalToHex(double num)
        {
            int remainder;
            int quotient = (int)num;
            int i = 0;
            char[] hex = new char[6];
            string hexadecimal = "";

            while (quotient != 0)
            {
                remainder = quotient % 16;

                // If remainder is 0-9, it is then converted into the Unicode equivalent
                if (remainder < 10) remainder += 48;
                // Otherwise, the remainder is converted into the Unicode equivalent of A-F
                else remainder += 55;

                hex[i] = (char)remainder;

                quotient /= 16;
                i++;
            }

            while (i < 6)
            {
                hex[i] = '0';
                i++;
            }

            for (i = 0; i < hex.Length; i++)
            {
                hexadecimal += hex[i];
            }

            return hexadecimal;
        }

        public static double HexToDecimal(string hex)
        {
            double num = 0;
            int unicode;

            for (int i = 0; i < hex.Length; i++)
            {
                unicode = hex[i];

                // Converts unicode characters to integers; if it is a digit character, it will be converted to its integer form, e.g. '0' = 0
                if (unicode >= 48 && unicode <= 57) unicode -= 48;
                // If unicode characters A-F, then it will be converted into the corresponding hexadecimal values, e.g. 'A' = 10 or 'F' = 15
                if (unicode >= 65 && unicode <= 90) unicode -= 55;

                num += unicode * Math.Pow(16, i);
            }

            return num;
        }

        public static string AverageHex(string str1, string str2)
        {
            var avgHexNum = (HexToDecimal(str1) + HexToDecimal(str2)) / 2;

            var hexString = DecimalToHex(avgHexNum);

            return hexString;
        }
    }
}
