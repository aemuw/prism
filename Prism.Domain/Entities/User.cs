using Prism.Domain.Enums;

namespace Prism.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRole Role { get; private set; }
        public bool IsEmailVerified { get; private set; }

        public string? VerificationCode { get; private set; }
        public DateTime? VerificationExpiry { get; private set; }

        public string? RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpiry { get; private set; }

        public ICollection<UserSource> Sources { get; private set; } = new List<UserSource>();
        public ICollection<SavedArticle> SavedArticles { get; private set; } = new List<SavedArticle>();

        public User(string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = UserRole.User;
            IsEmailVerified = false;
        }

        public bool VerifyEmail(string code)
        {
            if (VerificationCode != code || VerificationExpiry < DateTime.UtcNow)
                return false;

            IsEmailVerified = true;
            VerificationCode = null;
            VerificationExpiry = null;
            UpdateTimestamp();
            return true;
        }

        public void SetRefreshToken(string token, DateTime expiry)
        {
            RefreshToken = token;
            RefreshTokenExpiry = expiry;
            UpdateTimestamp();
        }

        public void SetVerificationCode(string code, DateTime expiry)
        {
            VerificationCode = code;
            VerificationExpiry = expiry;
            UpdateTimestamp();
        }

        public void RevokeRefreshToken()
        {
            RefreshToken = null;
            RefreshTokenExpiry = null;
            UpdateTimestamp();
        }

        public void UpdateProfile(string username)
        {
            Username = username;
            UpdateTimestamp();
        }
    }
}
