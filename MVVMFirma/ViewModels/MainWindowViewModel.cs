using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   
    // to jest ViewModel obslugujacy okno glowne aplikacji
    // w oknie glownym menu boczne z linkami oraz glowny obszar
    // roboczy z zakladkami 
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        // okno glowne ma w sobie kolekcje linkow tylko do odczytu
        // - mozna tez uzyc listy
        private ReadOnlyCollection<CommandViewModel> _Commands;
        // okno glowne zawiera tez kolekcje zakladek 
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields

        #region Commands
        //tworzymy propertisa do _Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if(_Commands == null)
                {
                    //tworzymy liste poniewaz readonlycollection nie mozna modifikowac
                    //a zatem cmds jest po to żeby było wzorcem dla readonlycollection
                    List<CommandViewModel> cmds = this.createCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
       
        //to jest funckja ktora tworzy komendy
        private List<CommandViewModel> createCommands()
        {
            Messenger.Default.Register<string>(this, open); //wykonaj Resolve
            //tworzymy nowa liste linkow
            return new List<CommandViewModel>
            {
                //kazdy element listy to nowy CommandViewModel o pierwszym parametrze
                //takim jak nazwa linku a drugim parametr mowi jaka funkcje wywolac
                //po kliknieciu
                //new CommandViewModel("Towar",
                //    new BaseCommand(()=>this.createTowar())),
                //new CommandViewModel("Towary",
                //    new BaseCommand(()=>this.showAllTowary())),
                new CommandViewModel("Osobowe",
                    new BaseCommand(()=>this.showAllOsobowe())),
                new CommandViewModel("Dodaj Osobowe",
                    new BaseCommand(()=>this.createDodajosobowe())),
                new CommandViewModel("Książka Adresowa",
                    new BaseCommand(()=>this.showAllAdresy())),
                //new CommandViewModel("Dodaj Kontakt",
                //    new BaseCommand(()=>this.createDodajKontakt())),                
                new CommandViewModel("Dodaj Klienta",
                    new BaseCommand(()=>this.createDodajKontakt())),
                new CommandViewModel("Dodaj Lokalizacje",
                    new BaseCommand(()=>this.showAllDodajLokalizacje())),
                new CommandViewModel("Statystyki",
                    new BaseCommand(()=>this.showAllStatystyki())),
                //new CommandViewModel("Auto",
                //    new BaseCommand(()=>this.createSzczegolyAuto())),
                new CommandViewModel("Citroen",
                    new BaseCommand(()=>this.createSzczegolyCitroen())),
                new CommandViewModel("All Faktury",
                    new BaseCommand(()=>this.showAllFaktury1())),
                new CommandViewModel("All Komisy",
                    new BaseCommand(()=>this.showAllKomisy())),
                new CommandViewModel("All Kontrahenci",
                    new BaseCommand(()=>this.ShowAllKontrahenci())),
                new CommandViewModel("All Pracownicy",
                    new BaseCommand(()=>this.ShowAllPracownicy())),
                new CommandViewModel("All Klienci",
                    new BaseCommand(()=>this.ShowAllKlienci())),
                new CommandViewModel("All Dostawcy",
                    new BaseCommand(()=>this.ShowAllDostawcy())),
                new CommandViewModel("Pojazd",
                    new BaseCommand(()=>this.createPojazd())),


                new CommandViewModel("Nowa Faktura",
                    new BaseCommand(() => this.CreateFaktura())),
                new CommandViewModel("Nowy Komis",
                    new BaseCommand(() => this.CreateKomis())),
                new CommandViewModel("Nowy Pojazd",
                    new BaseCommand(() => this.CreatePojazd())),
                new CommandViewModel("Nowy Raport",
                    new BaseCommand(() => this.CreateRaport())),



                //new CommandViewModel("wszyscy Kontrahenci",
                //    new BaseCommand(() => this.CreateWszyscyKontrahenci())),

                
                    //new CommandViewModel("Motocykle",
                //    new BaseCommand(()=>this.showAllMotocykle())),
                //new CommandViewModel("Dostawcze",
                //    new BaseCommand(()=>this.showAllDostawcze())),
                //new CommandViewModel("Ciężarowe",
                //    new BaseCommand(()=>this.showAllCiezarowe())),
                //new CommandViewModel("Budowlane",
                //    new BaseCommand(()=>this.showAllBudowlane())),
                //new CommandViewModel("Przyczepy",
                //    new BaseCommand(()=>this.showAllPrzyczepy())),
                //new CommandViewModel("Rolnicze",
                //    new BaseCommand(()=>this.showAllRolnicze())),

                new CommandViewModel("Pokaż Wyszstko",
                    new BaseCommand(()=>this.showAll())),

            };
        }
        #endregion Commands

        #region Workspaces
        //tworzymy propertisa do pola _Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion Workspaces



        //showAllMotocykle

        #region Helpers

        private void open(string name)
        {
            if (name == "Wszystkie faktury Add")
                CreateFaktura();
            if (name == "Kontrahenci Show")
                ShowAllKontrahenci();
            if (name == "Pojazd Show")
                createPojazd();
            if (name == "KlientAuto Show")
                createKlientOsobowe();
        }




        private void createWorkspace(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        //to jest funkcja ktora otworzy zakladke do dodawania towarow i jest
        //podpieta pod link wyzej

        //    private void createTowar()
        //{
        //    NowyTowarViewModel workspace = new NowyTowarViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}

        private void createDodajosobowe()
        {
            DodajOsoboweViewModels workspace = new DodajOsoboweViewModels();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        
        private void createPojazd()
        {
            PojazdViewModel workspace = new PojazdViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
                
        private void createKlientOsobowe()
        {
            KlientAutoViewModel workspace = new KlientAutoViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        
        //private void CreateWszyscyKontrahenci()
        //{
        //    WszyscyKontrahenciViewModel workspace = new WszyscyKontrahenciViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}

        private void createSzczegolyCitroen()
        {
            FrameAutoViewModel workspace = new FrameAutoViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        
        void CreatePojazd()
        {
            NowyPojazdViewModel workspace = new NowyPojazdViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        
        void CreateKomis()
        {
            NowyKomisViewModel workspace = new NowyKomisViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        private void createDodajKontakt()
        {
           // DodajKontaktViewModel workspace = new DodajKontaktViewModel();
            KlientAutoViewModel workspace = new KlientAutoViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        
        private void CreateRaport()
        {
            RaportSprzedazyViewModel workspace = new RaportSprzedazyViewModel();
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        //private void createSzczegolyAuto()
        //{
        //    AutoSzczegolyViewModel workspace = new AutoSzczegolyViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}


        private void showAll()
        {
            showAllOsobowe();
            showAllMotocykle();
            showAllDostawcze();
            showAllCiezarowe();
            showAllBudowlane();
            showAllPrzyczepy();
            showAllRolnicze();
        }


        private void showAllFaktury1()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKomisy()
        {
            WszystkieKomisyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszystkieKomisyViewModel) as WszystkieKomisyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKomisyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        
        private void ShowAllPracownicy()
        {
            WszystkiePracownicyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszystkiePracownicyViewModel) as WszystkiePracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllOsobowe()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            OsoboweViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                OsoboweViewModels) as OsoboweViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new OsoboweViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        //Koniec 

        private void showAllStatystyki()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            StatystykiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                StatystykiViewModel) as StatystykiViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new StatystykiViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        //Koniec 

        private void showAllDodajLokalizacje()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            DodajLokalizacjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                DodajLokalizacjeViewModel) as DodajLokalizacjeViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new DodajLokalizacjeViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        //Koniec 

        private void showAllAdresy()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            AdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                AdresyViewModel) as AdresyViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new AdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        //Koniec 

        private void showAllMotocykle()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            MotocykleViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                MotocykleViewModels) as MotocykleViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new MotocykleViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }

        private void showAllDostawcze()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            DostawczeViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                DostawczeViewModels) as DostawczeViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new DostawczeViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }

        private void showAllCiezarowe()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            CiezaroweViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                CiezaroweViewModels) as CiezaroweViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new CiezaroweViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }

        private void showAllBudowlane()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            BudowlaneViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                BudowlaneViewModels) as BudowlaneViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new BudowlaneViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        
        private void showAllPrzyczepy()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            PrzyczepyViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                PrzyczepyViewModels) as PrzyczepyViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new PrzyczepyViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
               
        private void showAllRolnicze()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            RolniczeViewModels workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                RolniczeViewModels) as RolniczeViewModels;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new RolniczeViewModels();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
                       
        private void ShowAllKontrahenci()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszyscyKontrahenciViewModel) as WszyscyKontrahenciViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
                               
        private void ShowAllKlienci()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            WszyscyKlienciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszyscyKlienciViewModel) as WszyscyKlienciViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new WszyscyKlienciViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }

                                       
        private void ShowAllDostawcy()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            WszyscyDostawcyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszyscyDostawcyViewModel) as WszyscyDostawcyViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new WszyscyDostawcyViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }



        //powyzsza funkcja za kazdym razem tworzyla nowa zakladke
        //ponizsza funkcja najpierw sprawdzi czy wyswietlania wszystkich 
        //towarow juz nie ma 
        //jak jest to przywroci jej aktywnosc
        //jak nie ma to stworzy nowa


        //to jest funkcja ktora wlacza aktywnosc zakladki
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView =
                CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion Helpers


        #region MenuCommands
        private BaseCommand _DodajAuto;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand DodajAuto
        {
            get
            {
               // if (_DodajAuto == null) _DodajAuto = new BaseCommand(() => createWorkspace(new DodajOsoboweViewModels()));
                if (_DodajAuto == null) _DodajAuto = new BaseCommand(() => createWorkspace(new NowyPojazdViewModel()));
                return _DodajAuto;
            }
        }

        private BaseCommand _PokazOsobowe;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazOsobowe
        {
            get
            {
                if (_PokazOsobowe == null) _PokazOsobowe = new BaseCommand(() => createWorkspace(new OsoboweViewModels()));
                return _PokazOsobowe;
            }
        }

        private BaseCommand _DodajLokalizacje;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand DodajLokalizacje
        {
            get
            {
                if (_DodajLokalizacje == null) _DodajLokalizacje = new BaseCommand(() => createWorkspace(new WszystkieKomisyViewModel()));
                return _DodajLokalizacje;
            }
        }

        private BaseCommand _DodajDoKsiazkiAdresowej;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand DodajDoKsiazkiAdresowej
        {
            get
            {
                if (_DodajDoKsiazkiAdresowej == null) _DodajDoKsiazkiAdresowej = new BaseCommand(() => createWorkspace(new DodajKontaktViewModel()));
                return _DodajDoKsiazkiAdresowej;
            }
        }

        private BaseCommand _PokazKsiazkeAdresowa;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazKsiazkeAdresowa
        {
            get
            {
                if (_PokazKsiazkeAdresowa == null) _PokazKsiazkeAdresowa = new BaseCommand(() => createWorkspace(new AdresyViewModel()));
                return _PokazKsiazkeAdresowa;
            }
        }
        
        private BaseCommand _PokazWszystkiePracownikow;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazWszystkiePracownikow
        {
            get
            {
                if (_PokazWszystkiePracownikow == null) _PokazWszystkiePracownikow = new BaseCommand(() => createWorkspace(new WszystkiePracownicyViewModel()));
                return _PokazWszystkiePracownikow;
            }
        }

        private BaseCommand _PokazStatystyke;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazStatystyke
        {
            get
            {
                if (_PokazStatystyke == null) _PokazStatystyke = new BaseCommand(() => createWorkspace(new StatystykiViewModel()));
                return _PokazStatystyke;
            }
        }
        //NOWE PRZYCISKI 2019 ******************************************************************************************
        
        private BaseCommand _PokazFaktury;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazFaktury
        {
            get
            {
                if (_PokazFaktury == null) _PokazFaktury = new BaseCommand(() => createWorkspace(new WszystkieFakturyViewModel()));
                return _PokazFaktury;
            }
        }
                
        private BaseCommand _PokazWszystkieKlienci;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazWszystkieKlienci
        {
            get
            {
                if (_PokazWszystkieKlienci == null) _PokazWszystkieKlienci = new BaseCommand(() => createWorkspace(new WszyscyKlienciViewModel()));
                return _PokazWszystkieKlienci;
            }
        }
                        
        private BaseCommand _PokazWszystkieDostawcy;
        // to jest komenda ktora zostanie podpiera pod menu i wywola funkcje createTowar
        public ICommand PokazWszystkieDostawcy
        {
            get
            {
                if (_PokazWszystkieDostawcy == null) _PokazWszystkieDostawcy = new BaseCommand(() => createWorkspace(new WszyscyDostawcyViewModel()));
                return _PokazWszystkieDostawcy;
            }
        }


        #endregion MenuCommands

    }
}
