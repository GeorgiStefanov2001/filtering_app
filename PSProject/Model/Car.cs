using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSProject.Model
{
    [Table("Cars")]
    public class Car : Entity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public Int32 Id { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String VehicleType { get; set; }
        public Int32 Year { get; set; }
        public Double EngineLitres { get; set; }
        public Int32 NumberOfDoors { get; set; }
    }
}
