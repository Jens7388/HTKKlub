using HTKKlub.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class RankingViewModel : ViewModelBase
    {
        protected ObservableCollection<Ranking> rankings;
        protected Ranking selectedRanking;

        public RankingViewModel()
        {
            Rankings = new ObservableCollection<Ranking>();
        }

        public virtual ObservableCollection<Ranking> Rankings
        {
            get
            {
                return rankings;
            }
            set
            {
                SetProperty(ref rankings, value);
            }
        }

        public virtual Ranking SelectedRanking
        {
            get
            {
                return selectedRanking;
            }
            set
            {
                SetProperty(ref selectedRanking, value);
            }
        }
    }
}