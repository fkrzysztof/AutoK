using MVVMFirma.Models.Entities;
using System;
using System.Linq;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UtargB : DatabaseClass
    {
        #region Constructor
        public UtargB(KomisEntities komisEntities)
            : base(komisEntities)
        {
        }
        #endregion Constructor

        #region BuisnessFunction
        //to jest funkcja ktora bedzie liczyla utarg w podanym jako parametr okresie
        //dla podanego jako parametr towaru
        //ta funkcja zostanie wywolana w RaportSprzedazyViewModel
        public decimal? UtargOkresTowar(DateTime odDaty, DateTime doDaty, int IdTowaru)
        {
            return
            (
            from PozycjeFaktury in komisEntities.PozycjeFaktury
            where PozycjeFaktury.Pojazdy.IdDokladnegoTypu == IdTowaru
            
            //  where
            //PozycjeFaktury.IdPojazdu == IdTowaru // &&
        //    PozycjeFaktury.Faktury3.DataWystawienia >= odDaty &&
        //    PozycjeFaktury.Faktury3.DataWystawienia <= doDaty
            select PozycjeFaktury.Cena  //* pozycja.ilosc
            ).Sum();
        }
        #endregion BuisnessFunction



    }
}