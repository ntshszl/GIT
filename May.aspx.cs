using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _Git_
{
    public partial class May : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //NISSIN SHAH ALAM ZONE 5
        protected void UploadExcel_Click(object sender, EventArgs e)

        {

            if (FileUploadExcel.HasFile)
            {
                try
                {
                    //Save File that have uploaded
                    FileUploadExcel.SaveAs(@"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + FileUploadExcel.FileName);
                    string path1 = @"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + FileUploadExcel.FileName;
                    string path = (Server.MapPath("/ExcelFile/" + FileUploadExcel.FileName));
                    FileUploadExcel.SaveAs(path);

                    //Extension file = xlsx
                    string ExcelConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                    OleDbConnection OleDBcon = new OleDbConnection(ExcelConnString);

                    //Using ole db to read file from excel 
                    OleDbCommand cmd = new OleDbCommand("Select * from [May$] WHERE [Warehouse] IS NOT NULL", OleDBcon);
                    OleDbCommand cmd2 = new OleDbCommand("Select * from [May$] WHERE [WAREHOUSE] IS NOT NULL", OleDBcon);


                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    objAdapter1.Fill(ds);

                    OleDbDataAdapter objAdapter2 = new OleDbDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    objAdapter2.Fill(ds2);

                    OleDBcon.Open();

                    // Create DbDataReader to Data Worksheet  
                    DbDataReader dr = cmd.ExecuteReader();
                    DbDataReader dr2 = cmd2.ExecuteReader();


                    // SQL Server Connection String  
                    string ConnStr = "Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345";


                    // SQL Delete Existing Data
                    SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd = new SqlCommand("DELETE FROM may_sum WHERE [Warehouse] = 'NISSIN PUNCAK ALAM ZONE 5' AND [Warehouse] IS NULL", con);
                    con.Open();
                    cd.ExecuteNonQuery();

                    SqlConnection cn = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd2 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] = 'NISSIN PUNCAK ALAM ZONE 5' AND [WAREHOUSE2] IS NULL", cn);
                    cn.Open();
                    cd2.ExecuteNonQuery();


                    // Bulk Copy to SQL Server
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnStr);
                    SqlBulkCopy bulkInsert2 = new SqlBulkCopy(ConnStr);


                    try
                    {
                        bulkInsert.DestinationTableName = "may_sum";
                        bulkInsert2.DestinationTableName = "may_search";

                        SqlBulkCopyColumnMapping warehouse_ = new SqlBulkCopyColumnMapping("Warehouse", "warehouse");
                        bulkInsert.ColumnMappings.Add(warehouse_);

                        SqlBulkCopyColumnMapping containercapacity_ = new SqlBulkCopyColumnMapping("Container Capacity", "containercapacity");
                        bulkInsert.ColumnMappings.Add(containercapacity_);

                        SqlBulkCopyColumnMapping date_ = new SqlBulkCopyColumnMapping("Date", "date");
                        bulkInsert.ColumnMappings.Add(date_);

                        SqlBulkCopyColumnMapping incoming_ = new SqlBulkCopyColumnMapping("Incoming", "incoming");
                        bulkInsert.ColumnMappings.Add(incoming_);

                        SqlBulkCopyColumnMapping outcoming_ = new SqlBulkCopyColumnMapping("Outgoing", "outgoing");
                        bulkInsert.ColumnMappings.Add(outcoming_);

                        SqlBulkCopyColumnMapping totalstorage_ = new SqlBulkCopyColumnMapping("Total Storage", "totalstorage");
                        bulkInsert.ColumnMappings.Add(totalstorage_);

                        SqlBulkCopyColumnMapping maxcapacity_ = new SqlBulkCopyColumnMapping("Max Capacity", "maximumcapacity");
                        bulkInsert.ColumnMappings.Add(maxcapacity_);

                        SqlBulkCopyColumnMapping accord_ = new SqlBulkCopyColumnMapping("ACCORD", "accord");
                        bulkInsert.ColumnMappings.Add(accord_);

                        SqlBulkCopyColumnMapping civic_ = new SqlBulkCopyColumnMapping("CIVIC", "civic");
                        bulkInsert.ColumnMappings.Add(civic_);

                        SqlBulkCopyColumnMapping crv_ = new SqlBulkCopyColumnMapping("CRV", "crv");
                        bulkInsert.ColumnMappings.Add(crv_);

                        SqlBulkCopyColumnMapping jazz_ = new SqlBulkCopyColumnMapping("JAZZ", "jazz");
                        bulkInsert.ColumnMappings.Add(jazz_);

                        SqlBulkCopyColumnMapping city_ = new SqlBulkCopyColumnMapping("CITY", "city");
                        bulkInsert.ColumnMappings.Add(city_);

                        SqlBulkCopyColumnMapping hrv_ = new SqlBulkCopyColumnMapping("HRV", "hrv");
                        bulkInsert.ColumnMappings.Add(hrv_);

                        SqlBulkCopyColumnMapping brv_ = new SqlBulkCopyColumnMapping("BRV", "brv");
                        bulkInsert.ColumnMappings.Add(brv_);

                        SqlBulkCopyColumnMapping jh_ = new SqlBulkCopyColumnMapping("JAZZ HEV", "jazzhev");
                        bulkInsert.ColumnMappings.Add(jh_);

                        SqlBulkCopyColumnMapping ch_ = new SqlBulkCopyColumnMapping("CITY HEV", "cityhev");
                        bulkInsert.ColumnMappings.Add(ch_);

                        SqlBulkCopyColumnMapping hh_ = new SqlBulkCopyColumnMapping("HRV HEV", "hrvhev");
                        bulkInsert.ColumnMappings.Add(hh_);


                        SqlBulkCopyColumnMapping wh_ = new SqlBulkCopyColumnMapping("WAREHOUSE2", "warehouse2");
                        bulkInsert2.ColumnMappings.Add(wh_);

                        SqlBulkCopyColumnMapping ln_ = new SqlBulkCopyColumnMapping("LOT NO", "lotno");
                        bulkInsert2.ColumnMappings.Add(ln_);

                        SqlBulkCopyColumnMapping in_ = new SqlBulkCopyColumnMapping("INVOICE NO", "invoiceno");
                        bulkInsert2.ColumnMappings.Add(in_);

                        SqlBulkCopyColumnMapping cn_ = new SqlBulkCopyColumnMapping("COUNTRY", "country");
                        bulkInsert2.ColumnMappings.Add(cn_);


                        bulkInsert.WriteToServer(dr);
                        bulkInsert2.WriteToServer(dr2);

                        SqlConnection c = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                        SqlCommand cd3 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] IS NULL", c);
                        c.Open();
                        cd3.ExecuteNonQuery();



                    }

                    catch (Exception labelex)
                    {
                        Response.Write("<script>alert('Data Duplicated/Error')</script>");
                        Response.Write(labelex);
                    }

                    OleDBcon.Close();

                    Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                    UploadLabel.Text = FileUploadExcel.FileName + " Uploaded";

                }

                catch (Exception)
                {
                    Response.Write("<script>alert('Error occured. Data may duplicated.')</script>");
                    UploadLabel.Text = " Error while uploading excel file.";
                }
            }

            else
            {
                UploadLabel.Text = " No file uploaded";
            }

        }

        //NISSIN SHAH ALAM ZONE 7
        protected void UploadExcel_Click2(object sender, EventArgs e)

        {

            if (UploadExcel2.HasFile)
            {
                try
                {
                    //Save File that have uploaded
                    UploadExcel2.SaveAs(@"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel2.FileName);
                    string path1 = @"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel2.FileName;
                    string path = (Server.MapPath("/ExcelFile/" + UploadExcel2.FileName));
                    UploadExcel2.SaveAs(path);

                    //Extension file = xlsx
                    string ExcelConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                    OleDbConnection OleDBcon = new OleDbConnection(ExcelConnString);

                    //Using ole db to read file from excel 
                    OleDbCommand cmd = new OleDbCommand("Select * from [May$] WHERE [Warehouse] IS NOT NULL", OleDBcon);
                    OleDbCommand cmd2 = new OleDbCommand("Select * from [May$] WHERE [WAREHOUSE] IS NOT NULL", OleDBcon);


                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    objAdapter1.Fill(ds);

                    OleDbDataAdapter objAdapter2 = new OleDbDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    objAdapter2.Fill(ds2);

                    OleDBcon.Open();

                    // Create DbDataReader to Data Worksheet  
                    DbDataReader dr = cmd.ExecuteReader();
                    DbDataReader dr2 = cmd2.ExecuteReader();


                    // SQL Server Connection String  
                    string ConnStr = "Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345";


                    // SQL Delete Existing Data
                    SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd = new SqlCommand("DELETE FROM may_sum WHERE [Warehouse] = 'NISSIN PUNCAK ALAM ZONE 7' AND [Warehouse] IS NULL", con);
                    con.Open();
                    cd.ExecuteNonQuery();

                    SqlConnection cn = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd2 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] = 'NISSIN PUNCAK ALAM ZONE 7' AND [WAREHOUSE2] IS NULL", cn);
                    cn.Open();
                    cd2.ExecuteNonQuery();


                    // Bulk Copy to SQL Server
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnStr);
                    SqlBulkCopy bulkInsert2 = new SqlBulkCopy(ConnStr);


                    try
                    {
                        bulkInsert.DestinationTableName = "may_sum";
                        bulkInsert2.DestinationTableName = "may_search";

                        SqlBulkCopyColumnMapping warehouse_ = new SqlBulkCopyColumnMapping("Warehouse", "warehouse");
                        bulkInsert.ColumnMappings.Add(warehouse_);

                        SqlBulkCopyColumnMapping containercapacity_ = new SqlBulkCopyColumnMapping("Container Capacity", "containercapacity");
                        bulkInsert.ColumnMappings.Add(containercapacity_);

                        SqlBulkCopyColumnMapping date_ = new SqlBulkCopyColumnMapping("Date", "date");
                        bulkInsert.ColumnMappings.Add(date_);

                        SqlBulkCopyColumnMapping incoming_ = new SqlBulkCopyColumnMapping("Incoming", "incoming");
                        bulkInsert.ColumnMappings.Add(incoming_);

                        SqlBulkCopyColumnMapping outcoming_ = new SqlBulkCopyColumnMapping("Outgoing", "outgoing");
                        bulkInsert.ColumnMappings.Add(outcoming_);

                        SqlBulkCopyColumnMapping totalstorage_ = new SqlBulkCopyColumnMapping("Total Storage", "totalstorage");
                        bulkInsert.ColumnMappings.Add(totalstorage_);

                        SqlBulkCopyColumnMapping maxcapacity_ = new SqlBulkCopyColumnMapping("Max Capacity", "maximumcapacity");
                        bulkInsert.ColumnMappings.Add(maxcapacity_);

                        SqlBulkCopyColumnMapping accord_ = new SqlBulkCopyColumnMapping("ACCORD", "accord");
                        bulkInsert.ColumnMappings.Add(accord_);

                        SqlBulkCopyColumnMapping civic_ = new SqlBulkCopyColumnMapping("CIVIC", "civic");
                        bulkInsert.ColumnMappings.Add(civic_);

                        SqlBulkCopyColumnMapping crv_ = new SqlBulkCopyColumnMapping("CRV", "crv");
                        bulkInsert.ColumnMappings.Add(crv_);

                        SqlBulkCopyColumnMapping jazz_ = new SqlBulkCopyColumnMapping("JAZZ", "jazz");
                        bulkInsert.ColumnMappings.Add(jazz_);

                        SqlBulkCopyColumnMapping city_ = new SqlBulkCopyColumnMapping("CITY", "city");
                        bulkInsert.ColumnMappings.Add(city_);

                        SqlBulkCopyColumnMapping hrv_ = new SqlBulkCopyColumnMapping("HRV", "hrv");
                        bulkInsert.ColumnMappings.Add(hrv_);

                        SqlBulkCopyColumnMapping brv_ = new SqlBulkCopyColumnMapping("BRV", "brv");
                        bulkInsert.ColumnMappings.Add(brv_);

                        SqlBulkCopyColumnMapping jh_ = new SqlBulkCopyColumnMapping("JAZZ HEV", "jazzhev");
                        bulkInsert.ColumnMappings.Add(jh_);

                        SqlBulkCopyColumnMapping ch_ = new SqlBulkCopyColumnMapping("CITY HEV", "cityhev");
                        bulkInsert.ColumnMappings.Add(ch_);

                        SqlBulkCopyColumnMapping hh_ = new SqlBulkCopyColumnMapping("HRV HEV", "hrvhev");
                        bulkInsert.ColumnMappings.Add(hh_);


                        SqlBulkCopyColumnMapping wh_ = new SqlBulkCopyColumnMapping("WAREHOUSE2", "warehouse2");
                        bulkInsert2.ColumnMappings.Add(wh_);

                        SqlBulkCopyColumnMapping ln_ = new SqlBulkCopyColumnMapping("LOT NO", "lotno");
                        bulkInsert2.ColumnMappings.Add(ln_);

                        SqlBulkCopyColumnMapping in_ = new SqlBulkCopyColumnMapping("INVOICE NO", "invoiceno");
                        bulkInsert2.ColumnMappings.Add(in_);

                        SqlBulkCopyColumnMapping cn_ = new SqlBulkCopyColumnMapping("COUNTRY", "country");
                        bulkInsert2.ColumnMappings.Add(cn_);


                        bulkInsert.WriteToServer(dr);
                        bulkInsert2.WriteToServer(dr2);

                        SqlConnection c = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                        SqlCommand cd3 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] IS NULL", c);
                        c.Open();
                        cd3.ExecuteNonQuery();



                    }

                    catch (Exception labelex)
                    {
                        Response.Write("<script>alert('Data Duplicated/Error')</script>");
                        Response.Write(labelex);
                    }

                    OleDBcon.Close();

                    Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                    Label1.Text = UploadExcel2.FileName + " Uploaded";

                }

                catch (Exception)
                {
                    Response.Write("<script>alert('Error occured. Data may duplicated.')</script>");
                    Label1.Text = " Error while uploading excel file.";
                }
            }

            else
            {
                Label1.Text = " No file uploaded";
            }

        }

        //SCHENKER
        protected void UploadExcel_Click3(object sender, EventArgs e)

        {

            if (UploadExcel3.HasFile)
            {
                try
                {
                    //Save File that have uploaded
                    UploadExcel3.SaveAs(@"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel3.FileName);
                    string path1 = @"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel3.FileName;
                    string path = (Server.MapPath("/ExcelFile/" + UploadExcel3.FileName));
                    UploadExcel3.SaveAs(path);

                    //Extension file = xlsx
                    string ExcelConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                    OleDbConnection OleDBcon = new OleDbConnection(ExcelConnString);

                    //Using ole db to read file from excel 
                    OleDbCommand cmd = new OleDbCommand("Select * from [May$] WHERE [Warehouse] IS NOT NULL", OleDBcon);
                    OleDbCommand cmd2 = new OleDbCommand("Select * from [May$] WHERE [WAREHOUSE] IS NOT NULL", OleDBcon);


                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    objAdapter1.Fill(ds);

                    OleDbDataAdapter objAdapter2 = new OleDbDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    objAdapter2.Fill(ds2);

                    OleDBcon.Open();

                    // Create DbDataReader to Data Worksheet  
                    DbDataReader dr = cmd.ExecuteReader();
                    DbDataReader dr2 = cmd2.ExecuteReader();


                    // SQL Server Connection String  
                    string ConnStr = "Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345";


                    // SQL Delete Existing Data
                    SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd = new SqlCommand("DELETE FROM may_sum WHERE [Warehouse] = 'SCHENKER' AND [Warehouse] IS NULL", con);
                    con.Open();
                    cd.ExecuteNonQuery();

                    SqlConnection cn = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd2 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] = 'SCHENKER' AND [WAREHOUSE2] IS NULL", cn);
                    cn.Open();
                    cd2.ExecuteNonQuery();


                    // Bulk Copy to SQL Server
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnStr);
                    SqlBulkCopy bulkInsert2 = new SqlBulkCopy(ConnStr);


                    try
                    {
                        bulkInsert.DestinationTableName = "may_sum";
                        bulkInsert2.DestinationTableName = "may_search";

                        SqlBulkCopyColumnMapping warehouse_ = new SqlBulkCopyColumnMapping("Warehouse", "warehouse");
                        bulkInsert.ColumnMappings.Add(warehouse_);

                        SqlBulkCopyColumnMapping containercapacity_ = new SqlBulkCopyColumnMapping("Container Capacity", "containercapacity");
                        bulkInsert.ColumnMappings.Add(containercapacity_);

                        SqlBulkCopyColumnMapping date_ = new SqlBulkCopyColumnMapping("Date", "date");
                        bulkInsert.ColumnMappings.Add(date_);

                        SqlBulkCopyColumnMapping incoming_ = new SqlBulkCopyColumnMapping("Incoming", "incoming");
                        bulkInsert.ColumnMappings.Add(incoming_);

                        SqlBulkCopyColumnMapping outcoming_ = new SqlBulkCopyColumnMapping("Outgoing", "outgoing");
                        bulkInsert.ColumnMappings.Add(outcoming_);

                        SqlBulkCopyColumnMapping totalstorage_ = new SqlBulkCopyColumnMapping("Total Storage", "totalstorage");
                        bulkInsert.ColumnMappings.Add(totalstorage_);

                        SqlBulkCopyColumnMapping maxcapacity_ = new SqlBulkCopyColumnMapping("Max Capacity", "maximumcapacity");
                        bulkInsert.ColumnMappings.Add(maxcapacity_);

                        SqlBulkCopyColumnMapping accord_ = new SqlBulkCopyColumnMapping("ACCORD", "accord");
                        bulkInsert.ColumnMappings.Add(accord_);

                        SqlBulkCopyColumnMapping civic_ = new SqlBulkCopyColumnMapping("CIVIC", "civic");
                        bulkInsert.ColumnMappings.Add(civic_);

                        SqlBulkCopyColumnMapping crv_ = new SqlBulkCopyColumnMapping("CRV", "crv");
                        bulkInsert.ColumnMappings.Add(crv_);

                        SqlBulkCopyColumnMapping jazz_ = new SqlBulkCopyColumnMapping("JAZZ", "jazz");
                        bulkInsert.ColumnMappings.Add(jazz_);

                        SqlBulkCopyColumnMapping city_ = new SqlBulkCopyColumnMapping("CITY", "city");
                        bulkInsert.ColumnMappings.Add(city_);

                        SqlBulkCopyColumnMapping hrv_ = new SqlBulkCopyColumnMapping("HRV", "hrv");
                        bulkInsert.ColumnMappings.Add(hrv_);

                        SqlBulkCopyColumnMapping brv_ = new SqlBulkCopyColumnMapping("BRV", "brv");
                        bulkInsert.ColumnMappings.Add(brv_);

                        SqlBulkCopyColumnMapping jh_ = new SqlBulkCopyColumnMapping("JAZZ HEV", "jazzhev");
                        bulkInsert.ColumnMappings.Add(jh_);

                        SqlBulkCopyColumnMapping ch_ = new SqlBulkCopyColumnMapping("CITY HEV", "cityhev");
                        bulkInsert.ColumnMappings.Add(ch_);

                        SqlBulkCopyColumnMapping hh_ = new SqlBulkCopyColumnMapping("HRV HEV", "hrvhev");
                        bulkInsert.ColumnMappings.Add(hh_);


                        SqlBulkCopyColumnMapping wh_ = new SqlBulkCopyColumnMapping("WAREHOUSE2", "warehouse2");
                        bulkInsert2.ColumnMappings.Add(wh_);

                        SqlBulkCopyColumnMapping ln_ = new SqlBulkCopyColumnMapping("LOT NO", "lotno");
                        bulkInsert2.ColumnMappings.Add(ln_);

                        SqlBulkCopyColumnMapping in_ = new SqlBulkCopyColumnMapping("INVOICE NO", "invoiceno");
                        bulkInsert2.ColumnMappings.Add(in_);

                        SqlBulkCopyColumnMapping cn_ = new SqlBulkCopyColumnMapping("COUNTRY", "country");
                        bulkInsert2.ColumnMappings.Add(cn_);


                        bulkInsert.WriteToServer(dr);
                        bulkInsert2.WriteToServer(dr2);

                        SqlConnection c = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                        SqlCommand cd3 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] IS NULL", c);
                        c.Open();
                        cd3.ExecuteNonQuery();



                    }

                    catch (Exception labelex)
                    {
                        Response.Write("<script>alert('Data Duplicated/Error')</script>");
                        Response.Write(labelex);
                    }

                    OleDBcon.Close();

                    Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                    Label2.Text = UploadExcel3.FileName + " Uploaded";

                }

                catch (Exception)
                {
                    Response.Write("<script>alert('Error occured. Data may duplicated.')</script>");
                    Label2.Text = " Error while uploading excel file.";
                }
            }

            else
            {
                Label2.Text = " No file uploaded";
            }

        }

        //TIONG NAM
        protected void UploadExcel_Click4(object sender, EventArgs e)

        {

            if (UploadExcel4.HasFile)
            {
                try
                {
                    //Save File that have uploaded
                    UploadExcel4.SaveAs(@"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel4.FileName);
                    string path1 = @"C:\Users\BSPT0765\source\repos\_Git_\_Git_\ExcelFile\" + UploadExcel4.FileName;
                    string path = (Server.MapPath("/ExcelFile/" + UploadExcel4.FileName));
                    UploadExcel4.SaveAs(path);

                    //Extension file = xlsx
                    string ExcelConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 8.0;";
                    OleDbConnection OleDBcon = new OleDbConnection(ExcelConnString);

                    //Using ole db to read file from excel 
                    OleDbCommand cmd = new OleDbCommand("Select * from [May$] WHERE [Warehouse] IS NOT NULL", OleDBcon);
                    OleDbCommand cmd2 = new OleDbCommand("Select * from [May$] WHERE [WAREHOUSE] IS NOT NULL", OleDBcon);


                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    objAdapter1.Fill(ds);

                    OleDbDataAdapter objAdapter2 = new OleDbDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    objAdapter2.Fill(ds2);

                    OleDBcon.Open();

                    // Create DbDataReader to Data Worksheet  
                    DbDataReader dr = cmd.ExecuteReader();
                    DbDataReader dr2 = cmd2.ExecuteReader();


                    // SQL Server Connection String  
                    string ConnStr = "Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345";


                    // SQL Delete Existing Data
                    SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd = new SqlCommand("DELETE FROM may_sum WHERE [Warehouse] = 'TIONG NAM' AND [Warehouse] IS NULL", con);
                    con.Open();
                    cd.ExecuteNonQuery();

                    SqlConnection cn = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                    SqlCommand cd2 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] = 'TIONG NAM' AND [WAREHOUSE2] IS NULL", cn);
                    cn.Open();
                    cd2.ExecuteNonQuery();


                    // Bulk Copy to SQL Server
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnStr);
                    SqlBulkCopy bulkInsert2 = new SqlBulkCopy(ConnStr);


                    try
                    {
                        bulkInsert.DestinationTableName = "may_sum";
                        bulkInsert2.DestinationTableName = "may_search";

                        SqlBulkCopyColumnMapping warehouse_ = new SqlBulkCopyColumnMapping("Warehouse", "warehouse");
                        bulkInsert.ColumnMappings.Add(warehouse_);

                        SqlBulkCopyColumnMapping containercapacity_ = new SqlBulkCopyColumnMapping("Container Capacity", "containercapacity");
                        bulkInsert.ColumnMappings.Add(containercapacity_);

                        SqlBulkCopyColumnMapping date_ = new SqlBulkCopyColumnMapping("Date", "date");
                        bulkInsert.ColumnMappings.Add(date_);

                        SqlBulkCopyColumnMapping incoming_ = new SqlBulkCopyColumnMapping("Incoming", "incoming");
                        bulkInsert.ColumnMappings.Add(incoming_);

                        SqlBulkCopyColumnMapping outcoming_ = new SqlBulkCopyColumnMapping("Outgoing", "outgoing");
                        bulkInsert.ColumnMappings.Add(outcoming_);

                        SqlBulkCopyColumnMapping totalstorage_ = new SqlBulkCopyColumnMapping("Total Storage", "totalstorage");
                        bulkInsert.ColumnMappings.Add(totalstorage_);

                        SqlBulkCopyColumnMapping maxcapacity_ = new SqlBulkCopyColumnMapping("Max Capacity", "maximumcapacity");
                        bulkInsert.ColumnMappings.Add(maxcapacity_);

                        SqlBulkCopyColumnMapping accord_ = new SqlBulkCopyColumnMapping("ACCORD", "accord");
                        bulkInsert.ColumnMappings.Add(accord_);

                        SqlBulkCopyColumnMapping civic_ = new SqlBulkCopyColumnMapping("CIVIC", "civic");
                        bulkInsert.ColumnMappings.Add(civic_);

                        SqlBulkCopyColumnMapping crv_ = new SqlBulkCopyColumnMapping("CRV", "crv");
                        bulkInsert.ColumnMappings.Add(crv_);

                        SqlBulkCopyColumnMapping jazz_ = new SqlBulkCopyColumnMapping("JAZZ", "jazz");
                        bulkInsert.ColumnMappings.Add(jazz_);

                        SqlBulkCopyColumnMapping city_ = new SqlBulkCopyColumnMapping("CITY", "city");
                        bulkInsert.ColumnMappings.Add(city_);

                        SqlBulkCopyColumnMapping hrv_ = new SqlBulkCopyColumnMapping("HRV", "hrv");
                        bulkInsert.ColumnMappings.Add(hrv_);

                        SqlBulkCopyColumnMapping brv_ = new SqlBulkCopyColumnMapping("BRV", "brv");
                        bulkInsert.ColumnMappings.Add(brv_);

                        SqlBulkCopyColumnMapping jh_ = new SqlBulkCopyColumnMapping("JAZZ HEV", "jazzhev");
                        bulkInsert.ColumnMappings.Add(jh_);

                        SqlBulkCopyColumnMapping ch_ = new SqlBulkCopyColumnMapping("CITY HEV", "cityhev");
                        bulkInsert.ColumnMappings.Add(ch_);

                        SqlBulkCopyColumnMapping hh_ = new SqlBulkCopyColumnMapping("HRV HEV", "hrvhev");
                        bulkInsert.ColumnMappings.Add(hh_);


                        SqlBulkCopyColumnMapping wh_ = new SqlBulkCopyColumnMapping("WAREHOUSE2", "warehouse2");
                        bulkInsert2.ColumnMappings.Add(wh_);

                        SqlBulkCopyColumnMapping ln_ = new SqlBulkCopyColumnMapping("LOT NO", "lotno");
                        bulkInsert2.ColumnMappings.Add(ln_);

                        SqlBulkCopyColumnMapping in_ = new SqlBulkCopyColumnMapping("INVOICE NO", "invoiceno");
                        bulkInsert2.ColumnMappings.Add(in_);

                        SqlBulkCopyColumnMapping cn_ = new SqlBulkCopyColumnMapping("COUNTRY", "country");
                        bulkInsert2.ColumnMappings.Add(cn_);


                        bulkInsert.WriteToServer(dr);
                        bulkInsert2.WriteToServer(dr2);

                        SqlConnection c = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                        SqlCommand cd3 = new SqlCommand("DELETE FROM may_search WHERE [WAREHOUSE2] IS NULL", c);
                        c.Open();
                        cd3.ExecuteNonQuery();



                    }

                    catch (Exception labelex)
                    {
                        Response.Write("<script>alert('Data Duplicated/Error')</script>");
                        Response.Write(labelex);
                    }

                    OleDBcon.Close();

                    Response.Write("<script>alert('Data Inserted Successfully.')</script>");
                    Label3.Text = UploadExcel4.FileName + " Uploaded";

                }

                catch (Exception)
                {
                    Response.Write("<script>alert('Error occured. Data may duplicated.')</script>");
                    Label3.Text = " Error while uploading excel file.";
                }
            }

            else
            {
                Label3.Text = " No file uploaded";
            }

        }
    }
}