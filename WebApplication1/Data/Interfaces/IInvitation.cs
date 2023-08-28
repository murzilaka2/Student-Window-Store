namespace WebApplication1.Data.Interfaces
{
    public interface IInvitation
    {
        IEnumerable<Invitation> Invitations { get; }
        Invitation GenerateInvitation();
        void DeleteInvitation(int id);
        void MakeUsed(string code);
    }
}
