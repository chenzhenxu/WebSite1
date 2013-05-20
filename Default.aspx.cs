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

public partial class SysQuery_DocumentatQuery: System.Web.UI.Page
{
    DocumentatManage documentatmanage = new DocumentatManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "文献查询页面";
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        gvBind();
    }
    protected void gvBookInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBookInfo.PageIndex = e.NewPageIndex;
        gvBind();
    }
    protected void gvBind()
    {
        DataSet ds = null;
        int intCondition = ddlCondition.SelectedIndex;
        if (txtCondition.Text == "")
        {
            ds = documentatmanage.GetAllDocumentat("tb_documentat");
        }
        else
        {
            switch (intCondition)
            {
                case 0:
                    documentatmanage.KeyWord = txtCondition.Text;
                    ds = documentatmanage.FindDocumentatByKeyWord(documentatmanage, "tb_documentat");
                    break;
                case 1:
                    documentatmanage.Title = txtCondition.Text;
                    ds = documentatmanage.FindDocumentatByTitle(documentatmanage, "tb_documentat");
                    break;
                case 2:
                    documentatmanage.Type = txtCondition.Text;
                    ds = documentatmanage.FindDocumentatByType(documentatmanage, "tb_documentat");
                    break;
                case 3:
                    documentatmanage.Author = txtCondition.Text;
                    ds = documentatmanage.FindDocumentatByAuthor(documentatmanage, "tb_documentat");
                    break;
                case 4:
                    documentatmanage.Topic = txtCondition.Text;
                    ds = documentatmanage.FindDocumentatByTopic(documentatmanage, "tb_documentat");
                    break;
                
            }
        }
        gvBookInfo.DataSource = ds;
        gvBookInfo.DataBind();
    }
}
