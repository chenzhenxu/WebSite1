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


public partial class Login : System.Web.UI.Page
{
    OperatorClass operatorclass = new OperatorClass();
    AdminManage adminmanage = new AdminManage();
    UserManage usermanage = new UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (UserName.Text == string.Empty)
        {
            Response.Write("<script>alert('名称不能为空！')</script>");
            return;
        }
        else
        {
            DataSet adminds = null;
            DataSet readerds = null;
            adminmanage.Name = UserName.Text;
            adminmanage.Pwd = Password.Text;
            adminds = adminmanage.Login(adminmanage);
            usermanage.ID = Password.Text;
            usermanage.Name = UserName.Text;
            readerds = usermanage.UserLogin(usermanage);
            if (adminds.Tables[0].Rows.Count > 0 && txtCode.Text == Request.Cookies["CheckCode"].Value)
            {
                Session["role"] = "Admin";
                Session["Name"] = UserName.Text;
                Response.Redirect("Default.aspx");
            }
            else if (readerds.Tables[0].Rows.Count > 0 && txtCode.Text == Request.Cookies["CheckCode"].Value)
            {
                Session["Name"] = UserName.Text;
                Session["readid"] = Password.Text;
                Session["role"] = "User";
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('登录名或密码不正确！')</script>");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        UserName.Text = Password.Text = txtCode.Text = string.Empty;
    }
}
