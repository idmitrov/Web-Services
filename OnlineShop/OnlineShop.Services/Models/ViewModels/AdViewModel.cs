namespace OnlineShop.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using OnlineShop.Models;

    public class AdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public UserViewModel Owner { get; set; }

        public string AdType { get; set; }

        public DateTime PostedOn { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return ad => new AdViewModel()
                {
                    Id = ad.Id,
                    Name = ad.Name,
                    Description = ad.Description,
                    Price = ad.Price,
                    AdType = ad.Type.Name,
                    PostedOn = ad.PostedOn,
                    Owner = new UserViewModel
                    {
                        Id = ad.OwnerId,
                        Username = ad.Owner.UserName
                    },
                    Categories = ad.Categories.Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                };
            }
        } 
    }
}