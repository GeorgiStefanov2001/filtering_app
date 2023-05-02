using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSProject.Model
{
    [Table("Movies")]
    public class Movie : Entity
    {
        public String Title { get; set; }
        public String Genre { get; set; }
        public Int32 Length { get; set; }
        public String Director { get; set; }
        public Int32 YearReleased { get; set; }
        public Double Rating { get; set; }

        public Movie()
        { }

        public Movie(String Title, String Genre, Int32 Length, String Director, Int32 YearReleased, Double Rating)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Length = Length;
            this.Director = Director;
            this.YearReleased = YearReleased;
            this.Rating = Rating;
        }
    }
}
