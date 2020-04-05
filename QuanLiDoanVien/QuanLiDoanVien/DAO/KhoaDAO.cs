using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class KhoaDAO
    {
        private static KhoaDAO instance;
        public static KhoaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhoaDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private KhoaDAO() { }

        public List<string> GetListKhoa()
        {
            List<string> list = new List<string>();

            string query = "Select * from Khoa";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                string Khoa = item["ID"].ToString();
                list.Add(Khoa);
            }
            return list;
        }

        public List<Khoa> GetKhoaByID(string id = "")
        {
            List<Khoa> list = new List<Khoa>();

            string query = "Select * from Khoa where ID = N'"+id+"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Khoa Khoa = new Khoa(item);
                list.Add(Khoa);
            }

            return list;
        }

        public void InsertKhoa(string id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_AddKhoa @id , @name", new object[] { id, id });
        }
    }
}
