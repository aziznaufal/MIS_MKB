using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using KmbMember.DataAccess;

namespace KmbMember
{
    public partial class DataMember : Form
    {
        private string _restriction;
        private string a_Code;
        private string s_Code;
        private string p_Code;
        private string _pathpic;
        public DataMember(string restriction)
        {
            InitializeComponent();
            _restriction = restriction;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            txtNIA.Visible = false;
            btnEdit.Visible = false;
            FillCboGender();
            FillCboNameCollege();
            txtTanggal.Visible = false;
            facultyLabel.Visible = false;
            majorLabel.Visible = false;
            yearLabel.Visible = false;
            cmbFacultyCollege.Visible = false;
            cmbMajorCollege.Visible = false;
            txtTahunAjaran.Visible = false;
        }

        public DataMember(string restriction, string A_code, string S_code, string P_code, List<ListItem> List)
        {
            InitializeComponent();
            _restriction = restriction;
            Console.WriteLine("A_Code: " + A_code + ", S_Code: " + S_code + ", P_Code: " + P_code);
            if (_restriction == "admin" || _restriction == "sekertaris")
            {
                btnEdit.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;

            }
            a_Code = A_code;
            s_Code = S_code;
            p_Code = P_code;
            var list = List;
            var _list = list.ToArray();
            var path = Path.GetFullPath(@"../Picture/" + _list[0].NIA.ToString() + ".jpg");
            Console.WriteLine("PATH: " + path);
            try
            {
                pic.ImageLocation = Application.StartupPath + "\\Picture\\" + _list[0].NIA.ToString() + ".jpg";
                Console.WriteLine("PATH: " + pic.ImageLocation);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                btnSubmit.Visible = false;
                txtNIA.Visible = true;
                var data_1 = new Anggota_KMB(a_Code);

                txtNIA.Text = _list[0].NIA.ToString();
                txtNIA.ReadOnly = true;
                txtName.Text = _list[0].Nama.ToString();
                txtName.ReadOnly = true;
                cmbGender.Text = _list[0].Gender.ToString();

                txtPlaceBorn.Text = _list[0].TempatLahir.ToString();
                txtPlaceBorn.ReadOnly = true;
                txtTanggal.Text = _list[0].TanggalLahir.ToString();
                txtTanggal.ReadOnly = true;
                txtRealAddress.Text = _list[0].AlamatAsli.ToString();
                txtRealAddress.ReadOnly = true;
                txtBoardingAddress.Text = _list[0].AlamatKos.ToString();
                txtBoardingAddress.ReadOnly = true;

                cmbNameCollege.Text = _list[0].NamaKampus.ToString();
                cmbFacultyCollege.Text = _list[0].NamaFakultas.ToString();
                cmbMajorCollege.Text = _list[0].NamaJurusan.ToString();
                txtTahunAjaran.Text = _list[0].TahunAngkatan.ToString();
                txtTahunAjaran.ReadOnly = true;

                txtPhone.Text = _list[0].Phone.ToString();
                txtPhone.ReadOnly = true;
                txtWA.Text = _list[0].WhatsApp.ToString();
                txtWA.ReadOnly = true;
                txtLine.Text = _list[0].Line.ToString();
                txtLine.ReadOnly = true;
                txtIG.Text = _list[0].Instagram.ToString();
                txtIG.ReadOnly = true;
                txtFB.Text = _list[0].Facebook.ToString();
                txtFB.ReadOnly = true;
                txtTwit.Text = _list[0].Twitter.ToString();
                txtTwit.ReadOnly = true;
            }
            catch (Exception er)
            {
                Console.WriteLine("error: " + er.StackTrace);
                Console.WriteLine("error: " + er.Message);

            }
        }

        private void DataMember_Load(object sender, EventArgs e)
        {

        }

