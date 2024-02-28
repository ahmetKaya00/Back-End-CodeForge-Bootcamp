namespace BasicApp.Models
{
    public class Repository{

        private static readonly List<Bootcamp> _bootcamp = new();

        static Repository(){
            _bootcamp = new List<Bootcamp>(){
                new() {Id = 1, Title = "Backend Bootcamp",Description="Güzel eğitim.", Instructor = "Ahmet Kaya", Image = "1.png", tag = new string[] {"web geliştirme", "asp.net"}, isActive = false, isHome = false},
                new() {Id = 2, Title = "Froundend Bootcamp",Description="Güzel eğitim.", Instructor = "Barış Uygun", Image = "2.png", tag = new string[] {"web geliştirme", "html" ,"Css"}, isActive = true, isHome = false},
                new() {Id = 3, Title = "Unity Bootcamp",Description="Güzel eğitim.", Instructor = "Özge Dirik", Image = "3.png", tag = new string[] {"oyun geliştirme", "unity"}, isActive = true, isHome = true},
            };
        }

        public static List<Bootcamp> Bootcamps{get{return _bootcamp;}}

        public static Bootcamp? GetById(int id){
            return _bootcamp.FirstOrDefault(b=>b.Id == id);
        }

    }
}