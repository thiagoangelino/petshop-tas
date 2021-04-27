namespace WebAPI_Petshop.Models
{
    public class Accommodation
    {
        public Accommodation(){}
        public Accommodation(int id, string acommodationName, int accommodationState, int petId)
        {
            this.Id = id;
            this.AccommodationName = acommodationName;
            this.AccommodationState = accommodationState;
            this.PetId = petId;            
        }

        public int Id { get; set; }
        public string AccommodationName { get; set; }
        public int AccommodationState { get; set; }
        public int PetId { get; set; }
    
    }
}