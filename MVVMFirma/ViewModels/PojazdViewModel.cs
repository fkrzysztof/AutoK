using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVMFirma.ViewModels
{
    class PojazdViewModel : WorkspaceViewModel
    {
        #region Constructor
        public PojazdViewModel()
        {
            base.DisplayName = "Pojazd";
            Messenger.Default.Register<PojazdyForAllView>(this, getWybranyPojazd);
            Messenger.Default.Register<Kontrahenci>(this, getKontrahent);
            Messenger.Default.Register<AdresyKontrahentow>(this, getAdresKontrahent);
            Napis = "I CO DA sie?";
            PojazdMarka = "Pojazd marki:";
            OgolnyTyp = "Osobowe";

            //na chwile
            Sprzedane = "";
        }

        #endregion Constructor


        #region Fields
        private BaseCommand _Drukuj;
        private BaseCommand _DodajKlienta;
        private PojazdyForAllView pojazdMessenger;
        public string Sprzedane;
        #endregion Fields

        #region Command
        //to jest komenda ktora zostanie podpieta pod przycisk zapisu
        public ICommand Drukuj
        {
            get
            {
                if (_Drukuj == null)
                    _Drukuj = new BaseCommand(() => drukujTo()); //ta komenda wywola metode saveAndClose() ktora zapisze rekod i zamknie zakladke
                return _Drukuj;
            }
        }
        public ICommand DodajKlienta
        {
            get
            {
                if (_DodajKlienta == null)
                    _DodajKlienta = new BaseCommand(() => sprzedaj()); //ta komenda wywola metode saveAndClose() ktora zapisze rekod i zamknie zakladke
                return _DodajKlienta;
            }
        }

        #endregion Command

        #region Properites

        public string Napis { get; set; }

        public string PojazdMarka { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public string DokladnyTyp { get; set; }
        public string OgolnyTyp { get; set; }
        public string Lokalizacja { get; set; }
        public DateTime? RokProdukcji { get; set; }
        public string Przebieg { get; set; }
        public int? Pojemnosc { get; set; }
        public string TypSilnika { get; set; }
        public int? Moc { get; set; }
        public decimal? Cena { get; set; }
        public string Opis { get; set; }
        public string VIN { get; set; }

        //wyposazenie pojazdu
        public bool? Abs { get; set; }
        public bool? ESzP { get; set; }
        public bool? ESzT { get; set; }
        public bool? Aux { get; set; }
        public bool? ISOFix { get; set; }
        public bool? CD { get; set; }
        public bool? SD { get; set; }
        public bool? USB { get; set; }
        public bool? Tempomat { get; set; }
        //foto
        public string FotoUrl { get; set; }
        //komis
        public string PojazdNazwaKomisu { get; set; }
        public string PojazdMiastoKomisu { get; set; }
        public string PojazdUlicaKomisu { get; set; } //nowe
        public string PojazdKodKomisu { get; set; }   //nowe
        public string PojazNrDomuKomisu { get; set; } 
        public string PojazNIPKomisu { get; set; } 
        //Kontrahent
        public string KontrahentImie { get; set; }
        public string KontrahentNazwisko { get; set; }
        //Kontrahent Adres
        public string KontrahentAdresKraj { get; set; }
        public string KontrahentAdresUlica { get; set; }
        public string KontrahentAdresNrDomu { get; set; }
        public string KontrahentAdresNrMieszkania { get; set; }
        public string KontrahentAdresKod { get; set; }
        public string KontrahentAdresMiasto { get; set; }


        //public string PojazdMarka
        //{
        //    get { return PojazdMarka; }
        //    set
        //    {
        //        if (value == PojazdMarka)
        //            return;
        //        PojazdMarka = value;
        //        base.OnPropertyChanged(() => PojazdMarka);
        //    }
        //}

        private string um = "umowa sprzedży AUTOAAA";

        #endregion Properites

        #region Helpers
     
        #region Print
        private void drukujTo()
        {
            
            
               PrintDialog pd = new PrintDialog();
               if(pd.ShowDialog() == true)
               {
                var doc = new FlowDocument();

                doc.ColumnWidth = pd.PrintableAreaWidth;
                doc.FontFamily = new FontFamily("Arial");
                doc.FontSize = 14.0;
                doc.PagePadding = new Thickness(50);

                Paragraph p1 = new Paragraph();
                p1.TextAlignment = TextAlignment.Center;
                Run r1 = new Run("UMOWA KUPNA SPRZEDAŻY\n\n");
                r1.FontWeight = FontWeights.UltraBold;
                r1.FontSize = 20.0;
                p1.Inlines.Add(r1);
                doc.Blocks.Add(p1);
                doc.Blocks.Add(new Paragraph(new Run("Zawarta w " + Lokalizacja + " dnia " + DateTime.Now.ToString().Remove(16) + " pomiędzy:")));
                doc.Blocks.Add(new Paragraph(new Run("Nazwa: " + PojazdNazwaKomisu + " " + 
                    "\nAdres: " + PojazdUlicaKomisu + " " + PojazNrDomuKomisu + ", " + Lokalizacja  + " " + PojazdKodKomisu +
                    "\nNIP: " + PojazNIPKomisu +
                    "\nzwanym/ą dalej SPRZEDAWCĄ (KOMISANTEM)" +
                    "\na" +
                    "\nImie i Nazwisko: " + KontrahentImie + " " + KontrahentNazwisko +
                    "\nAdres: " + KontrahentAdresUlica + " " + KontrahentAdresNrDomu + " " + KontrahentAdresNrMieszkania + ", " + KontrahentAdresKod + " " + KontrahentAdresMiasto +
                    "\nzwanym/ą dalej KUPUJĄCYM\n\n")));

                Paragraph p2 = new Paragraph();
                p2.TextAlignment = TextAlignment.Center;
                Run r2 = new Run("§ 1.");
                r2.FontWeight = FontWeights.UltraBold;
                p2.Inlines.Add(r2);
                doc.Blocks.Add(p2);

                doc.Blocks.Add(new Paragraph(new Run(
                    "1. Sprzedawca oświadcza, że przedmiotem sprzedaży jest samochód osobowy marki: " + PojazdMarka +
                    " rocznik: " + RokProdukcji.ToString().Remove(4) + ",numer nadwozia (VIN): " + VIN + ", przebieg: " + Przebieg +
                    " który stanowi przedmiot umowy komisu zawartej pomiędzy Sprzedawcą, a podmiotem trzecim (dalej: Samochód)." +
                    "\n2. Sprzedawca oświadcza, że Samochód jest wolny od wad prawnych, w tym wszelkich praw osób trzecich oraz że" +
                    " spełnia przesłanki dopuszczenia go do ruchu drogowego.")));

                Paragraph p3 = new Paragraph();
                p3.TextAlignment = TextAlignment.Center;
                Run r3 = new Run("§ 2.");
                r3.FontWeight = FontWeights.UltraBold;
                p3.Inlines.Add(r3);
                doc.Blocks.Add(p3);

                doc.Blocks.Add(new Paragraph(new Run(
                    "1. Kupujący oświadcza, że Samochód widział, a także zapoznał się z jego stanem technicznym.")));

                Paragraph p4 = new Paragraph();
                p4.TextAlignment = TextAlignment.Center;
                Run r4 = new Run("§ 3.");
                r4.FontWeight = FontWeights.UltraBold;
                p4.Inlines.Add(r4);
                doc.Blocks.Add(p4);

                doc.Blocks.Add(new Paragraph(new Run(
                    "1. Sprzedawca sprzedaje, a Kupujący kupuje Samochód za cenę: " + Cena + " PLN." +
                    "\n2. Sprzedawca niniejszym kwituje odbiór ww. kwoty, która w momencie podpisania umowy zostaje mu przekazana." +
                    "\n3. Wydanie Samochodu nastąpi niezwłocznie po podpisaniu niniejszej umowy." +
                    "\n4. Wraz z wydaniem Samochodu Sprzedawca przekaże Kupującemu wszelkie posiadane przez niego rzeczy służące " +
                    "do korzystania z Samochodu (w tym kluczyk/i), a także dowód rejestracyjny i dokumenty niezbędne do rejestracji." +
                    "\n5. Strony oświadczają, iż są świadome odpowiedzialności karnej i karnoskarbowej, w przypadku wskazania w § 3 ust." +
                    " 1 umowy, kwoty innej niż faktycznie zapłacona tytułem ceny Samochodu.")));

                Paragraph p5 = new Paragraph();
                p5.TextAlignment = TextAlignment.Center;
                Run r5 = new Run("§ 4.");
                r5.FontWeight = FontWeights.UltraBold;
                p5.Inlines.Add(r5);
                doc.Blocks.Add(p5);

                doc.Blocks.Add(new Paragraph(new Run(
                    "1. W sprawach nieuregulowanych zastosowanie znajdą przepisy Kodeksu cywilnego." +
                    "\n2. W przypadku sprzeczności postanowień niniejszej umowy z innymi dokumentami dotyczącymi sprzedaży" +
                    " Samochodu, pierwszeństwo w ustalaniu treści stosunku prawnego ma niniejsza umowa." +
                    "\n3. Spory wynikłe na tle niniejszej umowy rozpatrywać będzie sąd właściwy dla miejsca zamieszkania Kupującego.")));

                //doc.Blocks.Add(new Paragraph(new Run("Adres: " + PojazdUlicaKomisu + " " + PojazNrDomuKomisu + ", " + Lokalizacja  + " " + PojazdKodKomisu + " koniec")));
               // pd.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Simple document");

                Paragraph p6 = new Paragraph();
                p6.TextAlignment = TextAlignment.Center;
                Run r6 = new Run("\n\n\nSPRZEDAWCA                                                                           KUPUJĄCY");
                p6.Inlines.Add(r6);
                doc.Blocks.Add(p6);

                pd.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Simple document");

            }


            }
        #endregion Print

        private void getWybranyPojazd(PojazdyForAllView pojazd)
        {
            pojazdMessenger = pojazd;
            //IdNabywca = kontrahent.IdKontrahenta;
            //KontrahentDane = kontrahent.Nazwa + " " + kontrahent.Nazwisko + " " + kontrahent.Imie;
            PojazdMarka = pojazd.PojazdMarka + " " + pojazd.PojazdModel;
            Cena = pojazd.PojazdCena;
            Model = pojazd.PojazdModel;
            Marka = pojazd.PojazdMarka;
            DokladnyTyp = pojazd.PojazdDokladnytyp;
            //OgolnyTyp 
            RokProdukcji = pojazd.RokProdukcji;
            Przebieg = pojazd.Przebieg.Trim();
            Pojemnosc = pojazd.Pojemnosc;
            TypSilnika = pojazd.PojazdTypSilnika;
            Moc = pojazd.MocKM;
            Opis = pojazd.OpisPojazdu;
            VIN = pojazd.NrVIN;
            //Wyposazenie
            Abs = pojazd.PojazdAbs;
            ESzP = pojazd.PojazdESzP;
            ESzT = pojazd.PojazdESzT;
            Aux = pojazd.PojazdAux;
            ISOFix = pojazd.PojazdISOFix;
            CD = pojazd.PojazdCD;
            SD = pojazd.PojazdSD;
            USB = pojazd.PojazdUSB;
            Tempomat = pojazd.PojazdTempomat;
            FotoUrl = pojazd.PojazdUrl;
            //komis
            Lokalizacja = pojazd.PojazdMiastoKomisu;
            PojazdUlicaKomisu = pojazd.PojazdUlicaKomisu;
            PojazdKodKomisu = pojazd.PojazdKodKomisu;
            PojazNrDomuKomisu = pojazd.PojazNrDomuKomisu.Trim();
            PojazdNazwaKomisu = pojazd.PojazdNazwaKomisu;
            PojazNIPKomisu = pojazd.PojazNIPKomisu;
            
        }

        private void getAdresKontrahent(AdresyKontrahentow obj)
        {
            KontrahentAdresKraj = obj.Kraj;
            KontrahentAdresUlica = obj.Ulica;
            KontrahentAdresNrDomu = obj.NrDomu;
            KontrahentAdresNrMieszkania = obj.NrLokalu;
            KontrahentAdresKod = obj.KodPocztowy;
            KontrahentAdresMiasto = obj.Miasto;
        }

        private void getKontrahent(Kontrahenci obj)
        {
            KontrahentImie = obj.Imie;
            KontrahentNazwisko = obj.Nazwisko;
        }

        private void sprzedaj()
        {
            Messenger.Default.Send("KlientAuto Show");
            Messenger.Default.Send<PojazdyForAllView>(pojazdMessenger);


            Sprzedane = "Sprzedane"; //wywalic
        }

        #endregion Helpers


    }
}
