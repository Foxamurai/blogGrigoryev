using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogForStudents.Security.Extensions;
using blogGrigoryev.Domain.DB;
using blogGrigoryev.Domain.Model;
using blogGrigoryev.ViewModels.Blog;
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
        /// Главная страница
        /// </summary>
        /// <returns>Представление</returns>
        public IActionResult Index()
        {
            var posts = _blogDbContext.BlogPosts
                .Select(x => new BlogPostItemViewModel
                {
                    Author = x.Owner.FullName,
                    Created = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Created);

            return View(posts);
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
        public IActionResult AddPost(NewPostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            var post = new BlogPost
            {
                Created = DateTime.Now,
                Data = model.Data,
                Title = model.Title,
                Owner = user.Employee
            };

            _blogDbContext.BlogPosts.Add(post);

            _blogDbContext.SaveChanges();

            return View();
               
        }

        [Authorize]
        [HttpGet]
        
        public IActionResult UserPosts()
        {
            var user = this.GetAuthorizedUser();
            var posts = _blogDbContext.BlogPosts
                .Where(x => x.Owner.Id == user.Id)
                .Select(x => new BlogPostItemViewModel
                {
                    Author = x.Owner.FullName,
                    Created = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Created);

            return View(posts);
        }

    }
}
