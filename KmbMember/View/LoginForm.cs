using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KmbMember.DataAccess;

namespace KmbMember
{
    public partial class loginfrm : Form
    {
        public loginfrm()
        {
            InitializeComponent();
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            txtPass.Text = "";
        }

        private void onClick1(object sender, MouseEventArgs e)
        {
            txtUser.Text = "";
        }

        private void userkeyDown(object sender, KeyEventArgs e)
        {
            var data = new Acount();
            data.Username = txtUser.Text;
            data.Password = txtPass.Text;
            if (sender.Equals(txtUser))
            {
                if (e.KeyCode == Keys.Enter)
                    txtPass.Focus();
            }else if (sender.Equals(txtPass))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string restriction;
                    if (isValidated())
                    {
                        if (data.checkAcount())
                        {
                            if(data.Username == "azizfina" || data.Username == "saaaaaar")
                            {
                                restriction = "admin";
                                new ShowDataMember(restriction).Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName or Password is Wrong!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUser.Focus();
                        }
                    }
                }
                else if(e.KeyCode == Keys.Escape)
                {
                    txtUser.Focus();
                }
            }else if (sender.Equals(btnLogin))
            {
                if(e.KeyCode == Keys.Enter)
                {
                    if (isValidated())
                    {
                        if (data.checkAcount())
                        {
                            if (data.Username == "azizfina")
                            {
                                new ShowDataMember("Admin").Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName or Password is Wrong!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUser.Focus();
                        }
                    }
                }
            }
        }

        //validasi textbox
        private bool isValidated()
        {
            var start = false;
            if (txtUser.Text.Equals(""))
            {
                MessageBox.Show("UserName is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUser.Focus();
            }
            else if (txtPass.Text.Equals(""))
            {
                MessageBox.Show("Password is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPass.Focus();
            }
            else
            {
                start = true;
            }
            return start;
        }

        private void loginClicked(object sender, EventArgs e)
        {
            var data = new Acount();
            data.Username = txtUser.Text;
            data.Password = txtPass.Text;
            if (isValidated())
            {
                if (data.checkAcount())
                {
                    if (data.Username == "azizfina")
                    {
                        new ShowDataMember("Admin").Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(data.checkAcount().ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Focus();
                }
            }
        }

        private void login(object sender, KeyPressEventArgs e)
        {
            var data = new Acount();
            data.Username = txtUser.Text;
            data.Password = txtPass.Text;
            if (isValidated())
            {
                if (data.checkAcount())
                {
                    if (data.Username == "azizfina")
                    {
                        new ShowDataMember("Admin").Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(data.checkAcount().ToString(), "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Focus();
                }
            }
        }
    }
}
