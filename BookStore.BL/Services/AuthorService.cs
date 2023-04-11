﻿using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests;

namespace BookStore.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, 
            IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task Add(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            await _authorRepository.Add(author);
        }

        public async Task Delete(int id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();


        }
        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task Update(UpdateAuthorRequest authorUpdateRequests)
        {
            var authorToUpdate = _mapper.Map<Author>(authorUpdateRequests);
            await _authorRepository.Update(authorToUpdate);
        }
    }
}

