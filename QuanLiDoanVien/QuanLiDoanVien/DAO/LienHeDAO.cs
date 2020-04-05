using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class LienHeDAO
    {
        private static LienHeDAO instance;

        public static LienHeDAO Instance
        {
            get { if (instance == null) instance = new LienHeDAO(); return LienHeDAO.instance; }
            private set { LienHeDAO.instance = value; }
        }

        private LienHeDAO() { }

        public List<LienHe> LoadListLienHe()
        {
            List<LienHe> listLienHe = new List<LienHe>();

            DataTable data = new DataTable();

            data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.LienHe");

            foreach(DataRow item in data.Rows)
            {
                LienHe lienHe = new LienHe(item);

                listLienHe.Add(lienHe);
            }
            return listLienHe;
        }


        public void XoaLienHe(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.LienHe WHERE id = " + id);
        }

        public void InsertLienHe(string tenLienHe, string soDienThoai)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_InsertLienHe @tenLienhe , @soDienThoai", new object[] { tenLienHe, soDienThoai });
        }

        public void UpdateLienHe(string tenLienHe, string soDienThoai, int id)
        {
            DataProvider.Instance.ExecuteQuery("EXEC USP_UpDateLienHeByID @id , @tenThanhVien , @soDienThoai", new object[] { id, tenLienHe, soDienThoai});
        }
    }
}
