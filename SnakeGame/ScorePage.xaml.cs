namespace SnakeGame;

public partial class ScorePage : ContentPage
{
	public int Score 
	{ 
		get
		{
			return _score;
		}
		set 
		{
			_score = value;
			OnPropertyChanged(nameof(Score));
		} 
	}
	private int _score;
	public ScorePage(int score)
	{
		InitializeComponent();
		Score = score;
	}

    private async void MainMenuClicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MainPage();
    }
}