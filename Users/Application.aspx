<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="Users_Application" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="PrintButton" style="padding: 5px">[<a href="javascript:window.print()">打印本报名表</a>]</div>
  <div id="ApplicationTitle">北京大学2013年全国中学生信息科学夏令营报名表</div>
  <table id="ApplicationTable">
    <tr>
      <td><table id="CodeInfo">
          <tr>
            <td style="width: 45%">报名表号：
              <asp:Literal ID="AppID" runat="server" /></td>
            <td style="width: 55%">姓名：
              <asp:Literal ID="NameA" runat="server" /></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td><table id="BasicInfo">
          <tr>
            <td colspan="6" class="Title">学生基本信息</td>
            <td rowspan="6" style="width: 18%; text-align: center">贴照片处<br />
              请粘贴学生近期免冠一寸照片，否则本申请表无效</td>
          </tr>
          <tr>
            <td class="Right" style="width: 15%">姓名</td>
            <td style="width: 19%"><asp:Literal ID="NameB" runat="server" /></td>
            <td class="Right" style="width: 12%">性别</td>
            <td style="width: 6%"><asp:Literal ID="Gender" runat="server" /></td>
            <td class="Right" style="width: 10%">民族</td>
            <td style="width: 20%"><asp:Literal ID="Race" runat="server" /></td>
          </tr>
          <tr>
            <td class="Right">出生日期</td>
            <td><asp:Literal ID="Birthday" runat="server" /></td>
            <td class="Right">身份证号</td>
            <td colspan="3"><asp:Literal ID="IDCard" runat="server" /></td>
          </tr>
          <tr>
            <td class="Right">就读中学</td>
            <td colspan="5"><asp:Literal ID="SchoolName" runat="server" /></td>
          </tr>
          <tr>
            <td class="Right">学校通讯地址</td>
            <td colspan="5"><asp:Literal ID="SchoolAddr" runat="server" /></td>
          </tr>
          <tr>
            <td class="Right">家庭通讯地址</td>
            <td colspan="5"><asp:Literal ID="FamilyAddr" runat="server" /></td>
          </tr>
          <tr>
            <td class="Right">家庭电话</td>
            <td colspan="2"><asp:Literal ID="FamilyPhone" runat="server" /></td>
            <td colspan="2" class="Right">其它电话</td>
            <td colspan="2"><asp:Literal ID="OtherPhone" runat="server" /></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td><table id="FamilyMembers">
          <tr>
            <td colspan="5" class="Title">主要家庭成员</td>
          </tr>
          <tr>
            <td style="width: 12%">与本人关系</td>
            <td style="width: 12%">姓名</td>
            <td style="width: 46%">工作单位</td>
            <td style="width: 12%">职务</td>
            <td style="width: 18%">联系电话</td>
          </tr>
          <asp:Literal ID="FamilyMembers" runat="server" />
        </table></td>
    </tr>
    <tr>
      <td><table id="Performance">
          <tr>
            <td colspan="7" class="Title">学生在校成绩</td>
          </tr>
          <tr>
            <td style="width: 16%">高一上学期</td>
            <td style="width: 14%">排名 <asp:Literal ID="Term1Perf" runat="server" /></td>
            <td style="width: 14%">语文 <asp:Literal ID="Term1Chinese" runat="server" /></td>
            <td style="width: 14%">数学 <asp:Literal ID="Term1Math" runat="server" /></td>
            <td style="width: 14%">外语 <asp:Literal ID="Term1English" runat="server" /></td>
            <td style="width: 14%">物理 <asp:Literal ID="Term1Physics" runat="server" /></td>
            <td style="width: 14%">化学 <asp:Literal ID="Term1Chemistry" runat="server" /></td>
          </tr>
          <tr>
            <td style="width: 16%">高一下学期</td>
            <td style="width: 14%">排名 <asp:Literal ID="Term2Perf" runat="server" /></td>
            <td style="width: 14%">语文 <asp:Literal ID="Term2Chinese" runat="server" /></td>
            <td style="width: 14%">数学 <asp:Literal ID="Term2Math" runat="server" /></td>
            <td style="width: 14%">外语 <asp:Literal ID="Term2English" runat="server" /></td>
            <td style="width: 14%">物理 <asp:Literal ID="Term2Physics" runat="server" /></td>
            <td style="width: 14%">化学 <asp:Literal ID="Term2Chemistry" runat="server" /></td>
          </tr>
          <tr>
            <td style="width: 16%">高二上学期</td>
            <td style="width: 14%">排名 <asp:Literal ID="Term3Perf" runat="server" /></td>
            <td style="width: 14%">语文 <asp:Literal ID="Term3Chinese" runat="server" /></td>
            <td style="width: 14%">数学 <asp:Literal ID="Term3Math" runat="server" /></td>
            <td style="width: 14%">外语 <asp:Literal ID="Term3English" runat="server" /></td>
            <td style="width: 14%">物理 <asp:Literal ID="Term3Physics" runat="server" /></td>
            <td style="width: 14%">化学 <asp:Literal ID="Term3Chemistry" runat="server" /></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td><table id="Deliverance">
          <tr>
            <td><div class="Title">中学推荐意见</div>
              <div class="SignArea"><span>校长签字：　　　　　　　　(学校加盖公章)</span><br />
                <span>　　　　年　　月　　日</span></div></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td><table id="Headmaster">
          <tr>
            <td rowspan="2" class="Title" style="width: 16%">校长联系方式</td>
            <td style="width: 21%">校长姓名</td>
            <td style="width: 21%">办公电话</td>
            <td style="width: 21%">传真</td>
            <td style="width: 21%">手机</td>
          </tr>
          <tr>
            <td><asp:Literal ID="HeadmasterName" runat="server" /></td>
            <td><asp:Literal ID="HeadmasterOP" runat="server" /></td>
            <td><asp:Literal ID="HeadmasterFax" runat="server" /></td>
            <td><asp:Literal ID="HeadmasterMP" runat="server" /></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td><table id="Honors">
          <tr>
            <td colspan="2" class="Title">高中以来市级以上竞赛获奖情况</td>
          </tr>
          <asp:Literal ID="Honors" runat="server" />
        </table></td>
    </tr>
    <tr>
      <td><table id="Memo">
          <tr>
            <td>请将本表用A4纸打印，签字并盖章后连同其它相关报名材料(获奖证书复印件等)进行装订，装订时请将本报名表格作为报名材料封面，请勿另制封面。<br />
              请确保于6月10日前将整套报名材料邮寄至：北京大学信息科学技术学院本科教务办公室 邮编：100871<br />
              联系人：张老师 联系电话：010-62751894</td>
          </tr>
        </table></td>
    </tr>
  </table>
</asp:Content>
