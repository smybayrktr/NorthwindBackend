using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Veri varmış gibi davranacağımız için veri listesi tanımladık.

        public InMemoryProductDal() //New lendiğinde Product Listesi oluştur dedik.
        {
            _products = new List<Product> {
            new Product { ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=10, UnitsInStock=2},
            new Product { ProductId=2, CategoryId=1, ProductName="Tabak", UnitPrice=15, UnitsInStock=3},
            new Product { ProductId=3, CategoryId=2, ProductName="Masa", UnitPrice=110, UnitsInStock=4},
            new Product { ProductId=4, CategoryId=2, ProductName="Sandalye", UnitPrice=90, UnitsInStock=12},
            new Product { ProductId=5, CategoryId=3, ProductName="TV", UnitPrice=7550, UnitsInStock=8},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //Her p için listeyi gezip Idsi eşit olan productu bulur
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
