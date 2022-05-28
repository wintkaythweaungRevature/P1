using ShopDL;
using ShopModel;
using System.Collections;
namespace ShopBL;

public class CustomerBL 
{
  private CustomerRepo _repo { get; set; }
       
    public CustomerBL(CustomerRepo r)
    {
        this._repo = r;
    }
  public List<Customer> CustomerList()
    {
        List<Customer> ml = _repo.CustomerList();
        return ml;
    }
 
    public Customer NewCustomer(string fname, string lname, string username, string password,string email)
    {
        //pass the new data to the repo layer to insert int to the db.
        Customer m = _repo.NewCustomer(fname, lname, username, password,email);
        return m;
    }
    public Customer UpdateCustomerByID(string fname, string lname, string username, string password,string email)
    {
        //pass the new data to the repo layer to insert int to the db.
        Customer m = _repo.UpdateByCustomerID(fname, lname, username, password,email);
        return m;
    }
   
   
    

        


}
