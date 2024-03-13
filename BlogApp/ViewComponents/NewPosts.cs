using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class NewPosts : ViewComponent{
        private IPostRepository _postRapository;

        public NewPosts(IPostRepository postRepository){
            _postRapository = postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View(await _postRapository
                        .Posts
                        .OrderByDescending(p=>p.PublisedOn)
                        .Take(5)
                        .ToListAsync());
        }
    }
}