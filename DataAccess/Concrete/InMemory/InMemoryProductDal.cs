﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitInStock=15, UnitPrice=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitInStock=3, UnitPrice=500},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitInStock=2, UnitPrice=1500},
                new Product{ProductId=4, CategoryId=2, ProductName="Kalvye", UnitInStock=65, UnitPrice=150},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitInStock=1, UnitPrice=85}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            //1.Yöntem
            /*
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    productToDelete = product;
                }
            }*/

            //2.yöntem-Lambda
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdigim ürün idsine sahip olan listedeki ürünü bul demektir.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
