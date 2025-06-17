using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTL
{
    public class ConnectSQL
    {
        //Khai báo chuỗi kết nối
        private static string _ConnectString = @"Data Source=DESKTOP-BBQSFJ4\SQLEXPRESS;Initial Catalog=BTLHQT;Integrated Security=True";
        public static string ConnectString
        {
            get { return _ConnectString; }
        }

        //Hàm lấy thông tin theo câu lệnh truy vấn
        public static DataTable GetData(string strsql)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(ConnectString);
            try
            {
                cnn.Open();
                SqlCommand comd = new SqlCommand();
                comd.CommandType = CommandType.Text;
                comd.CommandText = strsql;
                comd.Connection = cnn;
                
                SqlDataAdapter sqlData = new SqlDataAdapter(comd);

                
                sqlData.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        public static bool ThucHien (string strsql, SqlParameter[] par = null)
        {
            bool kq = false;

            SqlConnection cnn = new SqlConnection(ConnectString);

            try
            {
                cnn.Open();
                SqlCommand comd = new SqlCommand();
                comd.CommandType = CommandType.Text;
                comd.CommandText = strsql;
                comd.Connection = cnn;
                //Nếu có tham số
                if (par != null && par.Length > 0)
                {
                    comd.Parameters.AddRange(par);
                }

                //Thực hiện công việc insert, update, delete
                kq = comd.ExecuteNonQuery() >0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return kq;
        }

        private static ActNhanVien _ActNhanVien = null;
        public static  ActNhanVien ActNhanVien
        {
            get
            {
                if (_ActNhanVien == null)
                {
                    _ActNhanVien = new ActNhanVien();
                }
                return _ActNhanVien;
            }
        }

        private static ActMayBay _actMayBay = null;
        public static ActMayBay ActMayBay
        {
            get
            {
                if(_actMayBay == null)
                {
                    _actMayBay = new ActMayBay();
                }
                return _actMayBay;
            }
        }

    }
}
