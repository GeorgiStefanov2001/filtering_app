using PSProject.Model;
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

        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                RaisePropertyChangedEvent("Movies");
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
            MovieContext context = new MovieContext();
            Movies = new ObservableCollection<Movie>(context.Movies);

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
            //MessageBox.Show("TODO: Will filter movies");
            var value = Convert.ChangeType(SelectedAttributes[0].AttributeValue, SelectedAttributes[0].AttributeType);
            MessageBox.Show(SelectedAttributes[0].AttributeName + " " + value + " " + value.GetType());
        }

    }
}
