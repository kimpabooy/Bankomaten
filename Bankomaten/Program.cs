namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool userOk = Login();
            bool currentUser = userOk;

            if (userOk)
            {
                Console.WriteLine("Välkommen till DinBank \n");
            }


            while (currentUser == true)
            {
                int userChoice = Menu();
                Console.Clear();
                Console.WriteLine("Loggar ut dig, vänta lite...");
                Thread.Sleep(1000);
                userOk = Login();
                currentUser = userOk;
            }


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
                Console.Clear();
                Console.WriteLine("Vänligen välj önskad metod\n");

                Console.WriteLine("1. Se ditt konto(n)/saldo");  // Account method? return int?
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
                            Account(menu);
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

            private static int Account(int userChoice)
            {
                int accountOne = 0;
                int accountTwo = 0;

                switch (userChoice)
                {
                    case 1:
                        accountOne = 14000; // kanske strings
                        accountTwo = 0;
                        Console.WriteLine($" Here are your Accounts\n #1 balance is: {accountOne}$\n #2 balance is: {accountTwo}$");
                        Console.ReadKey();
                        break;
                    case 2:
                        accountOne = 24000;
                        Console.WriteLine($"Your Account balance is: {accountOne} ");
                        break;
                    case 3:
                        accountOne = 9500;
                        Console.WriteLine($"Your Account balance is: {accountOne} ");
                        break;
                    case 4:
                        accountOne = 20000;
                        Console.WriteLine($"Your Account balance is: {accountOne} ");
                        break;
                    case 5:
                        accountOne = 30000;
                        Console.WriteLine($"Your Account balance is: {accountOne} ");
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                return userChoice;
            }
        
    }
}
