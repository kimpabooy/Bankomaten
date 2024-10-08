namespace Bankomaten
{
    internal class Program
    {

        static string[][] user = {   ["1","kim","921027"],
                                     ["2","håkan","670111"],
                                     ["3","alexander","951227"],
                                     ["4","yvonne","670719"],
                                     ["5","niklas","920304"]};

        static decimal[][] userAccount = {  [28000m],// [0,0]
                                            [20000m, 25000m],// [1,0][1,1]
                                            [12000m, 14000m, 34000m], // [2,0][2,1][2,2]
                                            [11000m, 34000m, 28000m, 205000m],// [3,0][3,1][3,2][3,3]
                                            [5000m, 40000m, 13000m, 60000m, 23000m]}; // [4,0][4,1][4,2][4,3][4,4]

        static string[] accountName = { "Privatkonto","sparkonto", "semesterkonto", "pensionkonto", "nöje"};

        static void Main(string[] args)
        {
            bool activeLogin = true;
            string userIndex;

            Console.WriteLine("Välkommen till DinBank \n");

            do
            {
                userIndex = Login();
                // Om användaren är tom ( "" ) efter 3 försök så stängs programmet av.
                if (userIndex == "")
                {
                    Console.WriteLine("Programmet stängs nu av");
                    Thread.Sleep(2500);
                    break;
                }
                else
                {
                    // Kollar om användaren vill logga ut ( 4 ) annars fortsätter att köra Menu();
                    int menuChoice = 0;
                    while (menuChoice != 4)
                    {
                        menuChoice = Menu(userIndex);
                    }
                }
            } while (activeLogin);
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
                
                string userPassword = HidePassword();

                for (int i = 0; i < user.Length; i++)
                {
                    if (userId == user[i][1] && userPassword == user[i][2])
                    {
                        activeUser = (user[i][0]);
                        return activeUser;
                    }
                }
                Console.Clear();
                Console.WriteLine("Fel användare eller lösenord, försök igen \n");
                count++;
            }
            
            if (count == 3)
            {
                Console.Clear();
                Console.WriteLine("Du har överskridit dina 3 försök.");
            }
            return activeUser;

        }
        static int Menu(string userIndex)
        {

            Console.Clear();
            Console.WriteLine("Vänligen välj önskad metod\n");

            Console.WriteLine("1. Se dina konton och saldo");  // Account method? return int?
            Console.WriteLine("2. Överför mellan konton"); // TransferBetweenAccounts method? return int?
            Console.WriteLine("3. Ta ut pengar"); // WithdrawalOrDeposit method? void?
            Console.WriteLine("4. Logga ut");              // Logout method? void?

            int menu = 0;
            try
            {
                menu = Convert.ToInt32(Console.ReadLine());     // säkra kod! (System.FormatException: )

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
                        Account(Convert.ToInt32(userIndex));
                        break;
                    case 2:
                        Transfer(Convert.ToInt32(userIndex));
                        break;
                    case 3:
                        Withdraw(Convert.ToInt32(userIndex));
                        break;
                    case 4:
                        menu = 4;
                        break;
                }
                userChoice = false;
          }
            return menu;
        }
        static int Account(int userIndex)
        {
            Console.WriteLine("Dina konton: ");
            userIndex = userIndex - 1; // användare
            for (int i = 0; i < userAccount[userIndex].Length; i++)
            {
                Console.WriteLine($"{accountName[i]}: {userAccount[userIndex][i]:C}"); // skriver ut kontonamn
            }
            Console.ReadKey();
        
            return userIndex;
        }
        static void Transfer(int userIndex)
        {
            int count = 1;
            userIndex = userIndex - 1;
            for (int i = 0; i < userAccount[userIndex].Length; i++)
            {
                Console.WriteLine($" {count}. {accountName[i]} {userAccount[userIndex][i]:C}");
                count++;
            }
            Console.WriteLine("\n(Välj med en siffra)");
            Console.WriteLine("Vilket konto vill du flytta ifrån?\n");
            int fromAccount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Vilket konto vill du flytta till?\n");
            int toAccount = Convert.ToInt32(Console.ReadLine());
            
            // debugging - remove when done
            Console.WriteLine($"{userAccount[userIndex][fromAccount -1]:C}, {userAccount[userIndex][toAccount -1]:C}");

            Console.WriteLine($"Hur mycket pengar vill du flytta ifrån {accountName[fromAccount -1]}t till {accountName[toAccount -1]}t ");
            decimal transferAmmount = Convert.ToDecimal(Console.ReadLine());

            userAccount[userIndex][fromAccount -1] -= transferAmmount;
            userAccount[userIndex][toAccount -1] += transferAmmount;
            Console.WriteLine($"Ditt{accountName[fromAccount -1]} har nu {userAccount[userIndex][fromAccount -1]:C}");
            Console.WriteLine($"Ditt{accountName[toAccount -1]} har nu {userAccount[userIndex][toAccount -1]:C}");
           
            Console.ReadKey();
        }
        static string HidePassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return "";
                    case ConsoleKey.Enter:
                        return password;
                    case ConsoleKey.Backspace:
                        if (password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        password += key.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }
        static void Withdraw(int userIndex)
        {
            
            decimal moneyWithraw = 0;
            int count = 1;
            userIndex -= 1;
            Console.WriteLine("\nHär är dina konton ");
            for (int i = 0; i < userAccount[userIndex].Length; i++)
            {
                Console.WriteLine($" {count}. {accountName[i]} {userAccount[userIndex][i]:C}");
                count++;
            }
            Console.WriteLine("\n(Välj med en siffra)");
            Console.WriteLine("Vilket konto vill du ta ut pengar ifrån? \n");
            int fromAccount = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine($"Hur mycket pengar vill du ta ut ifrån ditt {accountName[fromAccount -1]}: ");
            moneyWithraw = Convert.ToDecimal(Console.ReadLine());
            

            if (moneyWithraw <= userAccount[userIndex][fromAccount -1])
            {
                //userIndex += 1;
                userAccount[userIndex][fromAccount -1] -= moneyWithraw;
                Console.WriteLine($"\n Du har tagit ut {moneyWithraw:C} ifrån ditt {accountName[fromAccount - 1]} konto. ");
            }
            else
            {
                Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot");
            }

            Console.ReadKey();
        }
    }
}