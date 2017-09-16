using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace KmbMember.Config
{
    public class DBConnection
    {
        private NpgsqlConnection _connect;
        private string _dbname;
        public NpgsqlConnection Connect
        {
            get
            {
                return _connect ?? new NpgsqlConnection();
            }
        }
        public DBConnection()
        {
            _dbname = "kmb_anggota_db";

        }
        public void open()
        {

            var strconnect = String.Format("Server = localhost; Port = 5432; User Id = postgres; Password = admin12345; DataBase = '" + _dbname + "'");
            _connect = new NpgsqlConnection(strconnect);
            _connect.Open();

        }
        public void close()
        {
            _connect.Close();
        }
    }
}
