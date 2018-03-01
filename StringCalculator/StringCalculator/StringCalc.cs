using System;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalc
    {
        public int AddStrings(string numbers)
        {
            int total = 0;
            /*
             * Regex pattern for some delimeters. Excluding single *,/,+,-,^ Idea is to turn this into a better calculator This would have to be moved out to get the split string and
             * Switch between add,subtract, multiply, divide. Could then even minimize and match on just the operators and the numbers
            */
            const string delimiterPattern = @"([\r\n])|(\[(.*)\])|(\s{2,3})|(\,+)|(\;+)|(\|+)|(\^{2,3})|(\:+)|(\?+)|(\!+)|(\*{2,3})|(\%+)|(\/{2,3})|(\\+)|(\+{2,3})|(\-{2,3})";
            string[] splitNumbers = Regex.Split(numbers,delimiterPattern);
            
            foreach (var strNumber in splitNumbers)
            {
                if (!int.TryParse(strNumber, out int tempInt) && strNumber == string.Empty) tempInt = 0;

                if (tempInt < 0 || tempInt > 1000)
                {
                    try
                    {
                        if (tempInt < 0)
                        {
                            throw new NotSupportedException(
                                $"The Value {tempInt} is not supported: Negatives are not allowed");
                        }

                        if (tempInt > 1000)
                        {
                            throw new NotSupportedException(
                                $"The Value {tempInt} is not supported: Values over 1000 are ignored");
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        tempInt = 0;
                        Console.WriteLine(ex);
                    }
                }

                total += tempInt;
            }
            
            return total;
        }
    }
}