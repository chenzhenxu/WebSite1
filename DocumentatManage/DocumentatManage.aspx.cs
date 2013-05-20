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

public partial class DocumentatManage_DocumentatManage : System.Web.UI.Page
{
    DocumentatManage documentatmanage = new DocumentatManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "查看文献信息页面";
        if (!IsPostBack)
            gvBind();
    }
    protected void gvDocumentatInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentatInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvDocumentatInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        documentatmanage.Title = gvDocumentatInfo.DataKeys[e.RowIndex].Value.ToString();
        documentatmanage.DeleteDocumentat(documentatmanage);
        Response.Write("<script>alert('文献信息删除成功')</script>");
        gvBind();
    }
    private void gvBind()
    {
        DataSet ds = documentatmanage.GetAllDocumentat("tb_documentat");
        gvDocumentatInfo.DataSource = ds;
        gvDocumentatInfo.DataKeyNames = new string[] { "title" };
        gvDocumentatInfo.DataBind();
    }
}
