using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace katalog_miejsc_turystycznych
{
    /// <summary>
    /// Logika interakcji dla klasy PlaceInformation.xaml
    /// </summary>
    public partial class PlaceInformation : Window
    {
        private Place place;
        private PlacesManager placesManager;
        private double review;

        public PlaceInformation(Place place)
        {
            InitializeComponent();
            this.place = place;
            placesManager = PlacesManager.GetInstance(); 
            InterestingPlacesListView.ItemsSource = place.InterestingPlaces;
            PlaceNameTextBlock.Text = place.Name;
            PlaceRatingTextBlock.Text = CreateRevies(place.ReviewsMean, place.Reviews.Count);
            PlaceDescriptionTextBox.Text = place.Description;
            PlaceAddressTextBlock.Text = place.Localization;
        }
        
        private void Star_MouseDown(object sender, MouseEventArgs e)
        {
            review = FillStars(sender as Image);
            PlaceRatingTextBlock.Text = CreateRevies(CountTempReviewsMean(review), place.Reviews.Count + 1);
        }

        private void InterestingPlaces_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var elem = item as InterestingPlace;
            Console.WriteLine(elem);
            if (elem != null)
            {
                InterestingPlaceWindow interestingPlace = new InterestingPlaceWindow(elem);
                interestingPlace.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow(this);
            deleteWindow.Show();
            placesManager.DeletePlace(place.Id);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if (review != 0)
            {
                place.AddReview(review);
                placesManager.Update(place);
            }
            mainWindow.Show();
            Close();
        }

        private int FillStars(Image star)
        {
            BitmapImage yellowStar = new BitmapImage(new Uri(@"/katalog-miejsc-turystycznych;component/images/yellow star.png", UriKind.Relative));
            BitmapImage whiteStar = new BitmapImage(new Uri(@"/katalog-miejsc-turystycznych;component/images/white star.png", UriKind.Relative));

            switch (star.Name)
            {
                case "Star0":
                    Star0.Source = yellowStar;
                    Star1.Source = whiteStar;
                    Star2.Source = whiteStar;
                    Star3.Source = whiteStar;
                    Star4.Source = whiteStar;
                    PlaceReviewLabel.Content = "Terrible";
                    return 1;
                case "Star1":
                    Star0.Source = yellowStar;
                    Star1.Source = yellowStar;
                    Star2.Source = whiteStar;
                    Star3.Source = whiteStar;
                    Star4.Source = whiteStar;
                    PlaceReviewLabel.Content = "Poor";
                    return 2;
                case "Star2":
                    Star0.Source = yellowStar;
                    Star1.Source = yellowStar;
                    Star2.Source = yellowStar;
                    Star3.Source = whiteStar;
                    Star4.Source = whiteStar;
                    PlaceReviewLabel.Content = "Average";
                    return 3;
                case "Star3":
                    Star0.Source = yellowStar;
                    Star1.Source = yellowStar;
                    Star2.Source = yellowStar;
                    Star3.Source = yellowStar;
                    Star4.Source = whiteStar;
                    PlaceReviewLabel.Content = "Very good";
                    return 4;
                case "Star4":
                    Star0.Source = yellowStar;
                    Star1.Source = yellowStar;
                    Star2.Source = yellowStar;
                    Star3.Source = yellowStar;
                    Star4.Source = yellowStar;
                    PlaceReviewLabel.Content = "Excellent";
                    return 5;
                default:
                    return 0;
            }
        }

        private string CreateRevies(double reviesMean, int reviesCounter)
        {
            return $"{Math.Round(reviesMean, 1).ToString()} (ocen: {reviesCounter.ToString()})";
        }

        private double CountTempReviewsMean(double tempReview)
        {
            double reviesSum = place.ReviewsMean * place.Reviews.Count;
            return (reviesSum + tempReview) / (place.Reviews.Count + 1);
        }
    }
}
