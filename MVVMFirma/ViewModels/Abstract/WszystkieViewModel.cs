using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {

        //** kopia kodu z wyswietlania adresow


        #region Fields
        // to jest obiekt odpowiedzialny za polaczenie z baza danych
        protected KomisEntities komisEntities;
        //to jest komenda odpowiadajaca za zaladowanie wszystkich obiektow
        private BaseCommand _LoadCommand;
        private BaseCommand _AddCommand;

        //to jest lista towarow, ktora zostanie zaladowana z bazy danych
        //private ObservableCollection<Towary> _List;
        private ObservableCollection<T> _List;
        //sortowanie
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;

        #endregion Fields

        #region Properties
        // to jest properties do komendy ladujacej obiekty - standardowy kod
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());   //komenda ta wywola metode load
                return _LoadCommand;
            }
        }
        public ICommand AddCommand
        {
            get {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
                }
        }



        //to jest standardowy kod propertiesa do listy _List
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }
        }

        #endregion Properties

        #region SortAndFind
        //w tym polu zapisujemy po ktorej kolumnie sortowac
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxSortList();
            }
        }
        //to jest komenda ktora zostanie podpieta pod button sortuj
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    //komenda ta wywola metode sort ktora bedzie sortowac
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        //to jest wynik po czym bedziemy wyszukiwac
        public string FindField { get; set; }
        //tu zapisuje sie poczatek fazy wyszukujacej
        public string FindTextBox { get; set; }
        //tu znajduja sie elementy Comboboxa - po czym mozemy wyszukiwac
        public List<string> FindComboboxItems
        {
            get
            {
                //ta metoda okresla po czym bedziemy mogli wyszukiwac
                return GetComboboxFindList();
            }
        }
        //to jest komenda ktora zostanie podpieta pod przycisk szukaj
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    //komenda ta wywola metode find ktora wyszukuje rekordy
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        #endregion SortAndFind


        #region Constructor
        public WszystkieViewModel()
        {
            //zainicjujemy obiekt laczacy sie z baza danych
            this.komisEntities = new KomisEntities();
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda ktora zaladuje towary z bacy danych
        //ta funkcja jest abstrakcyjna bo nie ma bloku i bedzie napisana w klasach chiedziczacych po tej klasie
        public abstract void Load();
        private void Add()
        {
            Messenger.Default.Send(DisplayName + " Add");
            //wykonaj Resolve 
        }

        public abstract void Sort();
        public abstract List<string> GetComboboxSortList();
        public abstract void Find();
        public abstract List<string> GetComboboxFindList();


        #endregion


        //** koniec kopii
    }
}
