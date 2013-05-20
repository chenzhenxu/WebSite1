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

public partial class DocumentManage_TypeManage : System.Web.UI.Page
{
    TypeManage typemanage = new TypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看文献类型页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvBTypeInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBTypeInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBTypeInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBTypeInfo.EditIndex = e.NewEditIndex;
        gvBind();
    }
    protected void gvBTypeInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        typemanage.ID = gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString();
        typemanage.CategoryName = ((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        typemanage.ParentId = ((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        typemanage.CateLevel = Convert.ToInt32(((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[3].Controls[0])).Text);
        typemanage.CatePath = ((TextBox)(gvBTypeInfo.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        typemanage.UpdateType(typemanage);
        gvBTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBTypeInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBTypeInfo.EditIndex = -1;
        gvBind();
    }
    protected void gvBTypeInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        typemanage.ID = gvBTypeInfo.DataKeys[e.RowIndex].Value.ToString();
        typemanage.DeleteType(typemanage);
        Response.Write("<script>alert('文献类型信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = typemanage.GetAllType("tb_type");
        gvBTypeInfo.DataSource = ds;
        gvBTypeInfo.DataKeyNames = new string[] { "id" };
        gvBTypeInfo.DataBind();
    }
}
