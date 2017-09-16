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
    public class Anggota_KMB
    {
        public string Id { get; set; }
        public string NIA { get; set; }
        public string Nama { get; set; }
        public string Gender { get; set; }
        public string TempatLahir { get; set; }
        public string TanggalLahir { get; set; }
        public string AlamatAsli { get; set; }
        public string AlamatKos { get; set; }
        public Perguruan_Tinggi PT_Id { get; set; }
        private DBConnection _state;

        public Anggota_KMB(string id = null, string nia = null, string nama = null, string gender = null, string tempatlahir = null, string tanggallahir = null, string alamatasli = null, string alamatkos = null, string pt_id = null)
        {
            PT_Id = new Perguruan_Tinggi();
            Id = id;
            NIA = nia;
            Nama = nama;
            Gender = gender;
            TempatLahir = tempatlahir;
            TanggalLahir = tanggallahir;
            AlamatAsli = alamatasli;
            AlamatKos = alamatkos;
            PT_Id.Id = pt_id;   
            _state = new DBConnection();
        }

        public DataTable RetrievingData() //all
        {
            var data = new DataTable();
            var query = "SELECT a.id AS ID_Anggota, a.NIA AS Nomor_Induk_Anggota, a.nama AS Name, a.gender AS Gender, a.tempat_lahir AS Tempat_Lahir, a.tanggal_lahir AS Tanggal_Lahir, a.alamat_asli AS Alamat_Asli, a.alamat_kos AS Alamat_Kos, " +
                        "a.pt_id AS CollegeID, b.nama AS Perguruan_Tinggi, b.fakultas AS Fakultas, b.jurusan AS Jurusan, " +
                        "c.s_id AS ContactID, d.phone AS Phone_Number, d.whatsapp AS WA, d.line AS Line, d.insta AS Instagram, d.facebook AS Facebook, d.twitter AS Twitter " +
                        "FROM Anggota_KMB a JOIN Perguruan_Tinggi b " +
                        "ON a.pt_id = b.id JOIN Contact_Person c " +
                        "ON a.id = c.a_id JOIN Sosial_Media d " +
                        "ON c.s_id = d.id " +
                        "ORDER BY a.NIA";
            _state.open();
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            if (result.HasRows)
                data.Load(result);
            result.Close();
            _state.close();

            return data;
        }

        public DataTable SearchData(string search)
        {
            var data = new DataTable();

            return data;
        }
        public string[] RetrivingRecord(string key, string value) //all
        {
            var data = new string[1];
            var query = "SELECT a.id AS ID_Anggota, a.NIA AS Nomor_Induk_Anggota, a.nama AS Name, a.gender AS Gender, a.tempat_lahir AS Tempat_Lahir, a.tanggal_lahir AS Tanggal_Lahir, a.alamat_asli AS Alamat_Asli, a.alamat_kos AS Alamat_Kos, " +
                        "a.pt_id AS CollegeID, b.nama AS Perguruan_Tinggi, b.fakultas AS Fakultas, b.jurusan AS Jurusan, " +
                        "c.s_id AS ContactID, d.phone AS Phone_Number, d.whatsapp AS WA, d.line AS Line, d.insta AS Instagram, d.facebook AS Facebook, d.twitter AS Twitter " +
                        "FROM Anggota_KMB a JOIN Perguruan_Tinggi b " +
                        "ON a.pt_id = b.id JOIN Contact_Person c " +
                        "ON a.id = c.a_id JOIN Sosial_Media d " +
                        "ON c.s_id = d.id " +
                        "WHERE " + key + " = '" + value + "'";

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
                        data[i] = result.GetValue(i).ToString();
                        Console.WriteLine(data);
                    }
                }
                result.Close();
                _state.close();

                return data;
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Anggota_KMB.RetrivingRecord" + er.StackTrace);

            }
            return data;
        }

        //update
        public bool AttachData()
        {
            try
            {
                _state.open();
                var query = "INSERT INTO Anggota_KMB values('" + Id + "','" + NIA + "', '" + Nama + "', '" + Gender + "', '" + TempatLahir + "', '" + TanggalLahir + "', '" + AlamatAsli + "', '" + AlamatKos + "', '" + PT_Id.Id + "')";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
            }
            catch(Exception er)
            {
                Console.WriteLine("Error: "+er.Message);
            }
            
            return true;
        }
        public bool Update()
        {
            _state.open();
            var query = "UPDATE  Anggota_KMB set nama = '" + Nama + "', gender = '" + Gender + "', tempat_lahir = '" + TempatLahir + "', tanggal_lahir = '" + TanggalLahir + "', alamat_asli = '" + AlamatAsli + "', alamat_kos = '" + AlamatKos + "', pt_id = '" + PT_Id.Id + "' WHERE id = '" + Id + "'";
            var command = new NpgsqlCommand(query, _state.Connect);
            command.ExecuteNonQuery();
            return true;
        }

        //delete
        public bool Remove()
        {
            try
            {
                _state.open();
                var query = "DELETE FROM Anggota_KMB WHERE id = '" + Id + "'";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
            } catch (Exception er)
            {
                Console.WriteLine("Error Delete: " + er.StackTrace);
             }

            return true;
        }
        public string GenerateCode()
        {
            _state.open();
            string list = "";
            try
            {
                var query = "SELECT id FROM Anggota_KMB ORDER BY id DESC LIMIT 1";
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                list = "";
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
            }
            catch (Exception er)
            {
                Console.WriteLine("Error -- Anggota_KMB.GenerateCode:" + er.Message);
            }

            var id = "A" +list;
            return id;
        }

        public string GenerateNIA(string Year)
        {
            _state.open();
            var year = "KMB."+Year;
            var query = "SELECT NIA FROM Anggota_KMB WHERE NIA like '"+ year + "%' ORDER BY id DESC LIMIT 1";
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            var list = "";
            if (result.HasRows)
            {
                while (result.Read())
                {
                    var n = Convert.ToInt32(result.GetString(0).Substring(7,4)) + 1;
                    list = n.ToString().PadLeft(4, '0');
                }

            }
            else
            {
                list = "0001";
            }            
            result.Close();
            _state.close();
            return list;
        }

        public string GetCode()
        {
            _state.open();
            var query = "SELECT id FROM Anggota_KMB ORDER BY id DESC LIMIT 1";
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            var code = result.GetString(0);
            result.Close();
            _state.close();
            return code;
        }
    }
}
