using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using KmbMember.Config;
using System.Threading.Tasks;
namespace KmbMember.DataAccess
{
    public class Perguruan_Tinggi
    {
        public string Id { get; set; }
        public string Nama { get; set; }
        public string Fakultas { get; set; }
        public string Jurusan { get; set; }
        private DBConnection _state;
        public Perguruan_Tinggi(string id = null, string nama = null, string fakultas = null, string jurusan = null)
        {
            Id = id;
            Fakultas = fakultas;
            Nama = nama;
            Jurusan = jurusan;
            _state = new DBConnection();
        }

        public DataTable RetrievingData() //all
        {
            var data = new DataTable();
            var query = "SELECT * FROM Perguruan_Tinggi ORDER BY id";
            try
            {
                _state.open();
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                if (result.HasRows) data.Load(result);
                result.Close();
                _state.close();

                return data;
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Perguruan_Tinggi.RetrivingData" + er.StackTrace);
                return null;
            }
        }

        public string[] RetrivingRecord(string key, string value) //all
        {
            var data = new string[1];
            var query = "SELECT * FROM Perguruan_Tinggi WHERE " + key + " = '" + value + "'";
            try
            {
                _state.open();
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                if (result.HasRows)
                {
                    data = new string[result.FieldCount];
                    result.Read();
                    for (var i = 0; i < result.FieldCount; i++)
                    {
                        data[1] = result.GetValue(1).ToString();
                    }
                }
                result.Close();
                _state.close();

                return data;
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Perguruan_Tinggi.RetrivingRecord" + er.StackTrace);

            }
            return data;
        }
        public Dictionary<string, string> FillComboRecord() //ngisi combobox
        {
            var list = new Dictionary<string, string>();
            var query = "SELECT id, nama FROM Perguruan_Tinggi ORDER BY nama ASC";
            try
            {
                _state.open();
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                if (result.HasRows)
                {
                    list["0"] = "<Pilih Satu>";
                    while (result.Read())
                    {
                            list[result.GetValue(1).ToString()] = result.GetString(1);
                    }
                }
                result.Close();
                _state.close();

            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Perguruan_Tinggi.Dictionary<string, string> FillComboRecord" + er.StackTrace);

            }
            return list;
        }
        public Dictionary<string, string> FillFacultyComboRecord() //ngisi combobox Fakultas
        {
            var list = new Dictionary<string, string>();
            var query = "SELECT id, fakultas FROM Perguruan_Tinggi WHERE nama = '" + Nama + "' ORDER BY nama ASC";
            _state.open();
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            if (result.HasRows)
            {
                list["0"] = "<Pilih Satu>";
                while (result.Read())
                {
                    list[result.GetValue(1).ToString()] = result.GetString(1);
                }
            }
            result.Close();
            _state.close();
            return list;
        }
        public Dictionary<string, string> FillMajorComboRecord() //ngisi combobox jurusan
        {
            var list = new Dictionary<string, string>();
            var query = "SELECT id, jurusan FROM Perguruan_Tinggi WHERE nama = '" + Nama + "' AND fakultas = '"+ Fakultas +"' ORDER BY nama ASC";
            try
            {
                _state.open();
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                if (result.HasRows)
                {
                    list["0"] = "<Pilih Satu>";
                    while (result.Read())
                    {
                        list[result.GetValue(0).ToString()] = result.GetString(1);
                    }
                }
                result.Close();
                _state.close();

            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Perguruan_Tinggi.Dictionary<string, string> FillComboRecord" + er.StackTrace);

            }
            return list;
        }
        //update
        public bool AttachData()
        {
            try
            {
                _state.open();
                var query = "INSERT INTO Perguruan_Tinggi values('" + Id + "', '" + Nama + "', '" + Fakultas + "', '" + Jurusan + "')";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
                _state.close();
                return true;
            }
            catch(Exception er)
            {
                Console.WriteLine("error: " + er.Message);
            }
            
            return false;
        }

        public bool Update()
        {
            _state.open();
            var query = "UPDATE Perguruan_Tinggi set nama = '" + Nama + "', fakultas = '" + Fakultas + "', jurusan = '" + Jurusan + "' WHERE id = '" + Id + "'";
            Console.WriteLine(query);
            var command = new NpgsqlCommand(query, _state.Connect);
            command.ExecuteNonQuery();
            _state.close();
            return true;
        }

        //delete
        public bool Remove()
        {
            _state.open();
            var query = "DELETE FROM Perguruan_Tinggi WHERE id = '" + Id + "'";
            var command = new NpgsqlCommand(query, _state.Connect);
            command.ExecuteNonQuery();
            _state.close();
            return true;
        }

        public string GenerateCode()
        {
            _state.open();
            var list = "";
            var query = "SELECT id FROM perguruan_tinggi ORDER BY id DESC LIMIT 1";
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader();
            
                 //untuk mengekse yang berbentuk query, seperti select

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var n = Convert.ToInt32(result.GetString(0).ToString().Substring(1,4)) + 1;
                        list = n.ToString().PadLeft(4, '0');
                }

                }
                else
                {
                    list = "0001";
                }
                result.Close();
                _state.close();
                
            return "P"+list;
        }

        public string GetCode()
        {
            string code="";
            try
            {
                _state.open();
                var query = "SELECT id FROM Perguruan_Tinggi WHERE nama = '" + Nama + "' AND fakultas = '" + Fakultas + "' AND jurusan = '" + Jurusan + "'";
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                code = result.GetString(0);
                result.Close();
                _state.close();
                return code;
            }
            catch (Exception er)
            {
                Console.WriteLine("Error PT.GetData: " + er.Message);

            }
            return "P0001";
        }
    }
}
