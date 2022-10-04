using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VTBlockBackend.Data;
using VTBlockBackend.Enums;
using VTBlockBackend.Models;
using VTBlockBackend.Models.DBTables;
using VTBlockBackend.Utils;

namespace VTBlockBackend.Data;

public class ApplicationContextSeeder
{
    private readonly ApplicationContext _applicationContext;

    public ApplicationContextSeeder(ApplicationContext _applicationContext)
    {
        this._applicationContext = _applicationContext;
    }

    public void Seed(string SecretKey, string Issuer, string Audience)
    {
        _applicationContext.Users.RemoveRange(_applicationContext.Users);
        _applicationContext.Tag.RemoveRange(_applicationContext.Tag);
        _applicationContext.Task.RemoveRange(_applicationContext.Task);
        _applicationContext.ImageStorage.RemoveRange(_applicationContext.ImageStorage);
        _applicationContext.MarketItem.RemoveRange(_applicationContext.MarketItem);
        _applicationContext.SaveChanges();

        var users = new List<UserModel>();
        if (!_applicationContext.Users.Any())
        {
            var pas = Hash.GenerateHash("asdf");
            users.Add(new UserModel()
            {
                username = "gsanov",
                token = "asdf",
                password = pas.Key,
                salt = pas.Value,
                email = "gsanov@"
            });
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, users[^1].username));
            claims.Add(new Claim(ClaimTypes.Email, users[^1].email));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            users[^1].token = new JwtSecurityTokenHandler().WriteToken(token);
            _applicationContext.Users.AddRange(users);
        }

        var Task = new List<TaskModel>();
        if (!_applicationContext.Task.Any())
        {
            Task.Add(new TaskModel()
            {
                Name = "Task1",
                Description = "Task1",
                Reward = 123,
                CreatedBy = "gsanov",
                CreatedDate = DateTime.Now,
                DeadLine = DateTime.Now.AddDays(1),
            });
            Task.Add(new TaskModel()
            {
                Name = "Task2",
                Description = "Task2",
                Reward = 123,
                CreatedBy = "gsanov",
                CreatedDate = DateTime.Now,
                DeadLine = DateTime.Now.AddDays(1),
            });
        }

        var photos = new List<ImageStorage>()
        {
            new ImageStorage()
            {
                imageUrl = "boxes/aecc95ec2064745bf81e09943529a0bb.jpg",
            },
            new ImageStorage()
            {
                imageUrl = "boxes/ArcoLinux_2022-02-16_14-51-59.png",
            },
            new ImageStorage()
            {
                imageUrl = "boxes/колкие.jpg",
            },
        };


        _applicationContext.ImageStorage.AddRange(photos);
        _applicationContext.Task.AddRange(Task);
        _applicationContext.SaveChanges();

        var tags = new List<TagModel>()
        {
            new TagModel()
            {
                Name = "Tag1",
            },
            new TagModel()
            {
                Name = "Tag2",
            },
            new TagModel()
            {
                Name = "Tag3",
            },
        };
        _applicationContext.Tag.AddRange(tags);

        _applicationContext.SaveChanges();

        var marketItems = new List<MarketItemModel>()
        {
            new MarketItemModel()
            {
                Name = "Item1",
                Description = "Item1",
                Price = 123,
                Quantity = 23,
                Category = MarketItemCategory.Defalt
            },
            new MarketItemModel()
            {
                Name = "Item2",
                Description = "Item2",
                Price = 123,
                Quantity = 23,
                Category = MarketItemCategory.Defalt
            },
            new MarketItemModel()
            {
                Name = "Item3",
                Description = "Item3",
                Price = 123,
                Quantity = 23,
                Category = MarketItemCategory.Defalt
            },
        };
        
        _applicationContext.MarketItem.AddRange(marketItems);
        _applicationContext.SaveChanges();
    }
}