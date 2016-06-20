using System.Collections.Generic;
namespace WebApp.Models
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            PhoneViewModel = new List<PhoneViewModel>();
        }

        public PeopleViewModel PeopleViewModel { get; set; }
        public AddressViewModel AddressViewModel { get; set;  }
        public ICollection<PhoneViewModel> PhoneViewModel { get; set; }
    }
}