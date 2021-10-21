using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    //jezeli klasa dziala na jakims typie ktory przybiera konkretna instancje w klasie dziedziczacym to te klase powinnismy oprzec na mechanizmie typow generycznych
    public abstract class JedenViewModel<T> : WorkspaceViewModel //typ T to jest dowlony typ obiektu ktory bedzie dodawany za pomoca tej klasy. Czym jest T zdecydujemy w klasie dziedziczacej. W przypadku dodawania towarow T bedzie typu Towary
    {
        #region Fields
        //tworzymy obiekt do polaczenia z baza danych
        protected KomisEntities komisEntities;
        //tworzymy obiekt ktory bedziemy dodawac do bazy
        protected T item;
        //to jest komenda ktora zostanie podpieta pod przycisk zapisz
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Construktor
        public JedenViewModel()
        {
            //to jest utworzenie polaczenia z baza danych
            this.komisEntities = new KomisEntities();
        }
        #endregion Constructor

        #region Command
        //to jest komenda ktora zostanie podpieta pod przycisk zapisu
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose()); //ta komenda wywola metode saveAndClose() ktora zapisze rekod i zamknie zakladke
                return _SaveCommand;
            }
        }
        #endregion Command

        #region Helpers
        //to jest metoda ktora zapisuje rekod
        public abstract void Save();
        //to jest metoda ktora zapisuje rekord i zamyka zakladke
        private void SaveAndClose()
        {
            if (IsValid())
            {
                Save();
               // ShowMessageBoxInformation("Dokument został zapisany do bazy");
                onRequestClose();
            }
            else
                //dodaj tę funkcję do klasy BaseViewModel
                ShowMessageBox("Popraw błędy");
        }
        #endregion Helpers

        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion Validation

    }
}
