using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace records_viewer_sample
{
    public partial class frmRecordViewer : Form
    {
        public frmRecordViewer()
        {
            InitializeComponent();
        }

        private string db_file_path = "";
        Database _db;
        DataTable dt;

        private void toolStripBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.mdb|";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                db_file_path = dialog.FileName;

                _db = new Database(db_file_path);

                MessageBox.Show("Successfully imported the mdb file", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(db_file_path))
            {
                MessageBox.Show("Missing mdb file", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _db.get_all_records(dt = new DataTable(), grdData);


        }
    }
}
