using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesMVVM
{
    class MainWindowVM : ObservableObject
    {
        private readonly SuperheroesService superheroesService;
        public MainWindowVM()
        {
            superheroesService = new SuperheroesService();
            heroes = superheroesService.GetSamples();
            HeroeActual = heroes[0];
            Total = heroes.Count;
            Actual = 1;
            AvanzarCommand = new RelayCommand(Siguiente);
            RetrocederCommand = new RelayCommand(Anterior);
        }

        public RelayCommand AvanzarCommand { get; }
        public RelayCommand RetrocederCommand { get; }

        private ObservableCollection<Superheroe> heroes;
        public ObservableCollection<Superheroe> Heroes
        {
            get => heroes;
            set => SetProperty(ref heroes, value);
        }

        private Superheroe heroeActual;

        public Superheroe HeroeActual
        {
            get => heroeActual;
            set => SetProperty(ref heroeActual, value);
        }

        private int total;

        public int Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }

        private int actual;

        public int Actual
        {
            get => actual;
            set => SetProperty(ref actual, value);
        }

        public void Siguiente()
        {
            if (Actual < Total)
            {
                Actual++;
                HeroeActual = heroes[Actual - 1];
            }
        }

        public void Anterior()
        {
            if (Actual > 1)
            {
                Actual--;
                HeroeActual = heroes[Actual - 1];
            }
        }
    }
}
