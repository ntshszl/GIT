using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _Git_
{
    public partial class ByWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

                //populate dropdown
                if (!this.IsPostBack)
                {
                    string query = "SELECT DISTINCT warehouse FROM jan_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM feb_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM mar_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM apr_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM may_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM jun_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM jul_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM aug_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM sep_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM oct_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM nov_sum WHERE Month(date) = Month(getdate())" +
                        "UNION ALL SELECT DISTINCT warehouse FROM dec_sum WHERE Month(date) = Month(getdate())";
                    DataTable dt = GetData1(query);
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "warehouse";
                    DropDownList1.DataValueField = "warehouse";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Select Warehouse", ""));
                }
            }
        }



        //summary each warehouse
        private static DataTable GetData1(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        protected void PopulateChart1(object sender, EventArgs e)
        {
            //incoming bar graph
            Chart2.Visible = DropDownList1.SelectedValue != "";
            string queryy = string.Format("SELECT date, sum(incoming) as incoming FROM " +
                "(SELECT date, incoming FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                ")incoming GROUP BY date", DropDownList1.SelectedValue);
            DataTable dtt = GetData1(queryy);
            Chart2.DataSource = dtt;
            Chart2.ChartAreas[0].AxisX.Interval = 1;
            Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart2.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


            //outgoing bar graph
            Chart3.Visible = DropDownList1.SelectedValue != "";
            string quer = string.Format("SELECT date, sum(outgoing) as outgoing FROM " +
                "(SELECT date, outgoing FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, outgoing FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                ")out GROUP BY date", DropDownList1.SelectedValue);
            DataTable d = GetData1(quer);
            Chart3.DataSource = d;
            Chart3.ChartAreas[0].AxisX.Interval = 1;
            Chart3.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart3.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart3.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


            //summary all in out total
            Chart4.Visible = DropDownList1.SelectedValue != "";
            string query = string.Format("SELECT date, sum(incoming) as incoming, sum(outgoing) as outgoing, sum(totalstorage) as totalstorage, sum(maximumcapacity) as maximumcapacity FROM " +
                "(SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                ")summ GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt = GetData1(query);
            Chart4.DataSource = dt;
            Chart4.ChartAreas[0].AxisX.Interval = 1;
            Chart4.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart4.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart4.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart4.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart4.DataBind();


            //accord
            Chart5.Visible = DropDownList1.SelectedValue != "";
            string query1 = string.Format("SELECT date, sum(accord) as accord FROM " +
                "(SELECT date, accord FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, accord FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ") accord GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt1 = GetData1(query1);
            Chart5.DataSource = dt1;
            Chart5.ChartAreas[0].AxisX.Interval = 1;
            Chart5.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart5.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart5.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart5.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart5.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart5.DataBind();


            //civic
            Chart6.Visible = DropDownList1.SelectedValue != "";
            string query2 = string.Format("SELECT date, sum(civic) as civic FROM " +
                "(SELECT date, civic FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, civic FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")civic GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt2 = GetData1(query2);
            Chart6.DataSource = dt2;
            Chart6.ChartAreas[0].AxisX.Interval = 1;
            Chart6.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart6.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart6.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart6.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart6.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart6.DataBind();

            //jazz
            Chart1.Visible = DropDownList1.SelectedValue != "";
            string query6 = string.Format("SELECT date, sum(jazz) as jazz FROM " +
                "(SELECT date, jazz FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazz FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")jazz GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt6 = GetData1(query6);
            Chart1.DataSource = dt6;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart1.DataBind();

            //city
            Chart9.Visible = DropDownList1.SelectedValue != "";
            string query9 = string.Format("SELECT date, sum(city) as city FROM " +
                "(SELECT date, city FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, city FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")city GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt9 = GetData1(query9);
            Chart9.DataSource = dt9;
            Chart9.ChartAreas[0].AxisX.Interval = 1;
            Chart9.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart9.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart9.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart9.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart9.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart9.DataBind();

            //crv
            Chart14.Visible = DropDownList1.SelectedValue != "";
            string query10 = string.Format("SELECT date, sum(crv) as crv FROM " +
                "(SELECT date, crv FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, crv FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")crv GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt10 = GetData1(query10);
            Chart14.DataSource = dt10;
            Chart14.ChartAreas[0].AxisX.Interval = 1;
            Chart14.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart14.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart14.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart14.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart14.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart14.DataBind();

            //hrv
            Chart7.Visible = DropDownList1.SelectedValue != "";
            string query3 = string.Format("SELECT date, sum(hrv) as hrv FROM " +
                "(SELECT date, hrv FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrv FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")hrv GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt3 = GetData1(query3);
            Chart7.DataSource = dt3;
            Chart7.ChartAreas[0].AxisX.Interval = 1;
            Chart7.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart7.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart7.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart7.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart7.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart7.DataBind();


            //brv
            Chart8.Visible = DropDownList1.SelectedValue != "";
            string query4 = string.Format("SELECT date, sum(brv) as brv FROM " +
                "(SELECT date, brv FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, brv FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")brv GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt4 = GetData1(query4);
            Chart8.DataSource = dt4;
            Chart8.ChartAreas[0].AxisX.Interval = 1;
            Chart8.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart8.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart8.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart8.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart8.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart8.DataBind();

            

            
            //jazzhev
            Chart11.Visible = DropDownList1.SelectedValue != "";
            string query7 = string.Format("SELECT date, sum(jazzhev) as jazzhev FROM " +
                "(SELECT date, jazzhev FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, jazzhev FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")jazzhev GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt7 = GetData1(query7);
            Chart11.DataSource = dt7;
            Chart11.ChartAreas[0].AxisX.Interval = 1;
            Chart11.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart11.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart11.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart11.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart11.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart11.DataBind();

            //hrvhev
            Chart12.Visible = DropDownList1.SelectedValue != "";
            string query8 = string.Format("SELECT date, sum(hrvhev) as hrvhev FROM " +
                "(SELECT date, hrvhev FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, hrvhev FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")hrvhev GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt8 = GetData1(query8);
            Chart12.DataSource = dt8;
            Chart12.ChartAreas[0].AxisX.Interval = 1;
            Chart12.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart12.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart12.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart12.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart12.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart12.DataBind();

            //cityhev
            Chart13.Visible = DropDownList1.SelectedValue != "";
            string query13 = string.Format("SELECT date, sum(cityhev) as cityhev FROM " +
                "(SELECT date, cityhev FROM jan_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM feb_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM mar_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM apr_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM may_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM jun_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM jul_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM aug_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM sep_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM oct_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM nov_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    "UNION ALL SELECT date, cityhev FROM dec_sum WHERE Month(date) = Month(getdate()) AND warehouse = '{0}'" +
                    ")cityhev GROUP BY date", DropDownList1.SelectedValue);
            DataTable dt13 = GetData1(query13);
            Chart13.DataSource = dt13;
            Chart13.ChartAreas[0].AxisX.Interval = 1;
            Chart13.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
            Chart13.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Chart13.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart13.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            Chart13.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Chart13.DataBind();
        }



    }
}