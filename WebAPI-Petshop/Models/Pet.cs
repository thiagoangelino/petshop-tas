namespace WebAPI_Petshop.Models
{
    public class Pet
    {
        public Pet(){}
        public Pet(int petId, string petName, string petOwnerName, 
                    string petOwnerAddress, string petOwnerPhone, string petCause, 
                    int petHeaulthStatus, int accommodationId)
        {
            this.PetId = petId;
            this.PetName = petName;
            this.PetOwnerName = petOwnerName;
            this.PetOwnerAddress = petOwnerAddress;
            this.PetOwnerPhone = petOwnerPhone;
            this.PetCause = petCause;
            this.PetHeaulthState = petHeaulthStatus;
            this.AccommodationId = accommodationId;

        }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetOwnerName { get; set; }
        public string PetOwnerAddress { get; set; }
        public string PetOwnerPhone { get; set; }
        public string PetCause { get; set; }
        public int PetHeaulthState { get; set; }
        public int AccommodationId { get; set; }
    }
}