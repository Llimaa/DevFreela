namespace DevFreela.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public UserRole(int idUser, string role)
        {
            IdUser = idUser;
            Role = role;
        }

        public int IdUser { get; private set; }
        public string Role { get; private set; }
        public User User { get; private set; }
    }
}
