namespace SnakeGame;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnStartClicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new Game();
    }
}

