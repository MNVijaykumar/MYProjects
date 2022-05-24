using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayerAPI.Models;
using Ganss.Excel;

namespace DataAccessLayerAPI
{
    public interface IDAL
    {
        IEnumerable<ProductDetailViewModel> GetProducts();

        IEnumerable<ProductViewModel> GetProductsPerCategory(long productCategoryId);
    }
    public class DALFROMExcel : IDAL
    {
        private readonly string file = @"E:\Database.xlsx";
        public IEnumerable<ProductDetailViewModel> GetProducts()
        {
            var products = new ExcelMapper(file).Fetch<ProductModel>(0);
            var productModels = new ExcelMapper(file).Fetch<ProductDetailModel>(1);

            var productViewModel = (from product in products
                                    join productModel in productModels
                                    on product.Id equals productModel.ProductId
                                    select new ProductDetailViewModel
                                    {
                                        Id = product.Id,
                                        Name = product.Name,
                                        Total = productModel.Total,
                                        Ordered = productModel.Ordered,
                                        CostPerUnit = productModel.CostPerUnit
                                    }).ToList();
            return productViewModel;
        }

        public IEnumerable<ProductDetailViewModel> GetProductsPerCategory(long categoryId)
        {
            var products = new ExcelMapper(file).Fetch<ProductModel>(0);
            var productModels = new ExcelMapper(file).Fetch<ProductDetailModel>(1);

            var productViewModel = (from product in products
                                    join productModel in productModels
                                   on product.Id equals productModel.ProductId
                                    where product.CategoryId == categoryId
                                    select new ProductDetailViewModel
                                    {
                                        Id = product.Id,
                                        Name = product.Name,
                                        Total = productModel.Total,
                                        Ordered = productModel.Ordered,
                                        CostPerUnit = productModel.CostPerUnit
                                    }).ToList();
            return productViewModel;
        }

        IEnumerable<ProductViewModel> IDAL.GetProductsPerCategory(long productCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}