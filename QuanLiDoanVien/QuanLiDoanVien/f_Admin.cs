using QuanLiDoanVien.DAO;
using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDoanVien
{
    public partial class f_Admin : Form
    {
        public List<string> listID;
        public List<string> listKhoaID;
        public List<string> listLopID;

        public f_Admin()
        {
            InitializeComponent();
            
            listID = LoadListID();
            listLopID = LoadListLopID();
            listKhoaID = LoadListKhoaID();

            cbb_KhoaInfo.DataSource = listKhoaID;
            cbb_LopInfo.DataSource = listLopID;

            LoadStudentList();
            LoadCombobox();

            // Thử chơi thôi :))
            //pictureBox1.Image = LoadPicture(@"https://st.quantrimang.com/photos/image/2019/11/06/Hinh-Nen-Zoro-25.jpg");
        }

        #region Method

        public Bitmap LoadPicture(string url)
        {
            HttpWebRequest wreq;
            HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;

                wresp = (HttpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);
            }
            catch { MessageBox.Show("Không thể kết nối tới máy chủ, hãy kiểm tra lại đường truyền!", "Error!"); }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }

            return (bmp);
        }

        // Xóa dữ liệu trên trang thông tin cá nhân
        void ClearInfo(Control ctrl)
        {
            foreach(Control item in ctrl.Controls)
            {
                if(item is TextBox || item is ComboBox || item is RichTextBox )
                {
                    item.Text = "";
                }
                else if (item is DateTimePicker)
                {
                    (item as DateTimePicker).Value = DateTime.Now;
                }
                else if(item is TableLayoutPanel)
                {
                    ClearInfo(item);
                }
            }
        }

        // Trả về True nếu Tên hoặc ID trống
        bool isError()
        {
            this.errorProvider1.Clear();
            bool error = false;
            
            if(tbx_Name.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.tbx_Name, "Tên không được để trống");
                error = true;
            }

            if(tbx_ID.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(this.tbx_ID, "MSSV không được để trống");
                error = true;
            }

            return error;
        }

        // Xử lí nếu Khóa và Lớp đưa vào không hợp lệ trước khi đưa vào CSDL
        bool XuLyKhoaLop(ref string khoa, ref string lop)
        {
            if (!listKhoaID.Contains(khoa))
            {
                if (MessageBox.Show("Hiện tại chưa có khóa " + khoa + ". Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KhoaDAO.Instance.InsertKhoa(khoa);
                }
                else
                {
                    return false;
                }
            }
            if (!listLopID.Contains(lop))
            {
                if (MessageBox.Show("Hiện tại chưa có lớp " + lop + ". Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LopDAO.Instance.InsertLop(lop, khoa);
                }
                else
                {
                    return false;
                }
            }

            try
            {
                string temp = "20" + lop.Substring(0, 2);
                if (temp != khoa)
                {
                    if (MessageBox.Show("Lớp " + lop + " không nằm trong khóa " + khoa + ". Bạn muốn tự động chuyển thành khóa " + temp, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        khoa = temp;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Khóa và lớp không phù hợp");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Thêm mới hoặc Cập nhật dữ liệu Đoàn viên vào CSDL
        /// </summary>
        /// <param name="status">
        /// status = 0: Add
        /// status = 1: Update
        /// </param>
        void SetDataToDB(int status)
        {
            #region Gán dữ liệu trên Form thông tin vào các biến
            string iD = this.tbx_ID.Text;
            if (listID.Contains(iD) && status == 0)
            {
                MessageBox.Show("ID đã tồn tại");
                return;
            }

            string hoTen = this.tbx_Name.Text;
            string khoa = this.cbb_KhoaInfo.Text;
            string lop = this.cbb_LopInfo.Text;
            DateTime? ngaySinh = dtp_NgaySinh.Value;
            string gioiTinh = rdb_Male.Checked == true ? "Nam" : "Nữ";
            string queQuan = rtb_QueQuan.Text;
            string danToc = cbb_DanToc.Text;
            string tonGiao = cbb_TonGiao.Text;
            DateTime? ngayVaoDoan = dtp_NgayVaoDoan.Value;
            string noiVaoDoan = tbx_NoiVaoDoan.Text;
            string choOHienNay = rtb_ChoOHienNay.Text;
            string sDT = tbx_SDT.Text;
            string eMail = tbx_Email.Text;

            int laDangVien = rdb_Yes.Checked ? 1 : 0;
            DateTime? duBi = dtp_DuBi.Value;
            DateTime? chinhThuc = dtp_ChinhThuc.Value;

            string chucVu = rtb_ChucVu.Text;
            string tomTat = rtb_TomTat.Text;
            string kiLuat = rtb_KiLuat.Text;
            string khenThuong = rtb_KhenThuong.Text;
            string linkAnh = "";
            #endregion

            if(!XuLyKhoaLop(ref khoa, ref lop))
            { return; }

            Student student = new Student(iD, hoTen, khoa, lop, ngaySinh, gioiTinh, queQuan, danToc, tonGiao, ngayVaoDoan,
                        noiVaoDoan, choOHienNay, sDT, eMail, laDangVien, duBi, chinhThuc, chucVu, tomTat, kiLuat, khenThuong, linkAnh);

            if(status == 0)
            {
                StudentDAO.Instance.InsertStudent(student);
                MessageBox.Show("Thêm Đoàn viên mới thành công!", "Thông báo");
            }
            else if (status == 1)
            {
                StudentDAO.Instance.UpdatetStudent(student);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }

            LoadStudentList();
        }

        // Lấy dữ liệu từ Datagridview đưa ra form
        void ShowInfo(DataGridView gridView, int row)
        {
            string id = cbb_MSSV.Text;

            tbx_ID.Text = gridView.Rows[row].Cells[0].Value.ToString();

            tbx_Name.Text = gridView.Rows[row].Cells[1].Value.ToString();

            cbb_KhoaInfo.Text = gridView.Rows[row].Cells[2].Value.ToString();

            cbb_LopInfo.Text = gridView.Rows[row].Cells[3].Value.ToString();

            try { dtp_NgaySinh.Value = (DateTime)gridView.Rows[row].Cells[4].Value; }
            catch { dtp_NgaySinh.Value = DateTime.Now; }

            try { dtp_NgayVaoDoan.Value = (DateTime)gridView.Rows[row].Cells[9].Value; }
            catch { dtp_NgayVaoDoan.Value = DateTime.Now; }

            try { dtp_DuBi.Value = (DateTime)gridView.Rows[row].Cells[15].Value; }
            catch { dtp_DuBi.Value = DateTime.Now; }

            try { dtp_ChinhThuc.Value = (DateTime)gridView.Rows[row].Cells[16].Value; }
            catch { dtp_DuBi.Value = DateTime.Now; }

            string gioitinh = gridView.Rows[row].Cells[5].Value.ToString();
            if (gioitinh == "Nam")
            {
                rdb_Male.Checked = true;
            }
            else if (gioitinh == "Nữ")
            {
                rdb_Female.Checked = true;
            }
            else
            {
                rdb_Male.Checked = rdb_Female.Checked = false;
            }

            rtb_QueQuan.Text = gridView.Rows[row].Cells[6].Value.ToString();
            cbb_DanToc.Text = gridView.Rows[row].Cells[7].Value.ToString();
            cbb_TonGiao.Text = gridView.Rows[row].Cells[8].Value.ToString();
            rtb_ChoOHienNay.Text = gridView.Rows[row].Cells[11].Value.ToString();
            tbx_SDT.Text = gridView.Rows[row].Cells[12].Value.ToString();

            if ((int)gridView.Rows[row].Cells[14].Value == 1)
            {
                rdb_Yes.Checked = true;
            }
            else if ((int)gridView.Rows[row].Cells[14].Value == 0)
            {
                rdb_No.Checked = true;
            }
            else
            {
                rdb_Yes.Checked = rdb_No.Checked = false;
            }

            rtb_ChucVu.Text = gridView.Rows[row].Cells[17].Value.ToString();
            rtb_TomTat.Text = gridView.Rows[row].Cells[18].Value.ToString();
            rtb_KiLuat.Text = gridView.Rows[row].Cells[20].Value.ToString();
            rtb_KhenThuong.Text = gridView.Rows[row].Cells[19].Value.ToString();
        }

        // Lọc dữ liệu thông qua Khóa, Lớp, Tên, ID
        void FiltList(string khoa = "", string lop = "", string ten = "", string id = "")
        {
            dtgv_Student.DataSource = StudentDAO.Instance.GetListStudentByFilt(khoa, lop, ten, id);
        }

        // Load danh sách Đoàn viên từ CSDL đưa vào DataGridview
        void LoadStudentList()
        {
            dtgv_Student.DataSource = StudentDAO.Instance.LoadStudentList();

            for (int i = 4; i < dtgv_Student.ColumnCount; i++)
            {
                this.dtgv_Student.Columns[i].Visible = false;
            }
        }


        #region Load Danh sách ID của Khóa, Lớp, Đoàn viên

        List<string> LoadListID()
        {
            List<string> list = new List<string>();

            DataTable data = StudentDAO.Instance.LoadStudentList();

            foreach (DataRow item in data.Rows)
            {
                string id = item[0].ToString();
                list.Add(id);
            }

            return list;
        }

        List<string> LoadListKhoaID()
        {
            List<string> list = KhoaDAO.Instance.GetListKhoa();
            return list;
        }

        List<string> LoadListLopID()
        {
            List<string> list = LopDAO.Instance.GetListLop();
            return list;
        }

        #endregion

        # region DataBinding dữ liệu trong các combobox
        void LoadCombobox()
        {
            LoadKhoa();
            LoadLopByKhoa();
            LoadTenByLop();
            LoadIDByName();
        }

        void LoadKhoa()
        {
            cbb_Khoa.DataSource = listKhoaID;
            cbb_Khoa.Text = "";
        }

        void LoadLopByKhoa(string idKhoa = "")
        {
            List<Lop> listLop = LopDAO.Instance.GetListLopByKhoa(idKhoa);
            cbb_Lop.DataSource = listLop;
            cbb_Lop.DisplayMember = "ID";
            cbb_Lop.Text = "";
        }

        void LoadTenByLop(string idLop = "")
        {
            List<Student> listTen = StudentDAO.Instance.GetListNameByLop(idLop);
            cbb_HoTen.DataSource = listTen;
            cbb_HoTen.DisplayMember = "HoTen";
            cbb_HoTen.Text = "";
        }

        void LoadIDByName(string name = "")
        {
            List<Student> listID = StudentDAO.Instance.GetListIDByName(name);
            cbb_MSSV.DataSource = listID;
            cbb_MSSV.DisplayMember = "ID";
            cbb_MSSV.Text = "";
        }


        #endregion


        #endregion

        #region Event

        private void rdb_Yes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                tlpn_NgayVaoDang.Show();
            }
        }

        private void rdb_No_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                tlpn_NgayVaoDang.Hide();
            }
        }

        private void cbb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            id = cb.SelectedItem.ToString();

            LoadLopByKhoa(id);
        }

        private void cbb_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            Lop selected = cbb_Lop.SelectedItem as Lop;
            id = selected.ID;

            LoadTenByLop(id);
        }

        private void cbb_HoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            Student selected = cbb_HoTen.SelectedItem as Student;
            name = selected.HoTen;

            LoadIDByName(name);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            FiltList(cbb_Khoa.Text, cbb_Lop.Text, cbb_HoTen.Text, cbb_MSSV.Text);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadStudentList();
            ClearInfo(panel3);
        }

        private void dtgv_Student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            int numrow = e.RowIndex;
            if (numrow >= 0 && numrow < gridView.RowCount - 1)
            {
                ShowInfo(gridView, numrow);
            }
            this.errorProvider1.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (isError())
            {
                return;
            }

            SetDataToDB(0);
            listID = LoadListID();
            this.errorProvider1.Clear();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (isError())
            { return; }

            if (!listID.Contains(tbx_ID.Text))
            {
                if (MessageBox.Show("Chưa có Đoàn viên có ID " + tbx_ID.Text + ". Thêm mới Đoàn viên này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SetDataToDB(0);
                    listID = LoadListID();
                }
            }
            else
            {
                SetDataToDB(1);
            }
            this.errorProvider1.Clear();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string id = tbx_ID.Text;
            if (listID.Contains(id))
            {
                StudentDAO.Instance.DeleteStudent(id);
                MessageBox.Show("Xóa thành công", "Thông báo");

                LoadStudentList();
                LoadListID();
            }
            else
            {
                MessageBox.Show("Không có Đoàn viên có ID " + id, "Thông báo");
            }
            this.errorProvider1.Clear();
            ClearInfo(panel3);
        }


        #endregion

        private void f_Admin_Load(object sender, EventArgs e)
        {
            this.dtgv_Student.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            this.dtgv_Student.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9.5f);
            this.dtgv_Student.ForeColor = Color.Black;
        }
    }
}
