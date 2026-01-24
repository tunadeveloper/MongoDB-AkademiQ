namespace MongoDB_AkademiQ.DTOs.AdminDTOs
{
    public class CreateAdminDTO
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
