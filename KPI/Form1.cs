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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //连接数据库
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection("server=pcberp01;database=KBLIVE;user=kbinplan;pwd=kb@inplan");

            try
            {
                con.Open();
                //sqlcommand 对象的函数，返回一个SqlCommand类型的对象
                SqlCommand com = con.CreateCommand();
                //拼写语句
                com.CommandText = "exec GC_GETDATA20190524";
                //com.CommandType.;
                int count = com.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                SqlDataAdapter da1 = new SqlDataAdapter(com);
                SqlDataAdapter da2 = new SqlDataAdapter("exec GC_GETDATA20190524",con);
                DataSet ds1 = new DataSet();
                da2.Fill(ds1);
                dataGridView1.DataSource=ds1.Tables[0];
                /*
                 
                 */
            }
            catch (Exception b )
            {
                MessageBox.Show("数据库连接异常"+ b);
                throw;
            }
           
            con.Close();

            //增删改查
        }
    }
}
