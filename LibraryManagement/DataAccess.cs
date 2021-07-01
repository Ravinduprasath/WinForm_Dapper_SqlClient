using Dapper;
using LibraryManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class DataAccess
    {
        public List<Book> BookGet(string bookName) 
        {
            using (IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("LibraryDB"))) 
            {
                var books = connection.Query<Book>("dbo.spBook_GetByName @BookName", new { BookName = bookName }).ToList();

                return books;
            }
        }

        public void BookInsert(string bookName, string author, string category, int quantity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("LibraryDB")))
                {
                    List<Book> book = new List<Book>();

                    book.Add(new Book { BookName = bookName, Author = author, Category = category, Quantity = quantity });

                    connection.Execute("dbo.spBook_Insert @BookName, @Author, @Category, @Quantity", book);
                }
            }
            catch (SqlException) { } //To avoid exception trigger when user try to enter same book again
            
        }

        public void BookDelete(string bookName)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("LibraryDB")))
            {
                connection.Execute("dbo.spBook_DeleteByName @BookName", new { BookName = bookName });
            }
        }

        public void BookUpdate(string id,string bookName, string author, string category, int quantity)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionClass.ConVal("LibraryDB")))
            {
                List<Book> book = new List<Book>();

                book.Add(new Book { Id = int.Parse(id), BookName = bookName, Author = author, Category = category, Quantity = quantity });


                connection.Execute("dbo.spBook_UpdateById @Id, @BookName, @Author, @Category, @Quantity", book);
            }
        }
    }
}
