using System;
using System.Collections.Generic;

using OnlineTindahan.Models;
using System.Data;
using System.Data.SqlClient;
namespace OnlineTindahan.DataAccessLayer
{
    public class ProductsDAL : DataAccess
    {
        public Product GetProductByID(int productID)
        {
            var product = new Product();
            this.Command = "CSMP.dbo.MVC_GetProductDetails";
            this.Parameters.Add(new SqlParameter("@productID", productID));

            var dataTable = GetDataTable();

            if (this.IsSuccessful)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        product.ProductID = Convert.ToInt32(row["ProductID"]);
                        product.ProductName = row["ProductName"].ToString();
                        product.ProductDescription = row["ProductDescription"].ToString();
                        product.ProductGroup = row["ProductGroup"].ToString();
                        product.ProductClassification = row["ProductClassification"].ToString();
                        product.ProductBrand = row["ProductBrand"].ToString();
                        product.WarrantyInDays = Convert.ToInt32(row["WarrantyInDays"]);
                        product.AvailableQuantity = Convert.ToInt32(row["AvailableQuantity"]);
                        product.ProductPrice = Convert.ToDouble(row["ProductPrice"]);
                    }
                }
            }
            return product;
        }

        public List<Product> GetProductList()
        {
            var productList = new List<Product>();
            this.Command = "CSMP.dbo.MVC_GetProductDetails";
            var dataTable = GetDataTable();

            if (this.IsSuccessful)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var product = new Product();
                        product.ProductID = Convert.ToInt32(row["ProductID"]);
                        product.ProductName = row["ProductName"].ToString();
                        product.ProductDescription = row["ProductDescription"].ToString();
                        product.ProductGroup = row["ProductGroup"].ToString();
                        product.ProductClassification = row["ProductClassification"].ToString();
                        product.ProductBrand = row["ProductBrand"].ToString();
                        product.WarrantyInDays = Convert.ToInt32(row["WarrantyInDays"]);
                        product.AvailableQuantity = Convert.ToInt32(row["AvailableQuantity"]);
                        product.ProductPrice = Convert.ToDouble(row["ProductPrice"]);

                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
    }
}