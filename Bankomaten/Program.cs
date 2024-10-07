namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool activeLogin = true;
            string activeUser;

            Console.WriteLine("Välkommen till DinBank \n");

            do
            {
                activeUser = Login();

                if (activeUser == "")
                {
                    Console.WriteLine("Programmet stängs nu av");
                    Thread.Sleep(2500);
                    break;
                }
                else
                {
                    int menuChoice = 0;
                    while (menuChoice != 4)
                    {
                        menuChoice = Menu(activeUser);
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
                        activeUser = (users[i][0]);
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
        static int Menu(string activeUser)
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
                        Account(Convert.ToInt32(activeUser));
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
            int accountOne;
            int accountTwo;
            int accountThree;
            int accountFour;
            int accountFive;

            switch (userChoice)
            {
                case 1:
                    accountOne = 14000;
                    Console.WriteLine($" Here are your Accounts\n #1 balance is: {accountOne}$\n ");
                    Console.ReadKey();
                    break;
                case 2:
                    accountOne = 24000;
                    accountTwo = 580;
                    Console.WriteLine($" Here are your Accounts\n #1 balance is: {accountOne}$\n #2 balance is: {accountTwo}$");
                    break;
                case 3:
                    accountOne = 9500;
                    accountTwo = 580;
                    accountThree = 580;
                    Console.WriteLine($"Your Account balance is: #1 balance is: {accountOne}$ #2 balance is: {accountTwo}$ #3 balance is: {accountThree}$ ");
                    break;
                case 4:
                    accountOne = 20000;
                    accountTwo = 580;
                    accountThree = 580;
                    accountFour = 580;
                    Console.WriteLine($"Your Account balance is: #1 balance is: {accountOne}$ #2 balance is: {accountTwo}$ #3 balance is: {accountThree}$ #4 balance is: {accountFour}$");
                    break;
                case 5:
                    accountOne = 30000;
                    accountTwo = 30000;
                    accountThree = 30000;
                    accountFour = 30000;
                    accountFive = 30000;
                    Console.WriteLine($"Your Account balance is: #1 balance is: {accountOne}$ #2 balance is: {accountTwo}$ #3 balance is: {accountThree}$ #4 balance is: {accountFour}$ #5 balance is: {accountFive}$");
                    break;
                default:
                    break;
            }
        
            return userChoice;
        }
    }
}