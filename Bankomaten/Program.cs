namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till DinBank \n");
            string activeUser = Login(); // sparar ID
            bool activeMenu = true;

            if (activeUser == "")
            {
                Console.WriteLine("Programmet stängs nu av");
                Thread.Sleep(1500);
                activeMenu = false;
            }
            while (activeMenu)
            {
                Menu(activeUser);
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
                        activeUser = (users[i][0]);
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
        static int Menu(string id)
        {
            Console.Clear();
            Console.WriteLine("Vänligen välj önskad metod\n");

            Console.WriteLine("1. Se ditt konto(n)/saldo"); 
            Console.WriteLine("2. Överför mellan konton");  
            Console.WriteLine("3. Ta ut-/sätt in pengar");  
            Console.WriteLine("4. Logga ut");               
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
                        Account(menu);  // Överblick av konton.
                        break;
                    case 2:
                        menu = 2;       // Överföra mellan konton.
                        break;
                    case 3:
                        menu = 3;       // Insättning/Uttag av pengar på konton.
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

            //string[][] UserAccount = { ["1","kim","921027"],
            //                         ["2","håkan","670111"],
            //                         ["3","alexander","951227"],
            //                         ["4","yvonne","670719"],
            //                         ["5","niklas","920304"]};

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
