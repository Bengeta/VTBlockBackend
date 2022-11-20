using VTBlockBackend.Models;
using VTBlockBackend.Requests;
using VTBlockBackend.Responses;

namespace VTBlockBackend.Interfaces
{
    public interface IStockService
    {
        public Task<ResponseModel<PaginatedListModel<StockResponse>>> GetStocks(int page, int pageSize);
        public Task<ResponseModel<PaginatedListModel<StockResponse>>> GetStockByName(string Name);
        public Task<ResponseModel<StockResponse>> GetStockById(int Id);
        public Task<ResponseModel<StockResponse>> CreateStock(string token,StockRequest request);
        public Task<ResponseModel<StockResponse>> UpdateStock(string token,int id,StockRequest request);
        public Task<ResponseModel<StockResponse>> DeleteStock(int Id);
        
        public Task<ResponseModel<bool>> BuyStock(string token,int walletId, int id, int quantity);
        public Task<ResponseModel<bool>> SellStock(string token,int walletId, int id, int quantity);
        public Task<ResponseModel<List<QuoteResponse>>> GetQuotes();
        
        public Task<ResponseModel<List<StockResponse>>> GetUserStocks(string token);
        
    }
}