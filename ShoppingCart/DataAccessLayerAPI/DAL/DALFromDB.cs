using DataAccessLayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace DataAccessLayerAPI.DAL
{
    public class DALFromDB : IDAL
    {
        public IEnumerable<ProductDetailViewModel> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetProductsPerCategory(long productCategoryId)
        {
            var pri =Fetch(productCategoryId);

            return pri;
        }

        public List<ProductViewModel> Fetch(long productCategoryId)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select Id,Name,ImageData from Products where IsActive=1 and ProductCategoryId=@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", productCategoryId));
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var productViewModel = new ProductViewModel()
                            {
                                Name = sdr["Name"].ToString(),
                                Id = Convert.ToInt32(sdr["Id"]),
                                ImageData = (byte[])sdr["ImageData"]
                            };
                            productViewModels.Add(productViewModel);
                        }
                    }
                    connection.Close();
                }
            }
            return productViewModels;
        }

        public void UpdateOrder(long productId)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateProductOrderDetails", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ProductId", productId));
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}