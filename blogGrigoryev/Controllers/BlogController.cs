using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogGrigoryev.Domain.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogGrigoryev.Controllers
{
    /// <summary>
    /// Контроллер для работы с представлением Blog
    /// </summary>
    public class BlogController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }

        /// <summary>
        /// генерации результата запроса страницы Blog
        /// </summary>
        /// <returns>Представление Blog</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Метод открывает страницу с добавлением поста
        /// </summary>
        /// <returns>Возварщает страницу для добавления поста</returns>
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницу постов пользователя</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(NewPostModel model)
        {

        }

    }
}
