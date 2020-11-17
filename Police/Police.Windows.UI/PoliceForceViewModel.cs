using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Police.Common;
using Police.Windows.UI.Common;
using PoliceApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Police.Windows.UI
{
    public class PoliceForceViewModel : BindableBase, IPoliceForceViewModel, IViewModelBase
    {
        private IApiClient ApiClient { get; set; }

        private ObservableCollection<PoliceForce> _policeForces;
        public ObservableCollection<PoliceForce> PoliceForces
        {
            get
            {
                if (_policeForces == null)
                {
                    _policeForces = new ObservableCollection<PoliceForce>();
                }
                return _policeForces;
            }
            set
            {
                SetProperty(ref _policeForces, value);
            }
        }

        private PoliceForce _selectedPoliceForce;
        public PoliceForce SelectedPoliceForce
        {
            get => _selectedPoliceForce;
            set
            {
                SetProperty(ref _selectedPoliceForce, value);
                this.OnGetNeighbourhoods();
            }
        }

        private ObservableCollection<Neighbourhood> _neighbourhoods;
        public ObservableCollection<Neighbourhood> Neighbourhoods
        {
            get
            {
                if (_neighbourhoods == null)
                {
                    _neighbourhoods = new ObservableCollection<Neighbourhood>();
                }
                return _neighbourhoods;
            }
            set
            {
                SetProperty(ref _neighbourhoods, value);
            }
        }

        private Neighbourhood _selectedNeighbourhood;
        public Neighbourhood SelectedNeighbourhood
        {
            get => _selectedNeighbourhood;
            set
            {
                SetProperty(ref _selectedNeighbourhood, value);
                this.OnGetStopAndSearches();
            }
        }

        private ObservableCollection<StopAndSearch> _stopsStreets;
        public ObservableCollection<StopAndSearch> StopAndSearches
        {
            get
            {
                if (_stopsStreets == null)
                {
                    _stopsStreets = new ObservableCollection<StopAndSearch>();
                }
                return _stopsStreets;
            }
            set
            {
                SetProperty(ref _stopsStreets, value);
            }
        }

        //public DelegateCommand GetPoliceForcesCommand { get; set; }
        //public DelegateCommand GetNeighbourhoodsCommand { get; set; }
        //public DelegateCommand GetStopsStreetsCommand { get; set; }

        public PoliceForceViewModel(IApiClient apiClient)
        {
            this.ApiClient = apiClient;

            //Ideally we would have the Comboboxes data bound to DelegateCommands to control the Execute and CanExecute
            //and allow the required actions to be performed when interacting with the Api
            //this.GetPoliceForcesCommand = new DelegateCommand(OnGetPoliceForces);
            //this.GetNeighbourhoodsCommand = new DelegateCommand(OnGetNeighbourhoods, CanGetNeighbourhoods);
            //this.GetStopsStreetsCommand = new DelegateCommand(OnGetStopsStreets, CanGetStopsStreets);

            //Force initial API Call to load in PoliceForce data
            OnGetPoliceForces();
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(
                messageBoxText: message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }

        public void DisplayError(Exception ex)
        {
            MessageBox.Show(
                messageBoxText: ex.Message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }

        private async void OnGetPoliceForces()
        {
            try
            {
                var forces = await this.ApiClient.GetAsync<List<PoliceForce>>("forces");
                this.PoliceForces = new ObservableCollection<PoliceForce>(forces);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private async void OnGetNeighbourhoods()
        {
            if (!CanGetNeighbourhoods())
                return;

            try
            {
                var neighbourhoods = await this.ApiClient.GetAsync<List<Neighbourhood>>($"neighbourhood?policeForce={this.SelectedPoliceForce.ID}");
                this.Neighbourhoods = new ObservableCollection<Neighbourhood>(neighbourhoods);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private bool CanGetNeighbourhoods()
        {
            return this.SelectedPoliceForce != null;
        }

        private async void OnGetStopAndSearches()
        {
            if (!CanGetStopAndSearches())
                return;

            try
            {
                var stopAndSearches = await this.ApiClient.GetAsync<List<StopAndSearch>>($"stopsearch?policeForce={this.SelectedPoliceForce.ID}&neighbourhood={this.SelectedNeighbourhood.ID}");
                this.StopAndSearches = new ObservableCollection<StopAndSearch>(stopAndSearches);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private bool CanGetStopAndSearches()
        {
            return this.SelectedPoliceForce != null && this.SelectedNeighbourhood != null;
        }
    }
}
