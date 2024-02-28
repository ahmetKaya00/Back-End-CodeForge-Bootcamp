using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicApp.Models
{
    public class Bootcamp
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Instructor { get; set; }
        public string? Image { get; set; }
        public bool isActive {get;set;}
        public bool isHome {get;set;}
        public string[]? tag {get;set;}
    }
}