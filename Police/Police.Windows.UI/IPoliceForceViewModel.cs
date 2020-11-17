using Police.Common;
using PoliceApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Police.Windows.UI
{
    public interface IPoliceForceViewModel
    {
        ObservableCollection<PoliceForce> PoliceForces { get; set; }
        PoliceForce SelectedPoliceForce { get; set; }

        ObservableCollection<Neighbourhood> Neighbourhoods { get; set; }
        Neighbourhood SelectedNeighbourhood { get; set; }

        ObservableCollection<StopAndSearch> StopAndSearches { get; set; }
    }
}
