namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        private static bool Login()
        {
            bool userIdOk = false;
            bool userPasswordOk = false;
            bool logIn = false;

            Console.WriteLine("Vänligen logga in");
            Console.WriteLine();
            Console.Write("Användarnamn: ");
            string userId = Console.ReadLine().ToLower(); ;
            Console.Write("Lösenord: ");
            string userPassword = Console.ReadLine();

            string[] users = { "kim", "håkan", "alexander", "yvonne", "niklas" };
            string[] userArrPassword = { "921027", "670111", "951227", "670719", "920304" };

            foreach (string item in users)
            {
                if (userId == item)
                {
                    userIdOk = true;
                    break;
                }
                else
                {
                    userIdOk = false;
                }
            }

            foreach (string item in userArrPassword)
            {
                if (userPassword == item)
                {
                    userPasswordOk = true;
                    break;
                }
                else
                {
                    userPasswordOk = false;
                }
            }

            if (userIdOk && userPasswordOk)
            {
                logIn = true;
            }
            else
            {
                Console.WriteLine("inte rätt användare eller lösenord.");
                logIn = false;
            }

            return logIn;
        }
        private static int Menu()
        {
            Console.WriteLine("Vänligen välj önskad metod\n");

            Console.WriteLine("1. Se ditt konton/saldo");  // Account method? return int?
            Console.WriteLine("2. Överför mellan konton"); // TransferBetweenAccounts method? return int?
            Console.WriteLine("3. Ta ut-/sätt in pengar"); // WithdrawalOrDeposit method? void?
            Console.WriteLine("4. Logga ut");              // Logout method? void?

            int menu = Convert.ToInt32(Console.ReadLine());

            bool userChoice = true;
            while (userChoice)
            {
                switch (menu)
                {
                    case 1:
                        menu = 1;
                        break;
                    case 2:
                        menu = 2;
                        break;
                    case 3:
                        menu = 3;
                        break;
                    case 4:
                        menu = 4;
                        break;
                    default:
                        break;
                }
                userChoice = false;
            }
            return menu;
        }
    }
}
