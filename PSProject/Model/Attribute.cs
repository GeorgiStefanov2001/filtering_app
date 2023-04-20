using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PSProject.Model
{
    public class Attribute
    {
        public String AttributeName { get; set; }
        public Boolean Checked { get; set; }

        public Type AttributeType { get; set; }

        public String AttributeValue { get; set; }

        public override string ToString()
        {
            return AttributeName;
        }

        public static List<Attribute> GetAttributesOfEntity(Entity entity)
        {
            List<Attribute> attributes = new List<Attribute>();
            foreach (var property in entity.GetType().GetProperties())
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

        public static void AttributeCheckedUnchecked(ObservableCollection<Attribute> Attributes, ObservableCollection<Attribute> SelectedAttributes)
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
