namespace SexyZoom
{
    public class Message
    {
        private string userName;
        private string messageText;

        public Message(string userName, string messageText)
        {
            this.userName = userName;
            this.messageText = messageText;
        }

        public string Textify()
        {
            return $"{userName}: {messageText}";
        }
    }
}