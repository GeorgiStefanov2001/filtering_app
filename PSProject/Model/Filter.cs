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
                        var converter = TypeDescriptor.GetConverter(attr.AttributeType);
                        var attrValue = converter.ConvertFrom(attr.AttributeValue);
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
    }
}
