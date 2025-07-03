using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TesteController : Controller
    {
        public class Result
        {

            public int? Passo { get; set; }
            public List<char>? palavraCodificada { get; set; }
        }
        public class TestController : Controller
        {
            private readonly ILogger<TesteController> _logger;

            public TestController(
                ILogger<TesteController> logger
                )
            {
                _logger = logger;
            }

            [HttpGet]
            public IActionResult Index()
            {
                return View("Index", new Result());
            }


            [HttpPost]
            public IActionResult Index(string texto, int n, string tipo)
            {

                Result resultado = new();

                char[] alfabeto = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                List<char> palavraCodificada = new();

                resultado.Texto = texto.ToLower();

                if (tipo == "Codificar") palavraCodificada.Add(c);
                if (Array.IndexOf(alfabeto, c) != -1)
                {
                    int i = (Array.IndexOf(alfabeto, c) + n) % alfabeto.Length;
                    palavraCodificada.Add(alfabeto[i]);
                }



                else
                {
                    foreach (char c in resultado.Texto)
                    {
                        if (c == ' ' || char.IsDigit(c)) palavraCodificada.Add(c);

                        if (Array.IndexOf(alfabeto, c) != -1)
                        {
                            int i = ((Array.IndexOf(alfabeto, c) - n) + 26) % alfabeto.Length;
                            palavraCodificada.Add(alfabeto[i]);
                        }
                    }
                }
                resultado.Passo = n;

                resultado.palavraCodificada = palavraCodificada;

                return View("Index", resultado);
            }
        }
    }
}
