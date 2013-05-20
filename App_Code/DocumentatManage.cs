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
/// DocumentatManage 的摘要说明
/// </summary>
public class DocumentatManage
{
    public DocumentatManage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    #region 定义文献信息--数据结构
    private string title = "";
    private string content = "";
    private string keyword = "";
    private string author = "";
    private string topic = "";
    private string summary = "";
    private string references = "";
    private string source = "";
    private string type = "";
    private int downloads = 0;
    private DateTime uploadtime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    private string upload = "";
    private string check = "";
    private string path= "";

    /// <summary>
    /// 标题
    /// </summary>
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
   
    /// <summary>
    /// 内容
    /// </summary>
    public string Content 
    {
        get { return content; }
        set { content = value; }
    }
    /// <summary>
    /// 关键词
    /// </summary>
    public string KeyWord
    {
        get { return keyword; }
        set { keyword = value; }
    }
    /// <summary>
    /// 作者
    /// </summary>
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    /// <summary>
    /// 主题
    /// </summary>
    public string Topic
    {
        get { return topic; }
        set { topic = value; }
    }
    /// <summary>
    /// 摘要
    /// </summary>
    public string Summary
    {
        get { return summary; }
        set { summary = value; }
    }
    /// <summary>
    /// 引用
    /// </summary>
    public string References
    {
        get { return references; }
        set { references = value; }
    }
    /// <summary>
    /// 来源
    /// </summary>
    public string Source
    {
        get { return source; }
        set { source = value; }
    }
    /// <summary>
    /// 种类
    /// </summary>
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    /// <summary>
    /// 下载次数
    /// </summary>
    public int Downloads
    {
        get { return downloads; }
        set { downloads = value; }
    }
   
    
    /// <summary>
    /// 上传时间
    /// </summary>
    public DateTime Uploadtime
    {
        get { return uploadtime; }
        set { uploadtime = value; }
    }
    /// <summary>
    /// 上传者
    /// </summary>
    public string Upload
    {
        get { return upload; }
        set { upload = value; }
    }
    
    /// <summary>
    /// 审核
    /// </summary>
    public string Check
    {
        get { return check; }
        set { check = value; }
    }
    /// <summary>
    /// 借阅次数
    /// </summary>
    public string Path
    {
        get { return path; }
        set { path = value; }
    }
    #endregion
    #region 添加--文献信息
    /// <summary>
    /// 添加--文献信息
    /// </summary>
    /// <param name="bookmanage"></param>
    /// <returns></returns>
    public int AddDocumentat(DocumentatManage documentatmanage)
    {
        SqlParameter[] prams = {
			data.MakeInParam("@title",  SqlDbType.VarChar, 100, documentatmanage.Title),

            data.MakeInParam("@content",  SqlDbType.VarChar, 1000,documentatmanage.Content ),
            data.MakeInParam("@keyword",  SqlDbType.VarChar, 100, documentatmanage.KeyWord),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, documentatmanage.Author ),
            data.MakeInParam("@topic",  SqlDbType.VarChar, 100, documentatmanage.Topic ),
            data.MakeInParam("@summary",  SqlDbType.VarChar, 1000, documentatmanage.Summary ),
            data.MakeInParam("@references",  SqlDbType.VarChar,1000, documentatmanage.References ),
            data.MakeInParam("@source",  SqlDbType.VarChar, 50,documentatmanage.source ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, documentatmanage.Type ),
            data.MakeInParam("@downloads",  SqlDbType.Int, 4, documentatmanage.Downloads ),
            data.MakeInParam("@uploadtime",  SqlDbType.DateTime, 8, documentatmanage.Uploadtime ),
            data.MakeInParam("@upload",  SqlDbType.VarChar, 50, documentatmanage.Upload ),
            data.MakeInParam("@check",  SqlDbType.VarChar, 50, documentatmanage.Check ),
            data.MakeInParam("@path",  SqlDbType.VarChar,100, documentatmanage.Path ),
			};
        return (data.RunProc("INSERT INTO tb_documentat (title,content,keyword,author,topic,summary,references,source,type,downloads,uploadtime,upload,check,path) "
            + "VALUES (@title,@content,@keyword,author,@topic,@summary,@references,@source,@type,@downloads,@uploadtime,@upload,@check,@path)", prams));
    }
    #endregion
    #region 修改--文献信息
    ///<sumary>
    ///修改--文献信息
    ///</summary>
    ///<param name=""></param>
    ///<returns></returns>
  public int UpdateDocumentat(DocumentatManage documentatmanage)
  {
       SqlParameter[] prams = {
			data.MakeInParam("@title",  SqlDbType.VarChar, 100, documentatmanage.Title),
             
            data.MakeInParam("@content",  SqlDbType.VarChar, 1000,documentatmanage.Content ),
            data.MakeInParam("@keyword",  SqlDbType.VarChar, 100, documentatmanage.KeyWord),
            data.MakeInParam("@author",  SqlDbType.VarChar, 50, documentatmanage.Author ),
            data.MakeInParam("@topic",  SqlDbType.VarChar, 100, documentatmanage.Topic ),
            data.MakeInParam("@summary",  SqlDbType.VarChar, 1000, documentatmanage.Summary ),
            data.MakeInParam("@references",  SqlDbType.VarChar,1000, documentatmanage.References ),
            data.MakeInParam("@source",  SqlDbType.VarChar, 50,documentatmanage.source ),
            data.MakeInParam("@type",  SqlDbType.VarChar, 50, documentatmanage.Type ),
            data.MakeInParam("@downloads",  SqlDbType.Int, 8, documentatmanage.Downloads ),
            data.MakeInParam("@uploadtime",  SqlDbType.DateTime, 8, documentatmanage.Uploadtime ),
            data.MakeInParam("@upload",  SqlDbType.VarChar, 50, documentatmanage.Upload ),
            data.MakeInParam("@check",  SqlDbType.VarChar, 50, documentatmanage.Check ),
            data.MakeInParam("@path",  SqlDbType.VarChar,100, documentatmanage.Path ),
			};
       return (data.RunProc("update tb_documentat set title=@title,content=@content,keyword=@keyword,author=@author,topic=@topic,summary=@summary"
           + ",references=@references,source=@source,type=@type,downloads=@downloads,uploadtime=@uploadtime,upload=@upload,check=@check,path=@path", prams));
  }
  /// <summary>
  /// 每下载一次文献就将文献的下载次数加一
  /// </summary>
  /// <param name="bookmanage"></param>
  /// <returns></returns>
  public int UpdateDownloads(DocumentatManage documentatmanage)
  {
      SqlParameter[] prams = {
			data.MakeInParam("@title",  SqlDbType.VarChar, 100, documentatmanage.Title),
           data.MakeInParam("@downloads",  SqlDbType.Int, 8, documentatmanage.Downloads ),
			};
      return (data.RunProc("update tb_documentat set downloads=@downloads where title=@title", prams));
  }
    #endregion
  #region 删除--文献信息
  /// <summary>
  /// 删除--文献信息
  /// </summary>
  /// <param name="documentatmanage"></param>
  /// <returns></returns>
  public int DeleteDocumentat(DocumentatManage documentatmanage)
  {
      SqlParameter[] prams = {
			data.MakeInParam("@title",  SqlDbType.VarChar, 100, documentatmanage.Title),
			};
      return (data.RunProc("delete from tb_documentat where title=@title", prams));
  }
  #endregion
 #region 查询--文献信息
