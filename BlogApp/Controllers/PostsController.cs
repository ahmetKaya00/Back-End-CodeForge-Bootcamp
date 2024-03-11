using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostsController : Controller{

        private IPostRepository _context;

        public PostsController(IPostRepository context){
            _context = context;
        }
        public IActionResult Index(){
            return View(_context.Posts.ToList());
        }
    }
}