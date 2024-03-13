namespace BlogApp.Entity
{
    public enum TagColor{
        primary,danger,warning,success,secondary
    }
    public class Tag{
        public int TagId { get; set; }
        public string? Text {get;set;}
        public string? Url {get;set;}
        public TagColor? Color {get;set;}
        public List<Post> Posts {get;set;} = new List<Post>();
    }
}