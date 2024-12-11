using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem_Proj
{
    public static class DatabaseConfig
    {
        // Global connection string
        public static string ConnectionString { get; set; } = "Server=STEPH-LAPTOP\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        //public static string ConnectionString { get; set; } = "Server=JEIN\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        //public static string ConnectionString { get; set; } = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
    }
}
