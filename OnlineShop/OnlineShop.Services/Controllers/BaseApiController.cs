namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController() : this(new OnlineShopContext())
        {
        }

        public BaseApiController(OnlineShopContext data)
        {
            this.Data = data;
        }

        protected OnlineShopContext Data { get; set; }
    }
}
