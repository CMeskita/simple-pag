using simple_pag_Domain.Shared.Notificacao;

namespace simple_pag_Domain
{
    public class BusinessException:Exception
    {
        public Notify Notifications { get; protected set; }

        public BusinessException(string message) : base(message)
        {
            Notifications = new();
            Notifications.Add(message);
        }
        public BusinessException(string message, Notify notification) : base(message)
        {
            Notifications = notification;
        }

        public override string Message => Notifications.ToString();
    }
}
