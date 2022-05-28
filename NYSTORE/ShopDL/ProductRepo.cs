using ShopModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace ShopDL
{
    public class ProductRepo
    {
        public ProductMapper _mapper { get; set; }

    string connectionString=$"Server=tcp:electronicstoreserver.database.windows.net,1433;Initial Catalog=electronicstoreDb;Persist Security Info=False;User ID=electronicstoreDb;Password=100%Wintisperfect;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    // public List<Product> NewProduct()
    // {
    //     throw new NotImplementedException();
    // }

    public ProductRepo()
    {
        // this._repo = r;
        this._mapper = new ProductMapper();
    }

    public Product NewProduct(string ProductBrand,string Catgory,string UnitPrice,string Quantity,string Location)
    {
         string myQuery1 = $"INSERT INTO Product (Brand, Category, UnitPrice, Quantity,Location) VALUES (@n, @v, @p, @Q,@L);";
        
        //this using block creates teh SqlConnection.
        // the SqlConnection is the object that communicates with the Db.
        using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.AddWithValue("@n", ProductBrand);
            command.Parameters.AddWithValue("@v", Catgory);
            command.Parameters.AddWithValue("@p", UnitPrice);
            command.Parameters.AddWithValue("@Q", Quantity);
            command.Parameters.AddWithValue("@L", Location);
            query1.Open();//open the connection to the Db
            int results = command.ExecuteNonQuery();//actually conduct the query.
            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.

            // I usually requery the Db to get the data fresh and triple verify that the data was inputted correctly

            if (results == 1)
            {
                Product p = new Product
                {
                    ProductID = 100,
                    ProductBrand = ProductBrand,
                    Catgory=Catgory,
                    UnitPrice=Int32.Parse(UnitPrice),
                    Quantity=Int32.Parse(Quantity)
             
                                
                    
                };
                return p;
            }
            return null;

        };
    }
    
      
    
     public Product UpdateByProduct(string ProductBrand,string Catgory,string UnitPrice,string Quantity,string location)
    {
       
        
         string myQuery1 = $"Update  Product SET Brand=@n, Category=@v, UnitPrice=@p, Quantity=@Q ,Location=@L where Brand=@n and Category=@v;";
         //string myQuery1=$"Insert into Order ((ProductID,CustomerID,UnitPrice,Quantity,Location)Values(Select Product.ProductID ,Customer.CustomerID, Product.UnitPrice,Product.Quantity,Product.Location from Customer cross join Product) ;";
      
         using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.Parameters.AddWithValue("@n", ProductBrand);
            command.Parameters.AddWithValue("@v", Catgory);
              command.Parameters.AddWithValue("@p", UnitPrice);
            command.Parameters.AddWithValue("@Q", Quantity);
              command.Parameters.AddWithValue("@L", location);
            
            

            query1.Open();//open the connection to the Db
            int results = command.ExecuteNonQuery();//actually conduct the query.
            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.

            // I usually requery the Db to get the data fresh and triple verify that the data was inputted correctly

            if (results == 1)
            {
                Product p = new Product
                {
                    ProductID = 100,
                    ProductBrand = ProductBrand,
                    Catgory=Catgory,
                    UnitPrice=Int32.Parse(UnitPrice),
                    Quantity=Int32.Parse(Quantity)
             
                                
                    
                };
                return p;
            }
            return null;

        };
    }
     public Product UpdateByProductQuantity(string Quantity,string ProductBrand)
    {
       
        
         string myQuery1 = $"Update  Product SET  Quantity=(@Q-Quantity)  WHERE Brand=@b;";
         //string myQuery1=$"Insert into Order ((ProductID,CustomerID,UnitPrice,Quantity,Location)Values(Select Product.ProductID ,Customer.CustomerID, Product.UnitPrice,Product.Quantity,Product.Location from Customer cross join Product) ;";
      
         using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
          
            command.Parameters.AddWithValue("@Q", Quantity);
               command.Parameters.AddWithValue("@b", Quantity);
             
            
            

            query1.Open();//open the connection to the Db
            int results = command.ExecuteNonQuery();//actually conduct the query.
            query1.Close();//YOU MUST CLOSE THE CONNECTION FOR ANY OTHER METHOD TO ACCESS THE DB.

            // I usually requery the Db to get the data fresh and triple verify that the data was inputted correctly

            if (results == 1)
            {
                Product p = new Product
                {
                    ProductID = 100,
                    
                 
                                
                    
                };
                return p;
            }
            return null;

        };
    }
    
    
    
     public IDataReader SelectByProductID(string ProductID,string CustomerID,string UnitPrice,string Quantity,string location)
     {
          string myQuery1 = $"Insert into Product (@p,@cid,@price,@qty,@lo) s  where ProductID=@p ;";
         using (SqlConnection query1 = new SqlConnection(connectionString))
        {
            //The SqlCommand object uses the query text along with the SqlConnection object to open a connection and send the query.
            SqlCommand command = new SqlCommand(myQuery1, query1);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@p",SqlDbType.Char).Value=ProductID;
            command.Parameters.Add("@cid",SqlDbType.Char).Value=CustomerID;
            command.Parameters.Add("@price",SqlDbType.Char).Value=UnitPrice;
            command.Parameters.Add("@qty",SqlDbType.Char).Value=Quantity;
            command.Parameters.Add("@lo",SqlDbType.Char).Value=location;
            return command.ExecuteReader(CommandBehavior.CloseConnection);
    };
              
     }

    public List<Product> ProductList()
    {
        string myQuery1 = "SELECT * FROM Product;";
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
            List<Product> ml = new List<Product>();
            while (results.Read())
            {
                //mapp the current table row to a Member class objects
                Product m = this._mapper.DboToProduct(results);
                ml.Add(m);//send in the row of the reader to be mapped.
            }

            query1.Close();
            return ml;
        }
    }
   
    public List<Product> selectbyid()
    {
        string myQuery1 = "SELECT * FROM Product where ProductID= '{ProductID}';";
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
            List<Product> ml = new List<Product>();
            while (results.Read())
            {
                //mapp the current table row to a Member class objects
                Product m = this._mapper.DboToProduct(results);
                ml.Add(m);//send in the row of the reader to be mapped.
            }

            query1.Close();
            return ml;
        }
    }
    }
}