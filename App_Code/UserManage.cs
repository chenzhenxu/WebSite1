using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// UserManage 的摘要说明
/// </summary>
public class UserManage
{
    public UserManage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义用户信息--数据结构
    private string id = "";
    private string name = "";
    private string sex = "";
    private string pwd = "";
    private DateTime birthday = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string tel = "";
    private string email = "";
    private DateTime createdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private int uploadTimes = 0;
    

    /// <summary>
    /// 用户编号
    /// </summary>
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    /// <summary>
    /// 用户姓名
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /// <summary>
    /// 性别
    /// </summary>
    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    /// <summary>
    /// 用户密码
    /// </summary>
    public string Pwd
    {
        get { return pwd; }
        set { pwd = value; }
    }
    /// <summary>
    /// 出生日期
    /// </summary>
    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string Tel
    {
        get { return tel; }
        set { tel = value; }
    }
    /// <summary>
    /// Email地址
    /// </summary>
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    /// <summary>
    ///注册日期
    /// </summary>
    public DateTime CreateDate
    {
        get { return createdate; }
        set { createdate = value; }
    }
    /// <summary>
    /// 上传文献数量
    /// </summary>
    public int UploadTimes
    {
        get { return uploadTimes; }
        set { uploadTimes = value; }
    }
   
    #endregion

    #region 自动生成用户编号
    /// <summary>
    /// 自动生成用户编号
    /// </summary>
    /// <returns></returns>
    public string GetUserID()
    {
        DataSet ds = GetAllUser("tb_user");
        string strUserID = "";
        if (ds.Tables[0].Rows.Count == 0)
            strUserID = "1";
        else
            strUserID = (Convert.ToInt32(ds.Tables[0].Rows.Count) + 1).ToString();
            //strUserID = "2";
        return strUserID;
    }
    #endregion

    #region 添加--用户信息
    /// <summary>
    /// 添加--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int AddUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,usermanage.Name ),
            data.MakeInParam("@sex",  SqlDbType.Char, 4, usermanage.Sex ),
            
            data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, usermanage.Birthday ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20,usermanage.Tel ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 50, usermanage.Email),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, usermanage.CreateDate ),
            data.MakeInParam("@uploadTimes",  SqlDbType.Int, 8, usermanage.UploadTimes ),
			};
        return (data.RunProc("INSERT INTO tb_user(id,name,sex,birthday,tel,email,createDate,uploadTimes) "
            + "VALUES (@id,@name,@sex,@birthday,@tel,@email,@createdate,@uploadTimes)", prams));
    }
    #endregion

    #region 修改--用户信息
    /// <summary>
    /// 修改--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int UpdateUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,usermanage.Name ),
            data.MakeInParam("@sex",  SqlDbType.Char, 4, usermanage.Sex ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, usermanage.Pwd ),
            data.MakeInParam("@birthday",  SqlDbType.DateTime, 8, usermanage.Birthday ),
            data.MakeInParam("@tel",  SqlDbType.VarChar, 20,usermanage.Tel ),
            data.MakeInParam("@email",  SqlDbType.VarChar, 50, usermanage.Email),
            data.MakeInParam("@createdate",  SqlDbType.DateTime, 8, usermanage.CreateDate ),
            data.MakeInParam("@uploadnum",  SqlDbType.Int, 8, usermanage.UploadTimes ),
			};
        return (data.RunProc("update tb_user set name=@name,sex=@sex,type=@type,birthday=@birthday,"
            + "tel=@tel,email=@email,createDate=@createdate,uploadnum=@uploadnum where id=@id", prams));
    }
    /// <summary>
    /// 每借一次图书就将用户的借阅次数加一
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
   /* public int UpdateBorrowNum(UserManage usermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID ),
            data.MakeInParam("@borrownum",  SqlDbType.Int, 4, usermanage.BorrowNum),
            data.MakeInParam("@num",  SqlDbType.Int, 4, usermanage.Num),
			};
        return (data.RunProc("update tb_user set borrownum=@borrownum,num=@num where id=@id", prams));
    }
    * */
    #endregion
    
    #region 删除--用户信息
    /// <summary>
    /// 删除--用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public int DeleteUser(UserManage usermanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID ),
			};
        return (data.RunProc("delete from tb_user where id=@id", prams));
    }
    #endregion

    #region 查询--用户信息
    /// <summary>
    /// 根据--用户编号--得到用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindUserByCode(UserManage usermanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID +"%"),
			};
        return (data.RunProcReturn("select * from tb_user where id like @id", prams, tbName));
    }
    /// <summary>
    /// 根据--用户名称--得到用户信息
    /// </summary>
    /// <param name="usermanage"></param>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet FindUserByName(UserManage usermanage, string tbName)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@name",  SqlDbType.VarChar, 50,usermanage.Name+"%"),
			};
        return (data.RunProcReturn("select * from tb_user where name like @name", prams, tbName));
    }
   
    /// <summary>
    /// 得到所有--用户信息
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllUser(string tbName)
    {
        return (data.RunProcReturn("select * from tb_user ORDER BY id", tbName));
    }
    /// <summary>
    /// 得到所有用户借阅排行
    /// </summary>
    /// <param name="tbName"></param>
    /// <returns></returns>
    public DataSet GetAllUserSort(string tbName)
    {
        return (data.RunProcReturn("select * from tb_user where borrownum<>0 ORDER BY borrownum desc", tbName));
    }
    #endregion

    #region 用户登录
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="usermanage"></param>
    /// <returns></returns>
    public DataSet UserLogin(UserManage usermanage)
    {
        SqlParameter[] prams = {
            data.MakeInParam("@id",  SqlDbType.VarChar, 30, usermanage.ID ),
            data.MakeInParam("@name",  SqlDbType.VarChar, 50,usermanage.Name ),
			};
        return (data.RunProcReturn("SELECT * FROM tb_user WHERE (id = @id) AND (name = @name)", prams, "tb_user"));
    }
    #endregion
}