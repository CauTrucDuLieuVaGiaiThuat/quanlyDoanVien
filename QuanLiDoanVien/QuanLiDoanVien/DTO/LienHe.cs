using System.Data;

namespace QuanLiDoanVien.DTO
{
    public class LienHe
    {
        private int id;
        private string tenLienHe;
        private string soDienThoai;

        public int Id { get => id; set => id = value; }
        public string TenLienHe { get => tenLienHe; set => tenLienHe = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        public LienHe(int id, string tenLienHe, string soDienThoai)
        {
            this.Id = id;
            this.TenLienHe = tenLienHe;
            this.SoDienThoai = soDienThoai;
        }

        public LienHe(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenLienHe = row["tenThanhVien"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
        }
    }
}
