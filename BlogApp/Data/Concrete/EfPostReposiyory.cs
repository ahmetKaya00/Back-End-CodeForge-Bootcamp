using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete
{
    public class EfPostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public EfPostRepository(BlogContext context){
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        

        public void EditPost(Post post, int[] tagId){
            var entity = _context.Posts.Include(i=>i.Tags).FirstOrDefault(i=>i.PostId == post.PostId);

            if(entity != null){
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.Url = post.Url;
                entity.IsActive = post.IsActive;

                entity.Tags = _context.Tags.Where(tag => tagId.Contains(tag.TagId)).ToList();

                _context.SaveChanges();
            }
        }
    }
}