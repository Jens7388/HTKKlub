using HTKKlub.DataAccess;
using HTKKlub.Desktop.Gui.ViewModels.Commands;
using HTKKlub.Entities;
using HTKKlub.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class CourtViewModel: ViewModelBase
    {
        protected string courtName;
        protected ObservableCollection<Court> courts;
        protected Court selectedCourt;
        protected RelayCommand<object> addCommand;
        protected RelayCommand<object> editCommand;
        protected RelayCommand<object> saveCommand;
        protected RelayCommand<object> deleteCommand;
        private bool currentlyAdding = false;

        public CourtViewModel()
        {
            AddCommand = new RelayCommand<object>(Add);
            EditCommand = new RelayCommand<object>(Edit, CanEdit);
            SaveCommand = new RelayCommand<object>(Save, CanSave);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);
            Courts = new ObservableCollection<Court>();
        }

        public virtual ObservableCollection<Court> Courts
        {
            get
            {
                return courts;
            }
            set
            {
                SetProperty(ref courts, value);
            }
        }

        public virtual Court SelectedCourt
        {
            get
            {
                return selectedCourt;
            }
            set
            {
                SetProperty(ref selectedCourt, value);
            }
        }

        public virtual string CourtName
        {
            get { return courtName; }
            set
            {
                SetProperty(ref courtName, value);
            }
        }

        /// <summary>
        /// Loads all courts from the repo
        /// </summary>
        /// <returns></returns>
        public override async Task LoadAllAsync()
        {
            try
            {
                CourtRepository repo = new CourtRepository();

                IEnumerable<Court> courts = await repo.GetAllAsync();

                Courts.ReplaceWith(courts);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Command for adding Members
        /// </summary>
        public virtual RelayCommand<object> AddCommand
        {
            get
            {
                return addCommand;
            }
            set
            {
                SetProperty(ref addCommand, value);
            }
        }

        /// <summary>
        /// Command for editing Members
        /// </summary>
        public virtual RelayCommand<object> EditCommand
        {
            get
            {
                return editCommand;
            }
            set
            {
                SetProperty(ref editCommand, value);
            }
        }


        /// <summary>
        /// Command for saving Members
        /// </summary>
        public virtual RelayCommand<object> SaveCommand
        {
            get
            {
                return saveCommand;
            }
            set
            {
                SetProperty(ref saveCommand, value);
            }
        }

        /// <summary>
        /// Command for deleting Members
        /// </summary>
        public virtual RelayCommand<object> DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                SetProperty(ref deleteCommand, value);
            }
        }

        /// <summary>
        /// Eventhandler for the Add button in the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Add(object parameter)
        {
            if(!currentlyAdding)
            {
                SelectedCourt = new Court();

                CourtName = SelectedCourt.CourtName;
                currentlyAdding = true;
            }
            else
            {
                SelectedCourt = null;
                CourtName = null;
                currentlyAdding = false;
            }
        }
        /// <summary>
        /// Validates if the edit button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanEdit(object parameter)
        {
            if(parameter is Court court && court.PkCourtId >= 1 && CourtName == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Eventhandler for the Edit button int the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void Edit(object parameter)
        {
            if(parameter is Court court)
            {
                CourtName = court.CourtName;
            }
        }

        /// <summary>
        /// Validates if the save button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanSave(object parameter)
        {
            if(currentlyAdding || parameter is Court)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected virtual async void Save(object parameter)
        {
            CourtRepository repo = new CourtRepository();

            if(parameter is Court court)
            {
                //Checks if you are saving an edit or a new court
                if(court.PkCourtId >= 1)
                {
                    try
                    {
                        SelectedCourt.CourtName = CourtName;
                        await repo.UpdateAsync();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        Court newCourt = new Court()
                        {
                            CourtName = CourtName,
                        };

                        await repo.AddAsync(newCourt);
                        Courts.Add(newCourt);
                        currentlyAdding = false;
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    // Reset values in the view
                    CourtName = null;              
                    // Get the listview of the items
                    ICollectionView view = CollectionViewSource.GetDefaultView(Courts);
                    // Refresh listview
                    view.Refresh();
                }
            }
        }
        /// <summary>
        /// Validates if the delete button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanDelete(object parameter)
        {
            if(parameter is Court court && court.PkCourtId >= 1 && CourtName != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Eventhandler for the delete button in the view
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual async void Delete(object parameter)
        {
            CourtRepository repo = new CourtRepository();
            try
            {
                await repo.DeleteAsync(SelectedCourt);
                Courts.Remove(SelectedCourt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Reset values in the view
            CourtName = null;
            // Get the listview of the items
            ICollectionView view = CollectionViewSource.GetDefaultView(Courts);
            // Refresh listview
            view.Refresh();
        }
    }
}