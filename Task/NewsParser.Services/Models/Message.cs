namespace NewsParser.Services.Models
{
    public class Message
    {
        public Message(string email, string text)
        {
            Email = email;
            Text = text;
        }

        public string Email { get; set; }

        public string Text { get; set; }
    }
}
