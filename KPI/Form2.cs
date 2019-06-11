using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=pcberp01;database=KBLIVE;user=kbinplan;pwd=kb@inplan");
            try
            {
                con.Open();
                //sqlcommand 对象的函数，返回一个SqlCommand类型的对象
                SqlCommand com = con.CreateCommand();
                //拼写语句
                com.CommandText = "exec Pro_GC_GET_DATA20190602  "+ "'"+textBox1.Text.ToString()+ "'";
                /*
                //com.CommandText = "exec Pro_GC_GET_DATA20190602 'HE16N20K5JA0'";
                //com.CommandType.;
                //int count = com.ExecuteNonQuery();
                //if (count > 0)
                //{
                //    MessageBox.Show("添加成功");

                //}
                //else
                //{
                //    MessageBox.Show("添加失败");
                //}
                */
                SqlDataAdapter da2 = new SqlDataAdapter(com.CommandText, con);
                DataSet ds1 = new DataSet();
                da2.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception b)
            {
                MessageBox.Show("数据库连接异常" + b);
                throw;
            }

            con.Close();

        }
    }
}
