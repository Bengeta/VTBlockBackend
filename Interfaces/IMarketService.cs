using VTBlockBackend.Models;
using VTBlockBackend.Responses;

namespace VTBlockBackend.Interfaces;

public interface IMarketService
{
    public Task<ResponseModel<PaginatedListModel<MarketItemResponse>>> GetAllMarketItems(int page, int pageSize);
    public Task<ResponseModel<MarketItemResponse>> GetMarketItemById(int id);
}