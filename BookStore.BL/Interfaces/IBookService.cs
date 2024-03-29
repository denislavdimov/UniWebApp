﻿using BookStore.Models.Models;
using BookStore.Models.Requests.BookRequests;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById(int id);

        Task Add(AddBookRequest book);

        Task Delete(int id);

        Task Update(Book book);
    }
}
