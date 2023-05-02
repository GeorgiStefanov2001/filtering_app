using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PSProject.Model
{
    public class Filter<T> where T : Model.Entity
    {
        public static ObservableCollection<T> FilterEntitiesBasedOnAttributes(List<T> Entities, ObservableCollection<Attribute<T>> SelectedAttributes)
        {
            //firstly, verify that all selected attributes have a value
            List<string> missingValues = new List<string>();
            foreach(var attr in SelectedAttributes)
            {
                if (attr.AttributeValue=="") //param comes as String from the XAML textbox
                {
                    missingValues.Add(attr.AttributeName);
                }
            }

            if(missingValues.Count != 0)
            {
                throw new ArgumentException("Enter a value for attribute(s): " + String.Join(", ", missingValues) + ".");
            }

            ObservableCollection<T> result = new ObservableCollection<T>();

            foreach (var entity in Entities)
            {
                bool should_add_entity = true;
                foreach (var attr in SelectedAttributes)
                {
                    var property = entity.GetType().GetProperty(attr.AttributeName);
                    var propertyValue = property.GetValue(entity, null);
                    
                    if (propertyValue != null)
                    {
                        var attrValue = GetAttributeValue(attr);

                        if (attr.ComparisonType == 3)
                        {
                            //Contains
                            if(!propertyValue.ToString().ToLower().Contains(attrValue.ToString().ToLower()))
                            {
                                should_add_entity = false;
                            }
                        }
                        else
                        {
                            var compResult = (propertyValue as IComparable).CompareTo(attrValue as IComparable);
                            if (compResult != (attr.ComparisonType - 1)) // take a look at ComparisonType in the Attribute class
                            {
                                should_add_entity = false;
                            }
                        }
                    }
                }

                if (should_add_entity)
                    result.Add(entity);
            }

            return result;
        }

        private static object GetAttributeValue(Attribute<T> attribute)
        {
            var converter = TypeDescriptor.GetConverter(attribute.AttributeType);
            var attrValue = converter.ConvertFrom(attribute.AttributeValue);

            return attrValue;
        }
    }
}
