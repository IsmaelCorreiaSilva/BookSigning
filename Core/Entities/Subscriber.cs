

namespace Core.Entities
{
    public class Subscriber
    {
        public Subscriber(string name, string email, string phone, Address address) 
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public Subscriber(int id, string name, string email, string phone, Address address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public int Id { get; private set; }
        public string Name { get; private set; } 
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Address Address { get; private set; }
    }
}
