using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SitePage_MainSitePage : System.Web.UI.MasterPage
{
    OperatorClass operatorclass = new OperatorClass();
    AdminManage adminmanage = new AdminManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            menuNav.Items[1].Enabled = false;
            //menuNav.Items[2].ChildItems[0].Enabled = false;
            menuNav.Items[2].Enabled = false;
            menuNav.Items[3].Enabled = false;
            menuNav.Items[4].Enabled = false;

        }
        else if (Session["role"].ToString() == "Admin")
        {
            labDate.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";
            labXQ.Text = operatorclass.getWeek();
            if (Session["Name"].ToString() != null)
                labAdmin.Text = Session["Name"].ToString();

            adminmanage.Name = Session["Name"].ToString();
        }
        else {
            menuNav.Items[1].Enabled = false;
            menuNav.Items[2].ChildItems[0].Enabled = false;
            menuNav.Items[3].ChildItems[0].Enabled = false;
            menuNav.Items[3].ChildItems[1].Enabled = false;
            menuNav.Items[4].Enabled = false;
        }
    }
    protected void menuNav_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (menuNav.SelectedValue == "退出系统")
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}
