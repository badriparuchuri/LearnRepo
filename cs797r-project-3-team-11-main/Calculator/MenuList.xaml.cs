namespace Calculator;

public partial class MenuList : ContentPage
{
	public MenuList()
	{
		InitializeComponent();
	}

	private void OnLightEvent(object sender, EventArgs e)
	{
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear(); 
            mergedDictionaries.Add(new LightTheme());
        }
    }

	private void OnDarkEvent(object sender, EventArgs e)
	{
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new DarkTheme());
        }
    }

	private void OnRedEvent(object sender, EventArgs e)
	{
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new RedTheme());
        }
    }

	private void OnPinkEvent(object sender, EventArgs e)
	{
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new PinkTheme());
        }
    }
}