using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests;

namespace BookStore.DL.Repositories.InMemoryRepo
{
    public class AuthorInMemoryRepository 
    {
        public void Add(Author author)
        {
            InMemoryDb.Data.Authors.Add(author);
        }

        public void Delete(int id)
        {
            var authorToDelete =
                InMemoryDb.Data.Authors.FirstOrDefault(a => a.Id == id);

            if (authorToDelete != null)
            {
                InMemoryDb.Data.Authors.Remove(authorToDelete);
            }
        }

        public IEnumerable<Author> GetAll()
        {
            return InMemoryDb.Data.Authors;
        }

        public Author GetById(int id)
        {
            return InMemoryDb.Data.Authors.First(i => i.Id == id);
        }

        public void Update(Author author)
        {
            var authorToUpdate =
                InMemoryDb.Data.Authors.FirstOrDefault(a => a.Id == author.Id);

            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
            }
        }
    }
}

