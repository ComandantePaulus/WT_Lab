using System.Net.Http;
using WT_Lab.Domain;
using WT_Lab.Models;

namespace WT_Lab.Services
{
    public class ApiAssetService(HttpClient httpClient):IAssetService
    {

        public async Task<ResponseData<List<Asset>>> GetAssetListAsync()
        {
            var result = await httpClient.GetAsync(httpClient.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<List<Asset>>>();
            };
            var response = new ResponseData<List<Asset>>
            { Success = false, ErrorMessage = "Ошибка чтения API" };
            return response;
        }

        public async Task<ResponseData<AssetListModel<Asset>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var uri = httpClient.BaseAddress;
            var queryData = new Dictionary<string, string>();
            queryData.Add("pageNo", pageNo.ToString());
            if (!String.IsNullOrEmpty(categoryNormalizedName))
            {
                queryData.Add("category", categoryNormalizedName);
            }
            var query = QueryString.Create(queryData);
            var result = await httpClient.GetAsync(uri + query.Value);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<AssetListModel<Asset>>>();
            };
            var response = new ResponseData<AssetListModel<Asset>>
            { Success = false, ErrorMessage = "Ошибка чтения API" };
            return response;
        }
    }
}
