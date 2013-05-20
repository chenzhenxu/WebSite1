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

public partial class ReaderManage_AddReader : System.Web.UI.Page
{
    ValidateClass validate = new ValidateClass();
    UserManage usermanage = new UserManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "添加/修改用户信息页面";
        if (!IsPostBack)
        {
            if (Request["userid"] == null)
            {
                btnAdd.Enabled = true;
                txtUserID.Text = usermanage.GetUserID();
                txtBirthday.Text = txtDate.Text = DateTime.Now.ToShortDateString();
                txtDate.Text = txtDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                btnSave.Enabled = true;
                //txtUserID.Text = Request["userid"].ToString();
                txtUserID.Text = Request["userid"].ToString();
                usermanage.ID = txtUserID.Text;
                DataSet users = usermanage.FindUserByCode(usermanage, "tb_user");
                txtUser.Text = users.Tables[0].Rows[0][1].ToString();
                txtPwd.Text = users.Tables[0].Rows[0][2].ToString();
                ddlSex.SelectedValue = users.Tables[0].Rows[0][3].ToString();
                txtBirthday.Text = users.Tables[0].Rows[0][4].ToString();
                txtTel.Text = users.Tables[0].Rows[0][5].ToString();
                txtEmail.Text = users.Tables[0].Rows[0][6].ToString();
                txtDate.Text = users.Tables[0].Rows[0][7].ToString();
                txtUpload.Text = users.Tables[0].Rows[0][8].ToString();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ValidateFun();
         usermanage.ID = txtUserID.Text;
         usermanage.Name = txtUser.Text;
        if (usermanage.FindUserByName(usermanage, "tb_user").Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该读者已经存在！')</script>");
            return;
        }
        usermanage.Sex = ddlSex.Text;
        usermanage.Pwd = txtPwd.Text;
        usermanage.Birthday = Convert.ToDateTime(txtBirthday.Text);
        usermanage.Tel = txtTel.Text;
        usermanage.Email = txtEmail.Text;
        usermanage.CreateDate = Convert.ToDateTime(txtDate.Text);
        //usermanage.UploadNum = Convert.ToInt32(txtUpload.Text);
        usermanage.UploadTimes = 10;
        usermanage.AddUser(usermanage);
        Response.Redirect("UserManage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValidateFun();
        usermanage.ID = txtUserID.Text;
        usermanage.Name = txtUser.Text;
        usermanage.Sex = ddlSex.Text;
        usermanage.Pwd = txtPwd.Text;
        usermanage.Birthday = Convert.ToDateTime(txtBirthday.Text);
        usermanage.Tel = txtTel.Text;
        usermanage.Email = txtEmail.Text;
        usermanage.CreateDate = Convert.ToDateTime(txtDate.Text);
        usermanage.UploadTimes = Convert.ToInt32(txtUpload.Text);
        usermanage.UpdateUser(usermanage);
        Response.Redirect("UserManage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBirthday.Text = txtDate.Text = DateTime.Now.ToShortDateString();
        txtDate.Text = txtDate.Text = DateTime.Now.ToShortDateString();
        txtUser.Text =  txtTel.Text = txtEmail.Text =  txtPwd.Text=txtUpload.Text=string.Empty;
    }
    protected void ValidateFun()
    {
        if (txtUser.Text == "")
        {
            Response.Write("<script>alert('读者名称不能为空！');location='javascript:history.go(-1)';</script>");
            return;
        }
        
        if (!validate.validatePhone(txtTel.Text))
        {
            Response.Write("<script>alert('电话号码输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
        if (!validate.validateEmail(txtEmail.Text))
        {
            Response.Write("<script>alert('Email地址输入有误！');location='javascript:history.go(-1)';</script>");
            return;
        }
    }
}
