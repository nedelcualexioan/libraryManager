using System;

namespace libraryManager
{
    public class Book
    {
        private int id;
        private String book_name;
        private String author;
        private String created_at;

        public Book(int id, string bookName, string author, string createdAt)
        {
            this.id = id;
            book_name = bookName;
            this.author = author;
            created_at = createdAt;
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
                if (b.id.Equals(id) && b.book_name.Equals(book_name) && b.author.Equals(author) &&
                    b.created_at.Equals(created_at))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Book name: " + book_name + "\n";
            text += "Author: " + author + "\n:";
            text += "Created at: " + created_at + "\n";

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

        public string CreatedAt
        {
            get => created_at;
            set => created_at = value;
        }
    }
}