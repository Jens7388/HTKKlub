using HTKKlub.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
    }
}