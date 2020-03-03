using MediaLibrary.Core;
using System;
using System.Collections.Generic;


namespace MultiMediaLibrary.ConsoleApplication
{
    class SystemInterface
    {
        static void Main(string[] args)
        {

            DisplayBanner();

            // Create a Media Database based on the .csv file
           MediaLibrary database = new MediaLibrary("Media_Library_Database.csv");

            Console.WriteLine("Welcome to the Multi-Media Library archive manager");

            while (true)
            {
                // Ask user for media type
                Console.WriteLine("\nPlease, select media type you want to filter on: [A]lbum | [M]ovie | [B]ook | [V]ideogame | [E]xit");
                string type = Console.ReadLine();

                string headers = MultimediaItem.GetHeaders(type);

                // When user specifies a type that doesn't exist, exit the application
                if (headers == null)
                    return;

                // Ask user for property to order elements by
                Console.WriteLine(headers);
                string sortingProperty = Console.ReadLine();

                // Get filtered and sorted items from our database
                IEnumerable<MultimediaItem> records = database.GetElements(type, sortingProperty);

                // Print them on screen
                foreach (MultimediaItem item in records)
                    Console.WriteLine(item.DetailedInformation);
            }

            private static void DisplayBanner()
            {
                Console.WriteLine(@"
 ________________ 
< Corona Freeeee >
 ---------------- 
          \
           \
            \          __---__
                    _-       /--______
               __--( /     \ )XXXXXXXXXXX\v.
             .-XXX(   O   O  )XXXXXXXXXXXXXXX-
            /XXX(       U     )        XXXXXXX\
          /XXXXX(              )--_  XXXXXXXXXXX\
         /XXXXX/ (      O     )   XXXXXX   \XXXXX\
         XXXXX/   /            XXXXXX   \__ \XXXXX
         XXXXXX__/          XXXXXX         \__---->
 ---___  XXX__/          XXXXXX      \__         /
   \-  --__/   ___/\  XXXXXX            /  ___--/=
    \-\    ___/    XXXXXX              '--- XXXXXX
       \-\/XXX\ XXXXXX                      /XXXXX
         \XXXXXXXXX   \                    /XXXXX/
          \XXXXXX      >                 _/XXXXX/
            \XXXXX--__/              __-- XXXX/
             -XXXXXXXX---------------  XXXXXX-
                \XXXXXXXXXXXXXXXXXXXXXXXXXX/
                  ""VXXXXXXXXXXXXXXXXXXV""
    
               ");
            }
        }
    }
}


   
    
        