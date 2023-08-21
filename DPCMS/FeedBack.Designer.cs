namespace DPCMS
{
    partial class FeedBack
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcomment = new System.Windows.Forms.TextBox();
            this.pb_star1 = new System.Windows.Forms.PictureBox();
            this.pb_star2 = new System.Windows.Forms.PictureBox();
            this.pb_star4 = new System.Windows.Forms.PictureBox();
            this.pb_star3 = new System.Windows.Forms.PictureBox();
            this.pb_star5 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rating:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rating and Your FeedBack";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Comment:";
            // 
            // txtcomment
            // 
            this.txtcomment.Location = new System.Drawing.Point(43, 139);
            this.txtcomment.Multiline = true;
            this.txtcomment.Name = "txtcomment";
            this.txtcomment.Size = new System.Drawing.Size(350, 117);
            this.txtcomment.TabIndex = 9;
            this.txtcomment.TextChanged += new System.EventHandler(this.txtcomment_TextChanged);
            // 
            // pb_star1
            // 
            this.pb_star1.Image = global::DPCMS.Properties.Resources.white_star;
            this.pb_star1.Location = new System.Drawing.Point(117, 66);
            this.pb_star1.Name = "pb_star1";
            this.pb_star1.Size = new System.Drawing.Size(35, 25);
            this.pb_star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_star1.TabIndex = 10;
            this.pb_star1.TabStop = false;
            this.pb_star1.Click += new System.EventHandler(this.pb_star1_Click);
            // 
            // pb_star2
            // 
            this.pb_star2.Image = global::DPCMS.Properties.Resources.white_star;
            this.pb_star2.Location = new System.Drawing.Point(158, 66);
            this.pb_star2.Name = "pb_star2";
            this.pb_star2.Size = new System.Drawing.Size(35, 25);
            this.pb_star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_star2.TabIndex = 11;
            this.pb_star2.TabStop = false;
            this.pb_star2.Click += new System.EventHandler(this.pb_star2_Click);
            // 
            // pb_star4
            // 
            this.pb_star4.Image = global::DPCMS.Properties.Resources.white_star;
            this.pb_star4.Location = new System.Drawing.Point(241, 66);
            this.pb_star4.Name = "pb_star4";
            this.pb_star4.Size = new System.Drawing.Size(35, 25);
            this.pb_star4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_star4.TabIndex = 13;
            this.pb_star4.TabStop = false;
            this.pb_star4.Click += new System.EventHandler(this.pb_star4_Click);
            // 
            // pb_star3
            // 
            this.pb_star3.Image = global::DPCMS.Properties.Resources.white_star;
            this.pb_star3.Location = new System.Drawing.Point(200, 66);
            this.pb_star3.Name = "pb_star3";
            this.pb_star3.Size = new System.Drawing.Size(35, 25);
            this.pb_star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_star3.TabIndex = 12;
            this.pb_star3.TabStop = false;
            this.pb_star3.Click += new System.EventHandler(this.pb_star3_Click);
            // 
            // pb_star5
            // 
            this.pb_star5.Image = global::DPCMS.Properties.Resources.white_star;
            this.pb_star5.Location = new System.Drawing.Point(283, 66);
            this.pb_star5.Name = "pb_star5";
            this.pb_star5.Size = new System.Drawing.Size(35, 25);
            this.pb_star5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_star5.TabIndex = 14;
            this.pb_star5.TabStop = false;
            this.pb_star5.Click += new System.EventHandler(this.pb_star5_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(318, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_logout.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.Location = new System.Drawing.Point(46, 279);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(54, 19);
            this.btn_logout.TabIndex = 20;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DPCMS.Properties.Resources.happy_taxi_cartoon1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(471, 318);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pb_star5);
            this.Controls.Add(this.pb_star4);
            this.Controls.Add(this.pb_star3);
            this.Controls.Add(this.pb_star2);
            this.Controls.Add(this.pb_star1);
            this.Controls.Add(this.txtcomment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FeedBack";
            this.Text = "FeedBack";
            ((System.ComponentModel.ISupportInitialize)(this.pb_star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_star5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcomment;
        private System.Windows.Forms.PictureBox pb_star1;
        private System.Windows.Forms.PictureBox pb_star2;
        private System.Windows.Forms.PictureBox pb_star4;
        private System.Windows.Forms.PictureBox pb_star3;
        private System.Windows.Forms.PictureBox pb_star5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_logout;
    }
}