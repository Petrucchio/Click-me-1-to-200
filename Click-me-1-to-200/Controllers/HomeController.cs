using Click_me_1_to_200.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;

namespace Click_me_1_to_200.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            limparCsv();
            return View();
        }

        public IActionResult Create([Bind("valormin,valormax")] Number number,divisor divis)
        {
            
            bool div3, div5, div3and5;
            for(int i= number.valormin;i<= number.valormax; i++)
            {
                var value = i;
                if(div3 = i % 3 == 0)
                {
                    divis.divisivel = "X";
                }
                if(div5 = i % 5 == 0)
                {
                    divis.divisivel = "Y";
                }

                if (div3 && div5)
                {
                    divis.divisivel = "Z";
                }
                
                SalvarCsv(value,divis.divisivel);
                divis.divisivel = "";
            }

            return View();
        }

        private void limparCsv()
        {
                var linha = "";
                StreamWriter arquivo = new StreamWriter(@"C:\Users\vitux\source\repos\Click-me-1-to-200\Click-me-1-to-200\Data\numeros.csv");
                arquivo.WriteLine(linha);
                arquivo.Close();
            
        }
        private void SalvarCsv(int value,string divisivel )
        {
                var linha = value.ToString() + ";" + divisivel;
                StreamWriter arquivo = new StreamWriter(@"C:\Users\vitux\source\repos\Click-me-1-to-200\Click-me-1-to-200\Data\numeros.csv", true);
                arquivo.WriteLine(linha);
                arquivo.Close();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}