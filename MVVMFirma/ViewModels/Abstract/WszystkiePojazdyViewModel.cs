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
    public abstract class WszystkiePojazdyViewModel<T> : WorkspaceViewModel
    {

        //** kopia kodu z wyswietlania adresow


        #region Fields
        protected KomisEntities komisEntities;
        private BaseCommand _LoadCommand;
        private BaseCommand _AddCommand;

        private ObservableCollection<T> _List;
        //sortowanie
        private BaseCommand _SortCommand;
      //  private BaseCommand _FindCommand;

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
            get
            {
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

        public string SelectMarka { get; set; }
        public List<string> MarkaComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxMarka();
            }
        }
        
        public string SelectModel { get; set; }
        public List<string> ModelComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxModel();
            }
        }
                
        public DateTime SelectDataOd { get; set; }

        public DateTime SelectDataDo { get; set; }

        public string SelectRodzajPaliwa { get; set; }
        public List<string> RodzajPaliwaComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxRodzajPaliwa();
            }
        }

        public string SelectKlimatyzacja { get; set; }
        public List<string> KlimatyzacjaComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxKlimatyzacja();
            }
        }

        public string SelectKomis { get; set; }
        public List<string> KomisComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxKomis();
            }
        }
        
        public string SelectDokladnyTyp { get; set; }
        public List<string> DokladnyTypComboboxItems
        {
            get
            {
                //to jest metoda ktora okresli po jakich polach mozemy sortowac
                return GetComboboxDokladnyTyp();
            }
        }
                
        public int? SelectPrzebiegOd { get; set; }                
        public int? SelectPrzebiegDo { get; set; }
        public List<int> PrzebiegComboboxItems
        {
            get
            {
                return GetComboboxPrzebieg();
            }
        }


        public double? SelectMocOd { get; set; }
        public double? SelectMocDo { get; set; }

        public decimal? SelectCenaOd { get; set; }
        public decimal? SelectCenaDo { get; set; }




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


        #endregion SortAndFind


        #region Constructor
        public WszystkiePojazdyViewModel()
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
        public abstract List<string> GetComboboxMarka();
        public abstract List<string> GetComboboxModel();
        public abstract List<string> GetComboboxRodzajPaliwa();
        public abstract List<string> GetComboboxKlimatyzacja();
        public abstract List<string> GetComboboxKomis();
        public abstract List<string> GetComboboxDokladnyTyp();
        public abstract List<int>    GetComboboxPrzebieg();


        
        //public abstract void Find();
        //public abstract List<string> GetComboboxFindList();


        #endregion



    }
}
