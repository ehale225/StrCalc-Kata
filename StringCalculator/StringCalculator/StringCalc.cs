using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalc
    {
        public List<Exception> ExceptionList = new List<Exception>();
        public Exception Exception = new NotSupportedException();
        public int AddStrings(string numbers)
        {
            int total = 0;

            const string delimiterPattern = @"([\r\n])|(\[(.*)\])|(\s{2,3})|(\,+)|(\;+)|(\|+)|(\^{2,3})|(\:+)|(\?+)|(\!+)|(\*{2,3})|(\%+)|(\/{2,3})|(\\+)|(\+{2,3})|(\-{2,3})";
            string[] splitNumbers = Regex.Split(numbers,delimiterPattern);
            
            foreach (string strNumber in splitNumbers)
            {
                if (!int.TryParse(strNumber, out int tempInt) && strNumber == string.Empty) tempInt = 0;

                try
                    {
                        CheckTempValues(tempInt);
                    }
                    catch (NotSupportedException ex)
                    {
                        tempInt = 0;
                        Console.WriteLine(ex);
                    }
                

                total += tempInt;
            }
            
            return total;
        }

        private void CheckTempValues(int tempInt)
        {
            if (tempInt >= 0)
            {
                if (tempInt <= 1000) return;
                Exception = new NotSupportedException(
                    $"The Value {tempInt} is not supported: Values over 1000 are ignored");
                ExceptionList.Add(Exception);
                throw Exception;
            }

            Exception = new NotSupportedException(
                $"The Value {tempInt} is not supported: Negatives are not allowed");
            ExceptionList.Add(Exception);
            throw Exception;
        }
    }
}