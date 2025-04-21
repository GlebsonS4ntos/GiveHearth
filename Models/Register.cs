namespace GiveHearth.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf {  get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
