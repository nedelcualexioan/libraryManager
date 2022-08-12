using System;
using System.Collections.Generic;

namespace libraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepo repo = new BookRepo();


            Console.WriteLine(repo.getAll().Count);
        }
    }
}
