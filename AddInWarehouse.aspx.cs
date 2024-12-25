﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class AddInWarehouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsNull())
        {
            string date, number, name, units, inprice, total, notes, supply, people;
            date =DateTime.Now.ToString("yyyy-MM-dd");
            number = this.TextBox2.Text;
            name = this.TextBox3.Text;
            units = this.TextBox4.Text;
            inprice = this.TextBox5.Text;
            total = this.TextBox6.Text;
            notes = this.TextBox7.Text;
            supply = this.DropDownList1.Text;
            people = this.DropDownList2.Text;
            string sqlcoon = "Data Source=DESKTOP-5EMUFJI;Initial Catalog=BaseManagement;Integrated Security=True";
            string sql = "insert into InWarehouse(IDate,Number,ProductName,Count,InPrice,Total,Notes,SupplyUnit,Person) values (@IDate, @Number, @ProductName, @Count, @InPrice, @Total, @Notes, @SupplyUnit, @Person)";
            SqlParameter[] par = {
                new SqlParameter("@IDate",date),
                new SqlParameter("@Number",number),
                new SqlParameter("@ProductName",name),
                new SqlParameter("@Count",units),
                new SqlParameter("@InPrice",inprice),
                new SqlParameter("@Total",total),
                new SqlParameter("@Notes",notes),
                new SqlParameter("@SupplyUnit",supply),
                new SqlParameter("@Person",people)
                };
            using (SqlConnection con = new SqlConnection(sqlcoon))//SqlConnection连接，用using释放连接

            {
                using (SqlCommand com = new SqlCommand(sql, con))//SqlCommand连接，用using释放连接

                {
                    com.Parameters.AddRange(par);
                    //打开连接
                    con.Open();

                    int resert = Convert.ToInt32(com.ExecuteNonQuery());
                    //关闭连接
                    con.Close();
                    //释放连接
                    // con.Dispose();

                }
            }
            Response.Write("<script language='javascript'>alert('入库产品信息添加成功！');</script>");
            Server.Transfer("ManagerInWarehouse.aspx");
            /*SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Data Source=DESKTOP-5EMUFJI;Initial Catalog=BaseManagement;Integrated Security=True"]);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into InWarehouse(IDate,Number,ProductName,Count,InPrice,Total,Notes,SupplyUnit,Person) values ('" + date + "','" + number + "','" + name + "','" + units + "','" + inprice + "','" + total + "','" + notes + "','" + supply + "','" + people + "')", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Response.Write("<script language='javascript'>alert('入库产品信息添加成功！');</script>");
            Server.Transfer("ManagerInWarehouse.aspx");*/
        }
    }
    private bool IsNull()
    {
            if (this.TextBox2.Text == "")
            {
                Response.Write("<script language='javascript'>alert('入库编号不能为空！');</script>");
                return false;
            }
            else
            {
                if (this.TextBox3.Text == "")
                {
                    Response.Write("<script language='javascript'>alert('产品名称不能为空！');</script>");
                    return false;
                }

                else
                {
                    if (this.TextBox5.Text == "")
                    {
                        Response.Write("<script language='javascript'>alert('产品进货价不能为空！');</script>");
                        return false;
                    }
                    else
                    {
                        if (this.TextBox6.Text == "")
                        {
                            Response.Write("<script language='javascript'>alert('入库产品总价不能为空！');</script>");
                            return false;
                        }
                       
                            else
                            {
                               return true;
                            }
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("ManagerInWarehouse.aspx");
    }
}
