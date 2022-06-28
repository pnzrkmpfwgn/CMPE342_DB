using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        SqlConnection CN = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kurtk\OneDrive\Masaüstü\App_Data\Database1.mdf;Integrated Security=True;Connect Timeout=5");

        protected void Page_Init(object sender, EventArgs e)
        {
            CN.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand iNstr = CN.CreateCommand();
            iNstr.CommandType = CommandType.Text;
            iNstr.CommandText = "insert into myTable values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "')";
            iNstr.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand iNstr = CN.CreateCommand();
            iNstr.CommandType = CommandType.Text;
            iNstr.CommandText = "select * from myTable";
            iNstr.ExecuteNonQuery();

            DataTable DTab = new DataTable();
            SqlDataAdapter SDAdap = new SqlDataAdapter(iNstr);
            SDAdap.Fill(DTab);

            GridView1.DataSource = DTab;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand iNstr = CN.CreateCommand();
            iNstr.CommandType = CommandType.Text;
            iNstr.CommandText = "select * from myTable where brand ='" + TextBox2.Text + "'";
            iNstr.ExecuteNonQuery();

            DataTable DTab = new DataTable();
            SqlDataAdapter SDAadap = new SqlDataAdapter(iNstr);
            SDAadap.Fill(DTab);

            GridView1.DataSource = DTab;
            GridView1.DataBind();
        }
    }
}