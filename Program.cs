using LibraryManagement;
using System;
using System.Data;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=HOANGDUCTHIEN;Initial Catalog=library;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            DataAccess dataAccess = new DataAccess(connectionString);

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add, Update, Delete Book");
                Console.WriteLine("2. Add, Update, Delete Publisher");
                Console.WriteLine("3. Search Book by Name or Code");
                Console.WriteLine("4. View Publisher Statistics");
                Console.WriteLine("5. Exit");
                Console.Write("Your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        BookManagementMenu(dataAccess);
                        break;
                    case 2:
                        PublisherManagementMenu(dataAccess);
                        break;
                    case 3:
                        SearchBookMenu(dataAccess);
                        break;
                    case 4:
                        PublisherStatistics(dataAccess);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number from 1 to 5.");
                        break;
                }
            }
        }

        static void BookManagementMenu(DataAccess dataAccess)
        {
            while (true)
            {
                Console.WriteLine("\nBook Management:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View Books");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book Code: ");
                        string bookCode = Console.ReadLine();
                        Console.Write("Enter Book Name: ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter Publisher Code: ");
                        string publisherCode = Console.ReadLine();
                        dataAccess.AddBook(bookCode, bookName, publisherCode);
                        break;
                    case 2:
                        Console.Write("Enter Book Code to Update: ");
                        string updateBookCode = Console.ReadLine();
                        Console.Write("Enter New Book Name: ");
                        string newBookName = Console.ReadLine();
                        Console.Write("Enter New Publisher Code: ");
                        string newPublisherCode = Console.ReadLine();
                        dataAccess.UpdateBook(updateBookCode, newBookName, newPublisherCode);
                        break;
                    case 3:
                        Console.Write("Enter Book Code to Delete: ");
                        string deleteBookCode = Console.ReadLine();
                        dataAccess.DeleteBook(deleteBookCode);
                        break;
                    case 4:
                        Console.WriteLine("List of Book");
                        ViewBooks(dataAccess);
                        break;
                    case 5: return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number from 1 to 4.");
                        break;
                }
            }
        }
        static void ViewBooks(DataAccess dataAccess)
        {
            Console.WriteLine("\nBooks:");
            DataTable books = dataAccess.GetBooks();
            foreach (DataRow row in books.Rows)
            {
                Console.WriteLine($"Book Code: {row["BookCode"]}, Book Name: {row["BookName"]}, Publisher Code: {row["PublisherCode"]}");
            }
        }

        static void PublisherManagementMenu(DataAccess dataAccess)
        {
            while (true)
            {
                Console.WriteLine("\nPublisher Management:");
                Console.WriteLine("1. Add Publisher");
                Console.WriteLine("2. Update Publisher");
                Console.WriteLine("3. Delete Publisher");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Publisher Code: ");
                        string publisherCode = Console.ReadLine();
                        Console.Write("Enter Publisher Name: ");
                        string publisherName = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Phone: ");
                        string phone = Console.ReadLine();
                        dataAccess.AddPublisher(publisherCode, publisherName, address, phone);
                        break;
                    case 2:
                        Console.Write("Enter Publisher Code to Update: ");
                        string updatePublisherCode = Console.ReadLine();
                        Console.Write("Enter New Publisher Name: ");
                        string newPublisherName = Console.ReadLine();
                        Console.Write("Enter New Address: ");
                        string newAddress = Console.ReadLine();
                        Console.Write("Enter New Phone: ");
                        string newPhone = Console.ReadLine();
                        dataAccess.UpdatePublisher(updatePublisherCode, newPublisherName, newAddress, newPhone);
                        break;
                    case 3:
                        Console.Write("Enter Publisher Code to Delete: ");
                        string deletePublisherCode = Console.ReadLine();
                        dataAccess.DeletePublisher(deletePublisherCode);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number from 1 to 4.");
                        break;
                }
            }
        }

        static void SearchBookMenu(DataAccess dataAccess)
        {
            Console.WriteLine("\nSearch Book:");
            Console.Write("Enter book name or code to search: ");
            string searchKeyword = Console.ReadLine();
            DataTable searchResult = dataAccess.SearchBook(searchKeyword);
            Console.WriteLine("Search Result:");
            foreach (DataRow row in searchResult.Rows)
            {
                Console.WriteLine($"Book Code: {row["BookCode"]}, Book Name: {row["BookName"]}, Publisher Code: {row["PublisherCode"]}");
            }
        }

        static void PublisherStatistics(DataAccess dataAccess)
        {
            dataAccess.PublisherStatistics();
        }
    }
}
