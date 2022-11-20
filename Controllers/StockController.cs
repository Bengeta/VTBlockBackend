using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Responses;

namespace VTBlockBackend.Controllers;

[ApiController]
[Route("api/")]
public class StockController : BaseController
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet("stocks/page/{page:int}/{pageSize:int}")]
    public async Task<ResponseModel<PaginatedListModel<StockResponse>>> GetStocks(int page = 0, int pageSize = 10)
    {
        return await _stockService.GetStocks(page, pageSize);
    }
    
    [HttpGet("stocks/{id}")]
    public async Task<ResponseModel<StockResponse>> GetStock(int id)
    {
        return await _stockService.GetStockById(id);
    }
    
    [HttpPost("stocks/quotes")]
    public async  Task<ResponseModel<List<QuoteResponse>>> GetQuotes()
    {
        return await _stockService.GetQuotes();
    }
    
    [HttpGet("stocks/user")]
    [Authorize]
    public async Task<ResponseModel<List<StockResponse>>> GetUserStocks()
    {
        return await _stockService.GetUserStocks(Token());
    }
    
}