///<summary>
///根据--文献标题-得到文献信息
///</param name=""></param>
///<returns></returns>
  public DataSet FindDocumentatByTitle(DocumentatManage documentatmanage,string tbName)
  {
      SqlParameter[] prams = {
			data.MakeInParam("@title",  SqlDbType.VarChar, 100,"%"+ documentatmanage.Title+"%"),
			};
      return (data.RunProcReturn("select * from  tb_documentat where title like @title", prams, tbName));
  }
  ///<summary>
  ///根据--文献关键词--得到文献信息
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet FindDocumentatByKeyWord(DocumentatManage documentatmanage, string tbName)
  {
      SqlParameter[] prams = {
			data.MakeInParam("@keyword",  SqlDbType.VarChar, 100, "%"+documentatmanage.KeyWord+"%"),
			};
      return (data.RunProcReturn("select * from  tb_documentat where keyword like @keyword", prams, tbName));
  }
  ///<summary>
  ///根据--文献作者-得到文献信息
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet FindDocumentatByAuthor(DocumentatManage documentatmanage, string tbName)
  {
      SqlParameter[] prams = {
			            data.MakeInParam("@author",  SqlDbType.VarChar, 50, "%"+documentatmanage.Author+"%" ),
			};
      return (data.RunProcReturn("select * from  tb_documentat where author like @author", prams, tbName));
  }
  ///<summary>
  ///根据--文献类型-得到文献信息
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet FindDocumentatByType(DocumentatManage documentatmanage, string tbName)
  {
      SqlParameter[] prams = {
			            data.MakeInParam("@type",  SqlDbType.VarChar, 50, "%"+documentatmanage.Type+"%" ),
			};
      return (data.RunProcReturn("select * from  tb_documentat where type like @type", prams, tbName));
  }
  ///<summary>
  ///根据--文献主题-得到文献信息
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet FindDocumentatByTopic(DocumentatManage documentatmanage, string tbName)
  {
      SqlParameter[] prams = {
			          data.MakeInParam("@topic",  SqlDbType.VarChar, 100, "%"+documentatmanage.Topic+"%" ),
			};
      return (data.RunProcReturn("select * from  tb_documentat where topic like @topic", prams, tbName));
  }
  ///<summary>
  ///得到文献下载排行的前5名
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet GetDocumentatSort( string tbName)
  {
      return (data.RunProcReturn("select top 5* from tb_documentat where downloads<>0 ORDER BY downloads desc", tbName));
  }
  ///<summary>
  ///得到文献下载排行
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet GetAllDocumentatSort(string tbName)
  {
      return (data.RunProcReturn("select * from tb_documentat where downloads<>0 ORDER BY downloads desc", tbName));
  }
  ///<summary>
  ///得到所有--文献信息
  ///</param name=""></param>
  ///<returns></returns>
  public DataSet GetAllDocumentat( string tbName)
  {
      
      return (data.RunProcReturn("select * from  tb_documentat ORDER BY title",  tbName));
  }

 #endregion
}
