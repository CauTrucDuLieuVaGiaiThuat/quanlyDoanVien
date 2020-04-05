using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;
        public static LopDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LopDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private LopDAO() { }

        public List<Lop> GetListLopByKhoa(string idKhoa = "")
        {
            List<Lop> list = new List<Lop>();
            string query = "";

            if(idKhoa != "")
            {
                query = "select * from Lop where idKhoa = N'" + idKhoa + "'";
            }
            else
            {
                query = "select * from Lop";
            }

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Lop lop = new Lop(item);
                list.Add(lop);
            }

            return list;
        }

        public List<string> GetListLop()
        {
            List<string> list = new List<string>();

            string query = "Select * from Lop";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                string lop = item["ID"].ToString();
                list.Add(lop);
            }
            return list;
        }

        public void InsertLop(string id, string idKhoa)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_AddLop @id , @idKhoa", new object[] { id, idKhoa });
        }
    }
}
