using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace myProject
{
    /// <summary>
    /// It's class with common functions
    /// </summary>
    internal static class Helper
    {
       

        /// <summary>
        /// Provide enter to user and check, that it's int value, until value will be correct
        /// </summary>
        /// <param name="errorMessage">it's message will be show to user, if value didn't correct</param>
        /// <returns></returns>
        public static int GetIntFromUser(string errorMessage = "Enter correct integer number!")
        {
            int usersEnter;
            while (!Int32.TryParse(Console.ReadLine(), out usersEnter)) Console.WriteLine(errorMessage);
            return usersEnter;
        }
    }
}
