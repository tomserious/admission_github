<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs"
    Inherits="OnlinePay_Pay" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Literal ID="JS" runat="server" />
    <h1 style="text-align: center; margin: 5px; color: #B22; font-size: 24px">
        交费确认信息</h1>
    <table style="border: 1px solid #000; margin: 0 auto; width: 400px; font-size: 14px">
        <tr>
            <td style="padding: 5px 10px; border: 1px solid #000">
                报名号
            </td>
            <td style="padding: 5px 10px; border: 1px solid #000">
                <asp:Literal ID="UserNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding: 5px 10px; border: 1px solid #000">
                订单号
            </td>
            <td style="padding: 5px 10px; border: 1px solid #000">
                <asp:Literal ID="BillNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding: 5px 10px; border: 1px solid #000">
                交费数额
            </td>
            <td style="padding: 5px 10px; border: 1px solid #000">
                人民币：<asp:Literal ID="BillAmount" runat="server" />
                元
            </td>
        </tr>
    </table>
    <asp:Literal ID="v_mid" runat="server" />
    <asp:Literal ID="v_oid" runat="server" />
    <asp:Literal ID="v_rcvname" runat="server" />
    <asp:Literal ID="v_rcvaddr" runat="server" />
    <asp:Literal ID="v_rcvtel" runat="server" />
    <asp:Literal ID="v_rcvpost" runat="server" />
    <asp:Literal ID="v_amount" runat="server" />
    <asp:Literal ID="v_ymd" runat="server" />
    <asp:Literal ID="v_orderstatus" runat="server" />
    <asp:Literal ID="v_ordername" runat="server" />
    <asp:Literal ID="v_moneytype" runat="server" />
    <asp:Literal ID="v_url" runat="server" />
    <asp:Literal ID="v_md5info" runat="server" />
    <p style="text-align: center">
        <input type="submit" value="点此进行网上交费" /></p>
    <div style="padding: 10px 30px; border: 3px solid #777; background-color: #FFD; margin: 5px auto;
        width: 500px; font-size: 14px;">
        请记录交费确认信息中的订单号以备查询。<br />
        如果在支付过程中遇到问题，请联系首信易支付客服：<br />
        (010) 59321108 (7×24小时服务)<br />
        (010) 82652626-6576/6829/6613 (9:00-17:30)</div>
</asp:Content>
