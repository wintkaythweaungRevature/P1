using System;
using System.Data;
using System.Data.SqlClient;
using ShopDL;
using System.Collections.Generic;
using ShopBL;
using ShopModel;

namespace UI
{
    class Program
    {
      static void Main(string[] args)
      {  
            bool moveOn = false;// this is to signify that the user correctly entered the value.
             
            
        while (moveOn==false)
        {  
            CustomerRepo customerRepo = new CustomerRepo();
            CustomerBL customerBL = new CustomerBL(customerRepo);
            Customer newCustomer = new Customer();
            OldCustomerRepo oldCustomerRepo=new OldCustomerRepo();
            OldCustomerBL oldCustomerBL=new OldCustomerBL(oldCustomerRepo);
            OldCustomer oldCustomer=new OldCustomer();
            ProductRepo productRepo=new ProductRepo();
            ProductBL productBL=new ProductBL(productRepo);           
            Product newProduct=new Product();
            OrderRepo orderRepo=new OrderRepo();
            OrderBL orderBL=new OrderBL(orderRepo);
            Order order =new Order();

            Console.WriteLine("================================================");
            Console.WriteLine("          Welcome to New York Store! ");
            Console.WriteLine("================================================");
            Console.WriteLine("Please select from the list of options below:\n");
            Console.WriteLine("=============== Customer Menu ===================\n");
            Console.WriteLine("[1] - Enroll a new customer");
            Console.WriteLine("[2] - Place an order \n");
            Console.WriteLine("================ Admin Menu  ====================\n");
            Console.WriteLine("[3] - Update the inventory");
            Console.WriteLine("[4] - Add the new prouduct");
            Console.WriteLine("[5] - View Order List \n");
            Console.WriteLine("=============== Other Options  =================\n");
            Console.WriteLine("[6] - View a store's inventory");
            Console.WriteLine("[7] - View a sales");
            Console.WriteLine("[8] - Exit\n");
            string registerOrLogin = Console.ReadLine();
            
            
            switch (registerOrLogin)
            {
                case "1":// register member
                Console.WriteLine("Please enter your first name");
                string fname = Console.ReadLine();
                Console.WriteLine("Please enter your last name");
                string lname = Console.ReadLine();
                Console.WriteLine("Please enter your username");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string password = Console.ReadLine();
                Console.WriteLine("Please enter your email name");
                string email = Console.ReadLine();
                newCustomer = customerBL.NewCustomer(fname, lname, username,password, email);
                Console.WriteLine ("Successfull Saved!!!!");
                Console.WriteLine($" {newCustomer.fname} {newCustomer.lname} .From now!  You are one of our regular customer list .");
                moveOn = true;
                break;
                case "2": // place order
                Console.WriteLine("Please enter your username");
                string  oldusername= Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string oldpassword = Console.ReadLine();
                oldCustomer=oldCustomerBL.CustomerLogin(oldusername,oldpassword);
                Console.WriteLine("================================================");
                Console.WriteLine("==================  WELCOME MEMBER  ============\n");
                Console.WriteLine("Please select from the list of options below:\n");
                Console.WriteLine("[1] - Place an order");
                Console.WriteLine("[2] - Update your info");
                Console.WriteLine("================================================\n");
                string updateORorder=Console.ReadLine();
                   switch(updateORorder)
                   {
                     case "1":
                          Console.WriteLine("Please select from list of store below:\n");
                          List <Product> product = productBL.ProductList();
                          foreach (Product m in product)
                          {
                            Console.WriteLine("================================================\n");
                             IMenu me= new IMenu();
                            me.Placeorder();

                          //  newProduct=productBL.UpdatebyP_Quantity(ProductBrand,Category,UnitPrice,Quantity,location);
                          }

                     break;//case1 break;
                     case "2":
                     IMenu menu=new IMenu();
                     menu.Display();
                     break;
                    }
                  
                moveOn=true;
                break;  
                case "3":// update invertory
                Console.WriteLine("Please enter your product brand ");
                string opb = Console.ReadLine();
                Console.WriteLine("Please enter your category");
                string opv = Console.ReadLine();
                Console.WriteLine("Please enter your price ");
                string oup = Console.ReadLine();
                Console.WriteLine("Please enter your Quantity");
                string oQty = Console.ReadLine();
                Console.WriteLine("Please enter your location");
                string oLocation = Console.ReadLine();

                newProduct=productBL.ProductUpdate(opb,opv,oup,oQty,oLocation);
                Console.WriteLine ("Successfully Saved!!!");
                Console.WriteLine($" You added  {newProduct.Quantity} pieces of {newProduct.ProductBrand}  {newProduct.Catgory}");
                moveOn = true;                       
                break;
                case "4": // add new product
                Console.WriteLine("Please enter your product brand ");
                string pb = Console.ReadLine();
                Console.WriteLine("Please enter your product version");
                string pv = Console.ReadLine();
                Console.WriteLine("Please enter your price ");
                string up = Console.ReadLine();
                Console.WriteLine("Please enter your Quantity");
                string Qty = Console.ReadLine();
                Console.WriteLine("Please enter your location");
                string Location = Console.ReadLine();
                moveOn = true;
                newProduct=productBL.NewProduct(pb,pv,up,Qty,Location);
                Console.WriteLine ("Successfully Saved!!!");
                Console.WriteLine($" You add {newProduct.Quantity} pieces of {newProduct.ProductBrand}  {newProduct.Catgory}");
                moveOn=true;
                break;
                case "5":
                List <Order> orders = orderBL.OrderList();
                moveOn =true;
                break;
                case "6":
                List <Product> products = productBL.ProductList();
                moveOn=true;
                break;
                case "7":
                break;
                default:
                Console.WriteLine("That wasn't a valid choice. Please try again.");
                moveOn=false;
                break;
            }
            moveOn=false;

          }//loop
        moveOn=true;
           
        }//main method
       // Program p=new Program();
      }//class
            
  }//namespace

           