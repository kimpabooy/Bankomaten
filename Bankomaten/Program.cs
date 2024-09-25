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

    }
}
