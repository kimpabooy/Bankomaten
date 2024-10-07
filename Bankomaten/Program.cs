namespace Bankomaten
{
    internal class Program
    {

        static string[][] user = {   ["1","kim","921027"],
                                     ["2","håkan","670111"],
                                     ["3","alexander","951227"],
                                     ["4","yvonne","670719"],
                                     ["5","niklas","920304"]};

        static string[][] userAccount = {   ["28000"],// [0,0]
                                            ["20000","25000"],// [1,0][1,1]
                                            ["12000","14000","34000"], // [2,0][2,1][2,2]
                                            ["11000","34000","28000","205000"],// [3,0][3,1][3,2][3,3]
                                            ["5000","40000","13000","60000","23000"]}; // [4,0][4,1][4,2][4,3][4,4]

        static string[] accountName = { "Privatkonto","sparkonto", "semesterkonto", "pensionkonto", "nöje"};

        static void Main(string[] args)
        {
            bool activeLogin = true;
            string activeUser;

            Console.WriteLine("Välkommen till DinBank \n");

            do
            {
                activeUser = Login();
                // Om användaren är tom ( "" ) efter 3 försök så stängs programmet av.
                if (activeUser == "")
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
        static int Menu(string activeUser)
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
                        Account(Convert.ToInt32(activeUser));
                        break;
                    case 2:
                        //Transfer();
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
            Console.WriteLine("Here are your accounts: ");
            userChoice = userChoice - 1; // användare
            for (int i = 0; i < userAccount[userChoice].Length; i++)
            {
                Console.WriteLine($"{accountName[i]}: {userAccount[userChoice][i]}kr"); // skriver ut kontonamn
            }
            Console.ReadKey();
        
            return userChoice;
        }
        static void Transfer(int from, int to)
        {

            
            Console.ReadKey();
        }
    }
}