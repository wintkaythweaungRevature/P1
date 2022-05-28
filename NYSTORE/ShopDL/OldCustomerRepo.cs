using ShopModel;
using System.Data.SqlClient;
using System.Data;


namespace ShopDL;

    public class OldCustomerRepo
    {
         public OldCustomerMapper _mapper { get; set; }
    
    string connectionString=$"Server=tcp:electronicstoreserver.database.windows.net,1433;Initial Catalog=electronicstoreDb;Persist Security Info=False;User ID=electronicstoreDb;Password=100%Wintisperfect;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
  
public OldCustomerRepo()
    {
        // this._repo = r;
        this._mapper = new OldCustomerMapper();
    }
    

    public OldCustomer CustomerLogin(string oldusername,string oldpassword)
   {

      string myQuery1 = $"UPDATE [dbo].[Customer] SET  UserName=@u,Password=@p WHERE UserName=@u;";
        //this using block creates teh SqlConnection.
        // the SqlConnection is the object that communicates with the Db.
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {

            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.Add("@u", SqlDbType.VarChar).Value = oldusername;
           command.Parameters.Add("@p", SqlDbType.VarChar).Value = oldpassword;   
           query1.Open();
            int results = command.ExecuteNonQuery();//actually conduct the query.
            query1.Close();
          
            if (results == 1)
            {
                OldCustomer old = new OldCustomer
                {
                             
                    oldpassword = oldusername,
                    oldusername = oldpassword                                  
                    
                };
                return old;
            }
            return null;

        };
   }
    public List<OldCustomer> OldCustomersList()
    {
        string myQuery1 = "SELECT * FROM Customer;";
         using (SqlConnection query1 = new SqlConnection(connectionString))
        {
           SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Connection.Open();//open the connection to the Db
            SqlDataReader results = command.ExecuteReader();//actually conduct the query.

             List<OldCustomer> ml = new List<OldCustomer>();
            while (results.Read())
            {
                OldCustomer m = this._mapper.DboToOldCustomer(results);
                ml.Add(m);
            }

            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.
            return ml;
         } 
    }

    
    }