using HTKKlub.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class CourtViewModel: ViewModelBase
    {
        protected ObservableCollection<Court> courts;
        protected Court selectedCourt;

        public CourtViewModel()
        {
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
    }
}