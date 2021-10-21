using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class TowarB : DatabaseClass
    {
        #region Constructor
        public TowarB(KomisEntities komisEntities)
            : base(komisEntities)
        {
        }
        #endregion Constructor


            #region ViewFunction
            public IQueryable<ComboBoxKeyAndValue> GetTowaryComboboxItems()
            {
                return
                    (
                       from DokladnyTypPojazdu in komisEntities.DokladnyTypPojazdu
                       select new ComboBoxKeyAndValue
                       {
                           Key = DokladnyTypPojazdu.IdDokladnegoTypuPojazdu,
                           Value = DokladnyTypPojazdu.NazwaDokladnegoTypu // + " " + DokladnyTyp
                       }
                    ).ToList().AsQueryable();
            }
            #endregion ViewFunction

        }
}
