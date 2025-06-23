using Microsoft.AspNetCore.Mvc;
using Repository;
using Modelo;
using Aula05.ViewModels;
using System.Runtime.CompilerServices;

namespace Aula05.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment) {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult index() {
            List<Product> products = _productRepository.RetriveAll();
            return View(products);
        }

        [HttpPost]
        public IActionResult create(Product p) {
            _productRepository.Save(p);
            List<Product> products = _productRepository.RetriveAll();
            return View("Index" products);
        }

        [HttpPost]
        public IActionResult create() {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile() {
            string fileContent = string.Empty;
            foreach (Product p in CustomerData.Products) {
                fileContent += $"{p.Id};{p.Name};{p.Description};{p.CurrentPrice}\n"
            }
            SaveFile(fileContent, "DelimitedFile.txt");

            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitedFileFixed() {
            string fileContent = string.Empty;
            foreach (Product p in CustomerData.Products) {
                fileContent += string.Format("{0:5}{1:64}", p.Id, p.Name) +
                string.Format("{0:64}", p.Description) +
                string.Format("{0:32}", p.CurrentPrice) +
                "\n";
            }
            SaveFile(fileContent, "Fixed.txt");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            if (id == null || id.Value <= 0) return NotFound();

            Product product = _productRepository.Retrive(id.Value)

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int? id) {
            if (id == null || id <= 0) return NotFound();

            if (!_productRepository.DeleteById(id.Value)) return NotFound();

            return RedirectToAction("Index");
        }


        private bool SaveFile(string content, string fileName) {
            bool ret = true;
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName)) return false;

            var path = Path.Combine(environment.WebRootPath, "TextFiles");

            try {
                if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

                var filePath = Path.Combine(path, fileName);
                if (!System.IO.File.Exists(filePath)) {
                    using (StreamWriter sw = System.IO.File.CreateText(filePath)) {
                        sw.Write(content);
                    }
                }
            }

            catch (IOException ioEx) {
                string msg = ioEx.Message;
                ret = false;
            }

            catch (Exception ex) {
                string msg = ex.Message;
                ret = false;
            }

            return ret;
        }
    }
}
