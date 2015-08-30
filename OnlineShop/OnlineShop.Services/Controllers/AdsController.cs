namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using OnlineShop.Models;

    [Authorize]
    [RoutePrefix("api/ads")]
    public class AdsController : BaseApiController
    {
        // GET ALL Ads
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads
                .Where(ad => ad.Status == AdStatus.Open)
                .OrderByDescending(ad => ad.Type.Index)
                .ThenByDescending(ad => ad.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        // CREATE Ad
        [HttpPost]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (model == null) return this.BadRequest("Invalid user data.");

            // AUTHORIZE ATTRIBUTE CHECK THE SAME
            //if (userId == null) return this.BadRequest("User is not logged in.");

            if (!this.ModelState.IsValid) return this.BadRequest(this.ModelState);

            if (!this.Data.AdTypes.Any(t => t.Id == model.TypeId)) return this.BadRequest("Invalid TypeId");

            var categories = this.Data.Categories.Where(c => model.Categories.Contains(c.Id)).ToList();

            if (categories.Count < 1 || categories.Count > 3) return this.BadRequest("Categories allowed range 1 - 3");

            if (categories.Count != model.Categories.Count()) return this.BadRequest("Invalid category id provided");

            var adCreator = this.Data.Users.Find(userId);
            var adType = this.Data.AdTypes.Find(model.TypeId);

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TypeId = model.TypeId,
                Type = adType,
                Categories = categories,
                OwnerId = userId,
                Owner = adCreator,
                PostedOn = DateTime.Now,
                Status = 0
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads.Where(a => a.Id == ad.Id).Select(AdViewModel.Create).FirstOrDefault();

            return this.Ok(result);
        }

        // CLOSE Ad
        [HttpPut]
        [Route("{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.Find(id);

            if (ad == null) return this.NotFound();

            var userId = User.Identity.GetUserId();

            if (userId != ad.OwnerId) return this.BadRequest("User is not ad owner");

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;

            this.Data.SaveChanges();

            return this.Ok("Ad sucessfuly closed.");
        }
    }
}

