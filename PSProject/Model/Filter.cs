using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace PSProject.Model
{
    public class Filter<T>
    {
        public static ObservableCollection<T> FilterEntitiesBasedOnAttributes(List<T> Entities, ObservableCollection<Attribute> SelectedAttributes)
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
                        if (!attrValue.Equals(propertyValue))
                        {
                            should_add_entity = false;
                        }
                    }
                }

                if (should_add_entity)
                    result.Add(entity);
            }

            return result;
        }

        private static object GetAttributeValue(Attribute attribute)
        {
            var converter = TypeDescriptor.GetConverter(attribute.AttributeType);
            var attrValue = converter.ConvertFrom(attribute.AttributeValue);

            return attrValue;
        }

        private static object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
