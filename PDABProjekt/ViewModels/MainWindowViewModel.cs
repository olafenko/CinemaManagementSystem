using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.ViewModels.NowyViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;





namespace PDABProjekt.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _GlowneCommands;
        private ReadOnlyCollection<CommandViewModel> _SlownikoweCommands;
        private ReadOnlyCollection<CommandViewModel> _RaportyCommands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> GlowneCommands
        {
            get
            {
                if (_GlowneCommands == null)
                {
                    List<CommandViewModel> cmds = this.CreateGlowneCommands();
                    _GlowneCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _GlowneCommands;
            }
        }

        public ReadOnlyCollection<CommandViewModel> RaportyCommands
        {
            get
            {
                if (_RaportyCommands == null)
                {
                    List<CommandViewModel> cmds = this.CreateRaportyCommands();
                    _RaportyCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _RaportyCommands;
            }
        }

        public ReadOnlyCollection<CommandViewModel> SlownikoweCommands
        {
            get
            {
                if (_SlownikoweCommands == null)
                {
                    List<CommandViewModel> cmds = this.CreateSlownikoweCommands();
                    _SlownikoweCommands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _SlownikoweCommands;
            }
        }


        private List<CommandViewModel> CreateGlowneCommands()
        {
            Messenger.Default.Register<string>(this, Open); //messenger ktory nasluchuje stringa i jak go zlapie to wywola funkcje open

            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Wszystkie filmy",
                    new BaseCommand(() => this.ShowAllView<WszystkieFilmyViewModel>())),
                new CommandViewModel(
                    "Nowy Film",
                    new BaseCommand(() => this.CreateView(new NowyFilmViewModel()))),
                new CommandViewModel(
                    "Wszystkie seanse",
                    new BaseCommand(() => this.ShowAllView<WszystkieSeanseViewModel>())),
                new CommandViewModel(
                    "Nowy Seans",
                    new BaseCommand(() => this.CreateView(new NowySeansViewModel()))),
                new CommandViewModel(
                    "Dystrybutorzy",
                    new BaseCommand(() => this.ShowAllView<WszyscyDystrybutorzyViewModel>())),
                new CommandViewModel(
                    "Nowy Dystrybutor",
                    new BaseCommand(() => this.CreateView(new NowyDystrybutorViewModel()))),
                 new CommandViewModel(
                    "Sale",
                    new BaseCommand(() => this.ShowAllView<WszystkieSaleViewModel>())),
                   new CommandViewModel(
                    "Nowa Sala",
                    new BaseCommand(() => this.CreateView(new NowaSalaViewModel()))),
                 new CommandViewModel(
                    "Bilety",
                    new BaseCommand(() => this.ShowAllView<WszystkieBiletyViewModel>())),                            
            };
        }

        private List<CommandViewModel> CreateSlownikoweCommands()
        {
            
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Gatunki",
                    new BaseCommand(() => this.ShowAllView<WszystkieGatunkiViewModel>())),
                new CommandViewModel(
                    "Nowy gatunek",
                    new BaseCommand(() => this.CreateView(new NowyGatunekViewModel()))),
                 new CommandViewModel(
                    "Języki",
                    new BaseCommand(() => this.ShowAllView<WszystkieJezykiViewModel>())),
                 new CommandViewModel(
                     "Nowy język",
                     new BaseCommand(() => this.CreateView(new NowyJezykViewModel()))),
                 new CommandViewModel(
                    "Kategorie wiekowe",
                    new BaseCommand(() => this.ShowAllView<WszystkieKategorieWiekoweViewModel>())),
                  new CommandViewModel(
                     "Nowa kategoria wiekowa",
                     new BaseCommand(() => this.CreateView(new NowaKategoriaWiekowaViewModel()))),
                 new CommandViewModel(
                    "Kraje",
                    new BaseCommand(() => this.ShowAllView<WszystkieKrajeViewModel>())),
                 new CommandViewModel(
                     "Nowy kraj",
                     new BaseCommand(() => this.CreateView(new NowyKrajViewModel()))),
                 new CommandViewModel(
                    "Statusy filmu",
                    new BaseCommand(() => this.ShowAllView<WszystkieStatusyFilmuViewModel>())),
                  new CommandViewModel(
                     "Nowy status filmu",
                     new BaseCommand(() => this.CreateView(new NowyStatusFilmuViewModel()))),
                  new CommandViewModel(
                    "Statusy seansu",
                    new BaseCommand(() => this.ShowAllView<WszystkieStatusySeansuViewModel>())),
                  new CommandViewModel(
                     "Nowy status seansu",
                     new BaseCommand(() => this.CreateView(new NowyStatusSeansuViewModel()))),
                  new CommandViewModel(
                    "Typy biletów",
                    new BaseCommand(() => this.ShowAllView<WszystkieTypyBiletuViewModel>())),
                  new CommandViewModel(
                     "Nowy typ biletu",
                     new BaseCommand(() => this.CreateView(new NowyTypBiletuViewModel()))),
                  new CommandViewModel(
                    "Typy ekranów",
                    new BaseCommand(() => this.ShowAllView<WszystkieTypyEkranuViewModel>())),
                  new CommandViewModel(
                     "Nowy typ ekranu",
                     new BaseCommand(() => this.CreateView(new NowyTypEkranuViewModel()))),
                  new CommandViewModel(
                    "Typy nagłośnienia",
                    new BaseCommand(() => this.ShowAllView<WszystkieTypyNaglosnieniaViewModel>())),
                   new CommandViewModel(
                     "Nowy typ nagłośnienia",
                     new BaseCommand(() => this.CreateView(new NowyTypNaglosnieniaViewModel()))),
                  new CommandViewModel(
                    "Typy sal",
                    new BaseCommand(() => this.ShowAllView<WszystkieTypySaliViewModel>())),
                  new CommandViewModel(
                     "Nowy typ sali",
                     new BaseCommand(() => this.CreateView(new NowyTypSaliViewModel()))),
                   new CommandViewModel(
                    "Producenci",
                    new BaseCommand(() => this.ShowAllView<WszyscyProducenciViewModel>())),
                   new CommandViewModel(
                    "Reżyserzy",
                    new BaseCommand(() => this.ShowAllView<WszyscyRezyserzyViewModel>())),

            };
        }

        private List<CommandViewModel> CreateRaportyCommands()
        {
            
            return new List<CommandViewModel>
            {
                  new CommandViewModel(
                    "Raport sprzedaży biletów (per film)",
                    new BaseCommand(() => this.CreateView(new RaportSprzedazyBiletowViewModel()))),
                 new CommandViewModel(
                    "Raport zapełnienia seansów",
                    new BaseCommand(() => this.CreateView(new RaportZapelnieniaSeansowViewModel()))),
                 new CommandViewModel(
                    "Statystyki ogólne",
                    new BaseCommand(() => this.CreateView(new StatystykiOgolneViewModel())))
            };
        }

        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllView<T>() where T : WorkspaceViewModel, new()
        {

            T workspace = this.Workspaces.FirstOrDefault(vm => vm is T) as T;

            if(workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);

        }
                     
        
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void Open(string name)
        {
            switch (name)
            {
                case "FilmyAdd": {
                        CreateView(new NowyFilmViewModel()); //otwiera okno do dodawania filmu
                        break;
                }

                case "DystrybutorzyAdd":
                    {
                        CreateView(new NowyDystrybutorViewModel()); 
                        break;
                    }

                case "SaleAdd":
                    {
                        CreateView(new NowaSalaViewModel()); //otwiera okno do dodawania filmu
                        break;
                    }

                case "Gatunki filmoweAdd":
                    {
                        CreateView(new NowyGatunekViewModel()); //otwiera okno do dodawania gatunku
                        break;
                    }

                case "SeanseAdd":
                    {
                        CreateView(new NowySeansViewModel()); //otwiera okno do dodawania seansu
                        break;
                    }

                case "ProducenciAdd":
                    {
                        CreateView(new NowyProducentViewModel()); 
                        break;
                    }
                case "KrajeAdd":
                    {
                        CreateView(new NowyKrajViewModel()); 
                        break;
                    }
                case "JezykiAdd":
                    {
                        CreateView(new NowyJezykViewModel());
                        break;
                    }

                case "Kategorie wiekoweAdd":
                    {
                        CreateView(new NowaKategoriaWiekowaViewModel());
                        break;
                    }

                case "Statusy dla filmuAdd":
                    {
                        CreateView(new NowyStatusFilmuViewModel());
                        break;
                    }

                case "Statusy dla seansuAdd":
                    {
                        CreateView(new NowyStatusSeansuViewModel());
                        break;
                    }
                case "Typy biletówAdd":
                    {
                        CreateView(new NowyTypBiletuViewModel());
                        break;
                    }
                case "Typy ekranu saliAdd":
                    {
                        CreateView(new NowyTypEkranuViewModel());
                        break;
                    }
                case "Typy naglosnienia saliAdd":
                    {
                        CreateView(new NowyTypNaglosnieniaViewModel());
                        break;
                    }

                case "Typy saliAdd":
                    {
                        CreateView(new NowyTypSaliViewModel());
                        break;
                    }

                case "DystrybutorzyShow":
                    {
                        CreateView(new WszyscyDystrybutorzyViewModel());
                        break;
                    }

                case "FilmyShow":
                    {
                        CreateView(new WszystkieFilmyViewModel());
                        break;
                    }
                case "SaleShow":
                    {
                        CreateView(new WszystkieSaleViewModel());
                        break;
                    }

            }
            
        }
        #endregion
    }
}
