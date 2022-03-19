using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;



/// <summary>
/// SqlOperation 的摘要说明
/// 封装数据库的基本操作
/// 需要想办法优化改善
/// </summary>
public class SqlOperation
{
    public SqlOperation()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static SqlConnection SqlCon()
    {
        string cons = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        return new SqlConnection(cons);
    }

    public static object ScalarOperate(string sql)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        object obj = cmd.ExecuteScalar();
        con.Close();
        return obj;
    }

    public static object ScalarOperate(string sql, SqlParameter[] pms)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddRange(pms);
        object obj = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        con.Close();
        return obj;
    }

    public static SqlDataReader ReaderOperate(string sql)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        return dr;
    }

    public static SqlDataReader ReaderOperate(string sql, SqlParameter[] pms)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddRange(pms);
        SqlDataReader dr = cmd.ExecuteReader();
        cmd.Parameters.Clear();
        return dr;
    }

    public static SqlDataReader ReaderOperate(string sql, GridView gv)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        gv.DataSource = dr;
        gv.DataBind();
        return dr;
    }

    public static SqlDataReader ReaderOperate(string sql, DropDownList ddl, string field)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        DropDownList dropDownList = ddl;
        dropDownList.DataSource = dr;
        dropDownList.DataTextField = field;
        dropDownList.DataBind();
        return dr;
    }


    public static int QueryOperate(string sql)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        int n = cmd.ExecuteNonQuery();
        con.Close();
        return n;
    }

    public static int QueryOperate(string sql, SqlParameter[] pms)
    {
        SqlConnection con = SqlCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddRange(pms);
        int n = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
        return n;
    }
}