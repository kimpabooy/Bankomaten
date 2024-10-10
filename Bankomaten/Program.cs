namespace Bankomaten
{
    internal class Program
    {
        // Accounts [ID, Username, Password]
        static string[][] user = {   ["1","kim","921027"],
                                     ["2","håkan","670111"],
                                     ["3","alexander","951227"],
                                     ["4","yvonne","670719"],
                                     ["5","niklas","920304"]};
        // Account Balances
        static decimal[][] userAccount = {  [28000m],
                                            [20000m, 25000m],
                                            [12000m, 14000m, 34000m],
                                            [11000m, 34000m, 28000m, 205000m],
                                            [5000m, 40000m, 13000m, 60000m, 23000m]};
        // Account Names
        static string[] userAccountName = { "Privatkonto","sparkonto", "semesterkonto", "pensionkonto", "nöje"};

        static void Main(string[] args)
        {
            bool activeLogin = true; // Tracking if user is logged in or not.
            string userIndex;        // Tracking the logged in user's Index.

            Console.WriteLine("Välkommen till DinBank \n");

            do
            {
                userIndex = Login();

                // If Login() returns an empty string.
                if (userIndex == "")
                {
                    Console.WriteLine("Programmet stängs nu av");
                    Thread.Sleep(2500);
                    break;
                }
                else
                {
                    // Show menu until user decides to log out.
                    int menuChoice = 0;
                    while (menuChoice != 4)
                    {
                        menuChoice = Menu(userIndex);
                    }
                }
            } while (activeLogin);
        }

        // Logs the user in by compairing the username and password with user array and return the user index,
        // or an empty string after 3 failed attempt.
        static string Login()
        {
            int count = 0;  // Keeping track of login attempts.
            string activeUser = ""; // Stores the index of the logged in user.

            while (count < 3)
            {
                Console.WriteLine("Vänligen logga in");
                Console.WriteLine();
                Console.Write("Användarnamn: ");
                string userId = Console.ReadLine().ToLower();
                Console.Write("Lösenord: ");
                
                string userPassword = HidePassword(); // Hides the password input on the screen.

                // Compairs if the input of username and password is correkt in user array.
                for (int i = 0; i < user.Length; i++)
                {
                    if (userId == user[i][1] && userPassword == user[i][2])
                    {
                        activeUser = (user[i][0]);
                        return activeUser; // returns user index.
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
            return activeUser; // Return empty string if there is no mach of username and password in user array.
        }

        // Runs the Menu for the user.
        static int Menu(string userIndex)
        {
            // Runs the method corresponding to the menu choice.
            bool userChoice = true;
            int menu = 0;
            while (userChoice)
            {
                Console.Clear();
                Console.WriteLine("Vänligen välj önskad metod\n");

                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överför mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");

                try
                {
                    menu = Convert.ToInt32(Console.ReadLine()); // Trying to convert the input from the user.
                }
                catch (System.FormatException)
                {
                    // Catching the exception and then does nothing.
                }

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
                        Console.WriteLine("\nDu loggas nu ut...\n");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
                userChoice = false;
                if (menu < 1 || menu > 4 )
                {
                    Console.WriteLine("Ogiltligt val");
                    Console.ReadKey();
                    break;
                }
               
            }
            return menu;
        }

        // Displays the user's accounts and their balance.
        static int Account(int userIndex)
        {
            Console.WriteLine("Dina konton: ");
            userIndex = userIndex - 1;
            for (int i = 0; i < userAccount[userIndex].Length; i++) // Goes through the userAccount array on indexlocation of userIndex.
            {
                Console.WriteLine($"{userAccountName[i]}: {userAccount[userIndex][i]:C}"); // Dsiplaying the logged in users account names and balance.
            }
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta");
            Console.ReadKey();

            return userIndex;
        }

        // Method that transfer money between the users accounts.
        static void Transfer(int userIndex)
        {
            int count = 0; // keeping track of number of accounts.
            int fromAccount = 0;
            int toAccount = 0;

            bool rightInput = false;

            userIndex -= 1;
           
            do
            {
                count = 1;
                // Displaying users account again if any exception would occur.
                for (int i = 0; i < userAccount[userIndex].Length; i++)
                {
                    Console.WriteLine($" {count}. {userAccountName[i]} {userAccount[userIndex][i]:C}");
                    count++;
                }
                try
                {   
                    Console.WriteLine("\n(Välj med en siffra)");
                    Console.WriteLine("Vilket konto vill du flytta ifrån?\n");
                    fromAccount = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Vilket konto vill du flytta till?\n");
                    toAccount = Convert.ToInt32(Console.ReadLine());
                    rightInput = true;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Ogiltlig input, försök igen");
                    count--;
                    rightInput = false;
                    Console.ReadKey();
                    Console.Clear();
                }
               
                // Checks if the accounts exsists in userAccount.           
                if (rightInput && 
                    (fromAccount < 1 || fromAccount > userAccount[userIndex].Length) || 
                    (toAccount < 1 || toAccount > userAccount[userIndex].Length))
                {
                    Console.WriteLine("\nNågot gick fel. Har du angätt rätt konton?\n");
                    rightInput = false;   
                }

            } while (!rightInput);
            
            // Asking the user how much to transfer.
            Console.WriteLine($"Hur mycket pengar vill du flytta ifrån {userAccountName[fromAccount -1]}t till {userAccountName[toAccount -1]}t ");
            decimal transferAmmount = Convert.ToDecimal(Console.ReadLine());

            // Gives new values to the user accounts and displaying from witch account the user transfered money from/to.
            userAccount[userIndex][fromAccount -1] -= transferAmmount;
            userAccount[userIndex][toAccount -1] += transferAmmount;
            Console.WriteLine($"Ditt {userAccountName[fromAccount -1]} har nu {userAccount[userIndex][fromAccount -1]:C}");
            Console.WriteLine($"Ditt {userAccountName[toAccount -1]} har nu {userAccount[userIndex][toAccount -1]:C}");

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta");
            Console.ReadKey();
        }

        // Hides the input password when loggin in.
        static string HidePassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // saves the keypress
                switch (key.Key)
                {
                    case ConsoleKey.Escape: // If key "Escape", Return nothing.
                        return "";
                    case ConsoleKey.Enter: // If key "Enter", Return current password.
                        return password;
                    case ConsoleKey.Backspace: // If key "backspace", checks if there is anything to remove and removes last index.
                        if (password.Length > 0)
                        { 
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        password += key.KeyChar; // Adds the keypress/input to password but displaying "*" insted.
                        Console.Write("*");
                        break;
                }
            }
        }

        // Withdraws balance between users accounts.
        static void Withdraw(int userIndex )
        {
            bool pinOk = false;
            int pinCount = 1;
            userIndex -= 1;
            // Asking user to authenticate with there password.
            do
            {
                Console.Clear();
                Console.Write("Skriv in ditt lösenord: ");
                
                string userPassword = HidePassword();
                
                for (int i = 0; i < user.Length; i++)
                {
                    if (userPassword == user[i][2])
                    {
                        decimal moneyWithraw = 0;
                        int count = 1;
                        Console.Clear();

                        Console.WriteLine("\nHär är dina konton ");
                        for (int j = 0; j < userAccount[userIndex].Length; j++)
                        {
                            Console.WriteLine($" {count}. {userAccountName[j]} {userAccount[userIndex][j]:C}"); // Displays the accounts.
                            count++;
                        }
                        Console.WriteLine("\n(Välj med en siffra)");
                        Console.WriteLine("Vilket konto vill du ta ut pengar ifrån? \n");
                        int fromAccount = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Hur mycket pengar vill du ta ut ifrån ditt {userAccountName[fromAccount - 1]}: ");
                        moneyWithraw = Convert.ToDecimal(Console.ReadLine());

                        // Checks if the withdraw value is less or equal to the balance on the account.
                        if (moneyWithraw <= userAccount[userIndex][fromAccount - 1])
                        {
                            // Withdraw money from selected account.
                            userAccount[userIndex][fromAccount - 1] -= moneyWithraw;
                            Console.WriteLine($"\nDu har tagit ut {moneyWithraw:C} ifrån ditt {userAccountName[fromAccount - 1]} konto. ");
                        }
                        else
                        {
                            Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot"); // if insufficent funds
                        }
                    }
                    else if (pinCount == 3)
                    {
                        Console.WriteLine("\nFör många försök, återvänder till menyn");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                pinCount++;

            } while (!pinOk); // Checks untill the password is correct OR if user tried more then 3 times.

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta");
            Console.ReadKey();
        }
    }
}