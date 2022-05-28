using ShopModel;
using System.Data.SqlClient;
using System.Data;

namespace ShopDL;

public class CustomerRepo
{
    public CustomerMapper _mapper { get; set; }

    string connectionString=$"Server=tcp:electronicstoreserver.database.windows.net,1433;Initial Catalog=electronicstoreDb;Persist Security Info=False;User ID=electronicstoreDb;Password=100%Wintisperfect;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
  
public CustomerRepo()
    {
        // this._repo = r;
        this._mapper = new CustomerMapper();
    }
    public Customer NewCustomer(string fname,string lname,string username,string password,string email)
    {   string query= $" ";
        string myQuery1 = $"INSERT INTO Customer (FirstName, LastName, UserName, Password,Email) VALUES (@f, @l, @u, @p,@e);";
  
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.AddWithValue("@f", fname);
            command.Parameters.AddWithValue("@l", lname);
            command.Parameters.AddWithValue("@u", username);
            command.Parameters.AddWithValue("@p", password);
            command.Parameters.AddWithValue("@e", email);

            query1.Open();
            int results = command.ExecuteNonQuery();
            query1.Close();

            if (results == 1)
            {
                Customer m = new Customer
                {
                    CustomerID = 100,
                    fname = fname,
                    lname = lname,
                    username = username,
                    password = password,
                    email = email
                    
                    
                };
                return m;
            }
            return null;

        };
    }
   public List<Customer> CustomerList()
    {
        string myQuery1 = "SELECT * FROM Customer;";
        //this using block creates teh SqlConnection.
        // the SqlConnection is the object that communicates with the Db.
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Connection.Open();//open the connection to the Db
            SqlDataReader results = command.ExecuteReader();//actually conduct the query.

            //query the FamilyRepository Db for the list of Customers
            //USE ADO.NET .........
            //use the mapper to transfer the falues in to Customer objects in a List<Customer>.
            List<Customer> ml = new List<Customer>();
            while (results.Read())
            {
                //mapp the current table row to a Customer class objects
                Customer m = this._mapper.DboToCustomer(results);
                ml.Add(m);//send in the row of the reader to be mapped.
            }

            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.
            return ml;
        }
    }
    public Customer UpdateByCustomerID(string fname,string lname,string username,string password,string email)
   {
        string myQuery1 = $"UPDATE [dbo].[Customer] SET FirstName=@f,LastName=@l, UserName=@u,Password=@p,Email=@e WHERE UserName=@u;";
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.AddWithValue("@f",fname );
            command.Parameters.AddWithValue("@l", lname);
              command.Parameters.AddWithValue("@u", username);
            command.Parameters.AddWithValue("@p", password);
            command.Parameters.AddWithValue("@e", email);

            query1.Open();
            int results = command.ExecuteNonQuery();
             query1.Close();
            if (results == 1)
            {
                Customer m = new Customer
                {
                    CustomerID = 100,
                    fname = fname,
                    lname = lname,
                    username = username,
                    password = password,
                    email = email
                };
                return m;
            }
            return null;

        };
    }   
}

    
    
   

