<%@ Page Language="C#" MasterPageFile="~/MasterPage/Site.master" AutoEventWireup="true" CodeFile="TypeManage.aspx.cs" Inherits="DocumentManage_TypeManage" Title="Untitled Page" EnableEventValidation="false"%>
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
                  <td colspan="3" align="right" background="../images/danganguanli.gif" style="height: 45px; background-image: url(../images/tushuleixingguanli.gif);">&nbsp;</td>
                  </tr>
                <tr>
                  <td width="622" height="32" align="right"><img src="../images/tianjia tubiao.gif" width="19" height="18"></td>
                  <td width="89" align="right" class="daohang1"><asp:HyperLink ID="hpLinkAddBType" runat="server" NavigateUrl="~/DocumentatManage/AddType.aspx" Width="98px" ForeColor="Black">添加文献类型信息</asp:HyperLink></td>
                  <td width="45">&nbsp;</td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="23" background="../images/tu shu pai hang2.gif"><asp:GridView ID="gvBTypeInfo" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" PageSize="5" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvBTypeInfo_PageIndexChanging" OnRowCancelingEdit="gvBTypeInfo_RowCancelingEdit" OnRowDeleting="gvBTypeInfo_RowDeleting" OnRowEditing="gvBTypeInfo_RowEditing" OnRowUpdating="gvBTypeInfo_RowUpdating" Width="543px" HorizontalAlign="Center">
                    <HeaderStyle BackColor="#DFF5F5" Font-Bold="False" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="文献类型编号" ReadOnly="True" />
                        <asp:BoundField DataField="categoryName" HeaderText="类型名称" />
                        <asp:BoundField DataField="parentId" HeaderText="父级类型编号" />
                        <asp:BoundField DataField="cateLevel" HeaderText="类型级别" />
                        <asp:BoundField DataField="catePath" HeaderText="类型路径" />
                        <asp:CommandField EditText="修改" HeaderText="修改" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
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

