using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace _Git_
{
    public partial class JanSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
            SqlCommand cmd = new SqlCommand("SELECT * FROM jan_search where lotno LIKE '%'+@lotno+'%' OR invoiceno LIKE '%'+@invoiceno+'%'", con);
            con.Open();
            cmd.Parameters.AddWithValue("lotno", TxtSearch.Text);
            cmd.Parameters.AddWithValue("invoiceno", TxtSearch.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


    }
}