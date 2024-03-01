namespace FormApp.Models
{
    public class Repository{
        private static readonly List<Product> _product = new();
        private static readonly List<Category> _category = new();

        static Repository(){
            _category.Add(new Category {CategoryId = 1, Name ="Roman"});
            _category.Add(new Category {CategoryId = 2, Name ="Kişisel Gelişim"});

            _product.Add(new Product{ProductId = 1, BookName = "Son Ayı",PageCount = 225, IsActive = true, Image = "1.png",CategoryId = 1});
            _product.Add(new Product{ProductId = 2, BookName = "Tarık Buğra'nın Roman Dünyası",PageCount = 450, IsActive = true, Image = "2.png",CategoryId = 1});
            _product.Add(new Product{ProductId = 3, BookName = "Cadı",PageCount = 375, IsActive = true, Image = "3.png",CategoryId = 2});
        }

        public static List<Product> Products{get{return _product;}}

        public static void CreateProduct(Product entity){
            _product.Add(entity);
        }

        public static void EditProduct(Product updateProduct){
            var entity = _product.FirstOrDefault(b=>b.ProductId == updateProduct.ProductId);
            if(entity != null){
                entity.BookName = updateProduct.BookName;
                entity.PageCount = updateProduct.PageCount;
                entity.Image = updateProduct.Image;
                entity.CategoryId = updateProduct.CategoryId;
            }
        }
        public static List<Category> Categories{get{return _category;}}
    }
}