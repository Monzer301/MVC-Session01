using Microsoft.AspNetCore.Mvc;
using MVC_S01.Models;
using System.Security.Cryptography.X509Certificates;
namespace MVC_S01.Controllers
{
    [Route("Test")]
    public class ProductController : Controller
    {



        //get baseURL/Product/GetById -> id = 0 , otherId = 0
        //get baseURL/Product/GetById/10 -> id = 0 , otherId = 0    (3l4an ana kateb FromQuery
        //get baseURL/Product/GetById?id=10 -> id = 10 , otherId = 0
        //get baseURL/Product/GetById?otherid=10 -> id = 0 , otherId = 0
        //get baseURL/Product/GetById?id2=10 -> id = 0 , otherId = 10

        [HttpGet]
        public IActionResult GetById([FromQuery] int id, [FromQuery(Name = "id2")] int otherId)
        {
            return View();
        }


        [HttpGet]
        //binder create new object from ProductFilter and fill Each property
        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }

        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello from Json Action");
        }



        [HttpGet("productCode/{code}")]
        public IActionResult GetProductByCode(int Code)
        {
            return Json(new Product() { Id = Code, Name = "laptop" });
        }



        //Get BaseURL/Producrt/search =>Id = 0
        //Get BaseURL/Producrt/search/10 => Id = 10 [Bind From Route]
        //Get BaseURL/Producrt/search/?Id=20 => Id = 20 [Bind from Query]
        //Get BaseURL/Producrt/search/10?id=20 =>Id = 10 [Bind From Route]
        [HttpGet]
        //public IActionResult Search(int id)
        //{
        //    return View();
        //}




        //Action   
        //Get -> BaseURL/product/testAction
        //public string Index()
        //{
        //    return "<h1>Hello from Idex</h1>";
        //}

        // GET BAseUel/Json
        [HttpGet] //Default
        public ViewResult Index()
        {
            #region Content
            //ContentResult result = new ContentResult()
            //{
            //    Content= "<h1>Hello from Idex</h1>",
            //    StatusCode = 1000,
            //    ContentType = "text/html"
            //};
            //return Content("<h1>Hello from Idex</h1>","text/html");
            #endregion

            return View();
        }
        [HttpGet]
        public JsonResult GetProduct()
        {
            var products = new List<Product>()
            {
                new Product { Id = 10,Name="laptop" },
                new Product { Id = 20,Name="Mobile" }
            };
           return Json(products);
        }

        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else
                return Json(new Product() { Id = id, Name = "Labtop" });

        }
        public IActionResult FileAction()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/LinqAss.pdf");
            return File(fileBytes, "Applcation/pdf");
        }
    }
}
