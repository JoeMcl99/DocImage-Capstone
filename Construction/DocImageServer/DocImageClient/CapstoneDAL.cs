using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocImageClient
{
    class CapstoneDAL
    {

        private void openConnection()
        {
            SqlConnection objConnect = new SqlConnection(/*ConnectionString*/);
            objConnect.Open();
        }
    }      
    


}
