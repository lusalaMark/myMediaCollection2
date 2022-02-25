using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Linq;
using Microsoft.UI.Xaml;
using myMediaCollection2.Model;
using myMediaCollection2.Enums;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace myMediaCollection2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private IList<string> _mediums { get; set; }
        private IList<MediaItem> _items { get; set; }

        private bool _isLoaded;

        public MainWindow()
        {
            this.InitializeComponent();
            ItemList.Loaded += ItemList_Loaded;
           
            PopulateData();
        }

        private void ItemList_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var listView = (ListView)sender;
            PopulateData();
            listView.ItemsSource = _items;
        }

        public void PopulateData()
        {
            if (_isLoaded) return;
            _isLoaded = true;

            var cd = new MediaItem
            {
                Id = 1,
                Name = "Classical Favorites",
                MediaType = ItemType.Music,
                MediumInfo = new Medium { Id = 1, MediaType = ItemType.Music, Name = "CD" }
            };

            var book = new MediaItem
            {
                Id = 2,
                Name = "Classic Fairy Tales",
                MediaType = ItemType.Book,
                MediumInfo = new Medium { Id = 2, MediaType = ItemType.Book, Name = "Book" }
            };

            var bluRay = new MediaItem
            {
                Id = 3,
                Name = "The Mummy",
                MediaType = ItemType.Video,
                MediumInfo = new Medium { Id = 3, MediaType = ItemType.Video, Name = "Blu Ray" }
            };

            _items = new List<MediaItem>
            {
                cd,
                book,
                bluRay
            };
            _mediums = new List<string>
            {
             "All",
             nameof(ItemType.Book),
             nameof(ItemType.Music),
             nameof(ItemType.Video)
            };
        }
    }    
}