        private void FillCboGender()
        {
            try
            {
                var list = new Dictionary<string, string>();
                list["X"] = "<Select One>";
                list["L"] = "Laki-Laki";
                list["P"] = "Perempuan";

                cmbGender.Items.Clear();
                cmbGender.DataSource = new BindingSource(list, null);
                cmbGender.DisplayMember = "Value";
                cmbGender.ValueMember = "key";
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : FrmDataMember.FillcmbGender" + er.Message);
            }
        }

        private void FillCboNameCollege()
        {
            try
            {
                var data = new Perguruan_Tinggi();
                cmbNameCollege.Items.Clear();
                cmbNameCollege.DataSource = new BindingSource(data.FillComboRecord(), null);
                cmbNameCollege.DisplayMember = "Value";
                cmbNameCollege.ValueMember = "key";
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : FrmDataMember.FillComboRecord" + er.Message);
            }
        }

        private void FillCboFacultyCollege()
        {
            try
            {
                Console.WriteLine("value: " + cmbNameCollege.Text);
                var data = new Perguruan_Tinggi();
                data.Nama = cmbNameCollege.SelectedValue.ToString();
                cmbFacultyCollege.Items.Clear();
                cmbFacultyCollege.DataSource = new BindingSource(data.FillFacultyComboRecord(), null);
                cmbFacultyCollege.DisplayMember = "Value";
                cmbFacultyCollege.ValueMember = "key";
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : FrmDataMember.FillFacultyComboRecord" + er.Message);
            }
        }

        private void FillCboMajorCollege()
        {
            try
            {
                var data = new Perguruan_Tinggi();
                data.Nama = cmbNameCollege.SelectedValue.ToString();
                data.Fakultas = cmbFacultyCollege.SelectedValue.ToString();
                cmbMajorCollege.Items.Clear();
                cmbMajorCollege.DataSource = new BindingSource(data.FillMajorComboRecord(), null);
                cmbMajorCollege.DisplayMember = "Value";
                cmbMajorCollege.ValueMember = "key";
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : FRMDataMember.FillFacultyComboRecord" + er.Message);
            }
        }

