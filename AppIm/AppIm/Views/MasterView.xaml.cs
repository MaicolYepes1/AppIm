namespace AppIm.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

	public partial class MasterView : MasterDetailPage
	{
		public MasterView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
        }
	}
}