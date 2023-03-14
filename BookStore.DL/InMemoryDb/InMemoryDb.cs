using System;
using BookStore.Models.Models;

namespace BookStore.DL.InMemoryDb
{
    public static class Data
    {
        public static List<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Denkata"
            },

            new Author()
            {
                Id = 2,
                Name = "Peshkata"
            }
        };

        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Name = "DenkataBook2021",
                ReleaseDate = 2021
				// Title = "".
				// AuthorID = 1
            },

            new Book()
            {
                Id = 2,
                Name = "PeshkataBooks"
            },

            new Book()
            {
                Id = 1,
                Name = "DenkataBook2023",
                ReleaseDate = 2023
            }

        };

    }
}

