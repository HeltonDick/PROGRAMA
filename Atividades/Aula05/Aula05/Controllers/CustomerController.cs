using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System;


namespace Aula05.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private CustomerRepository _customerRepository;

        public CustomerController(IWebHostEnvironment environment) {
            _customerRepository = new CustomerRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View("Index", customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile() {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers) {
                fileContent += $"{c.Id};{c.Name};{c.HomeAddress.Id};{c.HomeAddress.City}" +
                    $";{c.HomeAddress.Country};{c.HomeAddress.State};" +
                    $"{c.HomeAddress.Street1};{c.HomeAddress.Street2};" +
                    $"{c.HomeAddress.PostalCode};{c.HomeAddress.AddressType}\n";
            }
            SaveFile(fileContent, "DelimitedFile.txt");

            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFileFixed() {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent += string.Format($"{0:64}", c.Id) string.Format($"{0:64}", c.Name);

                fileContent += $"{c.Id};{c.Name};{c.HomeAddress.Id};{c.HomeAddress.City}" +
                    $";{c.HomeAddress.Country};{c.HomeAddress.State};" +
                    $"{c.HomeAddress.Street1};{c.HomeAddress.Street2};" +
                    $"{c.HomeAddress.PostalCode};{c.HomeAddress.AddressType}\n";
            }
            SaveFile(fileContent, "Fixed.txt");
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            if (id == null || id.Value <= 0) return NotFound();

            Customer customer = _customerRepository.Retrieve(id.Value);

            if (customer == null) return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id) { 
            if (id == null || id <= 0) return NotFound();

            if (!_customerRepository.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }

        private bool SaveFile(string content, string fileName) {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName)) return false;

            var path = Path.Combine(environment.WebRootPath, "TextFiles");

            try {
                if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(path, fileName);

                if (!System.IO.File.Exists(filepath)) {
                    using (StreamWriter sw = System.IO.File.CreateText(filepath)) {
                        sw.Write(content);
                    }
                }
            }

            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
            }

            

            return ret;
        }
    }
}
