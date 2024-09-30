using WT_Lab.Entities;
using WT_Lab.Models;
namespace WT_Lab.Services
{
    public interface MemoryCategoryService:ICategoryService
    {
        public Task<ResponseData<List<Category>>>GetCategoryListAsync()
        {
            var categories = new List<Category>
{
                new Category {ID=1, Name="Серверы",
                NormalizedName="server"},
                new Category {ID=2, Name="ПК",
                NormalizedName="pc"},
                new Category {ID=3, Name="Сетевое оборудование",
                NormalizedName="network"}
                };
            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
