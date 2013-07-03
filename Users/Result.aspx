<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true"
    CodeFile="Result.aspx.cs" Inherits="Users_Result" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" runat="Server">
    <div id="Pass" runat="server">
        <div id="PrintButton" style="padding: 5px; text-align: right">
            [<a href="javascript:window.print()">打印本报到通知书</a>]</div>
        <div style="margin: 10px 20px; padding: 20px; border: #B22 5px solid; font-size: 20px;
            background-color: #FFC; text-align: justify; text-justify: inter-ideograph">
            <asp:Literal ID="NameLitPass" runat="server" />
            同学(编号
            <asp:Literal ID="IDLitPass" runat="server" />)：<br />
            祝贺您！通过对相关材料的审核，您顺利获得了参加此次夏令营的资格，请依《报到注意事项》的提示按时报到。
            <p style="font-size: 18px; margin: 30px 0 0 0; padding-left: 250px; text-align: center">
                北京大学信息科学技术学院<br />
                2013年6月20日</p>
        </div>
        <div>
            <p style="color: #B22; font-size: 14px; font-weight: bold; text-align: center">
                北京大学2013年全国中学生信息科学夏令营报到注意事项</p>
            <table style="width: 100%; margin: 0; line-height: 1.8">
                <tr>
                    <td valign="top">
                        1.
                    </td>
                    <td valign="top">
                        请获得资格的营员登陆自己的账号，打印报到通知书。除报到通知书外，报到时还需要持身份证或学生证等有效证件。
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        2.
                    </td>
                    <td valign="top">
                        夏令营报到时间为7月14日8:30-17:00，报到地点为北京大学理科2号楼一层门厅。<br />
                        联系电话：010-62751760/62751894。<br />
                        路线指示：<br />
                        ·北京站：从北京站乘坐地铁2号线至宣武门站，转乘地铁4号线至北京大学东门站。<br />
                        ·北京西站：从北京西站乘坐320路公交车至中关园站，即至北京大学东门。<br />
                        ·北京南站：从北京南站乘坐地铁4号线至北京大学东门站。<br />
                        ·首都机场：从机场乘坐机场巴士5线(首都机场—中关村)到中关村站下车，乘坐333路公交车至中关村西站，向北穿过小区即到北京大学南门，或向东步行200米，到中关村一桥路口，再向北200米即到北京大学东门。<br />
                        更多路线请查询百度地图：<a href="http://ditu.baidu.com/" target="_blank">http://ditu.baidu.com/</a>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        3.
                    </td>
                    <td valign="top">
                        夏令营日程安排为：
                        <table border="1" bordercolor="#000" cellpadding="5" cellspacing="0" style="width: 100%;
                            margin: 0">
                            <tr>
                                <td width="60">
                                    &nbsp;
                                </td>
                                <td align="center">
                                    上午8：30—11：30
                                </td>
                                <td align="center">
                                    下午14：00—17：00
                                </td>
                                <td align="center">
                                    晚上19：00—21：00
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    14日
                                </td>
                                <td colspan="2" align="center">
                                    学员报到
                                </td>
                                <td>
                                    辅导员、老师与营员见面会
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    第一天<br />
                                    (15日)
                                </td>
                                <td>
                                    开营仪式<br />
                                    院领导、招办领导及<br />
                                    知名教授的讲座
                                </td>
                                <td>                                    
                                    校园参观<br />
                                    各班组织活动
                                </td>
                                <td>
                                    院友讲座
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    第二天<br />
                                    (16日)
                                </td>
                                <td>
                                    计算机方向名师讲座
                                </td>
                                <td>
                                    智能方向名师讲座
                                </td>
                                <td>
                                    笔试
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    第三天<br />
                                    (17日)
                                </td>
                                <td>
                                    电子方向名师讲座
                                </td>
                                <td>
                                    微电子方向名师讲座
                                </td>
                                <td>
                                    笔试
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    第四天<br />
                                    (18日)
                                </td>
                                <td>
                                    电子实验考核<br />
                                    计算机上机考核
                                </td>
                                <td>
                                    面试
                                </td>
                                <td>
                                    联欢晚会
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    第五天<br />
                                    (19日)
                                </td>
                                <td>
                                    参观实验室<br />
                                    与老师、同学交流<br />
                                    结营仪式
                                </td>
                                <td colspan="2">
                                    返程
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        4.
                    </td>
                    <td valign="top">
                        夏令营费用需要在报到前通过首信易支付在线支付(<a href="/OnlinePay/Pay.aspx">点此进行在线支付</a>)。
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        5.
                    </td>
                    <td valign="top">
                        请同学们携带一些常用物品，如感冒药、创可贴及雨具等。
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        6.
                    </td>
                    <td valign="top">
                        营员报道后必须严格执行信息科学夏令营各项活动安排。
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="NotPass" runat="server">
        <div style="margin: 20px; padding: 20px; border: #777 5px solid; font-size: 20px;
            font-weight: bold; background-color: #EEE; text-align: justify; text-justify: inter-ideograph">
            <asp:Literal ID="NameLitNotPass" runat="server" />
            同学：<br />
            很遗憾您没能获得参加此次夏令营的资格。感谢您对我们的关注，祝愿您学业有成。
            <p style="font-size: 18px; margin: 30px 0 0 0; padding-left: 250px; text-align: center">
                北京大学信息科学技术学院<br />
                2013年6月20日</p>
        </div>

    </div>
</asp:Content>
