using System;
using System.Collections.Generic;
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
    }
}
