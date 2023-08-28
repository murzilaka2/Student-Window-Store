namespace WebApplication1.Data.Repository
{
    public class InvitationRepository : IInvitation
    {
        private readonly AppDbContext appDbContext;

        public InvitationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Invitation> Invitations => appDbContext.Invitation;

        public void DeleteInvitation(int id)
        {
            var currentInvitation = appDbContext.Invitation.FirstOrDefault(e => e.Id == id);
            if (currentInvitation != null)
            {
                appDbContext.Invitation.Remove(currentInvitation);
                appDbContext.SaveChanges();
            }
        }

        public Invitation GenerateInvitation()
        {
            Guid guid = Guid.NewGuid();
            string guidStr = guid.ToString();
            var currentInvitation = new Invitation
            {
                IsUsed = false,
                Href = "/auth/register?code=" + guidStr,
                Code = guidStr,
                GeneratedDate = DateTime.Now
            };
            appDbContext.Invitation.Add(currentInvitation);
            appDbContext.SaveChanges();
            return currentInvitation;
        }
        public void MakeUsed(string code)
        {
            var currentCode = appDbContext.Invitation.FirstOrDefault(e => e.Code.Equals(code));
            if (currentCode != null)
            {
                currentCode.IsUsed = true;
                appDbContext.Invitation.Update(currentCode);
                appDbContext.SaveChanges();
            }
        }
    }
}
