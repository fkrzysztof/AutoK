using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
   // class AdresyViewModel : WorkspaceViewModel
    public class AdresyViewModel : WszystkieZapytaniaSQL
    {
        /*    public AdresyViewModel()
            {
                base.DisplayName = "Ksiażka Adresowa";
            }
        */
        

        #region Constructor
        public AdresyViewModel()
        :base()
        {
            base.DisplayName = "Adresy";

        }
        #endregion Constructor

        #region Helpers
        //to jest metoda ktora zaladuje towary z bacy danych
        //ta funkcja jest abstrakcyjna bo nie ma bloku i bedzie napisana w klasach chiedziczacych po tej klasie
        public override void Load()
        {
            KontrahenciList = new ObservableCollection<Kontrahenci>
            (from Kontrahenci in komisEntities.Kontrahenci select Kontrahenci);
        }
        #endregion


    }
}
