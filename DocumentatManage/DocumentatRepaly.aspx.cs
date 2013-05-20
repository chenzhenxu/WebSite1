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

public partial class DocumentatManage_DocumentatRepaly: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ShowPdf1.FilePath = "../Files/软件工程.pdf";
       //this.ShowPdf1.FilePath = Request["path"].ToString();
    }
    
}

