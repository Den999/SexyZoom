namespace SexyZoom
{
    public class User
    {
        public string Name { get; private set; }
        
        public bool IsBadBoy => Karma <= 0;
        
        public int Karma { get; private set; }

        public void Punish()
        {
            Karma -= ZoomChat.KarmaPointsReducePerBadWord;
        }

        public User(string name, int karma)
        {
            Karma = karma;
            Name = name;
        }
    }
}