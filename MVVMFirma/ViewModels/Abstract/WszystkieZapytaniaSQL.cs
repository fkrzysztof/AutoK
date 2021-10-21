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
    public abstract class WszystkieZapytaniaSQL :WorkspaceViewModel
    {

        //** kopia kodu z wyswietlania adresow


        #region Fields
        // to jest obiekt odpowiedzialny za polaczenie z baza danych
        protected KomisEntities komisEntities;
        //to jest komenda odpowiadajaca za zaladowanie wszystkich obiektow
        private BaseCommand _LoadCommand;
        //to jest lista towarow, ktora zostanie zaladowana z bazy danych
        //private ObservableCollection<Towary> _List;
        private ObservableCollection<Kontrahenci> _KontrahenciList;
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
        //to jest standardowy kod propertiesa do listy _List
        public ObservableCollection<Kontrahenci> KontrahenciList
        {
            get
            {
                if (_KontrahenciList == null)
                    Load();
                return _KontrahenciList;
            }
            set
            {
                if (_KontrahenciList != value)
                {
                    _KontrahenciList = value;
                    OnPropertyChanged(() => KontrahenciList);
                }
            }
        }
        #endregion Properties

        #region Constructor
        public WszystkieZapytaniaSQL()
        {
            //zainicjujemy obiekt laczacy sie z baza danych
            this.komisEntities = new KomisEntities();
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda ktora zaladuje towary z bacy danych
        //ta funkcja jest abstrakcyjna bo nie ma bloku i bedzie napisana w klasach chiedziczacych po tej klasie
        public abstract void Load();

        #endregion


        //** koniec kopii
    }
}
