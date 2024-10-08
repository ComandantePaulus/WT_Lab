using Microsoft.AspNetCore.Mvc;
using WT_Lab.Domain;
using WT_Lab.Models;

namespace WT_Lab.Services
{
    public class MemoryAssetService : IAssetService
    {
        List<Asset> _assets;
        List<Category> category;
        IConfiguration _config;
        public MemoryAssetService([FromServices] IConfiguration config, ICategoryService categoryService)
        {
            _config = config;
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
                    Price =48500, Photo="images/1.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("server"))},
                    new Asset {ID = 2, Name="ПК Авалон+",
                    Description="Компьютер главного бухгалтера", InvNumber=55971,
                    Price =4750, Photo="images/2.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("pc"))},
                    new Asset {ID = 3, Name="Коммутатор Cisco SX-350",
                    Description="Коммутатор бухгалтерия", InvNumber=60795,
                    Price =12500, Photo="images/3.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("network"))},
                    new Asset {ID = 4, Name="Сервер DELL VRTX",
                    Description="Основной сервер предприятия", InvNumber=45701,
                    Price =69250, Photo="images/4.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("server"))},
                    new Asset {ID = 5, Name="Навигатор Garmin",
                    Description="Etrex 20x", InvNumber=11225,
                    Price =3665, Photo="images/5.png",
                    Category=category.Find(c=>c.NormalizedName.Equals("other"))},
                };
        }

        public Task<ResponseData<AssetListModel<Asset>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            // Создать объект результата
            var result = new ResponseData<AssetListModel<Asset>>();
            // Id категории для фильрации
            int? categoryId = null;
            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = category
                .Find(c =>
                c.NormalizedName.Equals(categoryNormalizedName))
                ?.ID;
            // Выбрать объекты, отфильтрованные по ID категории,
            // если этот ID имеется
            var data = _assets.Where(d => categoryId == null ||d.Category.ID.Equals(categoryId))?.ToList();

            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();
            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count /(double)pageSize);
            // получить данные страницы
            var listData = new AssetListModel<Asset>()
            {
                Items = data.Skip((pageNo - 1) *
            pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };
            // поместить данные в объект результата
            result.Data = listData;

            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);
        }
    }
}
