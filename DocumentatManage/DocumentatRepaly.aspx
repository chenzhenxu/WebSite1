<%@ Page Language="C#" MasterPageFile="~/MasterPage/Site.master" AutoEventWireup="true" CodeFile="DocumentatRepaly.aspx.cs" Inherits="DocumentatManage_DocumentatRepaly" Title="Untitled Page" EnableEventValidation="false"%>
<%@ Register Assembly="PdfViewer" Namespace="PdfViewer" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      
        &nbsp;
         <cc1:ShowPdf ID="ShowPdf1" runat="server" BorderStyle="Inset" BorderWidth="2px" FilePath=""
            Height="600px" Style="z-index: 103; left: 24px; top: 128px"
            Width="856px" />
      
</asp:Content>

