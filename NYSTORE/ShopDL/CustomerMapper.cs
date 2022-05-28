using ShopDL;
using ShopModel;

using System.Data.SqlClient;
namespace ShopDL
{
    public class CustomerMapper
    {

        
     internal Customer DboToCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer
            {
            CustomerID = (int)reader[0],
                fname = (string)reader[1],
                lname = (string)reader[2],
                username = (string)reader[3],
                password = (string)reader[4],
                email = (string)reader[5]
               

            };
            return customer;
        }   

       
    }
}