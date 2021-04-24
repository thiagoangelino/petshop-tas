namespace WebAPI_Petshop.Models
{
    public class Accommodation
    {
        public Accommodation(){}
        public Accommodation(int id, string nomeAcommodation, int status, int petId)
        {
            this.Id = id;
            this.NomeAccommodation = nomeAcommodation;
            this.Status = status;
            this.PetId = petId;            
        }

        public int Id { get; set; }
        public string NomeAccommodation { get; set; }
        public int Status { get; set; }
        public int PetId { get; set; }
    
    }
}