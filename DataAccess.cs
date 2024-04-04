using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tblBook";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
                return dataTable;
            }
        }

        public void AddBook(string bookCode, string bookName, string publisherCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tblBook (BookCode, BookName, PublisherCode) VALUES (@BookCode, @BookName, @PublisherCode)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookCode", bookCode);
                    command.Parameters.AddWithValue("@BookName", bookName);
                    command.Parameters.AddWithValue("@PublisherCode", publisherCode);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding book: " + ex.Message);
                }
            }
        }

        public void UpdateBook(string bookCode, string newBookName, string newPublisherCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tblBook SET BookName = @BookName, PublisherCode = @PublisherCode WHERE BookCode = @BookCode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookCode", bookCode);
                    command.Parameters.AddWithValue("@BookName", newBookName);
                    command.Parameters.AddWithValue("@PublisherCode", newPublisherCode);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Book updated successfully.");
                    else
                        Console.WriteLine("Book not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating book: " + ex.Message);
                }
            }
        }

        public void DeleteBook(string bookCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM tblBook WHERE BookCode = @BookCode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookCode", bookCode);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Book deleted successfully.");
                    else
                        Console.WriteLine("Book not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting book: " + ex.Message);
                }
            }
        }

        public DataTable GetPublishers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tblPublisher";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
                return dataTable;
            }
        }

        public void AddPublisher(string publisherCode, string publisherName, string address, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tblPublisher (PublisherCode, PublisherName, Address, Phone) VALUES (@PublisherCode, @PublisherName, @Address, @Phone)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PublisherCode", publisherCode);
                    command.Parameters.AddWithValue("@PublisherName", publisherName);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Publisher added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding publisher: " + ex.Message);
                }
            }
        }

        public void UpdatePublisher(string publisherCode, string newPublisherName, string newAddress, string newPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tblPublisher SET PublisherName = @PublisherName, Address = @Address, Phone = @Phone WHERE PublisherCode = @PublisherCode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PublisherCode", publisherCode);
                    command.Parameters.AddWithValue("@PublisherName", newPublisherName);
                    command.Parameters.AddWithValue("@Address", newAddress);
                    command.Parameters.AddWithValue("@Phone", newPhone);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Publisher updated successfully.");
                    else
                        Console.WriteLine("Publisher not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating publisher: " + ex.Message);
                }
            }
        }

        public void DeletePublisher(string publisherCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM tblPublisher WHERE PublisherCode = @PublisherCode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PublisherCode", publisherCode);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Publisher deleted successfully.");
                    else
                        Console.WriteLine("Publisher not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting publisher: " + ex.Message);
                }
            }
        }

        public DataTable SearchBook(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tblBook WHERE BookName LIKE @Keyword OR BookCode LIKE @Keyword";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error searching book: " + ex.Message);
                }
                return dataTable;
            }
        }

        public void PublisherStatistics()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p.PublisherCode, p.PublisherName, COUNT(b.BookCode) AS TotalBooks " +
                                   "FROM tblPublisher p " +
                                   "LEFT JOIN tblBook b ON p.PublisherCode = b.PublisherCode " +
                                   "GROUP BY p.PublisherCode, p.PublisherName";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Publisher Statistics:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Publisher Code: {reader["PublisherCode"]}, Publisher Name: {reader["PublisherName"]}, Total Books: {reader["TotalBooks"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving publisher statistics: " + ex.Message);
                }
            }
        }
    }
}
