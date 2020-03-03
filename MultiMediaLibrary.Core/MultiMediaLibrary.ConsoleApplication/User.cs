using System;

namespace MultiMediaLibrary.ConsoleApplication
{
    class User
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Library");
            Console.WriteLine("Please enter your name");
            string choice = Console.ReadLine();

            Console.WriteLine("hello {0},welcome to your application",choice);

 
        }
    }
}
