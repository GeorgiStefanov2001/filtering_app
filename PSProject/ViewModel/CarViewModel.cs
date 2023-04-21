using PSProject.Model;
using PSProject.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PSProject.ViewModel
{
    public class CarViewModel : ObservableObject
    {

        private ObservableCollection<Car> _filteredEntities;
        public ObservableCollection<Car> FilteredEntities
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

        private ObservableCollection<Model.Attribute<Car>> _attributes;
        public ObservableCollection<Model.Attribute<Car>> Attributes
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


        private ObservableCollection<Model.Attribute<Car>> _selectedAttributes;
        public ObservableCollection<Model.Attribute<Car>> SelectedAttributes
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

        public CarViewModel()
        {
            //get the attributes of the Car
            var carAttributes = Model.Attribute<Car>.GetAttributesOfEntity(new Car());
            Attributes = new ObservableCollection<Model.Attribute<Car>>(carAttributes);
            SelectedAttributes = new ObservableCollection<Model.Attribute<Car>>();
        }


        public void AttrCheckedUnchecked()
        {
            Model.Attribute<Car>.AttributeCheckedUnchecked(Attributes, SelectedAttributes);
        }

        public ICommand FilterCommand
        {
            get { return new DelegateCommand(FilterCars); }
        }

        public void FilterCars()
        {
            try
            {
                //get the filtered entities
                var cars = new DatabaseManager().GetCars();
                FilteredEntities = Model.Filter<Car>.FilterEntitiesBasedOnAttributes(cars, SelectedAttributes);

                //open the search window
                SearchWindow searchWindow = new SearchWindow();
                searchWindow.DataContext = this;
                searchWindow.Title = "Cars";
                searchWindow.Show();
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
