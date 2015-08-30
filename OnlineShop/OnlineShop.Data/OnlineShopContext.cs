namespace OnlineShop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopContext() : base("OnlineShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>());
        }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }

        // ADs
        public IDbSet<Ad> Ads { get; set; }

        // AdTypes
        public IDbSet<AdType> AdTypes { get; set; }

        // CATEGORIES
        public IDbSet<Category> Categories { get; set; }
    }
}