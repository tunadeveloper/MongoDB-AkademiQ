namespace MongoDB_AkademiQ.DTOs.AdminDTOs
{
    public class ResultAdminDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
