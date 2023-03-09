using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork;

internal class Program
{

    public static UserService userService = new UserService();

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the social network!");

        while (true)
        {
            Console.WriteLine("To register, enter your name:");
            string firstName = Console.ReadLine();

            Console.Write("surname:");
            string lastName = Console.ReadLine();

            Console.Write("password");
            string password = Console.ReadLine();

            Console.Write("email");
            string email = Console.ReadLine();

            UserRegistrationData userRegistrationData = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Email = email
            };

            try
            {
                userService.Register(userRegistrationData);
                Console.WriteLine("Registered successfully!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Enter correct user data.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occured.");
            }

            Console.ReadLine();
        }

    }
}