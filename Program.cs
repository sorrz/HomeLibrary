
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace HomeLibray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a List to be used as a Library
            List<Bok> archive = new List<Bok>();

            {
                archive.Add(new Bok("Hejsan", "120", "2009"));
                archive.Add(new Bok("Hejsan1", "230", "2011"));
                archive.Add(new Bok("Hejsan2", "2220", "1994"));
                archive.Add(new Bok("Hejsan3", "450", "1845"));
                archive.Add(new Bok("Hejsan4", "600", "2009"));
            }

            //Entry Message
            Console.WriteLine("Hi welcome, I've added a couple of books to the library\n But let's manually add one aswell: ");

           // While Loop to keep adding book for as long as the user want, passing the input to LowerCase to make sure we capture it.
           while (true)
           {

                
                Console.WriteLine("\n\nPress (Y)enter to start, \nor hit anything else to Print the library: ");
                string temp = Console.ReadLine().ToLower();
                if (temp =="y")
                {
                    AddBook(ref archive);
                    
                }
                else // Breaking out of the loop if something else then a Y was entred.
                    break;
           }


            // Order the list after PubYear, to a List.
            // Print a Title and the print foreach item in Archive.
            // 
            archive = archive.OrderBy(n => n.pubYear).ToList();
            archive.Reverse();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Publication Year      Title       No. of Pages");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in archive)
            {
                
                Console.WriteLine($"{item.pubYear}                 {item.title}        {item.pages} ");
            }

            // Waiting for user
            Console.ReadKey(true);
            // End of Main
        }


        // Making a new Method for adding books, taking the input
        // and reffing in the List of Books to add it.
        public static void AddBook(ref List<Bok> archive)
        {
            Console.WriteLine("Add a new title: ");
            var _titel = Console.ReadLine();
            Console.WriteLine("How many pages: ");
            var _pages = Console.ReadLine();
            Console.WriteLine("What year was it publicated: ");
            var _pubYear = Console.ReadLine();

            Bok b1 = new Bok(_titel, _pages, _pubYear);
            archive.Add(b1);
            Console.WriteLine("Added!");
            Thread.Sleep(1000);
            Console.Clear();

            

        }

        // Making a new class "bok" to hold the required Values for our Libray
        public class Bok
        {

            public string title = "";
            public string pages = "";
            public string pubYear = "";

            // Constructor to take the args to auto-add in the existing Librayr Objects.
            // Could have been left empty if we only take user input.
            public Bok(string title, string pages, string pubYear)
            {
                this.title = title;
                this.pages = pages;
                this.pubYear = pubYear;
            }


        }
    }


}



 