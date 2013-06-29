<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="BasicInfo.aspx.cs" Inherits="Users_BasicInfo" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">学生基本信息</div>
  <table id="BasicInfoTable">
    <tr>
      <td style="width: 15%">姓名</td>
      <td style="width: 35%"><asp:TextBox ID="Name" runat="server" CssClass="Text" /></td>
      <td style="width: 50%">请填写真实姓名，此姓名必须与身份证一致<br />
        如遇无法输入的生僻字，请以拼音代替<br />
        举例：李阿三、张JUN政</td>
    </tr>
    <tr>
      <td>性别</td>
      <td><asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
          <asp:ListItem Selected="True" Value="True">男</asp:ListItem>
          <asp:ListItem Value="False">女</asp:ListItem>
        </asp:RadioButtonList></td>
      <td></td>
    </tr>
    <tr>
      <td>民族</td>
      <td><asp:TextBox ID="Race" runat="server" CssClass="Text" /></td>
      <td>请正确填写民族<br />
        举例：汉族、土家族</td>
    </tr>
    <tr>
      <td>出生日期</td>
      <td><asp:TextBox ID="Birthday" runat="server" CssClass="Text" /></td>
      <td>请按照“年-月-日”的格式填写<br />
        举例：1990-8-15</td>
    </tr>
    <tr>
      <td>身份证号</td>
      <td><asp:TextBox ID="IDCard" runat="server" CssClass="Text" /></td>
      <td>请输入15或18位身份证号</td>
    </tr>
    <tr>
      <td>就读中学</td>
      <td>
          <asp:DropDownList ID="Province" runat="server" width="50" Height="20" AutoPostBack="true" OnSelectedIndexChanged="Province_SelectedIndexChanged">
                           
          </asp:DropDownList>
          <asp:DropDownList ID="SchoolName" runat="server" width="120" Height="20" >            
              
          </asp:DropDownList><br /><br />
          <asp:Label runat="server">其他</asp:Label>          
          <asp:CheckBox runat="server" ID="Others" OnCheckedChanged="Others_CheckedChanged" AutoPostBack="true"></asp:CheckBox >                 
          <asp:TextBox ID="otherSchool" runat="server" width="130" Height="15" Enabled="true" ></asp:TextBox>
      </td>       
      <td>
          注意：由于条件限制，未能完整列出各省市中学名单；<br />
          列表中未出现请勾选其他，在文本框填写就读中学的全称<br />          
        举例：北京大学附属中学、北京市顺义区第一中学
      </td>
    </tr>
    <tr>
      <td>学校通讯地址</td>
      <td><asp:TextBox ID="SchoolAddr" runat="server" CssClass="Text" TextMode="MultiLine" Rows="3" /></td>
      <td>请填写学校详细的通讯地址<br />
        举例：北京市海淀区颐和园路5号</td>
    </tr>
    <tr>
      <td>学校邮编</td>
      <td><asp:TextBox ID="SchoolPC" runat="server" CssClass="Text" /></td>
      <td></td>
    </tr>
    <tr>
      <td>家庭通讯地址</td>
      <td><asp:TextBox ID="FamilyAddr" runat="server" CssClass="Text" TextMode="MultiLine" Rows="3" /></td>
      <td>请填写家庭详细的通讯地址</td>
    </tr>
    <tr>
      <td>家庭邮编</td>
      <td><asp:TextBox ID="FamilyPC" runat="server" CssClass="Text" /></td>
      <td></td>
    </tr>
    <tr>
      <td>家庭电话</td>
      <td><asp:TextBox ID="FamilyPhone" runat="server" CssClass="Text" /></td>
      <td>请填写家庭的固定电话，格式为“区号-电话号码”<br />
        如果没有固定电话，也可以用家庭的手机号代替<br />
        举例：010-62765834</td>
    </tr>
    <tr>
      <td>其它电话</td>
      <td><asp:TextBox ID="OtherPhone" runat="server" CssClass="Text" /></td>
      <td>请填写可以与家庭取得联系的其它固定电话或手机</td>
    </tr>
    <tr>
      <td colspan="3"><asp:Button ID="Submit" Text="提交" runat="server" OnClick="OnSubmit_Click" class="Button" disabled/></td>
    </tr>
  </table>
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Name,ctl00_ctl00_MainContent_UserContent_Race" required="true" expression="numeric " mode="deny"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_SchoolName,ctl00_ctl00_MainContent_UserContent_SchoolAddr,ctl00_ctl00_MainContent_UserContent_FamilyAddr" required="true"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Birthday" validations="validanguage.validateDate" required="true" expression="numeric-" mode="allow"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_IDCard" regex="(^\d{15}$)|(^\d{17}[Xx0-9]$)" required="true" expression="numericXx" mode="allow"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_SchoolPC,ctl00_ctl00_MainContent_UserContent_FamilyPC" regex="^\d{6}$" required="true" expression="numeric" mode="allow"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_FamilyPhone,ctl00_ctl00_MainContent_UserContent_OtherPhone" regex="(^0\d{2,3}-\d{7,8}$)|(^1[358]\d{9}$)" required="true" expression="numeric-" mode="allow"> -->
</asp:Content>
