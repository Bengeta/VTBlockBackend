using Newtonsoft.Json;
using VTBlockBackend.Enums;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Requests;
using VTBlockBackend.Responses;

namespace Service
{
    public class StockService : IStockService
    {
        public async Task<ResponseModel<PaginatedListModel<StockResponse>>> GetStocks(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<PaginatedListModel<StockResponse>>> GetStockByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StockResponse>> GetStockById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StockResponse>> CreateStock(string token, StockRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StockResponse>> UpdateStock(string token, int id, StockRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StockResponse>> DeleteStock(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> BuyStock(string token, int id, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> SellStock(string token, int id, int quantity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<QuoteResponse>>> GetQuotes()
        {
            try
            {
                var quotes = new List<QuoteResponse>();
                using var client = new HttpClient();
                var key = "sLUa9Dzq59Tn9H32kA1UGQnZhW9bSXgr";
                var url = "https://api.apilayer.com/fixer/latest?base=USD&symbols=EUR,GBP";
                client.DefaultRequestHeaders.Add("ApiKey", key);
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<QuoteResponse>(content);
                    quotes.Add(result);
                }

                return new ResponseModel<List<QuoteResponse>>() {ResultCode = ResultCode.Success, Data = quotes};
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<QuoteResponse>>() {ResultCode = ResultCode.Failed};
            }
        }
    }
}