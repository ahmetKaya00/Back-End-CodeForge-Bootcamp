using EFCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    public class BootcampKayitController:Controller{
        private readonly DataContext _context;

        public BootcampKayitController(DataContext context){
            _context = context;
        }
    }
}