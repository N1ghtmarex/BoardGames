namespace Domain.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Username { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        byte[] PasswordHash { get; set; }
        byte[] PasswordSalt { get; set; }
    }
}
