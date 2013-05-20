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

public partial class DocumentatManage_AddDocumentat : System.Web.UI.Page
{
    ValidateClass validate=new ValidateClass();
    //BookcaseManage bookcasemanage = new BookcaseManage();
    TypeManage typemanage = new TypeManage();
    DocumentatManage documentatmanage = new DocumentatManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加文献信息页面";
        if (!IsPostBack)
        {
           

            DataSet typeds = typemanage.GetAllType("tb_type");
            ddlType.DataSource = typeds;
            ddlType.DataTextField = "categoryName";
            ddlType.DataBind();

            if (Request["title"] == null)
            {
                btnAdd.Enabled = true;
                txtUploadtime.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                btnSave.Enabled = true;
                //txtBCode.ReadOnly = txtBName.ReadOnly = true;
                txtTitle.Text = Request["title"].ToString();
                documentatmanage.Title = txtTitle.Text;
                DataSet documentatds = documentatmanage.FindDocumentatByTitle(documentatmanage,"tb_documentat");
                txtContent.Text = documentatds.Tables[0].Rows[0][2].ToString();
                //ddlBType.SelectedValue = bookds.Tables[0].Rows[0][2].ToString();
                txtKeyword.Text = documentatds.Tables[0].Rows[0][3].ToString();
                txtAuthor.Text = documentatds.Tables[0].Rows[0][4].ToString();
                txtTopic.Text = documentatds.Tables[0].Rows[0][5].ToString();
                txtSummary.Text = documentatds.Tables[0].Rows[0][6].ToString();
                txtReferences.Text = documentatds.Tables[0].Rows[0][7].ToString();
                txtSource.Text = documentatds.Tables[0].Rows[0][8].ToString();
                ddlType.SelectedValue = documentatds.Tables[0].Rows[0][9].ToString();
                txtDownloads.Text = documentatds.Tables[0].Rows[0][10].ToString();
                txtUpload.Text = documentatds.Tables[0].Rows[0][12].ToString();
                //txtCheck.Text = documentatds.Tables[0].Rows[0][13].ToString();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
       documentatmanage.Title = txtTitle.Text;
        if (documentatmanage.FindDocumentatByTitle(documentatmanage,"tb_documentat").Tables[0].Rows.Count > 0)
        {
            documentatmanage.Content = txtContent.Text;
            documentatmanage.KeyWord = txtKeyword.Text;
            documentatmanage.Author = txtAuthor.Text;
            documentatmanage.Topic= txtTopic.Text;
            documentatmanage.Summary = txtSummary.Text;
            documentatmanage.References= txtReferences.Text;
            documentatmanage.Source=txtSource.Text;
            documentatmanage.Type= ddlType.SelectedValue;
            documentatmanage.Downloads = Convert.ToInt32(txtDownloads.Text) ;
            documentatmanage.Uploadtime = Convert.ToDateTime(txtUploadtime.Text);
            documentatmanage.Check = "否";
            documentatmanage.Path = "~/Files/"+txtTitle.Text;
            documentatmanage.UpdateDocumentat(documentatmanage);
        }
        else
        {
             documentatmanage.Title = txtTitle.Text;
            documentatmanage.Content = txtContent.Text;
            documentatmanage.KeyWord = txtKeyword.Text;
            documentatmanage.Author = txtAuthor.Text;
            documentatmanage.Topic= txtTopic.Text;
            documentatmanage.Summary = txtSummary.Text;
            documentatmanage.References= txtReferences.Text;
            documentatmanage.Source=txtSource.Text;
            documentatmanage.Type= ddlType.SelectedValue;
            documentatmanage.Downloads = Convert.ToInt32(txtDownloads.Text) ;
            documentatmanage.Uploadtime = Convert.ToDateTime(txtUploadtime.Text);
            documentatmanage.Check = "否";
            documentatmanage.Path = "~/Files/"+txtTitle.Text;
            documentatmanage.AddDocumentat(documentatmanage);
        }
        Response.Redirect("DocumentatManage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValidateFun();
            documentatmanage.Title = txtTitle.Text;
            documentatmanage.Content = txtContent.Text;
            documentatmanage.KeyWord = txtKeyword.Text;
            documentatmanage.Author = txtAuthor.Text;
            documentatmanage.Topic= txtTopic.Text;
            documentatmanage.Summary = txtSummary.Text;
            documentatmanage.References= txtReferences.Text;
            documentatmanage.Source=txtSource.Text;
            documentatmanage.Type= ddlType.SelectedValue;
            documentatmanage.Downloads = Convert.ToInt32(txtDownloads.Text) ;
            documentatmanage.Uploadtime = Convert.ToDateTime(txtUploadtime.Text);
            documentatmanage.Check = "否";
            documentatmanage.Path = "~/Files/"+txtTitle.Text;
         Response.Redirect("DocumentatManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       txtUploadtime.Text = DateTime.Now.ToShortDateString();
        txtTitle.Text= txtContent.Text = txtKeyword.Text = txtAuthor.Text = txtTopic.Text = txtSummary.Text =txtReferences.Text =  ddlType.SelectedValue= txtDownloads.Text=string.Empty;
    }
    protected void ValidateFun()
    {
        if ( txtTitle.Text == "")
        {
            Response.Write("<script>alert('文献标题不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (txtKeyword.Text == "")
        {
            Response.Write("<script>alert('文献关键词不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtDownloads.Text))
        {
            Response.Write("<script>alert('下载次数输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
       
    }
    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
         if (FileUpLoad1.HasFile)  
        {  
            //判断文件是否小于10Mb  
            if (FileUpLoad1.PostedFile.ContentLength < 10485760)  
            {  
                try  
                {  
                    //上传文件并指定上传目录的路径  
                    FileUpLoad1.PostedFile.SaveAs(Server.MapPath("~/Files/")  
                        + FileUpLoad1.FileName);  
                    /*注意->这里为什么不是:FileUpLoad1.PostedFile.FileName 
                    * 而是:FileUpLoad1.FileName? 
                    * 前者是获得客户端完整限定(客户端完整路径)名称 
                    * 后者FileUpLoad1.FileName只获得文件名. 
                    */  
  
                    //当然上传语句也可以这样写(貌似废话):  
                    //FileUpLoad1.SaveAs(@"D:\"+FileUpLoad1.FileName);  
  
                    lblMessage.Text = "上传成功!";  
                }  
                catch (Exception ex)  
                {  
                    lblMessage.Text = "出现异常,无法上传!";  
                    //lblMessage.Text += ex.Message;  
                }  
  
            }  
            else  
            {  
                lblMessage.Text = "上传文件不能大于10MB!";  
            }  
        }  
        else  
        {  
            lblMessage.Text = "尚未选择文件!";  
        }  
    }  
    }


