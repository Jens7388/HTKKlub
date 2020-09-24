using HTKKlub.Entities;
using HTKKlub.Services;
using HTKKlub.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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

        public override async Task LoadAllAsync()
        {
            try
            {
                RankingService service  = new RankingService();

                IEnumerable<Ranking> rankings = await service.GetAllAsync();

                Rankings.ReplaceWith(rankings);
            }
            catch
            {
                throw;
            }
        }
    }
}