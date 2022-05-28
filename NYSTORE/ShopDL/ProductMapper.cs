using ShopModel ;

using ShopDL;
using System.Data.SqlClient;

namespace ShopDL
{
    public class ProductMapper
    {
        internal Product DboToProduct( SqlDataReader reader)
        {
             Product m = new Product
            {
                ProductID = (int)reader[0],
                ProductBrand = (string)reader[1],
                Catgory = (string)reader[2],
                UnitPrice = (int)reader[3],
                Quantity = (int)reader[4],
                location =(string)reader[5]
               
            };
            return m;
        }   
           
    }
}