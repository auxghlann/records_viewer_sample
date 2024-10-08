using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace records_viewer_sample
{
    public class Database
    {
    
        private string connection_str, conn;
        private OleDbConnection connection;
        private OleDbDataAdapter adapter;



        public Database(string db_file_path)
        {
            this.connection_str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db_file_path;
            //this.conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\khest\\Documents\\C#\\app_dev\\records_crud_sample\\db\\records.mdb";

            this.connection = new OleDbConnection(connection_str);
        }


        public OleDbConnection Connection
        {
            get { return this.connection; }
        }


        public void get_all_records(DataTable dt, DataGridView grdData)
        {

            string query = "SELECT * from records";

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            using (adapter = new OleDbDataAdapter(query, this.connection))
            {
                adapter.Fill(dt);
                grdData.DataSource = dt;

                Connection.Close();
            }
        }

    }
}
