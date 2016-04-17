using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATG_SE_Project2016.MODEL;

namespace ATG_SE_Project2016.CONTROLLER
{
    class CreateConnection
    {
        private DbConnection conn = new DbConnection();
        public bool OpenConnection()
        {
            return conn.OpenConnection();
        }
        public void CloseConnection()
        {
            conn.CloseConnection();
        }
    }
}
