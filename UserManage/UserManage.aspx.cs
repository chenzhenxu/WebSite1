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

public partial class UserManage_UserManage : System.Web.UI.Page
{
    UserManage usermanage = new UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看用户信息页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvReaderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReaderInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvReaderInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        usermanage.ID = gvReaderInfo.DataKeys[e.RowIndex].Value.ToString();
        usermanage.DeleteUser(usermanage);
        Response.Write("<script>alert('用户信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = usermanage.GetAllUser("tb_user");
        gvReaderInfo.DataSource = ds;
        gvReaderInfo.DataKeyNames = new string[] { "id" };
        gvReaderInfo.DataBind();
    }
}
