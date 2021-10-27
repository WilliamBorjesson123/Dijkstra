using System.Text.RegularExpressions;
using System;

namespace Västtrafik2._1
{
    public static class Input
    {
        // switches the string from input to a integer.
        public static int SwitchInputToInteger(string input)
        {
            var integerOutPut = 0;
            switch (input.ToUpper())
            {
                case "A":
                    integerOutPut = 0;
                    break;

                case "B":
                    integerOutPut = 1;
                    break;

                case "C":
                    integerOutPut = 2;
                    break;

                case "D":
                    integerOutPut = 3;
                    break;

                case "E":
                    integerOutPut = 4;
                    break;

                case "F":
                    integerOutPut = 5;
                    break;

                case "G":
                    integerOutPut = 6;
                    break;

                case "H":
                    integerOutPut = 7;
                    break;

                case "I":
                    integerOutPut = 8;
                    break;

                case "J":
                    integerOutPut = 9;
                    break;

                default:
                    break;
            }
            return integerOutPut;
        }

        public static bool CheckIfInputIsString(string input)
        {
            if (Regex.IsMatch(input, "^[a-j]+$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIfInputIsStringAZ(string input)
        {
            if (Regex.IsMatch(input, "^[a-z]+$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
