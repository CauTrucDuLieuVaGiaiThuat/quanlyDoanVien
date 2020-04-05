using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DTO
{
    public class ThongTinSuKien
    {
        private int iD;
        private string tenSuKien;
        private string noiDungchiTiet;
        private DateTime thoiGianBatDau;
        private DateTime thoiGianKetThuc;
        private string soLuongSinhVien;
        private string diaDiemToChuc;
        private string hoTroMuonDo;
        private int idLienHe;
        private string tenLienHe;
        private string soDienThoai;

        public int ID { get => iD; set => iD = value; }
        public string TenSuKien { get => tenSuKien; set => tenSuKien = value; }
        public string NoiDungchiTiet { get => noiDungchiTiet; set => noiDungchiTiet = value; }
        public DateTime ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public DateTime ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public string SoLuongSinhVien { get => soLuongSinhVien; set => soLuongSinhVien = value; }
        public string DiaDiemToChuc { get => diaDiemToChuc; set => diaDiemToChuc = value; }
        public string HoTroMuonDol { get => hoTroMuonDo; set => hoTroMuonDo = value; }
        public int IdLienHe { get => idLienHe; set => idLienHe = value; }
        public string TenLienHe { get => tenLienHe; set => tenLienHe = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        public ThongTinSuKien(int iD, string tenSuKien, string noiDungChiTiet, DateTime thoiGianBatDau,
                         DateTime thoiGianKetThuc, string soLuongSinhVien, string diaDiemToChuc, string hoTroMuonDo, int idLienHe
                            , string tenLienHe, string soDienThoai)
        {
            this.ID = iD;
            this.TenSuKien = tenSuKien;
            this.NoiDungchiTiet = noiDungChiTiet;
            this.ThoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            this.SoLuongSinhVien = soLuongSinhVien;
            this.DiaDiemToChuc = diaDiemToChuc;
            this.HoTroMuonDol = hoTroMuonDo;
            this.IdLienHe = idLienHe;
            this.TenLienHe = tenLienHe;
            this.SoDienThoai = soDienThoai;
        }

        public ThongTinSuKien(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.TenSuKien = row["tenSuKien"].ToString();
            this.NoiDungchiTiet = row["noiDungChiTiet"].ToString();
            this.ThoiGianBatDau = Convert.ToDateTime(row["thoiGianBatDau"].ToString());
            this.thoiGianKetThuc = Convert.ToDateTime(row["thoiGianKetThuc"].ToString());
            this.SoLuongSinhVien = row["soLuongSinhVien"].ToString();
            this.DiaDiemToChuc = row["diaDiemToChuc"].ToString();
            this.HoTroMuonDol = row["hoTroMuonDo"].ToString();
            this.IdLienHe = (int)row["idLienHe"];
            this.TenLienHe = row["tenThanhVien"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
        }
    }
}
