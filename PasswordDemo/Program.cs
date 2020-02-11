using System;

namespace PasswordDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create Secure Password Hash
            Console.Write("Enter Password: ");
            var textPassword = Console.ReadLine();
            var hashedPassword = PasswordUtility.PasswordHelper.Hash(textPassword);
            Console.WriteLine("\nHashed Password: {0}", hashedPassword);
           
            Console.WriteLine("\n====================================");
            Console.WriteLine("Now, you will need to type the password again to verify. Press any key to continue...");
            Console.WriteLine("====================================\n");
            Console.ReadKey();
            
            //Verify
            Console.Write("Enter Password Again to Verify: ");
            textPassword = Console.ReadLine();
            Console.WriteLine(PasswordUtility.PasswordHelper.Verify(textPassword, hashedPassword) ? "SUCCESS: Password Match!" : "ERROR: Password Mismatch!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("\n====================================");
            Console.WriteLine("Now, we will hash the password with custom Hash, Salt and Iteration. Press any key to continue...");
            Console.WriteLine("====================================");
            Console.ReadKey();

            var errorFree = false;
            var hash = PasswordUtility.PasswordHelper.HashSize;
            var salt = PasswordUtility.PasswordHelper.SaltSize;
            var iteration = PasswordUtility.PasswordHelper.Iterations;

            while (!errorFree)
            {
                Console.Write("\nEnter Desired Hash Size (int): ");
                var hashString = Console.ReadLine();
                
                Console.Write("\nEnter Desired Salt Size (int): ");
                var saltString = Console.ReadLine();

                Console.Write("\nEnter Desired Number of Iterations (int, >1000 but less than {0}): ",int.MaxValue);
                var iterateString = Console.ReadLine();

                errorFree = int.TryParse(hashString, out hash) && int.TryParse(saltString, out salt) && int.TryParse(iterateString, out iteration);
                if(!errorFree) Console.WriteLine("\nPlease enter a valid value. ");
            }

            PasswordUtility.PasswordHelper.HashSize = hash;
            PasswordUtility.PasswordHelper.SaltSize = salt;
            PasswordUtility.PasswordHelper.Iterations = iteration;

            Console.Write("\nEnter Password: ");
            textPassword = Console.ReadLine();
            hashedPassword = PasswordUtility.PasswordHelper.Hash(textPassword);
            Console.WriteLine("\nHashed Password: {0}", hashedPassword);

            Console.WriteLine("\n====================================");
            Console.WriteLine("Now, you will need to type the password again to verify. Press any key to continue...");
            Console.WriteLine("====================================\n");
            Console.ReadKey();

            //Verify
            Console.Write("Enter Password Again to Verify: ");
            textPassword = Console.ReadLine();
            Console.WriteLine(PasswordUtility.PasswordHelper.Verify(textPassword, hashedPassword) ? "SUCCESS: Password Match!" : "ERROR: Password Mismatch!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
