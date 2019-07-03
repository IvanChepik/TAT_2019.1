namespace Pages
{
    /// <summary>
    /// interface ILogining
    /// define common method for all login page
    /// </summary>
    public interface ILogining
    {
        bool Login(string email, string password);
    }
}