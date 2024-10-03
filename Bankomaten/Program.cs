namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till DinBank \n");
            
            string activeUser = Login();
                
                if (activeUser == "")
                {
                Console.WriteLine("Programmet stängs nu av");
                Thread.Sleep(1500);
                }

            bool menuActive = true;
            
            while (menuActive)
            {
                int userChoice = Menu();
                
                if (userChoice == 1)
                {
                    Account(userChoice);
                }
                else if (userChoice == 2)
                {

                }
                else if (userChoice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Loggar ut dig, vänta lite...\n");
                    Thread.Sleep(2000);
                    Login();
                }
            }
            
        }

        static string Login()
        {
            int count = 0;
            string activeUser = "";
            
            while (count < 3)
            {
                Console.WriteLine("Vänligen logga in");
                Console.WriteLine();
                Console.Write("Användarnamn: ");
                string userId = Console.ReadLine().ToLower();
                Console.Write("Lösenord: ");
                string userPassword = Console.ReadLine();

                string[][] users = { ["1","kim","921027"],
                                     ["2","håkan","670111"],
                                     ["3","alexander","951227"],
                                     ["4","yvonne","670719"],
                                     ["5","niklas","920304"]};
            
                for (int i = 0; i < users.Length; i++)
                {
                    if (userId == users[i][1] && userPassword == users[i][2])
                    {
                        activeUser = (users[i][1]);
                        return activeUser;
                    }

                }
                       count++;
            }
            if (count == 3)
            {
                Console.WriteLine("Du har överskridit dina 3 försök.");
                Console.ReadKey();
                
            }
                return activeUser;

        }    
        static int Menu()
            {
                Console.Clear();
                Console.WriteLine("Vänligen välj önskad metod\n");

                Console.WriteLine("1. Se ditt konto(n)/saldo");  // Account method? return int?
                Console.WriteLine("2. Överför mellan konton"); // TransferBetweenAccounts method? return int?
                Console.WriteLine("3. Ta ut-/sätt in pengar"); // WithdrawalOrDeposit method? void?
                Console.WriteLine("4. Logga ut");              // Logout method? void?
            int menu = 0;
            try
            {
                menu = Convert.ToInt32(Console.ReadLine());  // säkra kod! (System.FormatException: )

            }
            catch (System.FormatException)
            {

                
            }

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
                    }
                    userChoice = false;
                }
                return menu;
            }
        static int Account(int userChoice)
            {
                int accountOne = 0;
                int accountTwo = 0;
                //Login(users[0]);
                
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
                return userChoice;
            }
    }
}
