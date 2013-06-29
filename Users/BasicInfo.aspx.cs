using System;

public partial class Users_BasicInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BasicInfo bi;
        if (!IsPostBack && (bi = BasicInfo.GetBasicInfoByID(((Users)Session["Identify"]).UserID)) != null)
        {
            Name.Text = bi.Name;
            Gender.SelectedValue = bi.Gender.ToString();
            Race.Text = bi.Race;
            Birthday.Text = bi.Birthday.ToString("yyyy-M-d");
            IDCard.Text = bi.IDCard;
            SchoolName.Text = bi.SchoolName;
            SchoolAddr.Text = bi.SchoolAddr;
            SchoolPC.Text = bi.SchoolPC;
            FamilyAddr.Text = bi.FamilyAddr;
            FamilyPC.Text = bi.FamilyPC;
            FamilyPhone.Text = bi.FamilyPhone;
            OtherPhone.Text = bi.OtherPhone;
            Province.Text = bi.Province;
        }
        #region 填充省份DropdownList
        Province.Items.Add("安徽");
        Province.Items.Add("北京");
        Province.Items.Add("重庆");
        Province.Items.Add("福建");
        Province.Items.Add("甘肃");
        Province.Items.Add("广东");
        Province.Items.Add("广西");        
        Province.Items.Add("贵州");
        Province.Items.Add("海南");
        Province.Items.Add("河北");
        Province.Items.Add("河南");
        Province.Items.Add("黑龙江");
        Province.Items.Add("湖北");
        Province.Items.Add("湖南");
        Province.Items.Add("吉林");
        Province.Items.Add("江苏");
        Province.Items.Add("江西");
        Province.Items.Add("辽宁");
        Province.Items.Add("内蒙古");
        Province.Items.Add("宁夏");        
        Province.Items.Add("青海");
        Province.Items.Add("山东");
        Province.Items.Add("山西");
        Province.Items.Add("陕西");
        Province.Items.Add("上海");
        Province.Items.Add("四川");
        Province.Items.Add("天津");
        Province.Items.Add("西藏");
        Province.Items.Add("新疆");
        Province.Items.Add("云南");
        Province.Items.Add("浙江");
        
        #endregion
    }
    /// <summary>
    /// 提交基本信息，并重定向到报名管理首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        BasicInfo bi = new BasicInfo();
        bi.UserID = ((Users)Session["Identify"]).UserID;
        bi.Name = Name.Text.Trim();
        bi.Gender = bool.Parse(Gender.SelectedValue);
        bi.Race = Race.Text.Trim();
        bi.Birthday = DateTime.Parse(Birthday.Text);
        bi.IDCard = IDCard.Text.Trim();
        //bi.SchoolName = SchoolName.Text.Trim();
        if(Others.Checked)
        {
            bi.SchoolName = otherSchool.Text.Trim();
            bi.Province = Province.SelectedItem.Text.Trim();
        }
        else
        {
            bi.SchoolName = SchoolName.SelectedItem.Text.Trim();
            bi.Province = Province.SelectedItem.Text.Trim();
        }
        
        bi.SchoolAddr = SchoolAddr.Text.Trim();
        bi.SchoolPC = SchoolPC.Text.Trim();
        bi.FamilyAddr = FamilyAddr.Text.Trim();
        bi.FamilyPC = FamilyPC.Text.Trim();
        bi.FamilyPhone = FamilyPhone.Text.Trim();
        bi.OtherPhone = OtherPhone.Text.Trim();
        BasicInfo.SetBasicInfoByID(bi.UserID, bi);
        Response.Redirect("/Users/Index.aspx");
    }


    protected void Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        String myProvince = Province.SelectedItem.Text;
        #region 根据省份加载相应省份的重点中学
        switch (myProvince)
        {
            case "安徽":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("安徽省安庆市第一中学");
                SchoolName.Items.Add("安徽省蚌埠市第二中学");
                SchoolName.Items.Add("安徽省巢湖市第一中学");
                SchoolName.Items.Add("安徽省东至县第二中学");
                SchoolName.Items.Add("安徽省阜阳市第一中学");
                SchoolName.Items.Add("安徽省合肥市第一中学");
                SchoolName.Items.Add("安徽省合肥市一六八中学");
                SchoolName.Items.Add("安徽省淮北市第一中学");
                SchoolName.Items.Add("安徽省黄山市屯溪第一中学");
                SchoolName.Items.Add("安徽省师范大学附属中学");
                break;
            case "北京":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("北京大学附属中学");
                SchoolName.Items.Add("北京汇文中学");
                SchoolName.Items.Add("北京景山学校");
                SchoolName.Items.Add("北京师范大学第二附属中学");
                SchoolName.Items.Add("北京师范大学附属实验中学");
                SchoolName.Items.Add("北京师范大学附属中学");
                SchoolName.Items.Add("北京市第八十中学");
                SchoolName.Items.Add("北京市第八中学");
                SchoolName.Items.Add("北京市第二中学");
                SchoolName.Items.Add("北京市第十二中学");
                SchoolName.Items.Add("北京市第四中学");
                SchoolName.Items.Add("北京市第五中学");
                SchoolName.Items.Add("北京市十一学校");
                SchoolName.Items.Add("北京市顺义区牛栏山第一中学");
                SchoolName.Items.Add("北京市一零一中学");
                SchoolName.Items.Add("清华大学附属中学");
                SchoolName.Items.Add("首都师范大学附属育新学校");
                SchoolName.Items.Add("首都师范大学附属中学");
                SchoolName.Items.Add("中国人民大学附属中学");

                break;
            case "福建":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("福建省福州高级中学");
                SchoolName.Items.Add("福建省福州市第三中学");
                SchoolName.Items.Add("福建省福州市第一中学");
                SchoolName.Items.Add("福建省建瓯市第一中学");
                SchoolName.Items.Add("福建省建阳市第一中学");
                SchoolName.Items.Add("福建省莆田市第一中学");
                SchoolName.Items.Add("福建省泉州市第五中学");
                SchoolName.Items.Add("福建省厦门市第一中学");
                SchoolName.Items.Add("福建省厦门市双十中学");
                SchoolName.Items.Add("福建省厦门外国语学校");
                SchoolName.Items.Add("福建省上杭第一中学");
                SchoolName.Items.Add("福建省石狮石光华侨联合中学");
                SchoolName.Items.Add("福建省仙游第一中学");
                SchoolName.Items.Add("福建省长汀县第一中学");
                SchoolName.Items.Add("福建师范大学附属中学");

                break;
            case "甘肃":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("甘肃省定西市第一中学");
                SchoolName.Items.Add("甘肃省皋兰县第一中学");
                SchoolName.Items.Add("甘肃省嘉峪关市酒钢三中");
                SchoolName.Items.Add("甘肃省靖远县第二中学");
                SchoolName.Items.Add("甘肃省酒泉中学");
                SchoolName.Items.Add("甘肃省兰州化工公司总校第一中学");
                SchoolName.Items.Add("甘肃省兰州市第一中学");
                SchoolName.Items.Add("甘肃省兰州市新亚中学");
                SchoolName.Items.Add("甘肃省兰州铁路局第五中学");
                SchoolName.Items.Add("甘肃省兰州铁一中");
                SchoolName.Items.Add("甘肃省临泽县第一中学");
                SchoolName.Items.Add("甘肃省青海油田第一中学");
                SchoolName.Items.Add("甘肃省庆阳第一中学");
                SchoolName.Items.Add("甘肃省武威市第一中学");
                SchoolName.Items.Add("甘肃省榆中县第一中学");
                SchoolName.Items.Add("西北师范大学第一附属中学");

                break;
            case "广东":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("广东省佛山市第一中学");
                SchoolName.Items.Add("广东省广州市第二中学");
                SchoolName.Items.Add("广东省广州市第六中学");
                SchoolName.Items.Add("广东省广州市执信中学");
                SchoolName.Items.Add("广东省惠州市第一中学");
                SchoolName.Items.Add("广东省揭阳市第一中学");
                SchoolName.Items.Add("广东省汕头市潮阳实验学校");
                SchoolName.Items.Add("广东省汕头市金山中学");
                SchoolName.Items.Add("广东省深圳市高级中学");
                SchoolName.Items.Add("广东省深圳外国语学校");
                SchoolName.Items.Add("广东省深圳中学");
                SchoolName.Items.Add("广东省实验中学");
                SchoolName.Items.Add("广东省湛江市第一中学");
                SchoolName.Items.Add("广东省中山市第一中学");
                SchoolName.Items.Add("广东省中山市纪念中学");
                SchoolName.Items.Add("广东省珠海市第一中学");
                SchoolName.Items.Add("华南师范大学附属中学");

                break;
            case "广西":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("广西百色高级中学");
                SchoolName.Items.Add("广西桂林市第十八中学");
                SchoolName.Items.Add("广西桂林中学");
                SchoolName.Items.Add("广西河池高级中学");
                SchoolName.Items.Add("广西柳州高级中学");
                SchoolName.Items.Add("广西柳州市铁路第一中学");
                SchoolName.Items.Add("广西南宁市第二中学");
                SchoolName.Items.Add("广西南宁市第三中学");
                SchoolName.Items.Add("广西师范大学附属中学");
                SchoolName.Items.Add("广西田东高级中学");
                SchoolName.Items.Add("广西玉林市高级中学");

                break;
            case "贵州":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("贵州教育学院实验中学");
                SchoolName.Items.Add("贵州省安顺市云马中学");
                SchoolName.Items.Add("贵州省都匀一中");
                SchoolName.Items.Add("贵州省贵阳市第六中学");
                SchoolName.Items.Add("贵州省贵阳市第一中学");
                SchoolName.Items.Add("贵州省凯里市第一中学");
                SchoolName.Items.Add("贵州省思南中学");
                SchoolName.Items.Add("贵州省天柱民族中学");
                SchoolName.Items.Add("贵州省余庆中学");
                SchoolName.Items.Add("贵州省遵义市第四中学");
                SchoolName.Items.Add("贵州省遵义市汇川区遵义航天中学");
                SchoolName.Items.Add("贵州师范大学附属中学");

                break;
            case "海南":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("海南第二中学（琼州大学附属中学）");
                SchoolName.Items.Add("海南国科园实验学校");
                SchoolName.Items.Add("海南省国兴中学");
                SchoolName.Items.Add("海南省海口市第一中学");
                SchoolName.Items.Add("海南省海口市景山学校");
                SchoolName.Items.Add("海南省海口市实验中学");
                SchoolName.Items.Add("海南省农垦加来高级中学");
                SchoolName.Items.Add("海南省农垦中学");
                SchoolName.Items.Add("海南省万宁中学");
                SchoolName.Items.Add("海南省文昌中学");
                SchoolName.Items.Add("海南师范大学附属中学");
                SchoolName.Items.Add("海南中学");
                break;
            case "河北":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("河北省保定市第二中学");
                SchoolName.Items.Add("河北省保定市第三中学");
                SchoolName.Items.Add("河北省保定市第一中学");
                SchoolName.Items.Add("河北省昌黎汇文第一中学");
                SchoolName.Items.Add("河北省邯郸市第一中学");
                SchoolName.Items.Add("河北省衡水中学");
                SchoolName.Items.Add("河北省冀州市中学");
                SchoolName.Items.Add("河北省秦皇岛市第一中学");
                SchoolName.Items.Add("河北省石家庄市第二十四中学");
                SchoolName.Items.Add("河北省石家庄市第二中学");
                SchoolName.Items.Add("河北省石家庄市第一中学");
                SchoolName.Items.Add("河北省石家庄市外国语学校");
                SchoolName.Items.Add("河北省石家庄市辛集中学");
                SchoolName.Items.Add("河北省唐山市第一中学");
                SchoolName.Items.Add("河北省邢台市第一中学");
                SchoolName.Items.Add("河北省张家口市第一中学");
                SchoolName.Items.Add("河北省正定中学");


                break;
            case "":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("北京大学附属中学河南分校");
                SchoolName.Items.Add("河南大学附属中学");
                SchoolName.Items.Add("河南省淮阳中学");
                SchoolName.Items.Add("河南省开封高级中学");
                SchoolName.Items.Add("河南省洛阳市第一高级中学");
                SchoolName.Items.Add("河南省南阳市第一中学");
                SchoolName.Items.Add("河南省内黄县第一中学");
                SchoolName.Items.Add("河南省濮阳市第一高级中学");
                SchoolName.Items.Add("河南省濮阳市油田第二高级中学");
                SchoolName.Items.Add("河南省濮阳市油田第一中学");
                SchoolName.Items.Add("河南省商丘市第一高级中学");
                SchoolName.Items.Add("河南省实验中学");
                SchoolName.Items.Add("河南省夏邑县高级中学");
                SchoolName.Items.Add("河南省项城市第一高级中学");
                SchoolName.Items.Add("河南省新乡市第一中学");
                SchoolName.Items.Add("河南省信阳高级中学");
                SchoolName.Items.Add("河南省信阳市光山县第二高级中学");
                SchoolName.Items.Add("河南省偃师高级中学");
                SchoolName.Items.Add("河南省郑州市101中学");
                SchoolName.Items.Add("河南省郑州市第一中学");
                SchoolName.Items.Add("河南省郑州市外国语学校");
                SchoolName.Items.Add("河南省驻马店高级中学");
                SchoolName.Items.Add("河南师范大学附属中学");
                SchoolName.Items.Add("郑州大学第一附属中学");
                SchoolName.Items.Add("中国一拖集团有限公司高级中学");

                break;
            case "黑龙江":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("哈尔滨师范大学附属中学");
                SchoolName.Items.Add("黑龙江省大庆第一中学");
                SchoolName.Items.Add("黑龙江省大庆实验中学");
                SchoolName.Items.Add("黑龙江省大庆铁人中学");
                SchoolName.Items.Add("黑龙江省大庆中学");
                SchoolName.Items.Add("黑龙江省哈尔滨市第九中学");
                SchoolName.Items.Add("黑龙江省哈尔滨市第六中学");
                SchoolName.Items.Add("黑龙江省哈尔滨市第三中学");
                SchoolName.Items.Add("黑龙江省哈尔滨市双城兆麟中学");
                SchoolName.Items.Add("黑龙江省海林林业局第一中学");
                SchoolName.Items.Add("黑龙江省鹤岗市第一中学");
                SchoolName.Items.Add("黑龙江省佳木斯市第一中学");
                SchoolName.Items.Add("黑龙江省双鸭山市第一中学");

                break;
            case "湖北":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("湖北省黄冈中学");
                SchoolName.Items.Add("湖北省黄石市第二中学");
                SchoolName.Items.Add("湖北省荆门市龙泉中学");
                SchoolName.Items.Add("湖北省荆州中学");
                SchoolName.Items.Add("湖北省沙市中学");
                SchoolName.Items.Add("湖北省水果湖高级中学");
                SchoolName.Items.Add("湖北省武汉市第二中学");
                SchoolName.Items.Add("湖北省武汉市第三中学");
                SchoolName.Items.Add("湖北省武汉市外国语学校");
                SchoolName.Items.Add("湖北省仙桃中学（原沔阳中学）");
                SchoolName.Items.Add("湖北省襄樊市第四中学");
                SchoolName.Items.Add("湖北省襄樊市第五中学");
                SchoolName.Items.Add("湖北省孝感高级中学");
                SchoolName.Items.Add("湖北省宜昌市第一中学");
                SchoolName.Items.Add("湖北省宜昌市夷陵中学");
                SchoolName.Items.Add("华中师范大学第一附属中学");
                SchoolName.Items.Add("武汉钢铁集团公司第三子弟中学");

                break;
            case "湖南":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("湖南省衡阳市第八中学");
                SchoolName.Items.Add("湖南省浏阳市第一宗学");
                SchoolName.Items.Add("湖南省娄底市第一中学");
                SchoolName.Items.Add("湖南省湘潭市第一中学");
                SchoolName.Items.Add("湖南省湘西自治州民族中学");
                SchoolName.Items.Add("湖南省岳阳市第一中学");
                SchoolName.Items.Add("湖南省长沙麓山国际实验学校(长郡中学寄宿部)");
                SchoolName.Items.Add("湖南省长沙市第一中学");
                SchoolName.Items.Add("湖南省长沙市雅礼中学");
                SchoolName.Items.Add("湖南省长沙市长郡中学");
                SchoolName.Items.Add("湖南省株洲市第二中学");
                SchoolName.Items.Add("湖南省株洲市第四中学");
                SchoolName.Items.Add("湖南师范大学附属中学");

                break;
            case "吉林":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("东北师范大学附属中学");
                SchoolName.Items.Add("吉林省吉林市第一中学");
                SchoolName.Items.Add("吉林省吉林市外国语学校");
                SchoolName.Items.Add("吉林省吉林市毓文中学");
                SchoolName.Items.Add("吉林省辽源市第五中学");
                SchoolName.Items.Add("吉林省农安县实验中学");
                SchoolName.Items.Add("吉林省实验中学");
                SchoolName.Items.Add("吉林省四平市第一高级中学");
                SchoolName.Items.Add("吉林省通化市第一中学");
                SchoolName.Items.Add("吉林省延边第二中学");
                SchoolName.Items.Add("吉林省延边第一中学");
                SchoolName.Items.Add("吉林省长春市第十一中学");
                SchoolName.Items.Add("吉林省长春市外国语学校");
                break;
            case "江苏省":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("江苏省苏州市第一中学");
                SchoolName.Items.Add("江苏省苏州中学");
                SchoolName.Items.Add("江苏省泰兴中学");
                SchoolName.Items.Add("江苏省泰州中学");
                SchoolName.Items.Add("江苏省天一中学");
                SchoolName.Items.Add("江苏省通州高级中学");
                SchoolName.Items.Add("江苏省无锡市第一中学");
                SchoolName.Items.Add("江苏省新海高级中学");
                SchoolName.Items.Add("江苏省兴化中学");
                SchoolName.Items.Add("江苏省盱眙中学");
                SchoolName.Items.Add("江苏省徐州市第一中学");
                SchoolName.Items.Add("江苏省盐城中学");
                SchoolName.Items.Add("江苏省扬州中学");
                SchoolName.Items.Add("江苏省宜兴中学");
                SchoolName.Items.Add("江苏省镇江市第一中学");
                SchoolName.Items.Add("南京师范大学附属中学");

                break;
            case "江西":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("赣南师范学院附属中学");
                SchoolName.Items.Add("江西省东乡县第一中学");
                SchoolName.Items.Add("江西省抚州市第一中学");
                SchoolName.Items.Add("江西省高安中学");
                SchoolName.Items.Add("江西省吉安市白鹭洲中学");
                SchoolName.Items.Add("江西省吉安市第一中学");
                SchoolName.Items.Add("江西省金溪县第一中学");
                SchoolName.Items.Add("江西省景德镇第二中学");
                SchoolName.Items.Add("江西省九江市第二中学(同文)");
                SchoolName.Items.Add("江西省九江市第一中学");
                SchoolName.Items.Add("江西省乐平中学");
                SchoolName.Items.Add("江西省临川第一中学");
                SchoolName.Items.Add("江西省南昌市第二中学");
                SchoolName.Items.Add("江西省南昌市第十中学");
                SchoolName.Items.Add("江西省南昌市外国语学校");
                SchoolName.Items.Add("江西省南昌县莲塘第一中学");
                SchoolName.Items.Add("江西省上高二中");
                SchoolName.Items.Add("江西省新余市第一中学");
                SchoolName.Items.Add("江西省鹰潭市第一中学");
                SchoolName.Items.Add("江西省玉山县第一中学");
                SchoolName.Items.Add("江西师范大学附属中学");

                break;
            case "辽宁":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("辽宁省鞍山市第一中学");
                SchoolName.Items.Add("辽宁省本溪市第一中学");
                SchoolName.Items.Add("辽宁省本溪市高级中学");
                SchoolName.Items.Add("辽宁省大连市第八中学");
                SchoolName.Items.Add("辽宁省大连市第二十四中学");
                SchoolName.Items.Add("辽宁省大连市育明高级中学");
                SchoolName.Items.Add("辽宁省东北育才学校");
                SchoolName.Items.Add("辽宁省抚顺市第一中学");
                SchoolName.Items.Add("辽宁省阜新市实验中学");
                SchoolName.Items.Add("辽宁省盘锦市高级中学");
                SchoolName.Items.Add("辽宁省沈阳市第二中学");
                SchoolName.Items.Add("辽宁省实验中学");
                SchoolName.Items.Add("辽宁师范大学附属中学");

                break;
            case "内蒙古":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("内蒙古巴彦淖尔市杭锦后旗奋斗中学");
                SchoolName.Items.Add("内蒙古包钢第一中学");
                SchoolName.Items.Add("内蒙古包头市第三十三中学");
                SchoolName.Items.Add("内蒙古包头市第一中学");
                SchoolName.Items.Add("内蒙古北方重工业集团有限公司教育处第三中学");
                SchoolName.Items.Add("内蒙古赤峰市第二中学");
                SchoolName.Items.Add("内蒙古呼和浩特市第二中学");
                SchoolName.Items.Add("内蒙古集宁第一中学");
                SchoolName.Items.Add("内蒙古锡林郭勒盟第二中学");
                SchoolName.Items.Add("内蒙古牙克石林业第一中学"); break;
            case "宁夏":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("宁夏银川市第二中学");
                SchoolName.Items.Add("宁夏大学附属中学");
                SchoolName.Items.Add("宁夏贺兰县第一中学");
                SchoolName.Items.Add("宁夏平罗中学");
                SchoolName.Items.Add("宁夏石嘴山市第十七中学");
                SchoolName.Items.Add("宁夏吴忠高级中学");
                SchoolName.Items.Add("宁夏银川实验中学");
                SchoolName.Items.Add("宁夏银川市第一中学");
                SchoolName.Items.Add("宁夏中卫市第三中学");
                SchoolName.Items.Add("银川唐徕回民中学");
                break;
            case "青海":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("青海化隆回族自治县化隆第一中学");
                SchoolName.Items.Add("青海湟川中学");
                SchoolName.Items.Add("青海昆仑中学");
                SchoolName.Items.Add("青海省海北州祁连山中学");
                SchoolName.Items.Add("青海省互助土族自治县第一中学");
                SchoolName.Items.Add("青海省乐都县第一中学");
                SchoolName.Items.Add("青海省平安县第一高级中学");
                SchoolName.Items.Add("青海省西宁市第十四中学");
                SchoolName.Items.Add("青海省西宁市第五中学");
                SchoolName.Items.Add("青海师范大学附属中学");

                break;
            case "山东":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("山东省莱阳市第一中学");
                SchoolName.Items.Add("山东省莱州市第一中学");
                SchoolName.Items.Add("山东省青岛市第二中学");
                SchoolName.Items.Add("山东省日照市第一中学");
                SchoolName.Items.Add("山东省乳山市第一中学");
                SchoolName.Items.Add("山东省实验中学");
                SchoolName.Items.Add("山东省寿光市第一中学");
                SchoolName.Items.Add("山东省寿光市现代中学");
                SchoolName.Items.Add("山东省泰安市第一中学");
                SchoolName.Items.Add("山东省滕州市第一中学");
                SchoolName.Items.Add("山东省威海市第二中学");
                SchoolName.Items.Add("山东省威海市第一中学");
                SchoolName.Items.Add("山东省潍坊市第二中学");
                SchoolName.Items.Add("山东省潍坊市第一中学");
                SchoolName.Items.Add("山东省新泰市第一中学");
                SchoolName.Items.Add("山东省烟台市第二中学");
                SchoolName.Items.Add("山东省枣庄市第八中学");
                SchoolName.Items.Add("山东省淄博市第四中学");
                SchoolName.Items.Add("山东省邹城市第一中学");
                SchoolName.Items.Add("山东师范大学附属中学");

                break;
            case "山西":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("山西大学附属中学");
                SchoolName.Items.Add("山西省大同市第一中学");
                SchoolName.Items.Add("山西省平遥中学");
                SchoolName.Items.Add("山西省实验中学");
                SchoolName.Items.Add("山西省太谷中学校");
                SchoolName.Items.Add("山西省太原市成成中学");
                SchoolName.Items.Add("山西省太原市第五十二中学");
                SchoolName.Items.Add("山西省太原市第五中学");
                SchoolName.Items.Add("山西省太原市外国语学校");
                SchoolName.Items.Add("山西省太原市外国语学校");
                SchoolName.Items.Add("山西省忻州市第一中学");
                SchoolName.Items.Add("山西省阳泉市第一中学");
                SchoolName.Items.Add("山西省运城市康杰中学");


                break;
            case "陕西":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("陕西省安康中学");
                SchoolName.Items.Add("陕西省山阳中学");
                SchoolName.Items.Add("陕西省西安市第一中学");
                SchoolName.Items.Add("陕西省西安市铁一中");
                SchoolName.Items.Add("陕西省西安中学");
                SchoolName.Items.Add("陕西省宜川中学");
                SchoolName.Items.Add("陕西省镇安中学");
                SchoolName.Items.Add("陕西师范大学附属中学");
                SchoolName.Items.Add("西安交通大学附属中学");
                SchoolName.Items.Add("西安市高新第一中学");
                SchoolName.Items.Add("西北工业大学附属中学");

                break;
            case "上海":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("复旦大学附属中学");
                SchoolName.Items.Add("华东师范大学第二附属中学");
                SchoolName.Items.Add("上海交通大学附属中学");
                SchoolName.Items.Add("上海市曹杨第二中学");
                SchoolName.Items.Add("上海市崇明中学");
                SchoolName.Items.Add("上海市第六十中学");
                SchoolName.Items.Add("上海市格致中学");
                SchoolName.Items.Add("上海市建平中学");
                SchoolName.Items.Add("上海市教科院附属中学");
                SchoolName.Items.Add("上海市控江中学");
                SchoolName.Items.Add("上海市闵行中学");
                SchoolName.Items.Add("上海市南洋模范中学");
                SchoolName.Items.Add("上海市七宝中学");
                SchoolName.Items.Add("上海市青云中学");
                SchoolName.Items.Add("上海市市北中学");
                SchoolName.Items.Add("上海市松江第二中学");
                SchoolName.Items.Add("上海市西南位育中学");
                SchoolName.Items.Add("上海市延安中学");
                SchoolName.Items.Add("上海市杨浦高级中学");
                SchoolName.Items.Add("上海市育才中学");
                SchoolName.Items.Add("上海外国语大学附属外国语学校");
                SchoolName.Items.Add("上海中学");
                break;
            case "四川":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("四川省成都实验中学");
                SchoolName.Items.Add("四川省成都市第二十中学");
                SchoolName.Items.Add("四川省成都市第七中学");
                SchoolName.Items.Add("四川省成都市石室中学（成都市第四中学）");
                SchoolName.Items.Add("四川省成都市实验外国语学校");
                SchoolName.Items.Add("四川省成都市树德中学");
                SchoolName.Items.Add("四川省成都市新都一中");
                SchoolName.Items.Add("四川省德阳中学");
                SchoolName.Items.Add("四川省眉山中学");
                SchoolName.Items.Add("四川省绵阳南山中学");
                SchoolName.Items.Add("四川省绵阳中学");

                SchoolName.Items.Add("四川省南充高级中学");
                SchoolName.Items.Add("四川省彭州中学");
                SchoolName.Items.Add("四川省双流县棠湖中学");
                SchoolName.Items.Add("四川省雅安市雅安中学");
                SchoolName.Items.Add("四川外国语学院附属成都外国语学校");

                break;
            case "天津":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("天津市第五十一中学");
                SchoolName.Items.Add("天津市第一中学");
                SchoolName.Items.Add("天津市东丽中学");
                SchoolName.Items.Add("天津市民族中学");
                SchoolName.Items.Add("天津市南开中学");
                SchoolName.Items.Add("天津市实验中学");
                SchoolName.Items.Add("天津市塘沽第一中学");
                SchoolName.Items.Add("天津市新华中学");
                SchoolName.Items.Add("天津市燕山中学");
                SchoolName.Items.Add("天津市耀华中学");
                SchoolName.Items.Add("天津外国语学院附属外国语学校");
                break;
            case "西藏":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("西藏嘉黎县中学");
                SchoolName.Items.Add("西藏拉萨北京中学（拉萨第一高级中学）");
                SchoolName.Items.Add("西藏拉萨市第三高级中学");
                SchoolName.Items.Add("西藏拉萨市师范学校");
                SchoolName.Items.Add("西藏拉萨中学");
                SchoolName.Items.Add("西藏林芝地区第二中学");
                SchoolName.Items.Add("西藏林芝地区第一中学");
                SchoolName.Items.Add("西藏民族学院附中");
                break;
            case "新疆":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("新疆昌吉回族自治州回民中学（昌吉州第四中学）");
                SchoolName.Items.Add("新疆克拉玛依市第一中学");
                SchoolName.Items.Add("新疆生产建设兵团第二中学");
                SchoolName.Items.Add("新疆实验中学");
                SchoolName.Items.Add("新疆吐鲁番实验中学");
                SchoolName.Items.Add("新疆乌鲁木齐市八一中学");
                SchoolName.Items.Add("新疆乌鲁木齐市第八中学");
                SchoolName.Items.Add("新疆乌鲁木齐市第七十中学");
                SchoolName.Items.Add("新疆乌鲁木齐市第一中学");
                SchoolName.Items.Add("新疆乌鲁木齐市高级中学");
                break;
            case "云南":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("云南大理第一中学");
                SchoolName.Items.Add("云南省楚雄市第一中学");
                SchoolName.Items.Add("云南省昆明市第八中学");
                SchoolName.Items.Add("云南省昆明市第三中学");
                SchoolName.Items.Add("云南省昆明市第一中学");
                SchoolName.Items.Add("云南省昆明市禄劝民族中学");
                SchoolName.Items.Add("云南省昆明市明德中学");
                SchoolName.Items.Add("云南省曲靖市第一中学");
                SchoolName.Items.Add("云南省思茅第一中学");
                SchoolName.Items.Add("云南师范大学附属中学");

                break;
            case "浙江":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("浙江省富阳中学");
                SchoolName.Items.Add("浙江省杭州市第二中学");
                SchoolName.Items.Add("浙江省杭州市第十四中学");
                SchoolName.Items.Add("浙江省杭州市高级中学");
                SchoolName.Items.Add("浙江省杭州市学军中学");
                SchoolName.Items.Add("浙江省杭州外国语学校");
                SchoolName.Items.Add("浙江省嘉兴市第一中学");
                SchoolName.Items.Add("浙江省金华市第一中学");
                SchoolName.Items.Add("浙江省宁波市效实中学");
                SchoolName.Items.Add("浙江省宁波中学");
                SchoolName.Items.Add("浙江省绍兴市第一中学");
                SchoolName.Items.Add("浙江省绍兴县柯桥中学");
                SchoolName.Items.Add("浙江省绍兴县鲁迅中学");
                SchoolName.Items.Add("浙江省天台中学");
                SchoolName.Items.Add("浙江省桐乡市高级中学");
                SchoolName.Items.Add("浙江省温岭中学");
                SchoolName.Items.Add("浙江省温州中学");
                SchoolName.Items.Add("浙江省萧山中学");
                SchoolName.Items.Add("浙江省新昌中学");
                SchoolName.Items.Add("浙江省义乌中学");
                SchoolName.Items.Add("浙江省余姚中学");
                SchoolName.Items.Add("浙江省镇海中学");
                SchoolName.Items.Add("浙江省舟山中学");
                SchoolName.Items.Add("浙江省诸暨荣怀学校");
                SchoolName.Items.Add("浙江省诸暨中学");

                break;
            case "重庆":
                SchoolName.Items.Clear();
                SchoolName.Items.Add("四川外语学院附属外国语学校");
                SchoolName.Items.Add("西南师范大学附属中学");
                SchoolName.Items.Add("重庆巴蜀中学");
                SchoolName.Items.Add("重庆市巴蜀中学");
                SchoolName.Items.Add("重庆市第八中学");
                SchoolName.Items.Add("重庆市第一中学");
                SchoolName.Items.Add("重庆市南开中学");
                SchoolName.Items.Add("重庆市育才中学校");
                SchoolName.Items.Add("重庆三中");
                SchoolName.Items.Add("重庆市第十八中学");
                SchoolName.Items.Add("重庆铁路");
                SchoolName.Items.Add("重庆市第十八中学");
                SchoolName.Items.Add("重庆市清华中学");
                SchoolName.Items.Add("云阳中学");
                

                break;
            default: break;
        }
        #endregion
    }
    protected void Others_CheckedChanged(object sender, EventArgs e)
    {        
        if (Others.Checked)
        {
            //Province.Enabled = false;
            SchoolName.Enabled = false;
            otherSchool.Enabled = true;
        }
        else
        {
            //Province.Enabled = true;
            SchoolName.Enabled = true;
            otherSchool.Enabled = false;
        }
    }
}