        private void btnClicked(object sender, EventArgs e)
        {
            if (sender.Equals(btnCancel))
            {
                this.Close();
            }
            else if (sender.Equals(btnSubmit))
            {
                if (isValidated())
                {
                    if (txtNIA.Visible == false)
                    {
                        
                        Console.WriteLine("copyfile: " + Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg");
                        //SOSMED
                        var dataSosMed = new Sosial_Media();
                        var sos_id = dataSosMed.GenerateCode();
                        dataSosMed = new Sosial_Media(sos_id, txtPhone.Text, txtIG.Text, txtLine.Text, txtWA.Text, txtFB.Text, txtTwit.Text);
                        Console.WriteLine("sos_id: " + sos_id);
                        if (dataSosMed.AttachData())
                        {
                            //PT
                            var dataCollege = new Perguruan_Tinggi();
                            dataCollege.Nama = cmbNameCollege.SelectedValue.ToString();
                            dataCollege.Fakultas = cmbFacultyCollege.SelectedValue.ToString();
                            dataCollege.Jurusan = cmbMajorCollege.SelectedValue.ToString();
                            var pt_id = dataCollege.GetCode();
                            Console.WriteLine("Kampus: " + cmbNameCollege.SelectedItem.ToString() + ", Fakultas: " + cmbFacultyCollege.SelectedValue.ToString()/*pake ini*/ + ", Jurusan: " + cmbMajorCollege.SelectedValue.ToString() + ", pt_id: " + pt_id);

                            if (pt_id != "")
                            {
                                //DataMember
                                var dataMember = new Anggota_KMB();
                                var year = txtTahunAjaran.Text.Substring(2, 2);
                                var A_id = dataMember.GenerateCode();
                                var NIA = "KMB." + txtTahunAjaran.Text.Substring(2, 2) + "." + dataMember.GenerateNIA(year);
                                var DateBorn = txtDayBorn.Text + "/" + txtMonthBorn.Text + "/" + txtYearBorn.Text;
                                dataMember = new Anggota_KMB(A_id, NIA, txtName.Text, cmbGender.SelectedValue.ToString(), txtPlaceBorn.Text, DateBorn, txtRealAddress.Text, txtBoardingAddress.Text, pt_id);

                                if (dataMember.AttachData())
                                {
                                    //CP
                                    var dataCp = new Contact_Person(A_id, sos_id);
                                    try
                                    {
                                        File.Copy(_pathpic, Application.StartupPath + "\\Picture\\" + NIA + ".jpg", true);

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Picture is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    }
                                    if (dataCp.AttachData())
                                    {
                                        MessageBox.Show("Berhasil Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        resetcomponent();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Gagal Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Gagal Ditambahkan_Member", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }


                                Console.WriteLine("Kampus: " + cmbNameCollege.SelectedItem.ToString() + ", Fakultas: " + cmbFacultyCollege.SelectedValue.ToString()/*pake ini*/ + ", Jurusan: " + cmbMajorCollege.SelectedValue.ToString() + ", pt_id: " + pt_id);

                            }
                            else
                            {
                                MessageBox.Show("Gagal Ditambahkan_PT", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Gagal Ditambahkan_SosMed", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        var a_code = a_Code;
                        var s_code = s_Code;
                        var p_code = p_Code;
                        Console.WriteLine("Error - SosMed " + s_code);
                        try
                        {
                            File.Copy(_pathpic, Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg", true);

                        }
                        catch
                        {
                            MessageBox.Show("Picture is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        Console.WriteLine("copyfile: " + Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg");
                        try
                        {
                            var sosMed = new Sosial_Media(s_code, txtPhone.Text, txtIG.Text, txtLine.Text, txtWA.Text, txtFB.Text, txtTwit.Text);

                            if (sosMed.Update())
                            {
                                var dataCollege = new Perguruan_Tinggi(null, cmbNameCollege.SelectedValue.ToString(), cmbFacultyCollege.SelectedValue.ToString(), cmbMajorCollege.SelectedValue.ToString());
                                var pt_id = dataCollege.GetCode();
                                if (pt_id != "")
                                {
                                    var dataMember = new Anggota_KMB();
                                    var DateBorn = txtDayBorn.Text + "/" + txtMonthBorn.Text + "/" + txtYearBorn.Text;
                                    dataMember = new Anggota_KMB(a_code, txtNIA.Text, txtName.Text, cmbGender.SelectedValue.ToString(), txtPlaceBorn.Text, DateBorn, txtRealAddress.Text, txtBoardingAddress.Text, cmbMajorCollege.SelectedValue.ToString());
                                    if (dataMember.Update())
                                    {
                                        MessageBox.Show("Berhasil Diperbarui : " + cmbMajorCollege.SelectedValue.ToString(), "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Console.WriteLine("Error - P_T: " + pt_id);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Console.WriteLine("Error - SosMed");
                            }
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Console.WriteLine("Error - sosmed: " + er.Message);
                        }
                        //
                    }
                }

            }
            else if (sender.Equals(btnEdit))
            {
                txtName.ReadOnly = false;
                txtPlaceBorn.ReadOnly = false;

                txtDayBorn.Text = txtTanggal.Text.Substring(0, 2);
                txtMonthBorn.Text = txtTanggal.Text.Substring(3, 2);
                txtYearBorn.Text = txtTanggal.Text.Substring(6, 4);

                txtRealAddress.ReadOnly = false;
                txtBoardingAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
                txtWA.ReadOnly = false;
                txtLine.ReadOnly = false;
                txtIG.ReadOnly = false;
                txtFB.ReadOnly = false;
                txtTwit.ReadOnly = false;

                btnEdit.Visible = false;
                btnSubmit.Visible = true;
                FillCboGender();
                FillCboNameCollege();
                txtTanggal.Visible = false;
                facultyLabel.Visible = false;
                majorLabel.Visible = false;
                yearLabel.Visible = false;
                cmbFacultyCollege.Visible = false;
                cmbMajorCollege.Visible = false;
                txtTahunAjaran.Visible = false;
            }
            else if (sender.Equals(pic))
            {
                if (_restriction == "admin" || _restriction == "sekertaris")
                {
                    OFDpic.InitialDirectory = "e:\\";
                    OFDpic.Filter = "Jpg Image Files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    OFDpic.FilterIndex = 1;
                    OFDpic.RestoreDirectory = true;
                    if (OFDpic.ShowDialog() == DialogResult.OK)
                    {
                        pic.ImageLocation = OFDpic.FileName;
                        _pathpic = OFDpic.FileName;
                        Console.WriteLine("pathpic: " + pic.ImageLocation);
                        Console.WriteLine("savefilename: " + OFDpic.SafeFileName);

                    }
                }
            }

        }

        private void resetcomponent()
        {
            txtName.Text = "";
            cmbGender.SelectedIndex = 0;
            txtPlaceBorn.Text = "";
            txtDayBorn.Text = "";
            txtMonthBorn.Text = "";
            txtYearBorn.Text = "";
            cmbNameCollege.SelectedIndex = 0;
            cmbFacultyCollege.SelectedIndex = 0;
            cmbMajorCollege.SelectedIndex = 0;
            txtTahunAjaran.Text = "";
            txtPhone.Text = "";
            txtWA.Text = "";
            txtLine.Text = "";
            txtIG.Text = "";
            txtFB.Text = "";
            txtTwit.Text = "";
            txtRealAddress.Text = "";
            txtBoardingAddress.Text = "";
            facultyLabel.Visible = false;
            majorLabel.Visible = false;
            yearLabel.Visible = false;
            cmbFacultyCollege.Visible = false;
            cmbMajorCollege.Visible = false;
            txtTahunAjaran.Visible = false;
            pic.Image = null;
            txtName.Focus();
        }

        private bool isValidated()
        {
            var start = false;
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Name is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
            }
            else if (cmbGender.SelectedValue.Equals("0"))
            {
                MessageBox.Show("Gender is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbGender.Focus();
            }
            else if (txtRealAddress.Text.Equals(""))
            {
                MessageBox.Show("Address is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRealAddress.Focus();
            }
            else if (cmbNameCollege.SelectedValue.Equals("0"))
            {
                MessageBox.Show("College Name is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbNameCollege.Focus();
            }
            else if (cmbFacultyCollege.SelectedValue.Equals("0"))
            {
                MessageBox.Show("Faculty is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbFacultyCollege.Focus();
            }
            else if (cmbMajorCollege.SelectedValue.Equals("0"))
            {
                MessageBox.Show("Major is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbMajorCollege.Focus();
            }
            else if (txtPhone.Text.Equals(""))
            {
                MessageBox.Show("Phone is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhone.Focus();
            }
            else
            {
                start = true;
            }
            return start;
        }

        private void userKeyDown(object sender, KeyEventArgs e)
        {
            if (sender.Equals(txtName))
            {
                if (e.KeyCode == Keys.Enter)
                    cmbGender.Focus();
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else if (sender.Equals(cmbGender))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPlaceBorn.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtName.Focus();
                    txtName.Text = "";
                }
            }
            else if (sender.Equals(txtPlaceBorn))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDayBorn.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    cmbGender.Focus();
                }
            }
            else if (sender.Equals(txtDayBorn))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonthBorn.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtPlaceBorn.Focus();
                    txtPlaceBorn.Text = "";
                }
            }
            else if (sender.Equals(txtMonthBorn))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtYearBorn.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtDayBorn.Focus();
                    txtDayBorn.Text = "";
                }
            }
            else if (sender.Equals(txtYearBorn))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRealAddress.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtMonthBorn.Focus();
                    txtMonthBorn.Text = "";
                }
            }
            else if (sender.Equals(txtRealAddress))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBoardingAddress.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtYearBorn.Focus();
                    txtYearBorn.Text = "";
                }
            }
            else if (sender.Equals(txtBoardingAddress))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbNameCollege.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtRealAddress.Focus();
                    txtRealAddress.Text = "";
                }
            }
            else if (sender.Equals(cmbNameCollege))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        facultyLabel.Visible = true;
                        cmbFacultyCollege.Visible = true;
                        FillCboFacultyCollege();
                        Console.WriteLine("Kampus: " + cmbNameCollege.SelectedValue.ToString());
                        cmbFacultyCollege.Focus();

                    }
                    catch
                    {
                        MessageBox.Show("College Name is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtBoardingAddress.Focus();
                    txtBoardingAddress.Text = "";
                }
            }
            else if (sender.Equals(cmbFacultyCollege))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        majorLabel.Visible = true;
                        cmbMajorCollege.Visible = true;
                        FillCboMajorCollege();
                        Console.WriteLine("fakultas: " + cmbFacultyCollege.SelectedValue.ToString());
                        cmbMajorCollege.Focus();
                    }
                    catch
                    {
                        MessageBox.Show("Faculty is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    facultyLabel.Visible = false;
                    cmbFacultyCollege.Visible = false;
                    cmbNameCollege.Focus();
                }
            }
            else if (sender.Equals(cmbMajorCollege))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        yearLabel.Visible = true;
                        txtTahunAjaran.Visible = true;
                        Console.WriteLine("jurusan: " + cmbMajorCollege.SelectedValue.ToString());
                        txtTahunAjaran.Focus();
                    }
                    catch
                    {
                        MessageBox.Show("Major is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    majorLabel.Visible = false;
                    cmbMajorCollege.Visible = false;
                    cmbFacultyCollege.Focus();
                }
            }
            else if (sender.Equals(txtTahunAjaran))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPhone.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    yearLabel.Visible = false;
                    txtTahunAjaran.Visible = false;
                    cmbMajorCollege.Focus();
                }
            }
            else if (sender.Equals(txtPhone))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWA.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtTahunAjaran.Focus();
                    txtTahunAjaran.Text = "";
                }
            }
            else if (sender.Equals(txtWA))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLine.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtPhone.Focus();
                    txtPhone.Text = "";
                }
            }
            else if (sender.Equals(txtLine))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIG.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtWA.Focus();
                    txtWA.Text = "";
                }
            }
            else if (sender.Equals(txtIG))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFB.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtLine.Focus();
                    txtLine.Text = "";
                }
            }
            else if (sender.Equals(txtFB))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTwit.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtIG.Focus();
                    txtIG.Text = "";
                }

            }
            else if (sender.Equals(txtTwit))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (isValidated())
                    {
                        if (txtNIA.Visible == false)
                        {
                            Console.WriteLine("copyfile: " + Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg");
                            //SOSMED
                            var dataSosMed = new Sosial_Media();
                            var sos_id = dataSosMed.GenerateCode();
                            dataSosMed = new Sosial_Media(sos_id, txtPhone.Text, txtIG.Text, txtLine.Text, txtWA.Text, txtFB.Text, txtTwit.Text);
                            Console.WriteLine("sos_id: " + sos_id);
                            if (dataSosMed.AttachData())
                            {
                                //PT
                                var dataCollege = new Perguruan_Tinggi();
                                dataCollege.Nama = cmbNameCollege.SelectedValue.ToString();
                                dataCollege.Fakultas = cmbFacultyCollege.SelectedValue.ToString();
                                dataCollege.Jurusan = cmbMajorCollege.SelectedValue.ToString();
                                var pt_id = dataCollege.GetCode();
                                Console.WriteLine("Kampus: " + cmbNameCollege.SelectedItem.ToString() + ", Fakultas: " + cmbFacultyCollege.SelectedValue.ToString()/*pake ini*/ + ", Jurusan: " + cmbMajorCollege.SelectedValue.ToString() + ", pt_id: " + pt_id);

                                if (pt_id != "")
                                {
                                    //DataMember
                                    var dataMember = new Anggota_KMB();
                                    var year = txtTahunAjaran.Text.Substring(2, 2);
                                    var A_id = dataMember.GenerateCode();
                                    var NIA = "KMB." + txtTahunAjaran.Text.Substring(2, 2) + "." + dataMember.GenerateNIA(year);
                                    var DateBorn = txtDayBorn.Text + "/" + txtMonthBorn.Text + "/" + txtYearBorn.Text;
                                    dataMember = new Anggota_KMB(A_id, NIA, txtName.Text, cmbGender.SelectedValue.ToString(), txtPlaceBorn.Text, DateBorn, txtRealAddress.Text, txtBoardingAddress.Text, pt_id);

                                    if (dataMember.AttachData())
                                    {
                                        //CP
                                        try
                                        {
                                            File.Copy(_pathpic, Application.StartupPath + "\\Picture\\" + NIA + ".jpg", true);

                                        }
                                        catch
                                        {
                                            MessageBox.Show("Picture is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        }
                                        var dataCp = new Contact_Person(A_id, sos_id);
                                        if (dataCp.AttachData())
                                        {
                                            MessageBox.Show("Berhasil Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            resetcomponent();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Gagal Ditambahkan", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Gagal Ditambahkan_Member", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }


                                    Console.WriteLine("Kampus: " + cmbNameCollege.SelectedItem.ToString() + ", Fakultas: " + cmbFacultyCollege.SelectedValue.ToString()/*pake ini*/ + ", Jurusan: " + cmbMajorCollege.SelectedValue.ToString() + ", pt_id: " + pt_id);

                                }
                                else
                                {
                                    MessageBox.Show("Gagal Ditambahkan_PT", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }
                            else
                            {
                                MessageBox.Show("Gagal Ditambahkan_SosMed", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {

                            try
                            {
                                File.Copy(_pathpic, Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg", true);

                            }
                            catch
                            {
                                MessageBox.Show("Picture is Empty", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                            Console.WriteLine("copyfile: " + Application.StartupPath + "\\Picture\\" + txtNIA.Text + ".jpg");
                            var a_code = a_Code;
                            var s_code = s_Code;
                            var p_code = p_Code;
                            try
                            {
                                var sosMed = new Sosial_Media(s_code, txtPhone.Text, txtIG.Text, txtLine.Text, txtWA.Text, txtFB.Text, txtTwit.Text);

                                if (sosMed.Update())
                                {
                                    var dataCollege = new Perguruan_Tinggi(null, cmbNameCollege.SelectedValue.ToString(), cmbFacultyCollege.SelectedValue.ToString(), cmbMajorCollege.SelectedValue.ToString());
                                    var pt_id = dataCollege.GetCode();
                                    if (pt_id != "")
                                    {
                                        var dataMember = new Anggota_KMB();
                                        var DateBorn = txtDayBorn.Text + "/" + txtMonthBorn.Text + "/" + txtYearBorn.Text;
                                        dataMember = new Anggota_KMB(a_code, txtNIA.Text, txtName.Text, cmbGender.SelectedValue.ToString(), txtPlaceBorn.Text, DateBorn, txtRealAddress.Text, txtBoardingAddress.Text, cmbMajorCollege.SelectedValue.ToString());
                                        if (dataMember.Update())
                                        {
                                            MessageBox.Show("Berhasil Diperbarui : " + cmbMajorCollege.SelectedValue.ToString(), "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Console.WriteLine("Error - P_T: " + pt_id);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Console.WriteLine("Error - SosMed");
                                }
                            }
                            catch (Exception er)
                            {
                                MessageBox.Show("Gagal Diperbarui", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Console.WriteLine("Error - sosmed: " + er.Message);
                            }
                            //
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtFB.Focus();
                    txtFB.Text = "";
                }

            }
        }


    }
}
