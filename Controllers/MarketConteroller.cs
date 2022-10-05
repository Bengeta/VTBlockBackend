using Microsoft.AspNetCore.Mvc;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Responses;

namespace VTBlockBackend.Controllers;

public class MarketConteroller
{
    private IMarketService _marketService;

    public MarketConteroller(IMarketService marketService)
    {
        _marketService = marketService;
    }

    [HttpGet("api/market/items/{int page}/{int pageSize}")]
    public async Task<ResponseModel<PaginatedListModel<MarketItemResponse>>> GetItems(int page, int pageSize)
    {
        return await _marketService.GetAllMarketItems(page, pageSize);
    }
    
    [HttpGet("api/market/items/{int id}")]
    public async Task<ResponseModel<MarketItemResponse>> GetItems(int id)
    {
        return await _marketService.GetMarketItemById(id);
    }
}