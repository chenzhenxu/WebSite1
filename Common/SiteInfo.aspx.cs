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

public partial class Common_SiteInfo : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "网站信息页面";
        if (!IsPostBack)
        {
          
            
                txtLibName.Text = "文献资料管理系统";
                txtCurator.Text = "张网山";
                txtTel.Text = "111111111111";
                txtAddress.Text = "长沙市xxxxx";
                txtEmail.Text = "qwee@qq.com";
                txtUrl.Text = "www.wuyuww.cs.hn.cn";
                txtCDate.Text = "2009/09/09";
                txtIntroduce.Text = "此网站是用来测试使用的";
               
        
    }
   
    }
   
}
