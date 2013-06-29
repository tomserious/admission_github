<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Result.aspx.cs"
    Inherits="OnlinePay_Result" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="font-size: 14px; border: 3px solid #777; padding: 10px 30px; width: 500px;
        margin: 20px auto; background-color: #FFD; text-align: center; color: #B22;">
        <asp:Literal ID="Message" runat="server" /></div>
    <div style="padding: 10px 30px; border: 3px solid #777; background-color: #FFD; margin: 5px auto;
        width: 500px; font-size: 14px;">
        如果在支付过程中遇到问题，请联系首信易支付客服：<br />
        (010) 59321108 (7×24小时服务)<br />
        (010) 82652626-6576/6829/6613 (9:00-17:30)<br />
        联系客服时，请提供上面的订单编号。</div>
</asp:Content>
