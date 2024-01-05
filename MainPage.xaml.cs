using Newtonsoft.Json;

namespace zadanie5._01._24;

public partial class MainPage : ContentPage
{
	string text;
	string url;
	bool bladP = false;
	List<nowyK> joke = new List<nowyK>();
	public class nowyK
	{
		public string type { get; set; }
		public string setup { get; set; }
		public string punchline { get; set; }
	}
	public MainPage()
	{
		InitializeComponent();
	}
	public void urlT()
	{
		bladP = false;
		var tex = typ.Text;
		if (tex == "programming" || tex == "general" || tex == "knock-knock")
		{
			url = "https://official-joke-api.appspot.com/jokes/" + tex + "/random";
			tex = "";
			//blad.Text = url;
		}
		else
		{
			bladP = true;
		}
    }
	public async Task<nowyK> nowy()
	{
		urlT();
		if(bladP) { blad.Text = "Błędny typ"; await Task.Delay(1000); blad.Text = ""; return null; }
        HttpClient client = new HttpClient();
        text = await client.GetStringAsync(url);
		joke = JsonConvert.DeserializeObject<List<nowyK>>(text);
		type.Text = joke[0].type;
		await Task.Delay(1000);
		setup.Text = joke[0].setup;
		await Task.Delay(5000);
		punchline.Text = joke[0].punchline;
		return joke[0];
    }
	private void generuj(object sender, EventArgs e)
	{
		type.Text = "";
		setup.Text = "";
		punchline.Text = "";
        nowy();
    }
}

