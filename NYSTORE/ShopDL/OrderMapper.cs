using ShopModel ;

using ShopDL;
using System.Data.SqlClient;
namespace ShopDL
{
    public class OrderMapper
    {
          internal Order DboToOrder( SqlDataReader reader)
        {
             Order m = new Order
            {
                OrderID =(int)reader[0],
                ProductID = (int)reader[1],
                CustomerID = (int)reader[2],
                UnitPrice = (int)reader[3],
                Quantity = (int)reader[4],
                location =(string)reader[5]
               
            };
            return m;
        }   
      
        
    }
}