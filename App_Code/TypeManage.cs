using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
///TypeManage 的摘要说明
/// </summary>
public class TypeManage
{
	public TypeManage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    DataBase data = new DataBase();

    #region 定义文献类型信息--数据结构
    private string id;
    private string categoryname;
    private string parentid;
    private int catelevel;
    private string catepath;

    ///<summary>
    ///类型标识
    ///</summary>

    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    ///<summary>
    ///类型名称
    ///</summary>

    public string CategoryName
    {
        get { return categoryname; }
        set { categoryname = value; }
    }
    ///<summary>
    ///父级标识
    ///</summary>

    public string ParentId
    {
        get { return parentid; }
        set { parentid = value; }
    }

    ///<summary>
    ///级别
    ///</summary>

    public int CateLevel
    {
        get { return catelevel; }
        set { catelevel = value; }
    }
    ///<summary>
    ///路径
    ///</summary>

    public string  CatePath
    {
        get { return catepath; }
        set { catepath = value; }
    }
    #endregion

    #region 添加--类型信息
    ///<summary>
    ///添加--类型信息
    ///</summary>
    ///<param name=""></param>
    ///<returns></returns>
    
    public int AddType(TypeManage typemanage)
    {
        SqlParameter[] prams={
                    data.MakeInParam("@id",SqlDbType.VarChar,50,typemanage.ID),
                    data.MakeInParam("@categoryname",SqlDbType.VarChar,50,typemanage.CategoryName),
                    data.MakeInParam("@parentid",SqlDbType.VarChar,50,typemanage.ParentId),
                    data.MakeInParam("@catelevel",SqlDbType.Int,4,typemanage.CateLevel),
                    data.MakeInParam("@catepath",SqlDbType.VarChar,50,typemanage.CatePath),
                             };
        return (data.RunProc("INSERT INTO tb_type (id,categoryname,parentid,catelevel,catepath)VALUES(@id,@categoryname,@parentid,@catelevel,@catepath)",prams));
    }
    #endregion
    #region 修改--类型信息
    ///<summary>
    ///修改--类型信息
    ///</summary>
    ///<param name=""></param>
    ///<returns></returns>

    public int UpdateType(TypeManage typemanage)
    {
        SqlParameter[] prams ={
                    data.MakeInParam("@id",SqlDbType.VarChar,50,typemanage.ID),
                    data.MakeInParam("@categoryname",SqlDbType.VarChar,50,typemanage.CategoryName),
                    data.MakeInParam("@parentid",SqlDbType.VarChar,50,typemanage.ParentId),
                    data.MakeInParam("@catelevel",SqlDbType.Int,4,typemanage.CateLevel),
                    data.MakeInParam("@catepath",SqlDbType.VarChar,50,typemanage.CatePath),
                             };
        return (data.RunProc("update tb_type set categoryname=@categoryname ,parentid=@parentid,catelevel=@catelevel,catepath=@catepath where id=@id", prams));
    }
    #endregion
    #region 删除--类型信息
    ///<summary>
    ///删除--类型信息
    ///</summary>
    ///<param name=""></param>
    ///<returns></returns>

    public int DeleteType(TypeManage typemanage)
    {
        SqlParameter[] prams ={
                    data.MakeInParam("@id",SqlDbType.VarChar,50,typemanage.ID),

                             };
        return (data.RunProc("delete from tb_type  where id=@id", prams));
    }
    #endregion
    #region 查询--类型信息
    ///<summary>
    ///根据-类型名称--得到类型信息
    ///</summary>
    ///<param name=""></param>
    ///<returns></returns>

    public DataSet FindTypeByName(TypeManage typemanamege,string tbName)
    {
        SqlParameter[] prams ={
         data.MakeInParam("@name",SqlDbType.VarChar,50,typemanamege.CategoryName+"%"),
                              };
             return (data.RunProcReturn("select * from tb_type where name like @name",prams,tbName));
    }
    ///<summary>
    ///得到所有--类型信息
    ///</sumary>
    ///<param name=""></param>
    ///<returns></returns>
    public DataSet GetAllType(string tbName)
    { 
        return (data.RunProcReturn("select * from tb_type ORDER BY id",tbName));
    }

    #endregion



}