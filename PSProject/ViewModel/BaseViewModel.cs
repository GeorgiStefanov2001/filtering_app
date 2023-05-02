using PSProject.Model;
using PSProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PSProject.ViewModel
{
    public abstract class BaseViewModel<T> : ObservableObject where T : Model.Entity 
    {
        private ObservableCollection<T> _filteredEntities;
        public ObservableCollection<T> FilteredEntities
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

        private ObservableCollection<Model.Attribute<T>> _attributes;
        public ObservableCollection<Model.Attribute<T>> Attributes
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


        private ObservableCollection<Model.Attribute<T>> _selectedAttributes;
        public ObservableCollection<Model.Attribute<T>> SelectedAttributes
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

        private List<T> Entities;

        protected BaseViewModel(List<T> entities){
            T entity = (T)Activator.CreateInstance(typeof(T));
            var attributesOfEntity = Model.Attribute<T>.GetAttributesOfEntity(entity);
            Attributes = new ObservableCollection<Model.Attribute<T>>(attributesOfEntity);
            SelectedAttributes = new ObservableCollection<Model.Attribute<T>>();

            Entities = entities;
        }

        public void AttrCheckedUnchecked()
        {
            Model.Attribute<T>.AttributeCheckedUnchecked(Attributes, SelectedAttributes);
        }

        public ICommand FilterCommand
        {
            get { return new DelegateCommand(FilterEntities); }
        }

        protected void FilterEntities()
        {
            //Default implementation
            try
            {
                //get the filtered entities
                FilteredEntities = Model.Filter<T>.FilterEntitiesBasedOnAttributes(Entities, SelectedAttributes);

                //open the search window
                SearchWindow searchWindow = new SearchWindow();
                searchWindow.DataContext = this;
                searchWindow.Title = typeof(T).Name + "s";
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

        protected void ClearFilters()
        {
            SelectedAttributes.Clear();
            Attributes = new ObservableCollection<Model.Attribute<T>>(Attributes.Select(x => { x.Checked = false; return x; }).Select(x=> { x.AttributeValue = ""; return x; }).ToList());
        }
    }
}
