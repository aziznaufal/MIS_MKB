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
    public class Contact_Person
    {
        public string S_Id { get; set; }
        public string A_Id { get; set; }
        private DBConnection _state;

        public Contact_Person(string a_id = null, string s_id = null)
        {
            S_Id = s_id;
            A_Id = a_id;
            _state = new DBConnection();
        }

        public DataTable RetrievingData() //all
        {
            var data = new DataTable();
            var query = "SELECT a_id, s_id " +
                        "FROM Contact_Person";
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
                Console.WriteLine("ERROR : Contact_Person.RetrivingData" + er.StackTrace);
                return null;
            }
        }

        public string[] RetrivingRecord(string key, string value) //all
        {
            var data = new string[1];
            var query = "SELECT a_id, s_id " +
                        "FROM Contact_Person WHERE " + key + " = '" + value + "'";

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
                Console.WriteLine("ERROR : Contact_Person.RetrivingRecord" + er.StackTrace);

            }
            return data;
        }

        /*public bool Update()
        {
            _state.open();
            var query = "UPDATE  Contact_Person set a_id = '"+ A_Id +"', s_id = '"+ S_Id +"' WHERE Code = '" + Code + "'";
            var command = new NpgsqlCommand(query, _state.Connect);
            command.ExecuteNonQuery();
            return true;
        }*/

        //delete
        public bool Remove()
        {
            try
            {
                _state.open();
                var query = "DELETE FROM Contact_Person WHERE a_id = '" + A_Id + "'";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception er)
            {
                Console.WriteLine("error - CP: " + er.Message);
            }
            return false;
        }

        public bool AttachData()
        {
            try
            {
                _state.open();
                var query = "INSERT INTO Contact_Person values('" + A_Id + "', '" + S_Id + "')";
                var command = new NpgsqlCommand(query, _state.Connect);
                command.ExecuteNonQuery();
                _state.close();
                return true;
            }
            catch (Exception er)
            {
                Console.WriteLine("error: " + er.Message);
            }

            return false;
        }

        public string getCode()
        {
            string code="";
            try
            {
                
                _state.open();
                var query = "SELECT s_id FROM Contact_Person WHERE a_id = '" + A_Id + "' ORDER BY s_id DESC LIMIT 1";
                var command = new NpgsqlCommand(query, _state.Connect);
                var result = command.ExecuteReader(); //untuk mengekse yang berbentuk query, seperti select
                code = result.GetString(0);
                result.Close();
                _state.close();
                return code;
            }
            catch(Exception er)
            {
                Console.WriteLine("Eror - CP getCode : " +er.StackTrace+ " CODE= "+ code);
            }
            return null;
        }
    }
}
