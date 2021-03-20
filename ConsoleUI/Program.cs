using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();
            //EfProductDalTest();
            //EfProductDalTest2();
            //CategoryTest();
            //ProductDetailsTest();
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void ProductDetailsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void EfProductDalTest2()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void EfProductDalTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void InMemoryTest()
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
