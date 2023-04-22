using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_sqlite.Model;

namespace WpfApp_sqlite.Database
{
    public class My_database
    {
        private static string path = "database.sqlite";
        private SQLiteConnection con = new SQLiteConnection(@"Data Source= "+ path);
        public void Create_datatable()
        {
            // tạo datatabse 
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
            else {
                Debug.WriteLine("Đã tồn tại sqlite");
                return;
            }
        }
        public void Delete_datatable()
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        public void Create_table(string name)
        {
            Create_datatable();
            if (name != null)
            {
                con.Open();
                string query_create_table = "create table " + name + " (email varchar(50),pass varchar(50),emailkhoiphuc varchar(50),useragent varchar(450),proxy varchar(120),sdt varchar(20))";
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = query_create_table;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public int Add_data(string name_table, Profile profile)
        {
            string emailkp = null;
            string useragent = null;
            string proxy = null;
            string sdt = null;
            con.Open();
            SQLiteCommand qLiteCommand = con.CreateCommand();
            qLiteCommand.CommandText = "INSERT INTO profile(email,pass,emailkhoiphuc,useragent,proxy,sdt) VALUES(@email,@pass,@emailkhoiphuc,@useragent,@proxy,@sdt)";
            qLiteCommand.Parameters.AddWithValue("@email",profile.Email);
            qLiteCommand.Parameters.AddWithValue("@pass",profile.Password);
            if(!String.IsNullOrEmpty(profile.Emailkhoiphuc)) {
                emailkp = profile.Emailkhoiphuc;
            }
            if(!String.IsNullOrEmpty(profile.UserAgent))
            {
                useragent = profile.UserAgent;
            }
            if(!String.IsNullOrEmpty(profile.Proxy))
            { proxy = profile.Proxy; }
            if(!String.IsNullOrEmpty(profile.Sodienthoai))
            {
                sdt = profile.Sodienthoai;
            }
            qLiteCommand.Parameters.AddWithValue("@emailkhoiphuc", profile.Emailkhoiphuc);
            qLiteCommand.Parameters.AddWithValue("@proxy", profile.Proxy);
            qLiteCommand.Parameters.AddWithValue("@useragent", profile.UserAgent);
            qLiteCommand.Parameters.AddWithValue("@sdt", profile.Sodienthoai);
            int result = qLiteCommand.ExecuteNonQuery();
            con.Close();
            if (result == 0)
            {
                return 0;
            }
            else { return 1; }
        }

        public List<Profile> Loaddata(string table)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM " + table;
            var data_return = cmd.ExecuteReader();
            List<Profile> list = new List<Profile>();
                while (data_return.Read())
                {
                    Debug.WriteLine(data_return.ToString());
                    Profile profile = new Profile();
                    profile.Email = data_return.GetString(0);
                    profile.Password = data_return.GetString(1);
                    /*
                    profile.Emailkhoiphuc = data_return.GetString(2);
                    profile.UserAgent = data_return.GetString(3);
                    profile.Proxy = data_return.GetString(4);
                    profile.Sodienthoai = data_return.GetString(5);
                    */
                    list.Add(profile);
                }
            return list;
        }
        public int Update_data(string table,string var_update ,string email)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE profile Set pass = @pass where email = @email";
            cmd.Parameters.AddWithValue ("@pass", var_update);
            cmd.Parameters.AddWithValue ("@email", email);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Delete_data(string email)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM profile where email = @email";
            cmd.Parameters.AddWithValue("@email", email);
            int delete = cmd.ExecuteNonQuery();
            con.Close();
            return delete;
        }
    }
}
