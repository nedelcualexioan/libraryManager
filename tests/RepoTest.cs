using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libraryManager;
using Xunit;

namespace tests
{
    public class RepoTest
    {
        private BookRepo bookRepository;


        public RepoTest()
        {

            this.bookRepository = new BookRepo();
        }

        [Fact]
        public void testGetAll()
        {



            Assert.Equal(7, bookRepository.getAll().Count);

        }

        [Fact]

        public void testGetName()
        {
            Assert.NotNull(bookRepository.getName("The 48 Laws of Power"));
        }

        [Fact]

        public void testGetById()
        {
            Assert.NotNull(bookRepository.getById(1));
        }

        [Fact]
        public void testCreate()
        {
            Book book = new Book("bookName", "Author", DateTime.Now);

            bookRepository.create(book);

            Assert.Contains(book, bookRepository.getAll());
        }

        [Fact]

        public void testDeleteByDetails()
        {
            Book book = bookRepository.getName("Things we never got over");

            bookRepository.deleteByDetails("Things we never got over", "Lucy Score");

            Assert.DoesNotContain(book, bookRepository.getAll());
        }

        [Fact]
        public void testDeleteById()
        {
            Book book = bookRepository.getById(1);

            bookRepository.deleteById(1);

            Assert.DoesNotContain(book, bookRepository.getAll());
        }

        [Fact]

        public void testGetByAuthor()
        {
            Assert.NotNull(bookRepository.getByAuthor("Collin Hoover"));
        }

        [Fact]
        public void testGetByNameAndAuthor()
        {
            Assert.NotNull(bookRepository.getByNameAndAuthor("Verity", "Collin Hoover"));
        }

        [Fact]

        public void testIsBook()
        {
            Assert.True(bookRepository.isBookByNameAndAuthor("Verity", "Collin Hoover"));
        }
        

    }
}
