using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace libraryManager
{
    public class BookRepo
    {
        private readonly string connectionString;
        private DataAcces db;

        public BookRepo()
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath(@"W:\Documents\SQL\libraryManager\libraryManager\bin\Debug\net5.0").AddJsonFile("appsettings.json");

            var config = builder.Build();
            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Book> getAll()
        {
            string sql = "SELECT * FROM book";

            return db.LoadData<Book, dynamic>(sql, new { }, connectionString);
        }

        public List<Book> getAllSortByName()
        {

            string sql = "SELECT * FROM book ORDER BY book_name";

            return db.LoadData<Book, dynamic>(sql, new { }, connectionString);

        }

        public List<Book> getAllSortByDate()
        {
            string sql = "SELECT * FROM book ORDER BY created_at";

            return db.LoadData<Book, dynamic>(sql, new { }, connectionString);
        }

        public void create(Book book)
        {
            string sql = "INSERT INTO book (book_name, author, created_at) VALUES (@book_name,@author,@created_at)";

            db.SaveData(sql, new { book_name=book.BookName, author=book.Author,  created_at=book.CreatedAt },
                connectionString);
        }

        public Book getName(string book_name)
        {
            string sql = "SELECT * FROM book WHERE book_name = @book_name";

            return (db.LoadData<Book, dynamic>(sql, new { book_name }, connectionString))[0];
        }

        public List<Book> getByAuthor(string author)
        {
            string sql = "SELECT * FROM book WHERE author = @author";

            return db.LoadData<Book, dynamic>(sql, new { author }, connectionString);
        }

        public Book getByNameAndAuthor(string book_name, string author)
        {
            string sql = "SELECT * FROM book WHERE book_name = @book_name AND author = @author";

            return (db.LoadData<Book, dynamic>(sql, new { book_name, author }, connectionString))[0];
        }

        public Book getById(int id)
        {
            string sql = "SELECT * FROM book WHERE id = @id";
            if (db.LoadData<Book, dynamic>(sql, new { id }, connectionString).Count == 0)
            {
                return null;
            }

            return db.LoadData<Book, dynamic>(sql, new { id }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM book WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByDetails(string book_name, string author)
        {
            string sql = "DELETE FROM book WHERE book_name = @book_name AND author = @author";

            db.SaveData(sql, new { book_name, author }, connectionString);
        }

        public void updateNameById(int id, string book_name)
        {
            string sql = "UPDATE book SET book_name = @book_name WHERE id = @id";

            db.SaveData(sql, new { id, book_name }, connectionString);
        }

        public void updateAuthorById(int id, string author)
        {
            string sql = "UPDATE book SET author = @author WHERE id = @id";

            db.SaveData(sql, new { id, author }, connectionString);
        }

    }
}
