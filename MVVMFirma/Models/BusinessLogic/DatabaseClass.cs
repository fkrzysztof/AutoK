using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    //wszystkie klasy logiki biznesowej powinny sie znajdowac w warstwie Model
    //to jest klasa bazowa z ktorej beda dziedziczyly wszystkie 
    //klasy logiki biznesowej uzywajace bazy danych
    public class DatabaseClass
    {
        #region Fields
        //to jest obiekt odpowiedzilany za polaczenie z baza danych
        protected KomisEntities komisEntities;

        #endregion //Fields
        #region Constructor
        public DatabaseClass(KomisEntities komisEntities)
        {
            this.komisEntities = komisEntities;
        }
        #endregion //Constructor


    }
}
