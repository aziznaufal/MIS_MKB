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
    public class Acount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private DBConnection _state;

        public Acount(int id = 0, string username = null, string password = null)
        {
            Id = id;
            Username = username;
            Password = password;
            _state = new DBConnection();
        }

        public bool checkAcount()
        {
            var check = true;
            var data = new DataTable();
            var query = "SElECT count (*) from Acount where username = '" + Username + "' and password = '" + Password + "'";
            _state.open();
            var command = new NpgsqlCommand(query, _state.Connect);
            var result = command.ExecuteScalar(); //untuk mengekse yang berbentuk query, seperti select
            Console.WriteLine("value : " +result.ToString());
            if (result.ToString() != "1")
            {
                check = false;
            }
            
            _state.close();
            return check;
        }
    }
}

/*
                SqlConnection koneksi = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\kuliah\semester\3\PEMROGRAMAN LANJUT\CODING & WIN FORM\Final Project\Gudang\gudang\Gudang\Gudang\Gudang.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter login = new SqlDataAdapter("SElECT count (*) from Account where username = '" + username.Text + "' and password = '" + password.Text + "'", koneksi);
                DataTable data = new DataTable();
                try
                {
                    login.Fill(data);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                if (data.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Data_Base_Editting.Option log_in = new Data_Base_Editting.Option();
                    log_in.Show();

                }
                else
                {
                    MessageBox.Show("Wrong Password or Username");
                }
     */
