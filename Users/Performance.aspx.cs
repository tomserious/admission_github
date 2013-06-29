using System;

public partial class Users_Performance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Performance perf;
        if (!IsPostBack && (perf = Performance.GetPerformanceByID(((Users)Session["Identify"]).UserID)) != null)
        {
            Term1Rank.Text = perf.Term1Rank.ToString();
            Term1Total.Text = perf.Term1Total.ToString();
            Term2Rank.Text = perf.Term2Rank.ToString();
            Term2Total.Text = perf.Term2Total.ToString();
            Term3Rank.Text = perf.Term3Rank.ToString();
            Term3Total.Text = perf.Term3Total.ToString();
            Term1Chinese.Text = perf.Term1Chinese.ToString();
            Term1Math.Text = perf.Term1Math.ToString();
            Term1English.Text = perf.Term1English.ToString();
            Term1Physics.Text = perf.Term1Physics.ToString();
            Term1Chemistry.Text = perf.Term1Chemistry.ToString();
            Term2Chinese.Text = perf.Term2Chinese.ToString();
            Term2Math.Text = perf.Term2Math.ToString();
            Term2English.Text = perf.Term2English.ToString();
            Term2Physics.Text = perf.Term2Physics.ToString();
            Term2Chemistry.Text = perf.Term2Chemistry.ToString();
            Term3Chinese.Text = perf.Term3Chinese.ToString();
            Term3Math.Text = perf.Term3Math.ToString();
            Term3English.Text = perf.Term3English.ToString();
            Term3Physics.Text = perf.Term3Physics.ToString();
            Term3Chemistry.Text = perf.Term3Chemistry.ToString();
        }
    }

    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        Performance perf = new Performance();
        perf.UserID = ((Users)Session["Identify"]).UserID;
        perf.Term1Rank = int.Parse(Term1Rank.Text);
        perf.Term1Total = int.Parse(Term1Total.Text);
        perf.Term2Rank = int.Parse(Term2Rank.Text);
        perf.Term2Total = int.Parse(Term2Total.Text);
        perf.Term3Rank = int.Parse(Term3Rank.Text);
        perf.Term3Total = int.Parse(Term3Total.Text);
        perf.Term1Chinese = double.Parse(Term1Chinese.Text);
        perf.Term1Math = double.Parse(Term1Math.Text);
        perf.Term1English = double.Parse(Term1English.Text);
        perf.Term1Physics = double.Parse(Term1Physics.Text);
        perf.Term1Chemistry = double.Parse(Term1Chemistry.Text);
        perf.Term2Chinese = double.Parse(Term2Chinese.Text);
        perf.Term2Math = double.Parse(Term2Math.Text);
        perf.Term2English = double.Parse(Term2English.Text);
        perf.Term2Physics = double.Parse(Term2Physics.Text);
        perf.Term2Chemistry = double.Parse(Term2Chemistry.Text);
        perf.Term3Chinese = double.Parse(Term3Chinese.Text);
        perf.Term3Math = double.Parse(Term3Math.Text);
        perf.Term3English = double.Parse(Term3English.Text);
        perf.Term3Physics = double.Parse(Term3Physics.Text);
        perf.Term3Chemistry = double.Parse(Term3Chemistry.Text);
        Performance.SetPerformanceByID(perf.UserID, perf);
        Response.Redirect("/Users/Index.aspx");
    }
}
