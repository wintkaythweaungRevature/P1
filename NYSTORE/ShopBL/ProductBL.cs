using ShopDL;
using ShopModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopBL
{
    public class ProductBL
    {
         private ProductRepo _repo { get; set; }
       
    public ProductBL(ProductRepo r)
    {
        this._repo = r;
    }

    public List<Product> ProductList()
    {
        List<Product> ml = _repo.ProductList();
        return ml;
    }
   
    
    public Product NewProduct(string ProductBrand, string Category, string UnitPrice, string Quantity,string Location)
    {
        //pass the new data to the repo layer to insert int to the db.
        Product m = _repo.NewProduct(ProductBrand, Category, UnitPrice, Quantity,Location);
        return m;
    }
  public Product ProductUpdate(string ProductBrand, string Category, string UnitPrice, string Quantity,string location)
    {
        //pass the new data to the repo layer to insert int to the db.
        Product m = _repo.UpdateByProduct(ProductBrand, Category, UnitPrice, Quantity ,location);
        return m;
    }
    public Product P_QuantityUpdate( string Quantity,string ProductBrand)
    {
        //pass the new data to the repo layer to insert int to the db.
        Product m = _repo.UpdateByProductQuantity(Quantity,ProductBrand );
        return m;
    }
    
    
    



        
    }
}