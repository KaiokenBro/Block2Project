// Block Two Project: Password Checker Program
//
// Name: Victor Valdez Landa
// Date: 02/20/2025

namespace BlockTwoProject
{
    using System;

    class PasswordChecker
    {
        // Variable used to get a random object.
        private static Random random = new Random();

        // Boolean flags for minimum requirenments for a good password.
        private bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
        private string specialCharacters = "!@#$%^&*";

        /// <summary>
        /// This a methid to check where or not the input of the user is a good stromg password or not.
        /// </summary>
        /// <param name="password">
        /// The input of the User
        /// </param>
        /// <returns>
        /// Returns a boolean flag to show if its a good password or not.
        /// </returns>
        public bool IsStrongPassword(string password)
        {
            if (password.Length < 8) 
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    this.hasUpper = true;
                }
                if (char.IsLower(c)) {
                this.hasLower = true;
                }
                if (char.IsDigit(c))
                {
                    this.hasDigit = true;
                }
                if (specialCharacters.Contains(c))
                {
                    this.hasSpecial = true;
                }
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        /// <summary>
        /// This method will generate and return a random generated password for the User to use instead of the first one inputted.
        /// </summary>
        /// <returns>
        /// Returns a random strong password that is at least 12 characters long
        /// </returns>
        public string GenerateStrongPassword()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            char[] password = new char[12];

            for (int i = 0; i < 12; i++)
            {
                password[i] = characters[random.Next(characters.Length)];
            }

            return new string(password);
        }

        /// <summary>
        /// Main program to run the password checker class.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Type in a password to check the strength of it");
            string? inputFromUser = Console.ReadLine();

            PasswordChecker checker = new PasswordChecker();
            if (inputFromUser == null)
            {
                Console.WriteLine("Please enter a valid input (like a word please)");
            }
            else
            {
                {
                    if (checker.IsStrongPassword(inputFromUser))
                    {
                        Console.WriteLine("Your inputted Password is strong! Good for You!");
                    }
                    else
                    {
                        Console.WriteLine("Your password is not good enough, may be a risk");
                        Console.WriteLine("Instead use something like this: " + checker.GenerateStrongPassword());
                    }
                }
            }
        }
    }
}
