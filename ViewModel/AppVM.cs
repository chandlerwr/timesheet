using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timesheet.ViewModel {

    /// <summary>
    /// The view-model for the whole application.
    /// </summary>
    internal class AppVM : ObservableObject {

        private ObservableCollection<ProjectVM> _projects = new();
        private ProjectVM _project;

        public AppVM () {

            Projects = new(_projects);

            // 'entry' point
            // need to read settings, projects, etc.

        }

        #region Properties
        /// <summary>
        /// Timesheet projects.
        /// </summary>
        public ReadOnlyObservableCollection<ProjectVM> Projects { get; }

        /// <summary>
        /// The current selected project.
        /// </summary>
        public ProjectVM CurrentProject {
            get => _project;
            set => SetProperty(ref _project, value);
        }
        #endregion

        public void NewProject () {
            var newProject = new ProjectVM() { Name = $"Project {_projects.Count + 1}" };
            _projects.Add(newProject);
            CurrentProject = newProject;
        }

    }
}
