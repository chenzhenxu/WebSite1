using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DocumentatManage documentatmanage = new DocumentatManage();
        documentatmanage.Title = Request["title"];
        DataSet documentatmanageds = documentatmanage.FindDocumentatByTitle( documentatmanage,"tb_documentat");
        if (documentatmanageds.Tables[0].Rows.Count < 0)
            Response.Redirect("~/404/404.html"); 
        string filepath=documentatmanageds.Tables[0].Rows[0][13].ToString();
        int filedowns = Convert.ToInt32(documentatmanageds.Tables[0].Rows[0][9].ToString());
        documentatmanage.Downloads = filedowns + 1;
        documentatmanage.UpdateDownloads(documentatmanage);
        Response.Redirect(filepath);
    }
}