namespace SimpleMvc.App.Controllers
{
    using Framework.Contracts;
    using Framework.Controllers;
    using Framework.Attributes.Methods;

    public class HomeController : Controller
    {
        // GET  /home/index?id=5
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        // POST /home/index
        // BODY: Text=Ivan&Age=10
        //[HttpPost]
        //public IActionResult Index(int id, IndexModel model)
        //{
        //    return this.View();
        //}
    }
}
