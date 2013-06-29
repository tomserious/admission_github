<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReadNews.aspx.cs"
    Inherits="ReadNews" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <p style="color: #B22; font-weight: bold; text-align: center; font-size: 18px; margin: 10px;
        padding: 0">
        <asp:Literal ID="Title" runat="server" />
    </p>
    <hr style="margin: 0 30px" />
    <p style="color: #999; margin: 0; text-align: center">
        发布日期：
        <asp:Literal ID="NewsDate" runat="server" />
        阅读次数：
        <asp:Literal ID="ViewCounter" runat="server" />
    </p>
    <div class="ReadNewsContent">
        <asp:Literal ID="Content" runat="server" />
    </div>
</asp:Content>
