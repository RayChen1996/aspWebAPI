namespace sideprjWebApi
{
    public class UserRepository
    {
        private List<User> users = new();

        public User? GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
