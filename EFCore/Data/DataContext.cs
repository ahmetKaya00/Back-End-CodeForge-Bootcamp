using Microsoft.EntityFrameworkCore;

namespace EFCore.Data
{
    public class DataContext: DbContext{

        public DataContext(DbContextOptions<DataContext> options):base(options){
            
        }
        public DbSet<Bootcamp>Bootcamps => Set<Bootcamp>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<BootcampKayit> Kayitlar => Set<BootcampKayit>();
    }
}