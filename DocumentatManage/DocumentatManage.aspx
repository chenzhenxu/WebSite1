<%@ Page Language="C#" MasterPageFile="~/MasterPage/Site.master" AutoEventWireup="true" CodeFile="DocumentatManage.aspx.cs" Inherits="DocumentatManage_DocumentatManage" Title="Untitled Page" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="771" height="465" border="0" align="center" cellpadding="0" cellspacing="1" class="waikuang">
        <tr>
          <td valign="top"><table width="756" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="756" height="24" align="right" class="daohang1">&nbsp;</td>
            </tr>
            <tr>
              <td height="22" background="../images/tu shu pai hang2.gif"><table width="756" height="77" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="45" colspan="3" align="right" background="../images/danganguanli.gif">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBook" runat="server" NavigateUrl="~/DocumentatManage/AddDocumentat.aspx" ForeColor="Black">添加文献信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvDocumentatInfo" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvDocumentatInfo_PageIndexChanging" OnRowDeleting="gvDocumentatInfo_RowDeleting"  Width="678px" HorizontalAlign="Center">
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DFF5F5" />
                    <Columns>
                        <asp:BoundField DataField="title" HeaderText="标题" ReadOnly="True" />
                        <asp:BoundField DataField="keyword" HeaderText="关键词" />
                        <asp:BoundField DataField="author" HeaderText="作者" />
                        <asp:BoundField DataField="topic" HeaderText="主题" />
                        <asp:BoundField DataField="type" HeaderText="类型" />
                        <asp:BoundField DataField="downloads" HeaderText="下载次数" />
                        <asp:BoundField DataField="uploadtime" HeaderText="上传时间" />
                        <asp:BoundField DataField="upload" HeaderText="上传者" />
                        <asp:BoundField DataField="check" HeaderText="审核是否通过" />
                        <asp:HyperLinkField DataNavigateUrlFormatString="UpdateDocumentat.aspx?title={0}" HeaderText="详情"
                            Text="修改" DataNavigateUrlFields="title" >
                            <ControlStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <HeaderStyle ForeColor="Black" />
                        </asp:HyperLinkField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            <ControlStyle ForeColor="Black" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <p>&nbsp;</p></td>
            </tr>
            <tr>
              <td height="4" valign="top" background="../images/tu shu pai hang3.gif"></td>
            </tr>
            
          </table>
            </td>
        </tr>
      </table>
</asp:Content>

