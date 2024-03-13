using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ITagRepository{
        IQueryable<Tag> Tags {get;}

        void CreatePost(Tag tag);
    }   
}