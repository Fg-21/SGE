using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DB
{
    public class Connection
    {
        public static string getConnectionString()
        {
            return "server=fran.database.windows.net;database=PersonasDB;uid=fran;pwd=@abcd1234;trustServerCertificate=true;";
        }
    }
}
