using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public abstract class ViewModelBase: BindableBase
    {
        /// <summary>
        /// Loads data from the database
        /// </summary>
        public virtual Task LoadAllAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Runs the <see cref="LoadAllAsync"/> method
        /// </summary>
        /// <returns></returns>
        public virtual async Task InitializeAsync()
        {
            try
            {
                await LoadAllAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}