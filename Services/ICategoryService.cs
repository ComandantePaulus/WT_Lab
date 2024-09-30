using WT_Lab.Entities;
using WT_Lab.Models;

namespace WT_Lab.Services
{
    public interface ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
