using DashboardBoilerPlate.Core;
using DashboardBoilerPlate.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardBoilerPlate.MVVM.ViewModels
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ChartViewCommand { get; set; }

        public PCInfo PCInfo { get; set; }

        public ChartViewModel ChartVM { get; set; }
        public HomeViewModel HomeVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ChartVM = new ChartViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ChartViewCommand = new RelayCommand(o =>
            {
                CurrentView = ChartVM;
            });
            PCInfo = new PCInfo();
            PCInfo.PCName = Environment.MachineName;
            PCInfo.CoreCount = Environment.ProcessorCount.ToString();
            PCInfo.Ram = Environment.WorkingSet.ToString();
            PCInfo.OSVersion = Environment.OSVersion.ToString();
            PCInfo.GPUName = "NVIDIA GTX 1050TI"; //NEED TO GET DYNAMICALLY
        }
    }
}
