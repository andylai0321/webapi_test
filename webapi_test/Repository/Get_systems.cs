using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace webapi_test.Repository
{
    public class Get_systems
    {
        dataconn da = new dataconn();
        Get_Sqlstring cs = new Get_Sqlstring();

        string sqltxt;
        DataSet ds;
        public Get_systems()
        {

        }

        public List<Models.systems> PList = new List<Models.systems>() ;

        //get method for parameters or no parameters
        public List<Models.systems> Get_SystemsList(string pid)
        {
            if(pid == "")
            {
                sqltxt = "select * from systems";
            }
            else
            {
                sqltxt = "select * from systems where sid = " + pid; 
            }

             ds = da.getdataset(sqltxt, "systems");
             return  PList = da.ConvertDataTable<Models.systems>(ds.Tables["systems"]);
        }

        //put method
        public List<Models.systems> Get_SystemsList(Dictionary<string,string> modeldic)
        {
            ds = da.getdataset(cs.returnsqlstring("systems", modeldic), "systems");
            return PList = da.ConvertDataTable<Models.systems>(ds.Tables["systems"]);
        }

        //delete method
        public System.Net.Http.HttpResponseMessage delete_systemlist(string pid)
        {
            var response = new System.Net.Http.HttpResponseMessage();

            if (pid == "")
            {
                response.Headers.Add("DeleteMessage", "NO PID");
                return response;
            }
            else
            {
                sqltxt = "delete from systems where sid =" + pid;
                if(da.sqlcommand(sqltxt) > 0)
                {
                    response.Headers.Add("DeleteMessage", "Succsessfuly Deleted");
                    return response;
                }
                else
                {
                    response.Headers.Add("DeleteMessage", "NO DATA");
                    return response;
                }
            }
        }

        //update method
        public System.Net.Http.HttpResponseMessage update_systemlist(string pid, Dictionary<string, string> modeldic)
        {
            var response = new System.Net.Http.HttpResponseMessage();

            if (pid == "")
            {
                response.Headers.Add("UpdateMessage", "NO PID");
                return response;
            }
            else
            {
                if (da.sqlcommand(cs.returnupdatesqlstring("systems", modeldic, pid)) > 0)
                {
                    response.Headers.Add("UpdateMessage", "Succsessfuly Updated");
                    return response;
                }
                else
                {
                    response.Headers.Add("UpdateMessage", "NO DATA");
                    return response;
                }
            }
        }
    }
}
