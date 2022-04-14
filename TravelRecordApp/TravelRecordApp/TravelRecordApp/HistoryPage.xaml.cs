using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{

    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    var posts = conn.Table<Post>().ToList();

            //    postListView.ItemsSource = posts;
            //}

            postListView.ItemsSource = null;
            var posts = await Firestore.Read();
            postListView.ItemsSource = posts;
        }


        private void PostListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetail(selectedPost));
            }
        }
    }
}