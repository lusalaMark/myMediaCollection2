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
        private string selectedMedium;
        private ObservableCollection<MediaItem> items;
        private ObservableCollection<MediaItem> allItems;
        private IList<string> mediums;

        public MainViewModel()
        {
            PopulateData();
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
    }
    }
