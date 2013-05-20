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

public partial class BookManage_AddBType : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    TypeManage typemanage = new TypeManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加文献资料类型页面";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
        typemanage.ID = txtTypeID.Text;
        typemanage.CategoryName = txtType.Text;
        if (typemanage.FindTypeByName(typemanage, "tb_type").Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该类型已经存在！')</script>");
            return;
        }
        typemanage.ParentId = txtParent.Text;
        typemanage.CateLevel = Convert.ToInt32(txtCateLevel.Text);
        typemanage.CatePath =txtPath.Text;
        typemanage.AddType(typemanage);
        Response.Redirect("TypeManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtParent.Text = txtCateLevel.Text = txtPath.Text = txtTypeID.Text =txtType.Text= string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtType.Text == "")
        {
            Response.Write("<script>alert('文献类型名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateNum(txtCateLevel.Text))
        {
            Response.Write("<script>alert('级数输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}
