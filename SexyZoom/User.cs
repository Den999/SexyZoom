namespace SexyZoom
{
    public class User
    {
        public string Name { get; private set; }
        
        public bool IsBadBoy => karma <= 0;
        
        private int karma;

        public void Punish()
        {
            karma -= ZoomChat.KarmaPointsReducePerBadWord;
        }

        public User(int karma, string name)
        {
            this.karma = karma;
            this.Name = name;
        }
    }
}