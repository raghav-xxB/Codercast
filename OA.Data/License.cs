namespace OA.Data
{
    public class License : Entity
    {
        public enum LicenseType { VIEWING, DOWANLOADING}
        private User user;
        private Codecast codecast;
        private LicenseType type;
        public License(LicenseType type, User user, Codecast codecast)
        {
            this.Type = type;
            this.User = user;
            this.Codecast = codecast;
        }

        public User User { get => user; set => user = value; }
        public Codecast Codecast { get => codecast; set => codecast = value; }
        public LicenseType Type { get => type; set => type = value; }
    }
}