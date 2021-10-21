using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{   
    // NowyTowarViewModel jest zakladka, a zatem dziedziczy po
    // WorkspaceViewModel
    public class NowyTowarViewModel : WorkspaceViewModel
    {
        public NowyTowarViewModel()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Towar123";
        }
    }
}
