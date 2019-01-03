namespace AppIm.Views
{
    using Xamarin.Forms;
    
    
	public partial class AduanaPage : ContentPage
	{
		public AduanaPage ()
		{
			InitializeComponent ();
		}

        private void FechaFinal_DateSelected(object sender, DateChangedEventArgs e)
        {
            FechaFinal.Date = e.NewDate.Date;
        }
    }
}