using System;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories.InMemoryRepo
{
    public class AuthorInMemoryRepository : IAuthorRepository
    {
        public void Add(Author author)
        {
            InMemoryDb.InMemoryDb.Authors.Add(author);
        }

        public IEnumerable<Author> GetAll()
        {
            return InMemoryDb.InMemoryDb.Authors;
        }

        public Author GetById(int id)
        {
            return InMemoryDb.InMemoryDb.Authors.First(i => i.Id == id);
        }
    }
}

