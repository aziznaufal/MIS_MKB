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
    public class Sosial_Media
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Instagram { get; set; }
        public string Line { get; set; }
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        private DBConnection _state;
        public Sosial_Media(string id = null, string phone = null, string instagram = null, string line = null, string whatsapp = null, string facebook = null, string twitter = null)
        {
            Id = id;
            Phone = phone;
            Instagram = instagram;
            Line = line;
            WhatsApp = whatsapp;
            Facebook = facebook;
            Twitter = twitter;
            _state = new DBConnection();
        }

        public bool AttachData()
        {
            try
            {
                _state.open();
                var query = "INSERT INTO sosial_media values('" + Id + "', '" + Phone + "', '" + Instagram + "', '" + Facebook + "', '" + Twitter + "', '" + Line + "', '" + WhatsApp + "')";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
                _state.close();

                return true;
            }
            catch (Exception er)
            {
                Console.WriteLine("Error Sosmed.AttachData: " + er.Message);
            }
            
            return false;
        }

        public bool Update()
        {
            try
            {
                _state.open();
                var query = "UPDATE sosial_media set phone = '" + Phone + "', insta = '" + Instagram + "', line = '" + Line + "', whatsapp = '" + WhatsApp + "', facebook = '" + Facebook + "', twitter = '" + Twitter + "' WHERE id = '" + Id + "'";
                Console.WriteLine(query);
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
                _state.close();
                return true;

            }
            catch (Exception er)
            {
                Console.WriteLine("error - SosMed: " + er.Message);
            }
            return false;
        }

        //delete
        public bool Remove()
        {
            _state.open();
            var query = "DELETE FROM sosial_media WHERE id = '" + Id + "'";
            var command = new NpgsqlCommand(query, _state.Connect);
            command.ExecuteNonQuery();
            _state.close();
            return true;
        }

        public string GenerateCode() //overload
        {
            _state.open();
            var query = "SELECT id FROM sosial_media ORDER BY id DESC LIMIT 1";
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            var list = "";
            if (result.HasRows)
            {
                while (result.Read())
                {
                    var n = Convert.ToInt32(result.GetString(0).ToString().Substring(1, 4)) + 1;
                    list = n.ToString().PadLeft(4, '0');
                }

            }
            else
            {
                list = "0001";
            }
            result.Close();
            _state.close();
            return "S"+list;

        }

        public string GetCode()
        {
            _state.open();
            var query = "SELECT id FROM Sosial_Media ORDER BY id DESC LIMIT 1";
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
            var code = result.GetString(0);
            result.Close();
            _state.close();
            return code;
        }
    }
}
