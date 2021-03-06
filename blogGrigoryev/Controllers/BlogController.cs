﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace blogGrigoryev.Controllers
{
    /// <summary>
    /// Контроллер для работы с представлением Blog
    /// </summary>
    public class BlogController : Controller
    {
        /// <summary>
        /// генерации результата запроса страницы Blog
        /// </summary>
        /// <returns>Представление Blog</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
