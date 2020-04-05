using QuanLiDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiDoanVien.DAO
{
    public class StudentDAO
    {
        private static StudentDAO instance;
        public static StudentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private StudentDAO() { }

        public DataTable LoadStudentList()
        {
            string query = "exec USP_LoadStudentList";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<Student> GetStudentByID(string id = "")
        {
            List<Student> list = new List<Student>();
            string query = "";

            if (id != "")
            {
                query = "select * from DoanVien where id = N'" + id + "'";
            }
            else
            {
                query = "select * from DoanVien";
            }


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Student doanvien = new Student(item);
                list.Add(doanvien);
            }

            return list;
        }

        public List<Student> GetListNameByLop(string idLop = "")
        {
            List<Student> list = new List<Student>();
            string query = "";

            if (idLop != "")
            {
                query = "select * from DoanVien where idLop = N'" + idLop + "'";
            }
            else
            {
                query = "select * from DoanVien";
            }


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Student doanvien = new Student(item);
                list.Add(doanvien);
            }

            return list;
        }

        public List<Student> GetListIDByName(string name = "")
        {
            List<Student> list = new List<Student>();
            string query = "";

            if (name != "")
            {
                query = "select * from DoanVien where HoTen = N'" + name + "'";
            }
            else
            {
                query = "select * from DoanVien";
            }


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Student doanvien = new Student(item);
                list.Add(doanvien);
            }

            return list;
        }


        public DataTable GetListStudentByFilt(string khoa = "", string lop = "", string name = "", string id = "")
        {
            string query = "select ID as [MSSV], HoTen as [Họ và Tên], idKhoa as [Khóa], idLop as [Lớp], " +
                "NgaySinh as [Ngày sinh]," +
                "GioiTinh as [Giới tính]," +
                "QueQuan as [Quê quán]," +
                "DanToc as [Dân tộc]," +
                "TonGiao as [Tôn giáo]," +
                "NgayVaoDoan as [Ngày vào Đoàn]," +
                "NoiVaoDoan as [Nơi vào Đoàn]," +
                "ChoOHienNay as [Chỗ ở hiện nay]," +
                "SDT as [Số điện thoại]," +
                "Email," +
                "laDangVien as [Là Đảng viên]," +
                "DuBi as [Ngày vào Đảng dự bị]," +
                "ChinhThuc as [Ngày vào Đảng chính thức]," +
                "ChucVu as [Chức vụ]," +
                "TomTat as [Tóm tắt]," +
                "KiLuat as [Kỉ luật]," +
                "KhenThuong as [Khen thưởng]," +
                "LinkAnh as [Ảnh]" +
                " from dbo.DoanVien where 1 = 1";

            if(khoa != "")
            {
                query += " and idKhoa = '" + khoa + "'";
            }

            if(lop != "")
            {
                query += " and idLop = '" + lop + "'";
            }

            if(name != "")
            {
                query += " and HoTen = N'" + name + "'";
            }

            if(id != "")
            {
                query += " and ID = '" + id + "'";
            }

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void InsertStudent(Student student)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_AddStudent @ID , @HoTen , @idKhoa , @idLop , @NgaySinh , @GioiTinh , @QueQuan , @DanToc , @TonGiao , @NgayVaoDoan , @NoiVaoDoan , @ChoOHienNay , @SDT , @Email , @laDangVien , @DuBi , @ChinhThuc , @ChucVu , @TomTat , @KiLuat , @KhenThuong , @LinkAnh",
                new object[]
                {
                    student.ID,
                    student.HoTen,
                    student.Khoa,
                    student.Lop,
                    student.NgaySinh,
                    student.GioiTinh,
                    student.QueQuan,
                    student.DanToc,
                    student.TonGiao,
                    student.NgayVaoDoan,
                    student.NoiVaoDoan,
                    student.ChoOHienNay,
                    student.SDT,
                    student.EMail,
                    student.LaDangVien,
                    student.DuBi,
                    student.ChinhThuc,
                    student.ChucVu,
                    student.TomTat,
                    student.KiLuat,
                    student.KhenThuong,
                    student.LinkAnh
                }) ;
        }

        public void UpdatetStudent(Student student)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateStudent @ID , @HoTen , @idKhoa , @idLop , @NgaySinh , @GioiTinh , @QueQuan , @DanToc , @TonGiao , @NgayVaoDoan , @NoiVaoDoan , @ChoOHienNay , @SDT , @Email , @laDangVien , @DuBi , @ChinhThuc , @ChucVu , @TomTat , @KiLuat , @KhenThuong , @LinkAnh",
                new object[]
                {
                    student.ID,
                    student.HoTen,
                    student.Khoa,
                    student.Lop,
                    student.NgaySinh,
                    student.GioiTinh,
                    student.QueQuan,
                    student.DanToc,
                    student.TonGiao,
                    student.NgayVaoDoan,
                    student.NoiVaoDoan,
                    student.ChoOHienNay,
                    student.SDT,
                    student.EMail,
                    student.LaDangVien,
                    student.DuBi,
                    student.ChinhThuc,
                    student.ChucVu,
                    student.TomTat,
                    student.KiLuat,
                    student.KhenThuong,
                    student.LinkAnh
                });
        }

        public void DeleteStudent(string id)
        {
            string query = "exec USP_DeleteStudent @id";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }
    }
}
