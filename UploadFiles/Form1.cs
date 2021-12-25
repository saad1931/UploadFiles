using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UploadFiles
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CT235QF;Initial Catalog=UploadFiles;Integrated Security=True");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = true;
            op1.ShowDialog();
            int count = 0;

            foreach (string s in op1.FileNames)
            {
                
                string[] f = s.Split('\\');
                string fn = f[(f.Length) - 1];
                string dest = @" D:\Small Projects\UploadFiles\UploadFiles\Drive\" + fn;
                File.Copy(s, dest, true);
                string q = "insert into UploadFiles values('" + fn + "','" + dest + "')";
                cmd = new SqlCommand(q, con);
                con.Open();
                cmd.ExecuteNonQuery();
                count++;
                con.Close();

            }

            MessageBox.Show("Successfully Uploaded!");



        }
    }
}


