using ShopDL;
using ShopModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ShopBL
{
    public class OrderBL
    {
           private OrderRepo _repo { get; set; }
       
    public OrderBL(OrderRepo r)
    {
        this._repo = r;
    }

    public List<Order> OrderList()
    {
        List<Order> ml = _repo.OrderList();
        return ml;
    }
    
     public Order NewOrder(string ProductID,string CustomerID,string UnitPrice,string Quantity,string location)
    {
        //pass the new data to the repo layer to insert int to the db.
        Order m = _repo.NewOrder(ProductID,CustomerID,UnitPrice,Quantity,location);
        return m;
    }
    // public Order SlectByProductID(string ProductID,string CustomerID,string UnitPrice,string Quantity,string location)
    // {
    //     //pass the new data to the repo layer to insert int to the db.
    //     Order m = _repo.SelectByProductID(ProductID,CustomerID,UnitPrice,Quantity,location);
    //     return m;
    // }
   
    }
    
}