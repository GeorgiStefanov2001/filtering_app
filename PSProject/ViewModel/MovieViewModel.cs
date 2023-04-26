using PSProject.Model;

namespace PSProject.ViewModel
{
    public class MovieViewModel : BaseViewModel<Movie>
    {
        public MovieViewModel() 
            : base(new DatabaseManager().GetMovies())
        { }

    }
}
