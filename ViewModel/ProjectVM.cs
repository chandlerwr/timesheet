using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timesheet.ViewModel {

    /// <summary>
    /// The view-model for a timesheet project.
    /// </summary>
    internal class ProjectVM : ObservableObject {

        private string _name;

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name {
            get => _name;
            set => SetProperty(ref _name, value);
        }

    }
}
