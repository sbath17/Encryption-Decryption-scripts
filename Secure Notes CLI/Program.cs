//This is Encryption Description Scrips
//This has 5 program scripts to run (Encryption services, file servies, key services, notes & program) 
using System;
namespace Secure_Notes_CLI
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            var keyService = new KeyService();
            var encryptionService = new EncryptionService();
            var fileService = new FileService(encryptionService, keyService);

            while (true)
            {
                Console.WriteLine("\nSecure Notes CLI");
                Console.WriteLine("1. Write note");
                Console.WriteLine("2. Read note");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter your note: ");
                    string text = Console.ReadLine();

                    var note = new Note { Text = text, Timestamp = DateTime.Now };
                    fileService.AddNote(note, password);
                    Console.WriteLine("Note saved securely.");
                }
                else if (choice == "2")
                {
                    var notes = fileService.LoadNotes(password);

                    if (notes.Count == 0)
                    {
                        Console.WriteLine("No notes found.");
                    }
                    else
                    {
                        Console.WriteLine("Your notes:");
                        foreach (var n in notes)
                        {
                            Console.WriteLine($"{n.Timestamp}: {n.Text}");
                        }
                    }
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }
    }

}
