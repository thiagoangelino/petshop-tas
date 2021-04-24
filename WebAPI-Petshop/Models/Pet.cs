namespace WebAPI_Petshop.Models
{
    public class Pet
    {
        public Pet(){}
        public Pet(int id, string name, string ownerName, string ownerAddress, string ownerPhone, string cause, int heaulthStatus, int accommodationPetId)
        {
            this.Id = id;
            this.Name = name;
            this.OwnerName = ownerName;
            this.OwnerAddress = ownerAddress;
            this.OwnerPhone = ownerPhone;
            this.Cause = cause;
            this.HeaulthStatus = heaulthStatus;
            this.AccommodationPetId = accommodationPetId;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPhone { get; set; }
        public string Cause { get; set; }
        public int HeaulthStatus { get; set; }
        public int AccommodationPetId { get; set; }
    }
}