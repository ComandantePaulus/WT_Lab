using WT_Lab.Entities;
using WT_Lab.Models;

namespace WT_Lab.Services
{
    public class MemoryProductService : IAssetService
    {
        List<Asset> _assets;
        List<Category> category;
        public MemoryProductService(ICategoryService categoryService)
        {
            category = categoryService.GetCategoryListAsync()
            .Result
            .Data;
            SetupData();
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _assets = new List<Asset>
                {
                    new Asset {ID = 1, Name="Сервер DELL360",
                    Description="Основной сервер предприятия", InvNumber=45882,
                    Price =48500, Photo="Images/1.jpg",
                    Category=category.Find(c=>c.NormalizedName.Equals("server"))},
                    new Asset {ID = 2, Name="ПК Авалон+",
                    Description="Компьютер главного бухгалтера", InvNumber=55971,
                    Price =4750, Photo="Images/2.jpg",
                    Category=category.Find(c=>c.NormalizedName.Equals("pc"))},
                    new Asset {ID = 3, Name="Коммутатор Cisco SX-350",
                    Description="Коммутатор бухгалтерия", InvNumber=60795,
                    Price =12500, Photo="Images/3.jpg",
                    Category=category.Find(c=>c.NormalizedName.Equals("network"))}
                };
        }
        public Task<ResponseData<ProductListModel<Asset>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var model = new ProductListModel<Asset>() { Items = _assets };
            var result = new ResponseData<ProductListModel<Asset>>()
            {
                Data = model
            };
            return Task.FromResult(result);
        }
    }
}
