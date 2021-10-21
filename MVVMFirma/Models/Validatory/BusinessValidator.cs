using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class BusinessValidator : Validator
    {
        #region BusinessFunction
        public static string SprawdzVat(int? vat)
        {
            if (vat < 0 || vat > 100)
                return "Vat powinien byc z przedzialu od 0 do 100";
            return null;
        }

        //static public string NIPTest(string em)
        //{
        //    if (BusinessValidator.isValidEmail(em))
        //        return null;
        //    return "NIP nie jest prawodłowy";
        //}

        public static string isValidEmail(string inputEmail)
        {
            //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            //      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            //      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            //Regex re = new Regex(strRegex);
            //if (re.IsMatch(inputEmail))
            //    return "Email nie jest prawidlowy";
            //else
                return null;
        }


        #endregion BusinessFunction
    }
}
