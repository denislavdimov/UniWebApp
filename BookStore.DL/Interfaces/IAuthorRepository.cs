using System;
using BookStore.Models.Models;
using BookStore.Models.Requests;

namespace BookStore.DL.Interfaces
{
	public interface IAuthorRepository
	{
		Task<IEnumerable<Author>> GetAll();

		Task<Author> GetById(int id);

		Task Add(Author author);

		Task Delete(int id);

		Task Update(Author author);
	}
}

