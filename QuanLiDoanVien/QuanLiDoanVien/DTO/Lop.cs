using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DTO
{
    public class Lop
    {
        private string iD;
        private string iDKhoa;

        public string ID { get => iD; set => iD = value; }
        public string IDKhoa { get => iDKhoa; set => iDKhoa = value; }

        public Lop(string id, string iDKhoa)
        {
            this.ID = id;
            this.IDKhoa = iDKhoa;
        }

        public Lop(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.IDKhoa = row["idKhoa"].ToString();
        }
    }
}
