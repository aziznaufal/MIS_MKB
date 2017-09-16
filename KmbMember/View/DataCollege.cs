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
    public partial class DataCollege : Form
    {
        private string _code = " ";
        private string _restriction;

        public DataCollege(string restriction)
        {
            _restriction = restriction;
            InitializeComponent();
            ShowData();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            
            if (_restriction == "admin")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
        }

        private void ShowData()
        {
            try
            {
                var data = new Perguruan_Tinggi();
                CollegeData.DataSource = data.RetrievingData();

                CollegeData.Refresh();
                if (CollegeData.Columns.Count > 0)
                {
                    CollegeData.Columns[0].Visible = false;
                    CollegeData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    CollegeData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    CollegeData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                CollegeData.ClearSelection();
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Anggota_KMB.RetrivingData" + er.Message);
            }
        }

        private void SelectedData()
        {
            if (_restriction == "admin")
            {
                _code = CollegeData.Rows[CollegeData.CurrentCell.RowIndex].Cells[0].Value.ToString(); // menampung primary key
                btnAdd.Visible = false;
                btnDelete.Visible = true; btnEdit.Visible = true;
            }

            Console.WriteLine(_code);
        }

        public void resetcomponent()
        {
            _code = "";
            txtCollegeName.Text = "";
            txtFaculty.Text = "";
            txtMajor.Text = "";

            ShowData();
            if (_restriction == "admin")
            {
                btnAdd.Visible = true;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }

        }

        private void btnClicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                if (isValidated())
                {
                    var data = new Perguruan_Tinggi();
                    _code = data.GenerateCode();
                    data = new Perguruan_Tinggi(_code, txtCollegeName.Text, txtFaculty.Text, txtMajor.Text);
                    if (data.AttachData())
                    {
                        MessageBox.Show("Berhasil Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetcomponent();
                    }
                    else
                    {
                        MessageBox.Show("Gagal Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            else if (sender.Equals(btnEdit))
            {
                var data = new Perguruan_Tinggi(_code, txtCollegeName.Text, txtFaculty.Text, txtMajor.Text);
                data.Update();
                if (data.Update())
                {
                    MessageBox.Show("Berhasil DiUpdate", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
                else
                {
                    MessageBox.Show("Gagal DiUpdate", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else if (sender.Equals(btnDelete))
            {
                if (_code.Equals(""))
                {
                    MessageBox.Show("Code Not Selected!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    var msg = MessageBox.Show("Are you Sure", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        var data = new Perguruan_Tinggi(_code);
                        data.Remove();
                        if (data.Remove())
                        {
                            MessageBox.Show("Berhasil Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowData();
                        }
                        else
                        {
                            MessageBox.Show("Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                }
            }
            else if (sender.Equals(btnExit))
            {
                var msg = MessageBox.Show("Are you Sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    this.Hide();
                }
            }
            else if (sender.Equals(btnRefresh))
            {
                if(_restriction == "admin")
                {
                    ShowData();
                    _code = "";
                    btnAdd.Visible = true;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        private bool isValidated()
        {
            var start = false;
            if (txtCollegeName.Text.Equals(""))
            {
                MessageBox.Show("College Name is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCollegeName.Focus();
            }
            else if (txtMajor.Text.Equals(""))
            {
                MessageBox.Show("Major is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMajor.Focus();
            }

            else
            {
                start = true;
            }
            return start;
        }

        private void userKeyDown(object sender, KeyEventArgs e)
        {
            if (sender.Equals(txtCollegeName))
            {
                if (e.KeyCode == Keys.Enter)
                    txtFaculty.Focus();
                else if (e.KeyCode == Keys.Escape)
                    this.Close();
            }
            else if (sender.Equals(txtFaculty))
            {
                if (e.KeyCode == Keys.Enter)
                    txtMajor.Focus();
                else if (e.KeyCode == Keys.Escape)
                {
                    txtCollegeName.Focus();
                }
            }
            else if (sender.Equals(txtMajor))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (isValidated())
                    {
                        var msg = MessageBox.Show("Sure to update data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {

                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtFaculty.Focus();
                }
            }
        }

        private void DataCollege_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void DataCollege_Activated(object sender, EventArgs e)
        {
            ShowData();
        }

        private void CollegeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedData();
            txtCollegeName.Text = CollegeData.Rows[CollegeData.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtFaculty.Text = CollegeData.Rows[CollegeData.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txtMajor.Text = CollegeData.Rows[CollegeData.CurrentCell.RowIndex].Cells[3].Value.ToString();
        }
    }
}
