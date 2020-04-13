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
    public partial class fSuKien : Form
    {
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public fSuKien()
        {
            InitializeComponent();

            LoadMatrix();
            LoadDateTimePickerFilter();
            AddNumberIntoMatrixByDate(dtpkNgayLichThang.Value);

            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);

            LoadLienHe();
        }

        #region Menthods
        void LoadLienHe()
        {
            cbNguoiPhuTrach.DataSource = LienHeDAO.Instance.LoadListLienHe();
            cbNguoiPhuTrach.DisplayMember = "tenLienHe";

            txbSoDienThoai.DataBindings.Add(new Binding("Text", cbNguoiPhuTrach.DataSource, "soDienThoai"));

        }
        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight};
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.margin, oldBtn.Location.Y);
                    btn.Click += Btn_Click;

                    pnThang.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldBtn.Location.Y + Cons.dateButtonHeight) };
            }

            //SetDefaultDate();
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            DateTime endDate = useDate.AddMonths(1).AddDays(-1);

            int line = 0;

            for (int i = 1; i <= endDate.Day; i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (isEqualDate(useDate, DateTime.Now))
                {                    
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Blue;
                    btn.FlatAppearance.BorderSize = 2;
                }

                if (isEqualDate(useDate, date))
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Green;
                    btn.FlatAppearance.BorderSize = 3;
                }

                if (column >= 6)
                    line++;

                string text = LoadToolTipForDate(useDate);
                if (text != "")
                {
                    toolTipLichThang.SetToolTip(btn, text);
                    btn.BackColor = Color.Aqua;
                }

                useDate = useDate.AddDays(1);
            }
        }

        string LoadToolTipForDate(DateTime date)
        {
            List<SuKien> suKien = new List<SuKien>();
            suKien = SuKienDAO.Instance.GetSuKienByOneDate(date);
            string text = "";

            foreach (SuKien item in suKien)
            {
                text += item.TenSuKien + "\n";
            }

            return text;
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.FlatAppearance.BorderColor = Color.White;
                }
            }
        }
        void SetDefaultDate()
        {
            dtpkNgayLichThang.Value = DateTime.Now;
        }

        void LoadDateTimePickerFilter()
        {
            int day = dateOfWeek.IndexOf(dtpkNgayBatDauLoc.Value.DayOfWeek.ToString());

            DateTime today = new DateTime();
            today = dtpkNgayKetThucLoc.Value.AddDays(-day);

            dtpkNgayBatDauLoc.Value = new DateTime(today.Year, today.Month, today.Day);
            dtpkNgayKetThucLoc.Value = today.AddDays(6);
        }

        void LoadSuKienByDate(DateTime ngayBatDay, DateTime ngayKetThuc)
        {
            flpnSuKien.Controls.Clear();

            List<SuKien> list = new List<SuKien>();
            list = SuKienDAO.Instance.GetSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);

            foreach (SuKien item in list)
            {

                FlowLayoutPanel flpn = new FlowLayoutPanel { Width = flpnSuKien.Width, Height = 50 };
                TextBox txb = new TextBox { Text = item.TenSuKien, Width = 210, ReadOnly = true };
                DateTimePicker dtpkBatDau = new DateTimePicker { Value = item.ThoiGianBatDau, Format = DateTimePickerFormat.Custom, CustomFormat = "hh:mm tt 'ngày' dd/MM/yyyy", Width = 270 };
                Button btnChitietSuKien = new Button { Width = 80, Height = 36, Text = "Chi tiết", Tag = item.ID };
                btnChitietSuKien.Click += BtnChitietSuKien_Click;

                flpn.Controls.Add(txb);
                flpn.Controls.Add(dtpkBatDau);
                flpn.Controls.Add(btnChitietSuKien);

                flpnSuKien.Controls.Add(flpn);
            }
            AddNumberIntoMatrixByDate(dtpkNgayLichThang.Value);
        }
        #endregion

        #region Events
        private void BtnChitietSuKien_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            ThongTinSuKien thongTin = SuKienDAO.Instance.GetSuKienByID((int)btn.Tag);

            txbTenSuKien.Text = thongTin.TenSuKien;
            rtNoiDungSuKien.Text = thongTin.NoiDungchiTiet;
            dtpkNgayBatDau.Value = thongTin.ThoiGianBatDau;
            dtpkNgayKetThuc.Value = thongTin.ThoiGianKetThuc;
            rtThanhPhan.Text = thongTin.SoLuongSinhVien;
            rtDiaDiem.Text = thongTin.DiaDiemToChuc;
            rtHoTroMuonDo.Text = thongTin.HoTroMuonDol;
            cbNguoiPhuTrach.Text = thongTin.TenLienHe;
            txbSoDienThoai.Text = thongTin.SoDienThoai;

            btnCapNhatSuKien.Tag = thongTin.ID;
            btnXoaSuKien.Tag = thongTin.ID;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
                return;
            DateTime dateTime = new DateTime(dtpkNgayLichThang.Value.Year, dtpkNgayLichThang.Value.Month, Convert.ToInt32(btn.Text));
            dtpkNgayLichThang.Value = dateTime;

            dtpkNgayBatDauLoc.Value = dateTime;
            dtpkNgayKetThucLoc.Value = dateTime;
            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);
            tcSuKien.SelectedTab = tcSuKien.TabPages[1];
        }

        private void dtpkNgayLichThang_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnHomNayLichThang_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void btnThangTruoc_Click(object sender, EventArgs e)
        {
            dtpkNgayLichThang.Value = dtpkNgayLichThang.Value.AddMonths(-1);
        }
        private void btnThangSau_Click(object sender, EventArgs e)
        {
            dtpkNgayLichThang.Value = dtpkNgayLichThang.Value.AddMonths(1);
        }

        private void btnLocSuKien_Click(object sender, EventArgs e)
        {
            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);
        }
        private void btnThemSuKien_Click(object sender, EventArgs e)
        {
            LienHe lienHe = cbNguoiPhuTrach.SelectedItem as LienHe;

            SuKienDAO.Instance.InsertSuKien(txbTenSuKien.Text, rtNoiDungSuKien.Text, dtpkNgayBatDau.Value, dtpkNgayKetThuc.Value,
                rtThanhPhan.Text, rtDiaDiem.Text, rtHoTroMuonDo.Text, lienHe.Id);

            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);
        }

        private void btnCapNhatSuKien_Click(object sender, EventArgs e)
        {
            if ((int)btnCapNhatSuKien.Tag == -1)
            {
                MessageBox.Show("Cần chọn sự kiện trước khi cập nhật!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LienHe lienHe = cbNguoiPhuTrach.SelectedItem as LienHe;

            SuKienDAO.Instance.UpdateSuKienByID((int)btnCapNhatSuKien.Tag, txbTenSuKien.Text, rtNoiDungSuKien.Text, dtpkNgayBatDau.Value, dtpkNgayKetThuc.Value,
                rtThanhPhan.Text, rtDiaDiem.Text, rtHoTroMuonDo.Text, lienHe.Id);

            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);
        }

        private void btnXoaSuKien_Click(object sender, EventArgs e)
        {
            if ((int)btnXoaSuKien.Tag == -1)
            {
                MessageBox.Show("Cần chọn sự kiện trước khi xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SuKienDAO.Instance.DeleteSuKienByID((int)btnXoaSuKien.Tag);
            btnXoaSuKien.Tag = -1;
            LoadSuKienByDate(dtpkNgayBatDauLoc.Value, dtpkNgayKetThucLoc.Value);
        }

        private void fSuKien_Load(object sender, EventArgs e)
        {
            btnCapNhatSuKien.Tag = -1;
            btnXoaSuKien.Tag = -1;
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            fLienHe f = new fLienHe();

            f.ShowDialog();

            txbSoDienThoai.DataBindings.Clear();
            LoadLienHe();
        }

        private void đoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_Admin f = new f_Admin();
            f.ShowDialog();
        }


        #endregion
    }
}
