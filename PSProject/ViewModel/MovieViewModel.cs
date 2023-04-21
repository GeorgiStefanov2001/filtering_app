using PSProject.Model;
using PSProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

        private ObservableCollection<Model.Attribute> _attributes;
        public ObservableCollection<Model.Attribute> Attributes
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

        
        private ObservableCollection<Model.Attribute> _selectedAttributes;
        public ObservableCollection<Model.Attribute> SelectedAttributes
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
            Attributes = new ObservableCollection<Model.Attribute>(Model.Attribute.GetAttributesOfEntity(new Movie()));
            SelectedAttributes = new ObservableCollection<Model.Attribute>();
        }


        public void AttrCheckedUnchecked()
        {
            Model.Attribute.AttributeCheckedUnchecked(Attributes, SelectedAttributes);      
        }

        public ICommand FilterCommand
        {
            get { return new DelegateCommand(FilterMovies); }
        }

        public void FilterMovies()
        {
            try
            {
                var movies_from_db = new MovieContext().Movies.ToList<Movie>();
                FilteredEntities = Model.Filter<Movie>.FilterEntitiesBasedOnAttributes(movies_from_db, SelectedAttributes);
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
    }
}
