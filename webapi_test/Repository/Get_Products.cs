using System.Collections.Generic;
using System.Data;

namespace webapi_test.Repository
{
    public class Get_Products
    {
        dataconn da = new dataconn();
        string sqltxt;
        DataSet ds;
        public Get_Products()
        {

        }

        public List<Models.Products> PList = new List<Models.Products>() ;
        public List<Models.Products> Get_ProductsList(string pid)
        {
            if(pid == "")
            {
                sqltxt = "select * from Products";
            }
            else
            {
                sqltxt = "select * from Products where ProductID = " + pid; 
            }

             ds = da.getdataset(sqltxt, "products");
             return  PList = da.ConvertDataTable<Models.Products>(ds.Tables["products"]);
        }
    }
}
