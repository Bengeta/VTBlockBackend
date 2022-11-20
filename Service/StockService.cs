using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VTBlockBackend.Data;
using VTBlockBackend.Enums;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Requests;
using VTBlockBackend.Responses;

namespace Service
{
    public class StockService : IStockService
    {
        private readonly IConfiguration _configuration;

        public StockService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

        public async Task<ResponseModel<bool>> BuyStock(string token, int walletId, int id, int quantity)
        {
            try
            {
                await using var context = new ApplicationContext(_configuration);
                var stock = await context.UserStocks.FirstOrDefaultAsync(
                    x => x.id == id && x.Wallet.User.token == token);
                if (stock == null)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                var stock_ = await GetStock(stock.SecId);
                var wallet = await context.Wallet.FirstOrDefaultAsync(x => x.id == walletId && x.User.token == token);
                if (wallet == null)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                wallet.Balance -= stock_.Price * quantity;
                if (wallet.Balance < 0)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                stock.Amount += quantity;
                context.Wallet.Update(wallet);
                await context.SaveChangesAsync();
                return new ResponseModel<bool>
                {
                    Data = true, ResultCode = ResultCode.Success
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseModel<bool>> SellStock(string token, int walletId, int id, int quantity)
        {
            try
            {
                await using var context = new ApplicationContext(_configuration);
                var stock = await context.UserStocks.FirstOrDefaultAsync(
                    x => x.id == id && x.Wallet.User.token == token);
                if (stock == null)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                var stock_ = await GetStock(stock.SecId);
                var wallet = await context.Wallet.FirstOrDefaultAsync(x => x.id == walletId && x.User.token == token);
                if (wallet == null)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                wallet.Balance += stock_.Price * quantity;
                stock.Amount -= quantity;
                if (stock.Amount < 0)
                {
                    return new ResponseModel<bool>
                    {
                        Data = false, ResultCode = ResultCode.Failed
                    };
                }

                if (stock.Amount == 0)
                    context.UserStocks.Remove(stock);
                context.Wallet.Update(wallet);
                await context.SaveChangesAsync();
                return new ResponseModel<bool>
                {
                    Data = true, ResultCode = ResultCode.Success
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseModel<List<QuoteResponse>>> GetQuotes()
        {
            try
            {
                var quotes = new List<QuoteResponse>();
                using var client = new HttpClient();
                var key = "sLUa9Dzq59Tn9H32kA1UGQnZhW9bSXgr";
                var url = "https://api.apilayer.com/fixer/latest?base=USD&symbols=EUR,GBP,RUB";
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

        public async Task<ResponseModel<List<StockResponse>>> GetUserStocks(string token)
        {
            try
            {
                await using var context = new ApplicationContext(_configuration);
                var res = new List<StockResponse>();
                var stocks = await context.UserStocks.Where(x => x.Wallet.User.token == token).ToListAsync();
                foreach (var stock in stocks)
                {
                    var stock_ = await GetStock(stock.SecId);
                    res.Add(stock_);
                }

                return new ResponseModel<List<StockResponse>>() {ResultCode = ResultCode.Success, Data = res};
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseModel<List<StockResponse>>() {ResultCode = ResultCode.Failed};
            }
        }

        private async Task<StockResponse> GetStock(string secid)
        {
            using var client = new HttpClient();
            var url = "https://iss.moex.com/iss/securities.json?limit=1&q=" + secid;
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StockResponse>(content);
            return result;
        }
    }
}