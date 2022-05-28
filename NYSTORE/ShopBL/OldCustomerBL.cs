using ShopModel;
using   ShopDL;
namespace ShopBL
{
    public class OldCustomerBL
    {
         private OldCustomerRepo _repo { get; set; }
       
    public OldCustomerBL(OldCustomerRepo r)
    {
        this._repo = r;
    }
 public List<OldCustomer> OldCustomerList()
    {
        List<OldCustomer> ml = _repo.OldCustomersList();
        return ml;
    }

          public OldCustomer CustomerLogin( string oldusername, string oldpassword)
    {
        //pass the new data to the repo layer to insert int to the db.
        OldCustomer m = _repo.CustomerLogin( oldusername, oldpassword);
        return m;
    }
    }
}