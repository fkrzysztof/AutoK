using MVVMFirma.Helpers;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportSprzedazyViewModel : WorkspaceViewModel
    {
        #region Fields
        private KomisEntities komisEntities;
        #endregion Fields

        #region Constructor
        public RaportSprzedazyViewModel()
            : base() //to jest lista inicjalizacyjna, wywoluje ona konstruktor z klasy WszystkieViewModel - bazowej
        {
            komisEntities = new KomisEntities();
            base.DisplayName = "Raport Sprzedazy";
            //dodatkowo konstruktor ustawi wartosci domyslne pol
            OdDaty = DateTime.Now;//aktualna data
            DoDaty = DateTime.Now;
            Utarg = 0;
        }
        #endregion Constructor

        #region Properties
        //dla kazdego pola na widoku istotnego w obliczeniach dodajemy pole i wlasciwosc
        private DateTime _OdDaty;
        public DateTime OdDaty
        {
            get
            {
                return _OdDaty;
            }
            set
            {
                if (_OdDaty != value)
                {
                    _OdDaty = value;
                    OnPropertyChanged(() => OdDaty); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        private DateTime _DoDaty;
        public DateTime DoDaty
        {
            get
            {
                return _DoDaty;
            }
            set
            {
                if (_DoDaty != value)
                {
                    _DoDaty = value;
                    OnPropertyChanged(() => DoDaty); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        private int _IdTowaru;
        public int IdTowaru
        {
            get
            {
                return _IdTowaru;
            }
            set
            {
                if (_IdTowaru != value)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        //tworzymy teraz propetiesa obslugujacego Comboboxa wyswietlajacego towary
        public IQueryable<ComboBoxKeyAndValue> TowaryComboboxItems
        {
            get
            {
                //to jest wywolanie funkcji z logiki biznesowej klasy TowaryB z warstwy Model
                return new TowarB(komisEntities).GetTowaryComboboxItems();
            }
        }
        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (_Utarg != value)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        #endregion Properties

        #region Command
        //to jest komenda ktora zostanie podpieta pod przycisk oblicz i wywola metode
        //obliczUtargClik()
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczUtargClick());
                return _ObliczCommand;
            }
        }
        #endregion Command

        #region Helpers
        private void obliczUtargClick()
        {
            //wykorzystamy teraz funkcje UtargOkresTowar z klasy logiki biznesowej UtargB
            //z warstwy Model
            Utarg = new UtargB(komisEntities).UtargOkresTowar(OdDaty, DoDaty, IdTowaru);
        }
        #endregion Helpers
    }
}