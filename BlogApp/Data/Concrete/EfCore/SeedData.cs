using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
 public class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
            }
            if(!context.Tags.Any()){
                context.Tags.AddRange(
                    new Tag {Text = "web programlama"},
                    new Tag {Text = "backend"},
                    new Tag {Text = "fullstack"},
                    new Tag {Text = "game"}
                );       
                context.SaveChanges(); 
            }
            if(!context.Users.Any()){
                context.Users.AddRange(
                    new User {UserName = "ahmetkaya"},
                    new User {UserName = "diclebahceli"}
                );
                context.SaveChanges();
            }
            if(!context.Posts.Any()){
                context.Posts.AddRange(
                    new Post{
                        Title = "Backend Bootcamp",
                        Content = "Backend dersleri işlenecek",
                        Image = "1.jpeg",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(2).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Unity Game Tutorial",
                        Content = "Unity ile oyun yapımı",
                        Image = "2.png",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-7),
                        Tags = context.Tags.Take(4).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Asp.net Core Tutorial",
                        Content = "Web sitesi geliştireceğiz",
                        Image = "3.png",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }   
}