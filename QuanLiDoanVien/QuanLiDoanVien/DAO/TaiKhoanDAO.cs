using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set { TaiKhoanDAO.instance = value; }
        }

        private TaiKhoanDAO() { }

        public bool DangNhap(string tenTaiKhoan, string matKhau)
        {
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExecuteQuery("EXEC USP_DangNhap @tenTaiKhoan , @matKhau", new object[] { tenTaiKhoan, matKhau });

            return data.Rows.Count > 0;
        }
    }
}
