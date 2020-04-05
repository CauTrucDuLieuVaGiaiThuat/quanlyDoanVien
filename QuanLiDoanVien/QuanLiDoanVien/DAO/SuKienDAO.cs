using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class SuKienDAO
    {
        private static SuKienDAO instance;

        public static SuKienDAO Instance
        {
            get { if (instance == null) instance = new SuKienDAO(); return SuKienDAO.instance; }
            private set { SuKienDAO.instance = value; }
        }

        private SuKienDAO() { }

        public List<SuKien> GetSuKienByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            List<SuKien> list = new List<SuKien>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetSuKienByDate @ngayBatDau , @ngayKetThuc ", new object[] { ngayBatDau, ngayKetThuc });

            foreach (DataRow item in data.Rows)
            {
                SuKien suKien = new SuKien(item);
                list.Add(suKien);
            }
            return list;
        }

        public List<SuKien> GetSuKienByOneDate(DateTime ngayCanXet)
        {
            List<SuKien> list = new List<SuKien>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetSuKienByOneDate @ngayCanXet ", new object[] { ngayCanXet});

            foreach (DataRow item in data.Rows)
            {
                SuKien suKien = new SuKien(item);
                list.Add(suKien);
            }
            return list;
        }

        public ThongTinSuKien GetSuKienByID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.SuKien, dbo.LienHe WHERE SuKien.idLienHe = LienHe.id AND SuKien.id = " + id);

            if (data.Rows.Count > 0)
            {
                ThongTinSuKien thongTin = new ThongTinSuKien(data.Rows[0]);
                return thongTin;
            }

            return null;
        }

        public void InsertSuKien(string tenSuKien, string noiDungChiTiet, DateTime thoiGianBatDau,
                         DateTime thoiGianKetThuc, string soLuongSinhVien, string diaDiemToChuc, string hoTroMuonDo, int idLienHe)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_InsertSuKien @tenSuKien , @noiDungChiTiet , @thoiGianBatDau , @thoiGianKetThuc , @soLuongSinhVien , @diaDiemToChuc , @hoTroMuonDo , @idLienHe",
                                                          new object[] {tenSuKien , noiDungChiTiet , thoiGianBatDau , thoiGianKetThuc , soLuongSinhVien , diaDiemToChuc , hoTroMuonDo , idLienHe });
        }

        public void DeleteSuKienByID(int id)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_DeleteSuKienByID @idSuKien", new object[] { id });
        }

        public void UpdateSuKienByID(int id, string tenSuKien, string noiDungChiTiet, DateTime thoiGianBatDau,
                         DateTime thoiGianKetThuc, string soLuongSinhVien, string diaDiemToChuc, string hoTroMuonDo, int idLienHe)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_UpDateSuKienByID @id ,  @tenSuKien , @noiDungChiTiet , @thoiGianBatDau , @thoiGianKetThuc , @soLuongSinhVien , @diaDiemToChuc , @hoTroMuonDo , @idLienHe",
                                                          new object[] { id, tenSuKien, noiDungChiTiet, thoiGianBatDau, thoiGianKetThuc, soLuongSinhVien, diaDiemToChuc, hoTroMuonDo, idLienHe });
        }

    }
}
