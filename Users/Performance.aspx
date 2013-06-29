<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true"
    CodeFile="Performance.aspx.cs" Inherits="Users_Performance" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" runat="Server">
    <div id="ClassTitle">
        学生在校成绩</div>
    <table id="PerformanceTable">
        <tr>
            <td>
            </td>
            <td>
                年级排名</td>
            <td>
                年级总人数</td>
            <td>
                语文成绩</td>
            <td>
                数学成绩</td>
            <td>
                外语成绩</td>
            <td>
                物理成绩</td>
            <td>
                化学成绩</td>
        </tr>
        <tr>
            <td>
                高一上学期</td>
            <td>
                <asp:textbox id="Term1Rank" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1Total" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1Chinese" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1Math" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1English" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1Physics" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term1Chemistry" runat="server" cssclass="Text" />
            </td>
        </tr>
        <tr>
            <td>
                高一下学期</td>
            <td>
                <asp:textbox id="Term2Rank" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2Total" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2Chinese" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2Math" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2English" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2Physics" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term2Chemistry" runat="server" cssclass="Text" />
            </td>
        </tr>
        <tr>
            <td>
                高二上学期</td>
            <td>
                <asp:textbox id="Term3Rank" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3Total" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3Chinese" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3Math" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3English" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3Physics" runat="server" cssclass="Text" />
            </td>
            <td>
                <asp:textbox id="Term3Chemistry" runat="server" cssclass="Text" />
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:button id="Submit" text="提交" runat="server" onclick="OnSubmit_Click" class="Button" disabled />
            </td>
        </tr>
    </table>
    <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Term1Rank,ctl00_ctl00_MainContent_UserContent_Term1Total,ctl00_ctl00_MainContent_UserContent_Term2Rank,ctl00_ctl00_MainContent_UserContent_Term2Total,ctl00_ctl00_MainContent_UserContent_Term3Rank,ctl00_ctl00_MainContent_UserContent_Term3Total" regex="^\d+$" required="true" expression="numeric" mode="allow"> -->
    <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Term1Chinese,ctl00_ctl00_MainContent_UserContent_Term1Math,ctl00_ctl00_MainContent_UserContent_Term1English,ctl00_ctl00_MainContent_UserContent_Term1Physics,ctl00_ctl00_MainContent_UserContent_Term1Chemistry,ctl00_ctl00_MainContent_UserContent_Term2Chinese,ctl00_ctl00_MainContent_UserContent_Term2Math,ctl00_ctl00_MainContent_UserContent_Term2English,ctl00_ctl00_MainContent_UserContent_Term2Physics,ctl00_ctl00_MainContent_UserContent_Term2Chemistry,ctl00_ctl00_MainContent_UserContent_Term3Chinese,ctl00_ctl00_MainContent_UserContent_Term3Math,ctl00_ctl00_MainContent_UserContent_Term3English,ctl00_ctl00_MainContent_UserContent_Term3Physics,ctl00_ctl00_MainContent_UserContent_Term3Chemistry" regex="^\d{1,3}(\.[05])?$" required="true" expression="numeric." mode="allow"> -->
</asp:Content>
