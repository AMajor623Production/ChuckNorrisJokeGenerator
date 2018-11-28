using System;
using Xamarin.Forms;

namespace YourXamarinProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            JokeLabel.FontAttributes = FontAttributes.None;

            JokeGenerator generator = new JokeGenerator();
            JokeLabel.Text = await generator.GenerateJoke();
        }
    }
}
