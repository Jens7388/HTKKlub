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
using System.Windows.Controls;
using System.Windows.Data;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class MemberViewModel: ViewModelBase
    {
        protected string name;
        protected string address;
        protected string email;
        protected string phoneNumber;
        protected DateTime birthDate;
        protected RelayCommand<object> addCommand;
        protected RelayCommand<object> editCommand;
        protected RelayCommand<object> saveCommand;
        protected RelayCommand<object> deleteCommand;
        private bool currentlyAdding = false;

        protected ObservableCollection<Member> members;
        protected Member selectedMember;

        public MemberViewModel()
        {
            AddCommand = new RelayCommand<object>(Add);
            EditCommand = new RelayCommand<object>(Edit, CanEdit);
            SaveCommand = new RelayCommand<object>(Save, CanSave);
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);
            Members = new ObservableCollection<Member>();
        }

        public virtual ObservableCollection<Member> Members
        {
            get
            {
                return members;
            }
            set
            {
                SetProperty(ref members, value);
            }
        }

        public virtual Member SelectedMember
        {
            get
            {
                return selectedMember;
            }
            set
            {
                SetProperty(ref selectedMember, value);
            }
        }

        /// <summary>
        /// Name TextBox in the view
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        /// <summary>
        /// Address TextBox in the view
        /// </summary>
        public virtual string Address
        {
            get { return address; }
            set
            {
                SetProperty(ref address, value);
            }
        }

        /// <summary>
        /// Email TextBox in the view
        /// </summary>
        public virtual string Email
        {
            get { return email; }
            set
            {
                SetProperty(ref email, value);
            }
        }

        /// <summary>
        /// Phonenumber TextBox in the view
        /// </summary>
        public virtual string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                SetProperty(ref phoneNumber, value);
            }
        }

        /// <summary>
        /// Birthdate DatePicker in the view
        /// </summary>
        public virtual DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                SetProperty(ref birthDate, value);
            }
        }

        /// <summary>
        /// Loads alle members from the repo
        /// </summary>
        /// <returns></returns>
        public override async Task LoadAllAsync()
        {
            try
            {
                MemberRepository repo = new MemberRepository();

                IEnumerable<Member> members = await repo.GetAllAsync();

                Members.ReplaceWith(members);
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
        /// Validates if the save button can be pressed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected virtual bool CanSave(object parameter)
        {
            if(parameter is Member && Name != null)
            {
                return true;
            }
            else
            {
                return false;
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
                SelectedMember = new Member() { BirthDate = DateTime.Now };

                Name = SelectedMember.Name;
                Address = SelectedMember.Address;
                Email = SelectedMember.Email;
                PhoneNumber = SelectedMember.PhoneNumber;
                BirthDate = SelectedMember.BirthDate;
                currentlyAdding = true;
            }
            else
            {
                SelectedMember = null;
                Name = null;
                Address = null;
                Email = null;
                PhoneNumber = null;
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
            if(parameter is Member member && member.PkMemberId >= 1 && Name == null)
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
            if(parameter is Member member)
            {
                Name = member.Name;
                Address = member.Address;
                Email = member.Email;
                PhoneNumber = member.PhoneNumber;
                BirthDate = member.BirthDate;
            }
        }

        protected virtual async void Save(object parameter)
        {
            MemberRepository repo = new MemberRepository();

            if(parameter is Member member)
            {
                //Checks if you are saving an edit or a new member
                if(member.PkMemberId >= 1)
                {
                    try
                    {
                        SelectedMember.Name = Name;
                        SelectedMember.Address = Address;
                        SelectedMember.Email = Email;
                        SelectedMember.PhoneNumber = PhoneNumber;
                        SelectedMember.BirthDate = BirthDate;

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
                        Member newMember = new Member()
                        {
                            Name = Name,
                            Address = Address,
                            Email = Email,
                            PhoneNumber = PhoneNumber,
                            BirthDate = BirthDate,
                        };

                        await repo.AddAsync(newMember);
                        Members.Add(newMember);
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    // Reset values in the view
                    Name = null;
                    Address = null;
                    Email = null;
                    PhoneNumber = null;
                    BirthDate = DateTime.Now;

                    // Get the listview of the items
                    ICollectionView view = CollectionViewSource.GetDefaultView(Members);
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
            if(parameter is Member member && member.PkMemberId >= 1 && Name != null)
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
            MemberRepository repo = new MemberRepository();
            try
            {
                await repo.DeleteAsync(SelectedMember);
                Members.Remove(SelectedMember);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Reset values in the view
            Name = null;
            Address = null;
            Email = null;
            PhoneNumber = null;
            BirthDate = DateTime.Now;

            // Get the listview of the items
            ICollectionView view = CollectionViewSource.GetDefaultView(Members);
            // Refresh listview
            view.Refresh();
        }
    }
}