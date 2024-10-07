using WT_Lab.Domain;
using WT_Lab.Models;

namespace WT_Lab.Services
{
    public interface ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
