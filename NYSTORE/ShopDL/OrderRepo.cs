using ShopModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
namespace ShopDL
{
    public class OrderRepo
    {
     public OrderMapper _mapper { get; set; }

    string connectionString=$"Server=tcp:electronicstoreserver.database.windows.net,1433;Initial Catalog=electronicstoreDb;Persist Security Info=False;User ID=electronicstoreDb;Password=100%Wintisperfect;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    // public List<Product> NewProduct()
    // {
    //     throw new NotImplementedException();
    // }

    public OrderRepo()
    {
        // this._repo = r;
        this._mapper = new OrderMapper();
    }
    public List<Order> OrderList()
    {
        string myQuery1 = "SELECT * FROM Orders;";
        //this using block creates teh SqlConnection.
        // the SqlConnection is the object that communicates with the Db.
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Connection.Open();//open the connection to the Db
            SqlDataReader results = command.ExecuteReader();//actually conduct the query.

            //query the FamilyRepository Db for the list of members
            //USE ADO.NET .........
            //use the mapper to transfer the falues in to Member objects in a List<Member>.
            List<Order> ml = new List<Order>();
            while (results.Read())
            {
                //mapp the current table row to a Member class objects
                Order order= this._mapper.DboToOrder(results);
                ml.Add(order);//send in the row of the reader to be mapped.
            }

            query1.Close();
            return ml;
        }
    }
   
    
      public Order NewOrder(string productID,string customerID,string unitprice,string quantity,string location)
    {
        // string myQuery2 = $"select CustomerID from Customer where CustomerID=@v;";
        // string myQuery3 = $"select ProductID rom Product where ProductID=@n;";
        string myQuery1 = $"INSERT INTO Orders (ProductID, CustomerID, Amount, Quantity,Location) VALUES (@n, @v, @p, @Q,@L);";
 
 
        //this using block creates teh SqlConnection.
        // the SqlConnection is the object that communicates with the Db.
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.AddWithValue("@n", productID);
            command.Parameters.AddWithValue("@v", customerID);
            command.Parameters.AddWithValue("@p", unitprice);
            command.Parameters.AddWithValue("@Q", quantity);
            command.Parameters.AddWithValue("@L", location);
            query1.Open();//open the connection to the Db
            int results = command.ExecuteNonQuery();//actually conduct the query.
            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.

            // I usually requery the Db to get the data fresh and triple verify that the data was inputted correctly

            if (results == 1)
            {
                Order order = new Order
                {
                    OrderID = 100,
                    ProductID = Int32.Parse(productID),
                    CustomerID=Int32.Parse(customerID),
                    UnitPrice=Int32.Parse(unitprice),
                    Quantity=Int32.Parse(quantity),
                    location=location
                        
                };
                return order;
            }
            return null;

        };
    }
     
   
   
    }
}