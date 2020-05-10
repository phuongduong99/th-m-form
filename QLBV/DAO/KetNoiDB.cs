using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBV.DAO
{
    public class KetNoiDB
    {
        private static KetNoiDB khoa;

        public static KetNoiDB Khoa
        {
            get
            {
                if (khoa == null) khoa = new KetNoiDB { };
                return khoa;
            }

            private set
            {
                khoa = value;
            }
        }

        private KetNoiDB() { }

        private string constr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLBV;Integrated Security=True";

        // sử dụng PROC

        public DataTable LayBangPROC(string sql, object[] prm = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                if(prm != null)
                {
                    string[] listprm = sql.Split(' ');
                    int i = 0;
                    foreach(string item in listprm)
                    {
                        if(item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, prm[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(data);
                connection.Close();
                
            }
            return data;
        }

        public int ChayLenhPROC(string sql, object[] prm = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                if (prm != null)
                {
                    string[] listprm = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listprm)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, prm[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object DemSoPROC(string sql, object[] prm = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                if (prm != null)
                {
                    string[] listprm = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listprm)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, prm[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        // lệnh thường
        public DataTable LayBang(string sql)
        {
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlDataAdapter adt = new SqlDataAdapter(sql, connection);
            DataTable data = new DataTable();
            adt.Fill(data);
            connection.Close();
            return data;
        }
    }
}
