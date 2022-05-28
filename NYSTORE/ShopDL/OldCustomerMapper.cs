using System.Data.SqlClient;
using ShopDL;
using ShopModel;
namespace ShopDL
{
    public class OldCustomerMapper
    {
         internal OldCustomer DboToOldCustomer(SqlDataReader reader)
        {
            OldCustomer oldCustomer = new OldCustomer
            {
            
                oldusername = (string)reader[0],
                oldpassword = (string)reader[1]
              
               

            };
            return oldCustomer;
        }   
      
        
    }
}