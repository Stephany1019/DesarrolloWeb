using System;

namespace database
{
    partial public class DBConnection1 : DBConnection
    {
        public DBConnection1()
        {
            InitializeComponent();
        }
        public void connection (EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("DESKTOP-9O59Q0P\SQLEXPRESS; database=base1 ; integrated security = true");
            conexion.open;
        }
    }
}