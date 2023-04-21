using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PSProject.Model
{
    public class Attribute<T>
    {
        public String AttributeName { get; set; }

        public Boolean Checked { get; set; }

        public Type AttributeType { get; set; }

        public String AttributeValue { get; set; }

        public Boolean IsComparible { get; set; }

        //0 -> lower than
        //1 -> equals
        //2 -> greater than
        public Int32 ComparisonType { get; set; }

        public override string ToString()
        {
            return AttributeName;
        }

        public static List<Attribute<T>> GetAttributesOfEntity(T entity)
        {
            List<Attribute<T>> attributes = new List<Attribute<T>>();
            foreach (var property in entity.GetType().GetProperties())
            {
                if (!property.Name.Equals("Id"))
                {
                    var attr = new Model.Attribute<T>();
                    attr.AttributeName = property.Name;
                    attr.Checked = false;
                    attr.AttributeType = property.PropertyType;
                    attr.AttributeValue = "";
                    attr.IsComparible = (property.PropertyType == typeof(String)) ? false : true;
                    attr.ComparisonType = 1; //by default, 'equals'
                    attributes.Add(attr);
                }
            }

            return attributes;
        }

        public static void AttributeCheckedUnchecked(ObservableCollection<Attribute<T>> Attributes, ObservableCollection<Attribute<T>> SelectedAttributes)
        {
            foreach (var attribute in Attributes)
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
    }
}
