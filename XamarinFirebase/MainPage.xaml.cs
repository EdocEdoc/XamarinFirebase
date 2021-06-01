using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFirebase
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }


        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            double weight = double.Parse(Weight.Text); double height = double.Parse(Height.Text);
            var bmi = (weight / height / height) * 10000;

            string status = "";

            if (bmi < 18.5) status = "Underweight ";
            if (bmi >= 18.5 && bmi <= 24.9) status = "Normal weight ";
            if (bmi >= 25 && bmi <= 29.9) status = "Overweight";
            if (bmi >= 30) status = "Obesity ";

            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, weight, height, bmi, status);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

    }
}
