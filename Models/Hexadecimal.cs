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
                if (remainder < 10) remainder = remainder + 48;
                else remainder = remainder + 55;
                hex[i] = (char)remainder;
                quotient = quotient / 16;
                i++;
            }

            while (i < 6)
            {
                hex[i] = '0';
                i++;
            }

            for (i = hex.Length - 1; i >= 0; i--)
            {
                hexadecimal += hex[i];
            }

            while (hexadecimal.Length < 6)
            {
                hexadecimal = "0" + hexadecimal;
            }

            return hexadecimal;
        }

        public static double HexToDecimal(string hex)
        {
            double num = 0;
            int rem;

            for (int i = 0; i < hex.Length; i++)
            {
                rem = hex[i];
                if (rem >= 48 && rem <= 57) rem -= 48;
                if (rem >= 65 && rem <= 90) rem -= 55;
                num += rem * Math.Pow(16, i);
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
