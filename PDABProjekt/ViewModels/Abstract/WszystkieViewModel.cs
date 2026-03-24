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
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {

        #region BazaDanych

        protected readonly PABProjektEntities kinoEntities;

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
            Messenger.Default.Send(DisplayName + "Add"); // ten messenger jest z mvvm light i wysyla on komunikat do MainWindowViewModel, która wywoła zakladke
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

        #region Konstruktor

        public WszystkieViewModel()
        {
            kinoEntities = new PABProjektEntities();

        }

        #endregion

        #region Sortowanie i szukanie

        private BaseCommand _SortCommand;

        public ICommand SortCommand
        {

            get
            {
                if (_SortCommand == null) _SortCommand = new BaseCommand(Sort);
                return _SortCommand;
            }

       
        }

        //to jest pole po czym sortowac
        public string SortField { get; set; }


        //to jest prop, do pobierania po czym bedziemy sortowac
        public List<string> SortComboBoxItems
        {

            get
            {
                return GetComboBoxSortList();
            }

        }

        public abstract void Sort(); // tu bedziemy decydowac jak sortowac

        public abstract List<string> GetComboBoxSortList(); // tu bedziemy decydowac po czym sortowac



        private BaseCommand _FindCommand;

        public ICommand FindCommand
        {

            get
            {
                if (_FindCommand == null) _FindCommand = new BaseCommand(Find);
                return _FindCommand;
            }

        }

        //to jest pole po czym sortowac
        public string FindField { get; set; }

        //to jest pole w ktorym zapisuje sie poczatek slowa wyszukiwanego
        public string FindTextBox { get; set; }

        //to jest prop, do pobierania po czym bedziemy wyszukiwac
        public List<string> FindComboBoxItems
        {

            get
            {
                return GetComboBoxFindList();
            }

        }

        public abstract void Find(); // tu bedziemy decydowac jak  szukamy
        public abstract List<string> GetComboBoxFindList(); // tu bedziemy decydowac po czym mozna filtrowac

        #endregion


    }
}
