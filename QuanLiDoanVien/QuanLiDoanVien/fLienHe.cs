using QuanLiDoanVien.DAO;
using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDoanVien
{
    public partial class fLienHe : Form
    {
        public fLienHe()
        {
            InitializeComponent();

            LoadLienHe();

            btn_Delete.Tag = -1;
            btn_Update.Tag = -1;
        }

        void LoadLienHe()
        {
            lvLienHe.Items.Clear();
            List<LienHe> list = LienHeDAO.Instance.LoadListLienHe();
            int i = 0;

            foreach(LienHe item in list)
            {
                ListViewItem lv = new ListViewItem(item.TenLienHe);

                lv.SubItems.Add(item.SoDienThoai);
                lvLienHe.Items.Add(lv);

                lvLienHe.Items[i].SubItems[0].Tag = item.Id;

                i++;
            }

            txbTenLienHe.Text = "";
            txbSoDienThoai.Text = "";
        }

        private void lvLienHe_Click(object sender, EventArgs e)
        {
            txbTenLienHe.Text = lvLienHe.SelectedItems[0].SubItems[0].Text;
            txbSoDienThoai.Text = lvLienHe.SelectedItems[0].SubItems[1].Text;

            btn_Delete.Tag = lvLienHe.SelectedItems[0].SubItems[0].Tag;
            btn_Update.Tag = lvLienHe.SelectedItems[0].SubItems[0].Tag;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if((int)btn_Delete.Tag == -1)
            {
                MessageBox.Show("Cần chọn liên hệ trước khi xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LienHeDAO.Instance.XoaLienHe((int)btn_Delete.Tag);

            btn_Delete.Tag = -1;
            LoadLienHe();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            LienHeDAO.Instance.InsertLienHe(txbTenLienHe.Text, txbSoDienThoai.Text);

            LoadLienHe();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

            if ((int)btn_Delete.Tag == -1)
            {
                MessageBox.Show("Cần chọn liên hệ trước khi cập nhật!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LienHeDAO.Instance.UpdateLienHe(txbTenLienHe.Text, txbSoDienThoai.Text, (int)btn_Delete.Tag);

            btn_Delete.Tag = -1;
            LoadLienHe();
        }
    }
} 
