using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSProject.Model
{
    [Table("Cars")]
    public class Car : Entity
    {
        public String Make { get; set; }
        public String Model { get; set; }
        public String VehicleType { get; set; }
        public Int32 Year { get; set; }
        public Double EngineLitres { get; set; }
        public Int32 NumberOfDoors { get; set; }

        public Car()
        { }

        public Car(String Make, String Model, String VehicleType, Int32 Year, Double EngineLitres, Int32 NumberOfDoors)
        {
            this.Make = Make;
            this.Model = Model;
            this.VehicleType = VehicleType;
            this.Year = Year;
            this.EngineLitres = EngineLitres;
            this.NumberOfDoors = NumberOfDoors;
        }
    }
}
