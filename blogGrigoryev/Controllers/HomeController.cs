using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blogGrigoryev.Models;

namespace blogGrigoryev.Controllers
{
    /// <summary>
    /// Контроллер для работы с представлением Home
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Конструктор класса <see cref="HomeController"/>
        /// </summary>
        /// <param name="logger">Объект логирования</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Генерации результата запроса страницы Home
        /// </summary>
        /// <returns>Представление Home</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// генерации результата запроса страницы Privacy
        /// </summary>
        /// <returns>Представление Privacy</returns>
        public IActionResult Privacy()
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
