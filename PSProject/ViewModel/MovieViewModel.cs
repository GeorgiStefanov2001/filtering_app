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
    public class MovieViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                PropChanged("Movies");
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
                PropChanged("Attributes");
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
                PropChanged("SelectedAttributes");
            }
        }


        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public MovieViewModel()
        {
            MovieContext context = new MovieContext();
            Movies = new ObservableCollection<Movie>(context.Movies);

            //get the attributes of the Movie as a collection of strings
            Attributes = new ObservableCollection<Model.Attribute>(GetMovieAttributes());
            SelectedAttributes = new ObservableCollection<Model.Attribute>();
        }

        private List<Model.Attribute> GetMovieAttributes()
        {
            Movie movie = new Movie();
            List<Model.Attribute> attributes = new List<Model.Attribute>();
            foreach(var property in movie.GetType().GetProperties())
            {
                if (!property.Name.Equals("Id"))
                {
                    Model.Attribute attr = new Model.Attribute();
                    attr.AttributeName = property.Name;
                    attr.Checked = false;
                    attr.AttributeType = property.PropertyType;
                    attr.AttributeValue = "";
                    attributes.Add(attr);
                }
            }

            return attributes;
        }

        public void AttrCheckedUnchecked()
        {
            foreach(var attribute in Attributes)
            {

                if (attribute.Checked)
                {
                    if (!SelectedAttributes.Contains(attribute))
                    {
                        SelectedAttributes.Add(attribute);
                    }
                }
                else if (SelectedAttributes.Contains(attribute))
                {
                    SelectedAttributes.Remove(attribute);
                }
            }
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
