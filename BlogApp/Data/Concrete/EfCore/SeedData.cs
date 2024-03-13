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
                    new Tag {Text = "web programlama", Url = "web-programlama", Color = TagColor.primary},
                    new Tag {Text = "backend", Url = "backend", Color = TagColor.success},
                    new Tag {Text = "fullstack", Url = "full-stack", Color = TagColor.danger},
                    new Tag {Text = "game", Url = "game", Color = TagColor.secondary},
                    new Tag {Text = "tech", Url = "tech", Color = TagColor.warning}
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
                        Url = "backend-bootcamp",
                        Image = "1.jpeg",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(2).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Unity Game Tutorial",
                        Content = "Unity ile oyun yapımı",
                        Url = "unity-game-tutorial",
                        Image = "2.png",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-7),
                        Tags = context.Tags.Take(4).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Asp.net Core Tutorial",
                        Content = "Web sitesi geliştireceğiz",
                        Url = "asp-net-core",
                        Image = "3.png",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 2
                    },
                    new Post{
                        Title = "React Bootcamp",
                        Content = "Web sitesi geliştireceğiz",
                        Url = "react",
                        Image = "3.png",
                        IsActive = true,
                        PublisedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(1).ToList(),
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }   
}