using System;

namespace PasswordTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create Secure Password Hash
            Console.WriteLine("Enter Password: ");
            var textPassword = Console.ReadLine();
            var hashedPassword = PasswordUtility.PasswordHelper.Hash(textPassword);
            Console.WriteLine("Hashed Password: {0}", hashedPassword);
           
            Console.WriteLine("\n====================================");
            Console.WriteLine("Now, you will need to type the password again to verify. Press any key continue...");
            Console.WriteLine("====================================\n");
            Console.ReadKey();
            
            //Verify
            Console.WriteLine("Enter Password Again to Verify: ");
            textPassword = Console.ReadLine();
            Console.WriteLine(PasswordUtility.PasswordHelper.Verify(textPassword, hashedPassword) ? "SUCCESS: Password Match!" : "ERROR: Password Mismatch!");
            Console.ReadKey();
        }
    }
}
