using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DTO
{
    public class Student
    {
        private string iD;
        private string hoTen;
        private string khoa;
        private string lop;
        private DateTime? ngaySinh;
        private string gioiTinh;
        private string queQuan;
        private string danToc;
        private string tonGiao;
        private DateTime? ngayVaoDoan;
        private string noiVaoDoan;
        private string choOHienNay;
        private string sDT;
        private string eMail;
        private int laDangVien;
        private DateTime? duBi;
        private DateTime? chinhThuc;
        private string chucVu;
        private string tomTat;
        private string kiLuat;
        private string khenThuong;
        private string linkAnh;

        #region Proterties

        public string ID { get => iD; set => iD = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string Lop { get => lop; set => lop = value; }
        public DateTime? NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string DanToc { get => danToc; set => danToc = value; }
        public string TonGiao { get => tonGiao; set => tonGiao = value; }
        public DateTime? NgayVaoDoan { get => ngayVaoDoan; set => ngayVaoDoan = value; }
        public string NoiVaoDoan { get => noiVaoDoan; set => noiVaoDoan = value; }
        public string ChoOHienNay { get => choOHienNay; set => choOHienNay = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public int LaDangVien { get => laDangVien; set => laDangVien = value; }
        public DateTime? DuBi { get => duBi; set => duBi = value; }
        public DateTime? ChinhThuc { get => chinhThuc; set => chinhThuc = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string TomTat { get => tomTat; set => tomTat = value; }
        public string KiLuat { get => kiLuat; set => kiLuat = value; }
        public string KhenThuong { get => khenThuong; set => khenThuong = value; }
        public string LinkAnh { get => linkAnh; set => linkAnh = value; }

        #endregion

        public Student(string iD, string hoTen, string khoa, string lop, DateTime? ngaySinh, string gioiTinh, string queQuan, string danToc, string tonGiao, DateTime? ngayVaoDoan,
                        string noiVaoDoan, string choOHienNay, string sDT, string eMail, int laDangVien, DateTime? duBi, DateTime? chinhThuc, string chucVu, string tomTat, string kiLuat, string khenThuong, string linkAnh)
        {
            this.ID = iD;
            this.HoTen = hoTen;
            this.Khoa = khoa;
            this.Lop = lop;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.QueQuan = queQuan;
            this.DanToc = danToc;
            this.TonGiao = tonGiao;
            this.NgayVaoDoan = ngayVaoDoan;
            this.NoiVaoDoan = noiVaoDoan;
            this.ChoOHienNay = choOHienNay;
            this.SDT = sDT;
            this.EMail = eMail;
            this.LaDangVien = laDangVien;
            this.ChinhThuc = chinhThuc;
            this.DuBi = duBi;
            this.ChucVu = chucVu;
            this.TomTat = tomTat;
            this.KiLuat = kiLuat;
            this.KhenThuong = khenThuong;
            this.LinkAnh = linkAnh;
        }

        public Student(DataRow row)
        {
            this.ID = row["ID"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.Khoa = row["idKhoa"].ToString();
            this.Lop = row["idLop"].ToString();

            var temp = row["NgaySinh"];
            if(temp.ToString() != "")
            {
                this.NgaySinh = (DateTime?)temp;
            }


            this.GioiTinh = row["GioiTinh"].ToString();
            this.QueQuan = row["QueQuan"].ToString();
            this.DanToc = row["DanToc"].ToString();
            this.TonGiao = row["TonGiao"].ToString();

            temp = row["NgayVaoDoan"];
            if (temp.ToString() != "")
            {
                this.NgayVaoDoan = (DateTime?)temp;
            }

            this.NoiVaoDoan = row["NoiVaoDoan"].ToString();
            this.ChoOHienNay = row["ChoOHienNay"].ToString();
            this.SDT = row["SDT"].ToString();
            this.EMail = row["Email"].ToString();
            this.LaDangVien = (int)row["laDangVien"];

            temp = row["DuBi"];
            if (temp.ToString() != "")
            {
                this.DuBi = (DateTime?)temp;
            }

            temp = row["ChinhThuc"];
            if (temp.ToString() != "")
            {
                this.ChinhThuc = (DateTime?)temp;
            }

            this.ChucVu = row["ChucVu"].ToString();
            this.TomTat = row["TomTat"].ToString();
            this.KiLuat = row["KiLuat"].ToString();
            this.KhenThuong = row["KhenThuong"].ToString();
            this.LinkAnh = row["LinkAnh"].ToString();
        }
    }
}
