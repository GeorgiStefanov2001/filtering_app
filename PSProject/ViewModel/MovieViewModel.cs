using PSProject.Model;
using PSProject.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PSProject.ViewModel
{
    public class MovieViewModel : ObservableObject
    {

        private ObservableCollection<Movie> _filteredEntities;
        public ObservableCollection<Movie> FilteredEntities
        {
            get
            {
                return _filteredEntities;
            }
            set
            {
                _filteredEntities = value;
                RaisePropertyChangedEvent("FilteredEntities");
            }
        }

        private ObservableCollection<Model.Attribute<Movie>> _attributes;
        public ObservableCollection<Model.Attribute<Movie>> Attributes
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
                RaisePropertyChangedEvent("Attributes");
            }
        }

        
        private ObservableCollection<Model.Attribute<Movie>> _selectedAttributes;
        public ObservableCollection<Model.Attribute<Movie>> SelectedAttributes
        {
            get
            {
                return _selectedAttributes;
            }
            set
            {
                _selectedAttributes = value;
                RaisePropertyChangedEvent("SelectedAttributes");
            }
        }

        public MovieViewModel()
        {
            //get the attributes of the Movie
            var movieAttributes = Model.Attribute<Movie>.GetAttributesOfEntity(new Movie());
            Attributes = new ObservableCollection<Model.Attribute<Movie>>(movieAttributes);
            SelectedAttributes = new ObservableCollection<Model.Attribute<Movie>>();
        }


        public void AttrCheckedUnchecked()
        {
            Model.Attribute<Movie>.AttributeCheckedUnchecked(Attributes, SelectedAttributes);      
        }

        public ICommand FilterCommand
        {
            get { return new DelegateCommand(FilterMovies); }
        }

        public void FilterMovies()
        {
            try
            {
                //get the filtered entities
                var movies = new DatabaseManager().GetMovies();
                FilteredEntities = Model.Filter<Movie>.FilterEntitiesBasedOnAttributes(movies, SelectedAttributes);

                //open the search window
                SearchWindow searchWindow = new SearchWindow();
                searchWindow.DataContext = this;
                searchWindow.Title = "Movies";
                searchWindow.Show();
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public ICommand ClearFiltersCommand
        {
            get { return new DelegateCommand(ClearFilters); }
        }

        public void ClearFilters()
        {
            SelectedAttributes.Clear();
            Attributes = new ObservableCollection<Model.Attribute<Movie>>(Attributes.Select(x => { x.Checked = false; return x; }).ToList());
        }
    }
}
