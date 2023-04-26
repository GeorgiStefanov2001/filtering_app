using PSProject.Model;

namespace PSProject.ViewModel
{
    public class CarViewModel : BaseViewModel<Car>
    {
        public CarViewModel()
             : base(new DatabaseManager().GetCars())
        { }
    }
}
