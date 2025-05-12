using System;

namespace NotificationService
{
    /// <summary>
    /// Interface that defines the contract for sending messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Sends a message to the specified recipient.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="recipient">The recipient's contact information (phone number or email).</param>
        void SendMessage(string message, string recipient);
    }

    /// <summary>
    /// Implementation of the IMessageService to send messages via SMS.
    /// </summary>
    public class SmsSender : IMessageService
    {
        /// <summary>
        /// Sends an SMS message to the given phone number.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="phoneNumber">The recipient's phone number.</param>
        public void SendMessage(string message, string phoneNumber)
        {
            // Configuring SMS service here (e.g., using a third-party API).
            Console.WriteLine($"{message} has been sent to {phoneNumber} via SMS.");
        }
    }

    /// <summary>
    /// A class responsible for notifying recipients using a message service.
    /// </summary>
    public class Alert
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// Initializes a new instance of the Alert class with the specified message service.
        /// </summary>
        /// <param name="messageService">The message service to be used for sending notifications.</param>
        public Alert(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        /// <summary>
        /// Sends a notification to the recipient with the given message.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="recipient">The recipient's phone number or email.</param>
        public void Notify(string message, string recipient)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("Message cannot be empty", nameof(message));
            if (string.IsNullOrEmpty(recipient)) throw new ArgumentException("Recipient cannot be empty", nameof(recipient));

            _messageService.SendMessage(message, recipient);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Choose the service (could be SmsSender, EmailSender, etc.)
            IMessageService messageService = new SmsSender();

            // Create the Alert instance with the chosen message service.
            Alert alert = new Alert(messageService);

            // Send a notification (SMS in this case).
            alert.Notify("Hello, this is your verification code", "0933873...");

            // You could easily switch to another service here by changing `messageService`.
            // E.g., for email: IMessageService messageService = new EmailSender();
        }
    }
}
using System;

namespace NotificationService
{
    /// <summary>
    /// Interface that defines the contract for sending messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Sends a message to the specified recipient.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="recipient">The recipient's contact information (phone number or email).</param>
        void SendMessage(string message, string recipient);
    }

    /// <summary>
    /// Implementation of the IMessageService to send messages via SMS.
    /// </summary>
    public class SmsSender : IMessageService
    {
        /// <summary>
        /// Sends an SMS message to the given phone number.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="phoneNumber">The recipient's phone number.</param>
        public void SendMessage(string message, string phoneNumber)
        {
            // Configuring SMS service here (e.g., using a third-party API).
            Console.WriteLine($"{message} has been sent to {phoneNumber} via SMS.");
        }
    }

    /// <summary>
    /// A class responsible for notifying recipients using a message service.
    /// </summary>
    public class Alert
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// Initializes a new instance of the Alert class with the specified message service.
        /// </summary>
        /// <param name="messageService">The message service to be used for sending notifications.</param>
        public Alert(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        /// <summary>
        /// Sends a notification to the recipient with the given message.
        /// </summary>
        /// <param name="message">The message content to be sent.</param>
        /// <param name="recipient">The recipient's phone number or email.</param>
        public void Notify(string message, string recipient)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("Message cannot be empty", nameof(message));
            if (string.IsNullOrEmpty(recipient)) throw new ArgumentException("Recipient cannot be empty", nameof(recipient));

            _messageService.SendMessage(message, recipient);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Choose the service (could be SmsSender, EmailSender, etc.)
            IMessageService messageService = new SmsSender();

            // Create the Alert instance with the chosen message service.
            Alert alert = new Alert(messageService);

            // Send a notification (SMS in this case).
            alert.Notify("Hello, this is your verification code", "0933873...");

            // You could easily switch to another service here by changing `messageService`.
            // E.g., for email: IMessageService messageService = new EmailSender();
        }
    }
}
