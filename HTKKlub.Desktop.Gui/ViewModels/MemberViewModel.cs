using HTKKlub.DataAccess;
using HTKKlub.Entities;
using HTKKlub.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class MemberViewModel: ViewModelBase
    {
        protected ObservableCollection<Member> members;
        protected Member selectedMember;

        public MemberViewModel()
        {
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
    }
}