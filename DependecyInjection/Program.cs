using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependecyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager efProductManager= new ProductManager(new EfProductDal());//Kullanımı ise bu şekilde. 
            ProductManager nhProductManager = new ProductManager(new NhProductDal()); 
            //E ama burda nesne türettik diyebilirsiniz. Gayette haklısınız. Buradaki nesne türetimini azaltmak içinse IoC Container kullanıyoruz.
            //IoC Container implementasyonunu yorum satırlarıyla anlatamayacağım için yazmadım ama googledan araştırabilirsiniz.

            nhProductManager.GetAll();
            efProductManager.GetAll();

            Console.ReadLine();
        }
    }

    class EfProductDal:IProductDal
    {
        public void GetAll()
        {
            Console.WriteLine("Products Listed With Entity Framework");
        }
    }

    class NhProductDal:IProductDal
    {
        public void GetAll()
        {
            Console.WriteLine("Products listed with NHiberNate");
        }
    }

    class ProductManager
    {
        //Dependency injection için öncelikle interface'imizin fieldını tanımlıyoruz.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)//Daha sonra constructor parametresine aynı interface'in örneğini türetiyoruz.
        {
            _productDal = productDal;//Son olarak parametreden gelen nesne örneğini fieldımıza atıyoruz. Bu sayede injection tamamlanıyor.
            /*
              Dependecy Injection solid prensiplerinin "D" harfini temsil eder. Nesneyi doğrudan türetmek bellek için çok pahalı bir işlemdir(bellekte çok yer kaplar).
              Bu tasarım deseni nesne örneğini doğrudan türetmeden çağırmamıza yarıyor. 
              Bu sayede bellekte tasarruf sağlamış oluyoruz.
             */
        }

        public void GetAll()
        {
            _productDal.GetAll();
        }
    }
    interface IProductDal
    {
        void GetAll();
    }
}
