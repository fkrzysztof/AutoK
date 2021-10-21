using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.ViewModels.Abstract;
using MVVMFirma.Helpers;

namespace MVVMFirma.ViewModels
{
    class JedenWszystkieViewModell<J, W> : JedenViewModel<J>
    {
        #region Fields
        //private BaseCommand _LoadListCommand;
        private ObservableCollection<W> _List;
        private BaseCommand _ShowAddViewCommand;
        protected string DisplayListName;
        #endregion // Fields
        #region Properties
        public ObservableCollection<W> List
        {
            get
            {
                if (_List == null)
                    LoadList();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand = new BaseCommand(() => ShowAddView());
                }
                return _ShowAddViewCommand;
            }
        }
        #endregion //Properties
        #region Constructor
        public JedenWszystkieViewModel()
        : base()
        {
        }
        #endregion // Constructor
        #region Helpers
        public abstract void LoadList();
        private void ShowAddView()
        {
            Messenger.Default.Send(DisplayListName + " Add");
        }

        #endregion Helpers
 }
}