using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSProject.Model
{
    [Table("Movies")]
    public class Movie
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Genre { get; set; }
        public Int32 Length { get; set; }
        public String Director { get; set; }
        public Int32 YearReleased { get; set; }
        public Double Rating { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
