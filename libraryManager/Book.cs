using System;

namespace libraryManager
{
    public class Book
    {
        private int id;
        private String book_name;
        private String author;
        private DateTime created_at;

        public Book(int id, string bookName, string author, DateTime created_at)
        {
            this.id = id;
            book_name = bookName;
            this.author = author;
            this.created_at = created_at;
        }

        public Book()
        {

        }

        public Book(string book_name, string author, DateTime created_at)
        {
            this.book_name = book_name;
            this.author = author;
            this.created_at = created_at;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book b)
            {
                if (b.book_name.Equals(book_name) && b.author.Equals(author))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Book name: " + book_name + "\n";
            text += "Author: " + author + "\n";
            text += "Created at: " + created_at.ToShortDateString() + "\n";

            return text;
        }

        public string BookName
        {
            get => book_name;
            set => book_name = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public DateTime CreatedAt
        {
            get => created_at;
            set => created_at = value;
        }
    }
}