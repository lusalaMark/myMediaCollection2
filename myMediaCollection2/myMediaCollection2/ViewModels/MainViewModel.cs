using myMediaCollection2.Enums;
using myMediaCollection2.Model;
using myMediaCollection2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace myMediaCollection2.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ICommand AddEditCommand { get; set; }
        private MediaItem selectedMediaItem;
        private int additionalItemCount = 1;
        private string selectedMedium;
        private ObservableCollection<MediaItem> Items;
        private ObservableCollection<MediaItem> allItems;
        private IList<string> mediums;
        public MainViewModel()
        {
            PopulateData();
            DeleteCommand = new RelayCommand(DeleteItem,CanDeleteItem);
            // No CanExecute param is needed for this command
            // because you can always add or edit items.
            AddEditCommand = new RelayCommand(AddOrEditItem);
        }
        public IList<string> Mediums
        {
            get
            {
                return mediums;
            }
            set
            {
                SetProperty(ref mediums, value);
            }
        }
        public MediaItem SelectedMediaItem
        {
            get => selectedMediaItem;
            set
            {
                SetProperty(ref selectedMediaItem, value);
                ((RelayCommand)DeleteCommand).
               RaiseCanExecuteChanged();
            }
        }
        public void AddOrEditItem()
        {
            // Note this is temporary until
            // we use a real data source for items.
            const int startingItemCount = 3;
            var newItem = new MediaItem
            {
                Id = startingItemCount + additionalItemCount,
                Location = LocationType.InCollection,
                MediaType = ItemType.Music,
                MediumInfo = new Medium
                {
                    Id = 1,
                    MediaType = ItemType.Music,
                    Name = "CD"
                },
                Name = $"CD {additionalItemCount}"
            };
            allItems.Add(newItem);
            Items.Add(newItem);
            additionalItemCount++;
        }
        public ICommand DeleteCommand { get; set; }
        private void DeleteItem()
        {
            allItems.Remove(SelectedMediaItem);
            Items.Remove(SelectedMediaItem);
        }
        private bool CanDeleteItem() => selectedMediaItem !=
        null;
    }
    }
