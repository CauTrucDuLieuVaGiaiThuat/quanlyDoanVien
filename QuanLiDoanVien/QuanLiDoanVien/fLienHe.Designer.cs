namespace QuanLiDoanVien
{
    partial class fLienHe
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
            this.lvLienHe = new System.Windows.Forms.ListView();
            this.lvclTenLienHe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvclSoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbSoDienThoai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbTenLienHe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvLienHe);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btn_Update);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 366);
            this.panel1.TabIndex = 9;
            // 
            // lvLienHe
            // 
            this.lvLienHe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvclTenLienHe,
            this.lvclSoDienThoai});
            this.lvLienHe.GridLines = true;
            this.lvLienHe.HideSelection = false;
            this.lvLienHe.Location = new System.Drawing.Point(9, 3);
            this.lvLienHe.Name = "lvLienHe";
            this.lvLienHe.Size = new System.Drawing.Size(563, 223);
            this.lvLienHe.TabIndex = 15;
            this.lvLienHe.UseCompatibleStateImageBehavior = false;
            this.lvLienHe.View = System.Windows.Forms.View.Details;
            this.lvLienHe.Click += new System.EventHandler(this.lvLienHe_Click);
            // 
            // lvclTenLienHe
            // 
            this.lvclTenLienHe.Text = "Tên liên hệ";
            this.lvclTenLienHe.Width = 320;
            // 
            // lvclSoDienThoai
            // 
            this.lvclSoDienThoai.Text = "Số điện thoại";
            this.lvclSoDienThoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lvclSoDienThoai.Width = 239;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbSoDienThoai);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(1, 298);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 64);
            this.panel3.TabIndex = 10;
            // 
            // txbSoDienThoai
            // 
            this.txbSoDienThoai.Location = new System.Drawing.Point(163, 20);
            this.txbSoDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.txbSoDienThoai.Name = "txbSoDienThoai";
            this.txbSoDienThoai.Size = new System.Drawing.Size(358, 32);
            this.txbSoDienThoai.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số điện thoại:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbTenLienHe);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 233);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 57);
            this.panel2.TabIndex = 9;
            // 
            // txbTenLienHe
            // 
            this.txbTenLienHe.Location = new System.Drawing.Point(161, 13);
            this.txbTenLienHe.Margin = new System.Windows.Forms.Padding(4);
            this.txbTenLienHe.Name = "txbTenLienHe";
            this.txbTenLienHe.Size = new System.Drawing.Size(360, 32);
            this.txbTenLienHe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên liên hệ:";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.AutoSize = true;
            this.btn_Delete.BackgroundImage = global::QuanLiDoanVien.Properties.Resources.delete_button1;
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(544, 320);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(31, 30);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Tag = "";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.AutoSize = true;
            this.btn_Update.BackgroundImage = global::QuanLiDoanVien.Properties.Resources.update_button;
            this.btn_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(544, 282);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(31, 30);
            this.btn_Update.TabIndex = 12;
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.AutoSize = true;
            this.btn_Add.BackgroundImage = global::QuanLiDoanVien.Properties.Resources.add_button;
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(544, 246);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(31, 30);
            this.btn_Add.TabIndex = 13;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // fLienHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 390);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fLienHe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liên hệ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbSoDienThoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbTenLienHe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListView lvLienHe;
        private System.Windows.Forms.ColumnHeader lvclTenLienHe;
        private System.Windows.Forms.ColumnHeader lvclSoDienThoai;
    }
}