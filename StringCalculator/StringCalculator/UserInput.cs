using System;
using System.Collections.Generic;

namespace StringCalculator
{
    /// <summary>
    /// User input class is used to combine strings into single string
    /// This Class will be used to gather input and combine or split the strings
    /// </summary>
    public class UserInput
    {
        public string UserInputStr { get; set; }
        public List<string> UserInputList { get;set; } = new List<string>();

        public string GetUserInput(string[] args)
        {
            UserInputStr = args.Length > 0 ? StringCombine(args) : GetInfoFromUser();

            return UserInputStr;
        }


        public string GetInfoFromUser()
        {
            Console.WriteLine("Enter Your Numbers by a delimeter exluding single operators(*,/,+,-,^) (Please Press Q to quit)");

            while (UserInputStr == null || !UserInputStr.ToLower().Equals("q"))
            {
                UserInputStr = Console.ReadLine();
                if (UserInputStr != null && !UserInputStr.ToLower().Equals("q"))
                {
                    UserInputList.Add(UserInputStr);
                }
            }

            return StringCombine(UserInputList.ToArray());
        }

        /// <summary>
        /// Method to join strings using the newline \r\n (Using Environment.Newline)
        /// </summary>
        /// <param name="strToJoin"></param>
        /// <returns>A combined string</returns>
        public string StringCombine(string[] strToJoin)
        {
            return string.Join(Environment.NewLine, strToJoin);
        }
    }
}