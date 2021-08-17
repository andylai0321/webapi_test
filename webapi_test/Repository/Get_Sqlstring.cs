using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webapi_test.Repository
{
    public class Get_Sqlstring
    {
        public string returnsqlstring(string tablename, Dictionary<string, string> modellist)
        {
            int itemcount = 0;
            string sqltxt = "";

            //先計算傳入的參數中那些值不是空白的數量，以做sql語法中是否要加and的條件
            foreach (KeyValuePair<string, string> item in modellist)
            {
                if (item.Value != "")
                {
                    itemcount++;
                }
            }

            if (modellist.Count <= 0)
            {
                sqltxt = "select * from " + tablename;
            }
            else
            {
                int pindex = 0;//item index for value != 0

                sqltxt = @"select * from " + tablename + " where ";
                foreach (KeyValuePair<string, string> item in modellist)
                {
                    if (item.Value != "")
                    {
                        pindex++;

                        if (pindex == itemcount)
                        {
                            //判斷傳入值是否為數字 + 字串不加and
                            sqltxt += string.Format("{0} =" + ((Regex.IsMatch(item.Value, @"^[0-9]+$")) ? "{1} " : "'{1}' "), item.Key, item.Value);
                        }
                        else
                        {
                            //判斷傳入值是否為數字 + 字串加and
                            sqltxt += string.Format("{0} =" + ((Regex.IsMatch(item.Value, @"^[0-9]+$")) ? "{1} and " : "'{1}' and "), item.Key, item.Value);
                        }
                    }
                }
            }

            return sqltxt;
        }

        public string returnupdatesqlstring(string tablename, Dictionary<string, string> modellist,string id)
        {
            int itemcount = 0;
            string sqltxt = "";

            //先計算傳入的參數中那些值不是空白的數量，以做sql語法中是否要加and的條件
            foreach (KeyValuePair<string, string> item in modellist)
            {
                if (item.Value != "")
                {
                    itemcount++;
                }
            }

            if (modellist.Count != 0)
            {
                int pindex = 0;//item index for value != 0
                string Strsid = "";

                sqltxt = @"update " + tablename + " set ";
                foreach (KeyValuePair<string, string> item in modellist)
                {
                    if (item.Value != "")
                    {
                        pindex++;
                        
                        if (item.Key == "sid")
                        {
                            Strsid = item.Value;
                        }
                        else
                        {
                            if (pindex == itemcount)
                            {
                                //判斷傳入值是否為數字 + 字串不加and
                                sqltxt += string.Format("{0} =" + ((Regex.IsMatch(item.Value, @"^[0-9]+$")) ? "{1} " : "'{1}' "), item.Key, item.Value);
                            }
                            else
                            {
                                //判斷傳入值是否為數字 + 字串加and
                                sqltxt += string.Format("{0} =" + ((Regex.IsMatch(item.Value, @"^[0-9]+$")) ? "{1} , " : "'{1}' , "), item.Key, item.Value);
                            }
                        }
                    }
                }

                sqltxt += " where sid= " + Strsid;
            }

            return sqltxt;
        }
    }
}
