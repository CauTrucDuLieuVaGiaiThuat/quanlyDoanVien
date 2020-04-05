using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DTO
{
    public class Khoa
    {
        public Khoa(string id, string name = "")
        {
            this.ID = id;
            this.Name = name;
        }

        public Khoa(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["name"].ToString();
        }

        private string iD;
        private string name;

        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
