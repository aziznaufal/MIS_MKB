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
using Microsoft.CSharp;
using ExcelDataReader;
using System.IO;
using ClosedXML.Excel;

namespace KmbMember
{
    public partial class ShowDataMember : Form
    {
        private string _code = "";
        private string _Soscode = "";
        private string _Ptcode = "";
        private string _restriction;
        private List<ListItem> _listItem;
        
        public ShowDataMember()
        {
            InitializeComponent();
            ShowData();
            btnAddMember.Visible = false;
            btnDelete.Visible = false;
            btnAddCollege.Visible = false;
            btnExport.Visible = false;
            btnEdit.Visible = false;
        }

        public ShowDataMember(string restriction)
        {
            _restriction = restriction;
            if (_restriction == "admin")
            {
                InitializeComponent();
                ShowData();
                btnInput.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
            else if(_restriction == "sekertaris")
            {
                InitializeComponent();
                ShowData();
                btnInput.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnAddCollege.Visible = false;
            }
            else
            {
                InitializeComponent();
                ShowData();
                btnInput.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnAddMember.Visible = false;
            }
        }

        private void ShowData()
        {
            try
            {
                var data = new Anggota_KMB();
                MemberGridView.DataSource = data.RetrievingData();

                MemberGridView.Refresh();
                if (MemberGridView.Columns.Count > 0)
                {
                    MemberGridView.Columns[0].Visible = false;
                    MemberGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    MemberGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    MemberGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    MemberGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    MemberGridView.Columns[8].Visible = false;
                    MemberGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[12].Visible = false;
                    MemberGridView.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[16].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    MemberGridView.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                MemberGridView.ClearSelection();
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : Anggota_KMB.RetrivingData" + er.Message);
            }
        }

        private void SelectedData()
        {
            _code = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[0].Value.ToString(); // menampung primary key
            _Soscode = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[12].Value.ToString(); // menampung primary key
            _Ptcode = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[8].Value.ToString(); // menampung primary key
            btnAddMember.Visible = false;
            var gender = "";
            if (MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[3].Value.ToString() == "L")
            {
                gender = "Laki-Laki";
            }
            else
            {
                gender = "Perempuan";
            }
            if (_restriction == "admin" || _restriction == "sekertaris")
            {
                btnDelete.Visible = true; btnEdit.Visible = true;
            }
            _listItem = new List<ListItem>
                {
                    new ListItem
                    {
                        NIA = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                        Nama = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                        Gender = gender,
                        TempatLahir = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                        TanggalLahir = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                        AlamatAsli = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                        AlamatKos = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                        NamaKampus = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[9].Value.ToString(),
                        NamaFakultas = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[10].Value.ToString(),
                        NamaJurusan = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[11].Value.ToString(),
                        Phone = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[13].Value.ToString(),
                        WhatsApp = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[14].Value.ToString(),
                        Line = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[15].Value.ToString(),
                        Instagram = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[16].Value.ToString(),
                        Facebook = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[17].Value.ToString(),
                        Twitter = MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[18].Value.ToString(),
                        TahunAngkatan = "20"+MemberGridView.Rows[MemberGridView.CurrentCell.RowIndex].Cells[1].Value.ToString().Substring(4,2)
                    }
                };

        }

        public void resetcomponent()
        {
            _code = "";
            ShowData();
            if (_restriction == "admin" || _restriction == "sekertaris")
            {
                btnAddMember.Visible = true;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }

        }

        private void btnClicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnInput))
            {
                new loginfrm().Show();
                this.Hide();
            }
            else if (sender.Equals(btnSearch))
            {
                try
                {
                    try
                    {
                        var bs = new BindingSource();
                        bs.DataSource = MemberGridView.DataSource;
                        bs.Filter = "name LIKE '%" + txtSearch.Text + "%'";
                        MemberGridView.DataSource = bs;
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine(er.Message);
                        try
                        {
                            var bs = new BindingSource();
                            bs.DataSource = MemberGridView.DataSource;
                            bs.Filter = "nomor_induk_anggota LIKE '____" + txtSearch.Text + "%'";
                            MemberGridView.DataSource = bs;
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                            try
                            {
                                var bs = new BindingSource();
                                bs.DataSource = MemberGridView.DataSource;
                                bs.Filter = "alamat_asli LIKE '%" + txtSearch.Text + "%'";
                                MemberGridView.DataSource = bs;
                            }
                            catch (Exception et)
                            {
                                Console.WriteLine(et.Message);
                                try
                                {
                                    var bs = new BindingSource();
                                    bs.DataSource = MemberGridView.DataSource;
                                    bs.Filter = "alamat_kos LIKE '%" + txtSearch.Text + "%'";
                                    MemberGridView.DataSource = bs;
                                }
                                catch (Exception eu)
                                {
                                    Console.WriteLine(eu.Message); try
                                    {
                                        var bs = new BindingSource();
                                        bs.DataSource = MemberGridView.DataSource;
                                        bs.Filter = "perguruan_tinggi LIKE '%" + txtSearch.Text + "%'";
                                        MemberGridView.DataSource = bs;
                                    }
                                    catch (Exception ev)
                                    {
                                        Console.WriteLine(ev.Message); try
                                        {
                                            var bs = new BindingSource();
                                            bs.DataSource = MemberGridView.DataSource;
                                            bs.Filter = "jurusan LIKE '%" + txtSearch.Text + "%'";
                                            MemberGridView.DataSource = bs;
                                        }
                                        catch (Exception ew)
                                        {
                                            Console.WriteLine(ew.Message);
                                            var bs = new BindingSource();
                                            bs.DataSource = MemberGridView.DataSource;
                                            bs.Filter = "phone_number LIKE '%" + txtSearch.Text + "%'";
                                            MemberGridView.DataSource = bs;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else if (sender.Equals(btnAddMember))
            {
                new DataMember(_restriction).Show();
            }
            else if (sender.Equals(btnAddCollege))
            {
                new DataCollege(_restriction).Show();
            }
            else if (sender.Equals(btnDelete))
            {
                Console.WriteLine("code = " + _code);

                if (_code=="")
                {
                    MessageBox.Show("Code Not Selected!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    File.Delete(Application.StartupPath + "\\Picture\\" + _listItem[0].NIA.ToString() + ".jpg");
                    Console.WriteLine("code = " + _code);
                    var code = _code;
                    var SosCode = _Soscode;
                    var PtCode = _Ptcode;
                    var msg = MessageBox.Show("Are you Sure", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        Console.WriteLine("A_id = " + code +", S_id = " + SosCode + ", P_id = " + PtCode);

                        var data = new Anggota_KMB(code);
                        var cp = new Contact_Person(code, SosCode);
                        var sosmed = new Sosial_Media(SosCode);
                        if (cp.Remove())
                        {
                            if (sosmed.Remove())
                            {
                                if (data.Remove())
                                {
                                    MessageBox.Show("Berhasil Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    resetcomponent();
                                }
                                else
                                {
                                    MessageBox.Show("Anggota Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("SosMed Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("CP Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                }
            }
            else if (sender.Equals(btnReset))
            {
                ShowData();
                resetcomponent();
            }
            else if (sender.Equals(btnEdit))
            {
                if (_code == "")
                {
                    MessageBox.Show("No Code Selected", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    new DataMember(_restriction, _code, _Soscode, _Ptcode, _listItem).Show();
                }

            }
            else if (sender.Equals(btnExit))
            {
                var msg = MessageBox.Show("Are you Sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    this.Dispose();

                }
            }
            else if (sender.Equals(btnExport))
            {
                //new KmbMember.View.IOReport("export", MemberGridView).Show();
                ExportToExcelWithFormatting(MemberGridView);
            }
        }

        private void DataGridClicked(object sender, DataGridViewCellEventArgs e)
        {
            SelectedData();
            Console.WriteLine("code = " + _code);
        }

        private void DataGridDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (_code == "")
            {
                MessageBox.Show("No Code Selected", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                new DataMember(_restriction, _code, _Soscode, _Ptcode, _listItem).Show();
            }


        }

        private void FormLoad(object sender, EventArgs e)
        {
            resetcomponent();
        }

        private void FormActivated(object sender, EventArgs e)
        {
            ShowData();
            resetcomponent();
        }

        private void userKeyDown(object sender, KeyEventArgs e)
        {
            if (sender.Equals(txtSearch))
            {
                if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        try
                        {
                            var bs = new BindingSource();
                            bs.DataSource = MemberGridView.DataSource;
                            bs.Filter = "name LIKE '%" + txtSearch.Text + "%'";
                            MemberGridView.DataSource = bs;
                        }
                        catch (Exception er)
                        {
                            Console.WriteLine(er.Message);
                            try
                            {
                                var bs = new BindingSource();
                                bs.DataSource = MemberGridView.DataSource;
                                bs.Filter = "nomor_induk_anggota LIKE '____" + txtSearch.Text + "%'";
                                MemberGridView.DataSource = bs;
                            }
                            catch (Exception es)
                            {
                                Console.WriteLine(es.Message);
                                try
                                {
                                    var bs = new BindingSource();
                                    bs.DataSource = MemberGridView.DataSource;
                                    bs.Filter = "alamat_asli LIKE '%" + txtSearch.Text + "%'";
                                    MemberGridView.DataSource = bs;
                                }
                                catch (Exception et)
                                {
                                    Console.WriteLine(et.Message);
                                    try
                                    {
                                        var bs = new BindingSource();
                                        bs.DataSource = MemberGridView.DataSource;
                                        bs.Filter = "alamat_kos LIKE '%" + txtSearch.Text + "%'";
                                        MemberGridView.DataSource = bs;
                                    }
                                    catch (Exception eu)
                                    {
                                        Console.WriteLine(eu.Message); try
                                        {
                                            var bs = new BindingSource();
                                            bs.DataSource = MemberGridView.DataSource;
                                            bs.Filter = "perguruan_tinggi LIKE '%" + txtSearch.Text + "%'";
                                            MemberGridView.DataSource = bs;
                                        }
                                        catch (Exception ev)
                                        {
                                            Console.WriteLine(ev.Message); try
                                            {
                                                var bs = new BindingSource();
                                                bs.DataSource = MemberGridView.DataSource;
                                                bs.Filter = "jurusan LIKE '%" + txtSearch.Text + "%'";
                                                MemberGridView.DataSource = bs;
                                            }
                                            catch (Exception ew)
                                            {
                                                Console.WriteLine(ew.Message);
                                                var bs = new BindingSource();
                                                bs.DataSource = MemberGridView.DataSource;
                                                bs.Filter = "phone_number LIKE '%" + txtSearch.Text + "%'";
                                                MemberGridView.DataSource = bs;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtSearch.Text = "";
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (_restriction == "admin" || _restriction == "sekertaris")
                {
                    if (_code == "")
                    {
                        MessageBox.Show("Code Not Selected!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        File.Delete(Application.StartupPath + "\\Picture\\" + _listItem[0].NIA.ToString() + ".jpg");
                        Console.WriteLine("code = " + _code);
                        var code = _code;
                        var SosCode = _Soscode;
                        var PtCode = _Ptcode;
                        var msg = MessageBox.Show("Are you Sure", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {
                            Console.WriteLine("A_id = " + code + ", S_id = " + SosCode + ", P_id = " + PtCode);

                            var data = new Anggota_KMB(code);
                            var cp = new Contact_Person(code, SosCode);
                            var sosmed = new Sosial_Media(SosCode);
                            if (cp.Remove())
                            {
                                if (sosmed.Remove())
                                {
                                    if (data.Remove())
                                    {
                                        MessageBox.Show("Berhasil Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        resetcomponent();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Anggota Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("SosMed Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("CP Gagal Dihapus", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                    }
                }
            }

        }

        public void ExportToExcelWithFormatting(DataGridView dataGridView1)
        {
            string fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.Title = "To Excel";
            saveFileDialog1.FileName = this.Text + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";



            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(this.Text);
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].Name;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value.ToString();

                        if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                        {
                            XLAlignmentHorizontalValues align;

                            switch (dataGridView1.Rows[i].Cells[j].Style.Alignment)
                            {
                                case DataGridViewContentAlignment.BottomRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.MiddleRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;
                                case DataGridViewContentAlignment.TopRight:
                                    align = XLAlignmentHorizontalValues.Right;
                                    break;

                                case DataGridViewContentAlignment.BottomCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.MiddleCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;
                                case DataGridViewContentAlignment.TopCenter:
                                    align = XLAlignmentHorizontalValues.Center;
                                    break;

                                default:
                                    align = XLAlignmentHorizontalValues.Left;
                                    break;
                            }

                            worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;

                            XLColor xlColor = XLColor.FromColor(dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor);
                            worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);

                            worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dataGridView1.Font.Name;
                            worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dataGridView1.Font.Size;

                        }
                    }
                }
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
                MessageBox.Show("Done");
            }
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            var msg = MessageBox.Show("Are you Sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
            {
                var neww = new ShowDataMember();
                neww.Activate();
            }
        }
    }
}
