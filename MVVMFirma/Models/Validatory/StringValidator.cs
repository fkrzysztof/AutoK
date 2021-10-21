using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class StringValidator : Validator
    {
        #region ValidationFunction
        //to jest funkcja ktora sprawdza czy parametr wartosc zaczyna sie z duzej litery
        //jezeli nie zaczyna sie od duzej to funkcja zwroci komunikat z bledem jako string
        //natomiast gdy zaczyna sie od duzej zwroci null
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                //jezeli nieprawda ze wartosc na pozycji 0 ma litere duza to wtedy
                if (!char.IsUpper(wartosc, 0))
                    return "Rozpocznij duza litera";
            }
            catch (Exception)
            {

            }
            return null;
        }
        #endregion ValidationFunction
    }
}