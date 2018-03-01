using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput usrInput = new UserInput();
            string usrInputs = usrInput.GetUserInput(args);
            StringCalc strCalc = new StringCalc();
            int total = strCalc.AddStrings(usrInputs);
            Console.WriteLine($"Your total is: {total} {Environment.NewLine}Enter a key to close");
            Console.ReadKey();

        }
    }
}
