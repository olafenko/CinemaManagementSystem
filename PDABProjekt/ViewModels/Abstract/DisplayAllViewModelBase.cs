using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Helper;
using PDABProjekt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels.Abstract
{
    public abstract class DisplayAllViewModelBase<T> : DatabaseVMClass
    {

        #region Constructor

        public DisplayAllViewModelBase() : base() { }

        #endregion

        #region Command

        private BaseCommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(Load);
                return _LoadCommand;
            }
        }


        private BaseCommand _AddCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null) _AddCommand = new BaseCommand(Add);
                return _AddCommand;
            }
        }
        private void Add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }


        #endregion

        #region Lista

        protected ObservableCollection<T> _List;

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) Load();
                return _List;
            }

            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }

        }

        public abstract void Load();

        #endregion

       

        #region Sort and find

        private BaseCommand _SortCommand;

        public ICommand SortCommand
        {

            get
            {
                if (_SortCommand == null) _SortCommand = new BaseCommand(Sort);
                return _SortCommand;
            }

       
        }

        public string SortField { get; set; }


        public List<string> SortComboBoxItems
        {

            get
            {
                return GetComboBoxSortList();
            }

        }

        public virtual void Sort() {
            Load();
        }

        public abstract List<string> GetComboBoxSortList();



        private BaseCommand _FindCommand;

        public ICommand FindCommand
        {

            get
            {
                if (_FindCommand == null) _FindCommand = new BaseCommand(Find);
                return _FindCommand;
            }

        }

        public string FindField { get; set; }

        public string FindTextBox { get; set; }

        public List<string> FindComboBoxItems
        {

            get
            {
                return GetComboBoxFindList();
            }

        }

        public virtual void Find() {
            Load();
        }
        public abstract List<string> GetComboBoxFindList(); 

        #endregion


    }
}
