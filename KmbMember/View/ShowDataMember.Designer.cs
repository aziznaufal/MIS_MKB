namespace KmbMember
{
    partial class ShowDataMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MemberGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddCollege = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 703);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1079, 703);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MemberGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 669);
            this.panel3.TabIndex = 3;
            // 
            // MemberGridView
            // 
            this.MemberGridView.AllowUserToAddRows = false;
            this.MemberGridView.AllowUserToDeleteRows = false;
            this.MemberGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberGridView.Location = new System.Drawing.Point(0, 0);
            this.MemberGridView.Name = "MemberGridView";
            this.MemberGridView.ReadOnly = true;
            this.MemberGridView.RowHeadersVisible = false;
            this.MemberGridView.Size = new System.Drawing.Size(844, 669);
            this.MemberGridView.TabIndex = 0;
            this.MemberGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridClicked);
            this.MemberGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridDoubleClicked);
            this.MemberGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userKeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnExit);
            this.panel5.Controls.Add(this.btnDelete);
            this.panel5.Controls.Add(this.btnAddCollege);
            this.panel5.Controls.Add(this.btnAddMember);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(844, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 669);
            this.panel5.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(0, 508);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(235, 127);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "&QUIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(0, 381);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(235, 127);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnClicked);
            // 
            // btnAddCollege
            // 
            this.btnAddCollege.AutoSize = true;
            this.btnAddCollege.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddCollege.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCollege.Location = new System.Drawing.Point(0, 254);
            this.btnAddCollege.Name = "btnAddCollege";
            this.btnAddCollege.Size = new System.Drawing.Size(235, 127);
            this.btnAddCollege.TabIndex = 2;
            this.btnAddCollege.Text = "ADD &COLLEGE";
            this.btnAddCollege.UseVisualStyleBackColor = true;
            this.btnAddCollege.Click += new System.EventHandler(this.btnClicked);
            // 
            // btnAddMember
            // 
            this.btnAddMember.AutoSize = true;
            this.btnAddMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.Location = new System.Drawing.Point(0, 127);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(235, 127);
            this.btnAddMember.TabIndex = 1;
            this.btnAddMember.Text = "&ADD MEMBER";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnClicked);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(0, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(235, 127);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "R&ESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnClicked);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.btnInput);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1079, 34);
            this.panel4.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(404, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(152, 34);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "EDI&T DATA";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnClicked);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(556, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(152, 34);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "E&XPORT DATA";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnClicked);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.txtSearch);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(708, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(371, 34);
            this.panel6.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(247, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 20);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnClicked);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(2, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userKeyDown);
            // 
            // btnInput
            // 
            this.btnInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInput.Location = new System.Drawing.Point(0, 0);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(152, 34);
            this.btnInput.TabIndex = 0;
            this.btnInput.Text = "&INPUT DATA";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnClicked);
            // 
            // ShowDataMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1079, 703);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowDataMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Anggota KMB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormActivated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnAddCollege;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView MemberGridView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnEdit;
    }
}