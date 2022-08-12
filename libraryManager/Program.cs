using System;
using System.Collections.Generic;

namespace libraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepo repo = new BookRepo();


            repo.updateDateById(1, DateTime.Parse("09-12-2002"));
        }
    }
}
