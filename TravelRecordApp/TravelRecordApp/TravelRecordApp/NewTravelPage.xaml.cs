using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using SQLite;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;
using TravelRecordApp.Helpers;

namespace TravelRecordApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }


        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post newPost = new Post()
                {
                    Experience = exprentienceEntry.Text,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    VenueName = selectedVenue.name,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name
                };

                //using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
                //{
                //    conn.CreateTable<Post>();
                //    int rowsAffected = conn.Insert(newPost);

                //    if (rowsAffected > 0)
                //    {
                //        experienceEntry.Text = string.Empty;
                //        DisplayAlert("Success", "Post saved", "Ok");
                //    }
                //    else
                //        DisplayAlert("Failure", "Post was not saved, please try again", "Ok");
                //}

                bool result = Firestore.Insert(newPost);
                if (result)
                {
                    exprentienceEntry.Text = string.Empty;
                    DisplayAlert("Success", "Post saved", "Ok");
                }
                else
                    DisplayAlert("Failure", "Post was not saved, please try again", "Ok");
            }
            catch (NullReferenceException nrex)
            {

            }
            catch (Exception ex)
            {

            }


        }
    }
}