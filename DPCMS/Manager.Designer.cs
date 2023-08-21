namespace DPCMS
{
    partial class Manager
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.txtnumber = new System.Windows.Forms.TextBox();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.txtlicense = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcnic = new System.Windows.Forms.TextBox();
            this.comBrole = new System.Windows.Forms.ComboBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btn_logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(495, 223);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(165, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Admin Dashboard";
            // 
            // comboBox
            // 
            this.comboBox.DisplayMember = "A";
            this.comboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "View Users",
            "View Drivers"});
            this.comboBox.Location = new System.Drawing.Point(35, 55);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(126, 27);
            this.comboBox.TabIndex = 6;
            this.comboBox.Text = "Please Select";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(147, 362);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(74, 26);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(323, 362);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 26);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(426, 362);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(74, 26);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txtfname
            // 
            this.txtfname.Location = new System.Drawing.Point(584, 97);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(140, 20);
            this.txtfname.TabIndex = 10;
            this.txtfname.Text = "Firstname";
            // 
            // txtlname
            // 
            this.txtlname.Location = new System.Drawing.Point(584, 123);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(140, 20);
            this.txtlname.TabIndex = 11;
            this.txtlname.Text = "Lastname";
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(584, 227);
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(140, 20);
            this.txtnumber.TabIndex = 13;
            this.txtnumber.Text = "Phone Number";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(584, 149);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(140, 20);
            this.txtmail.TabIndex = 12;
            this.txtmail.Text = "E- mail";
            //this.txtmail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtlicense
            // 
            this.txtlicense.Location = new System.Drawing.Point(584, 279);
            this.txtlicense.Name = "txtlicense";
            this.txtlicense.Size = new System.Drawing.Size(140, 20);
            this.txtlicense.TabIndex = 16;
            this.txtlicense.Text = "License";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(584, 253);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(140, 20);
            this.txtaddress.TabIndex = 15;
            this.txtaddress.Text = "Address";
            // 
            // txtcnic
            // 
            this.txtcnic.Location = new System.Drawing.Point(584, 201);
            this.txtcnic.Name = "txtcnic";
            this.txtcnic.Size = new System.Drawing.Size(140, 20);
            this.txtcnic.TabIndex = 14;
            this.txtcnic.Text = "CNIC";
            // 
            // comBrole
            // 
            this.comBrole.FormattingEnabled = true;
            this.comBrole.Items.AddRange(new object[] {
            "Admin",
            "Driver"});
            this.comBrole.Location = new System.Drawing.Point(584, 305);
            this.comBrole.Name = "comBrole";
            this.comBrole.Size = new System.Drawing.Size(140, 21);
            this.comBrole.TabIndex = 17;
            this.comBrole.Text = "Role";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(584, 175);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(140, 20);
            this.txtpass.TabIndex = 18;
            this.txtpass.Text = "password";
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_logout.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.Location = new System.Drawing.Point(670, 21);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(54, 19);
            this.btn_logout.TabIndex = 21;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DPCMS.Properties.Resources.admin__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(758, 419);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.comBrole);
            this.Controls.Add(this.txtlicense);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtcnic);
            this.Controls.Add(this.txtnumber);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.txtlname);
            this.Controls.Add(this.txtfname);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.TextBox txtlname;
        private System.Windows.Forms.TextBox txtnumber;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.TextBox txtlicense;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcnic;
        private System.Windows.Forms.ComboBox comBrole;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btn_logout;
    }
}