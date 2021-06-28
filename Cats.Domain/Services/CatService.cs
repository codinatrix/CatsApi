﻿using Cats.Domain.Entities;
using Cats.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats.Domain.Services
{

    public interface ICatService
    {
        public Task<List<Cat>> GetCats();
    }

    public class CatService : ICatService
    {
        ICatRepository _catRepository;

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> GetCats()
        {
           return await _catRepository.GetCats().ToListAsync();
        }

        public async Task<List<Cat>> GetSpecificCats()
        {
            List<Cat> twoCats = await _catRepository.GetCats()
                .Take(2).ToListAsync();


            List<Cat> varrickCats = await _catRepository.GetCats()
                .Where(c => c.Name.Equals("Varrick"))
                .ToListAsync();

            return twoCats;
        }
    }
}
