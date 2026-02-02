using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await repository.GetCategories();
        }
    }
}
