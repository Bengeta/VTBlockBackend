using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VTBlockBackend.Enums;
using VTBlockBackend.Interfaces;
using VTBlockBackend.Models;
using VTBlockBackend.Data;
using VTBlockBackend.Models;
using VTBlockBackend.Responses;
using VTBlockBackend.Utils;
using VTBlockBackend.Models.DBTables;

namespace VTBlockBackend.Service;

public class MarketService : IMarketService
{
    private ApplicationContext _context;
    private JwtSettings _options;

    public MarketService(ApplicationContext context, IOptions<JwtSettings> options)
    {
        _context = context;
        _options = options.Value;
    }

    public async Task<ResponseModel<PaginatedListModel<MarketItemResponse>>> GetAllMarketItems(int page, int pageSize)
    {
        try
        {
            var marketItems = await (from MarketItems in _context.MarketItem
                join MarketItemImage in _context.MarketItemImage on MarketItems.Id equals MarketItemImage.MarketItemId
                join imageStorage in _context.ImageStorage on MarketItemImage.ImageId equals imageStorage.Id
                select new MarketItemResponse()
                {
                    Id = MarketItems.Id,
                    Name = MarketItems.Name,
                    Description = MarketItems.Description,
                    Price = MarketItems.Price,
                    ImageUrl = imageStorage.imageUrl,
                    Category = MarketItems.Category,
                    Quantity = MarketItems.Quantity
                }).ToListAsync();

            var paginatedList = PagedList<MarketItemResponse>.ToPagedList(marketItems, page, pageSize);
            return new ResponseModel<PaginatedListModel<MarketItemResponse>>()
            {
                Data = new PaginatedListModel<MarketItemResponse>()
                {
                    currentPage = paginatedList.CurrentPage,
                    isNext = paginatedList.HasNext,
                    countPage = paginatedList.TotalCount,
                    isPrev = paginatedList.HasPrevious,
                    data = paginatedList
                },
                ResultCode = ResultCode.Success
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ResponseModel<PaginatedListModel<MarketItemResponse>>() {ResultCode = ResultCode.Failed};
        }
    }

    public async Task<ResponseModel<MarketItemResponse>> GetMarketItemById(int id)
    {
        try
        {
            var marketItem = await (from MarketItems in _context.MarketItem
                join MarketItemImage in _context.MarketItemImage on MarketItems.Id equals MarketItemImage.MarketItemId
                join imageStorage in _context.ImageStorage on MarketItemImage.ImageId equals imageStorage.Id
                where MarketItems.Id == id
                select new MarketItemResponse()
                {
                    Id = MarketItems.Id,
                    Name = MarketItems.Name,
                    Description = MarketItems.Description,
                    Price = MarketItems.Price,
                    ImageUrl = imageStorage.imageUrl,
                    Category = MarketItems.Category,
                    Quantity = MarketItems.Quantity
                }).FirstOrDefaultAsync();
            return new ResponseModel<MarketItemResponse>()
            {
                Data = marketItem,
                ResultCode = ResultCode.Success
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ResponseModel<MarketItemResponse>() {ResultCode = ResultCode.Failed};
        }
    }
}