using Hangfire.Annotations;

namespace JobCode.Core.Entities
{
    public class UserCompany: BaseEntity
    {
        protected UserCompany() { }

        public UserCompany(int userId, int companyId)
        {
            UserId = userId;
            CompanyId = companyId;
        }

        public int UserId { get; private set; }

        [UsedImplicitly]
        public User? User { get; private set; }
        public int CompanyId { get; private set; }

        [UsedImplicitly]
        public Company? Company { get; private set; }
    }
}
