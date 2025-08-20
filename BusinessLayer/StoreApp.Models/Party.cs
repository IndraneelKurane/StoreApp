using StoreApp.Models.Base;

namespace StoreApp.Models
{
    public class Party : BusinessModel<Party>
    {
        private string _name = string.Empty;
        private string _address = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _email = string.Empty;
        private DateTime _createdOn = DateTime.Now;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public DateTime CreatedOn
        {
            get => _createdOn;
            set => SetProperty(ref _createdOn, value);
        }


        public static implicit operator Party(Dal.Entities.PartyEntity entity)
        {
            if (entity == null) return null!;
            return new Party
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email
            };
        }
        public static implicit operator Dal.Entities.PartyEntity(Party party)
        {
            if (party == null) return null!;
            return new Dal.Entities.PartyEntity
            {
                Id = party.Id,
                Name = party.Name,
                Address = party.Address,
                PhoneNumber = party.PhoneNumber,
                Email = party.Email
            };
        }
    }
}
