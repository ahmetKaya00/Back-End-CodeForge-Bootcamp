using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TagsMenu : ViewComponent{
        private ITagRepository _tagRapository;

        public TagsMenu(ITagRepository tagRepository){
            _tagRapository = tagRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View( await _tagRapository.Tags.ToListAsync());
        }
    }
}