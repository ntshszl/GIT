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
    public partial class JanuarySummary : System.Web.UI.Page
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
                con.Open();
            
                //summary all in out total
                SqlCommand monthsummary = new SqlCommand(
                   "SELECT date, sum(incoming) as incoming, sum(outgoing) as outgoing, sum(totalstorage) as totalstorage, sum(maximumcapacity) as maximumcapacity FROM " +
                    "(SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming, outgoing, totalstorage, maximumcapacity FROM dec_sum WHERE Month(date) = 1" +
                    ")summ GROUP BY date ", con);
                SqlDataAdapter MonthSum = new SqlDataAdapter(monthsummary);
                DataSet monthsum = new DataSet();
                MonthSum.Fill(monthsum);
                Chart1.DataSource = monthsum;
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //incoming bar graph
                SqlCommand incoming = new SqlCommand("SELECT date, sum(incoming) as incoming FROM " +
                    "(SELECT date, incoming FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, incoming FROM dec_sum WHERE Month(date) = 1" +
                    ")iinc GROUP BY date", con);
                SqlDataAdapter Incoming = new SqlDataAdapter(incoming);
                DataSet inc = new DataSet();
                Incoming.Fill(inc);
                Chart2.DataSource = inc;
                Chart2.ChartAreas[0].AxisX.Interval = 1;
                Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart2.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //outgoing bar graph
                SqlCommand outgoing = new SqlCommand("SELECT date, sum(outgoing) as outgoing FROM " +
                    "(SELECT date, outgoing FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, outgoing FROM dec_sum WHERE Month(date) = 1" +
                    ")out GROUP BY date", con);
                SqlDataAdapter Outgoing = new SqlDataAdapter(outgoing);
                DataSet ou = new DataSet();
                Outgoing.Fill(ou);
                Chart3.DataSource = ou;
                Chart3.ChartAreas[0].AxisX.Interval = 1;
                Chart3.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart3.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart3.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


                //accord
                SqlCommand accord = new SqlCommand("SELECT date, sum(accord) as accord FROM " +
                    "(SELECT date, accord FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, accord FROM dec_sum WHERE Month(date) = 1" +
                    ")acc GROUP BY date", con);
                SqlDataAdapter Accord = new SqlDataAdapter(accord);
                DataSet acc = new DataSet();
                Accord.Fill(acc);
                Chart4.DataSource = acc;
                Chart4.ChartAreas[0].AxisX.Interval = 1;
                Chart4.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart4.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart4.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart4.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


                //civic
                SqlCommand civic = new SqlCommand("SELECT date, sum(civic) as civic FROM " +
                    "(SELECT date, civic FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, civic FROM dec_sum WHERE Month(date) = 1" +
                    ") civic GROUP BY date", con);
                SqlDataAdapter Civic = new SqlDataAdapter(civic);
                DataSet civ = new DataSet();
                Civic.Fill(civ);
                Chart5.DataSource = civ;
                Chart5.ChartAreas[0].AxisX.Interval = 1;
                Chart5.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart5.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart5.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart5.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart5.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart5.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //jazz
                SqlCommand jazz = new SqlCommand("SELECT date, sum(jazz) as jazz FROM" +
                    "(SELECT date, jazz FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazz FROM dec_sum WHERE Month(date) = 1" +
                    ") jazz GROUP BY date", con);
                SqlDataAdapter Jazz = new SqlDataAdapter(jazz);
                DataSet ja = new DataSet();
                Jazz.Fill(ja);
                Chart6.DataSource = ja;
                Chart6.ChartAreas[0].AxisX.Interval = 1;
                Chart6.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart6.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart6.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart6.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart6.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart6.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //city
                SqlCommand city = new SqlCommand("SELECT date, sum(city) as city FROM " +
                    "(SELECT date, city FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, city FROM dec_sum WHERE Month(date) = 1" +
                    ")city GROUP BY date", con);
                SqlDataAdapter City = new SqlDataAdapter(city);
                DataSet ci = new DataSet();
                City.Fill(ci);
                Chart7.DataSource = ci;
                Chart7.ChartAreas[0].AxisX.Interval = 1;
                Chart7.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart7.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart7.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart7.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart7.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart7.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //crv
                SqlCommand crv = new SqlCommand("SELECT date, sum(crv) as crv FROM " +
                    "(SELECT date, crv FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, crv FROM dec_sum WHERE Month(date) = 1" +
                    ")crv GROUP BY date", con);
                SqlDataAdapter Crv = new SqlDataAdapter(crv);
                DataSet cr = new DataSet();
                Crv.Fill(cr);
                Chart8.DataSource = cr;
                Chart8.ChartAreas[0].AxisX.Interval = 1;
                Chart8.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart8.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart8.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart8.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart8.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart8.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //hrv
                SqlCommand hrv = new SqlCommand("SELECT date, sum(hrv) as hrv FROM " +
                    "(SELECT date, hrv FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrv FROM dec_sum WHERE Month(date) = 1" +
                    ")hrv GROUP BY date", con);
                SqlDataAdapter Hrv = new SqlDataAdapter(hrv);
                DataSet hr = new DataSet();
                Hrv.Fill(hr);
                Chart9.DataSource = hr;
                Chart9.ChartAreas[0].AxisX.Interval = 1;
                Chart9.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart9.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart9.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart9.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart9.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart9.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


                //brv
                SqlCommand brv = new SqlCommand("SELECT date, sum(brv) as brv FROM " +
                    "(SELECT date, brv FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, brv FROM dec_sum WHERE Month(date) = 1" +
                    ")brv GROUP BY date", con);
                SqlDataAdapter Brv = new SqlDataAdapter(brv);
                DataSet br = new DataSet();
                Brv.Fill(br);
                Chart10.DataSource = br;
                Chart10.ChartAreas[0].AxisX.Interval = 1;
                Chart10.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart10.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart10.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart10.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart10.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart10.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


                //jazzhev
                SqlCommand jazzhev = new SqlCommand("SELECT date, sum(jazzhev) as jazzhev FROM " +
                    "(SELECT date, jazzhev FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, jazzhev FROM dec_sum WHERE Month(date) = 1" +
                    ")jazzhev GROUP BY date", con);
                SqlDataAdapter Jazzhev = new SqlDataAdapter(jazzhev);
                DataSet jh = new DataSet();
                Jazzhev.Fill(jh);
                Chart11.DataSource = jh;
                Chart11.ChartAreas[0].AxisX.Interval = 1;
                Chart11.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart11.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart11.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart11.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart11.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart11.ChartAreas[0].AxisY.MajorGrid.Enabled = false;


                //cityhev
                SqlCommand cityhev = new SqlCommand("SELECT date, sum(cityhev) as cityhev FROM " +
                    "(SELECT date, cityhev FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, cityhev FROM dec_sum WHERE Month(date) = 1" +
                    ")jazzhev GROUP BY date", con);
                SqlDataAdapter Cityhev = new SqlDataAdapter(cityhev);
                DataSet ch = new DataSet();
                Cityhev.Fill(ch);
                Chart12.DataSource = ch;
                Chart12.ChartAreas[0].AxisX.Interval = 1;
                Chart12.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart12.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart12.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart12.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart12.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart12.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                //hrvhev
                SqlCommand hrvhev = new SqlCommand("SELECT date, sum(hrvhev) as hrvhev FROM " +
                    "(SELECT date, hrvhev FROM jan_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM feb_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM mar_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM apr_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM may_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM jun_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM jul_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM aug_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM sep_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM oct_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM nov_sum WHERE Month(date) = 1" +
                    "UNION ALL SELECT date, hrvhev FROM dec_sum WHERE Month(date) = 1" +
                    ")hrvhev GROUP BY date", con);
                SqlDataAdapter Hrvhev = new SqlDataAdapter(hrvhev);
                DataSet hh = new DataSet();
                Hrvhev.Fill(hh);
                Chart13.DataSource = hh;
                Chart13.ChartAreas[0].AxisX.Interval = 1;
                Chart13.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart13.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Verdana", 8f);
                Chart13.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart13.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                Chart13.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart13.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
        }     
    }
}