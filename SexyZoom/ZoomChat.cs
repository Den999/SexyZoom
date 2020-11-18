using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SexyZoom
{
    public class ZoomChat : Singleton<ZoomChat>
    {
        public const int KarmaPointsReducePerBadWord = -50;
        private List<string> BadWords = new List<string>{"Zoom", "Fuck"};
        
        private List<User> users = new List<User>();
        private List<Message> messages = new List<Message>();

        public void AddUser(User newUser)
        {
            if (newUser == null)
            {
                Console.WriteLine("ERROR: User is null!");
                return;
            }
            users.Add(newUser);
        }

        public void WriteMessage(string userName, string text)
        {
            User user = null;
            foreach (User u in users)
            {
                if (u.Name == userName)
                    user = u;
            }

            if (user == null)
            {
                Console.WriteLine("ERROR: User not found!");
                return;
            }

            string badWord = "";
            foreach (var barWord in BadWords)
            {
                if (text.ToLower().IndexOf(barWord.ToLower()) != -1)
                {
                    badWord = barWord;
                    user.Punish();
                    break;
                }
            }

            if (badWord != "")
            {
                Console.WriteLine($"User: {user.Name} sayed: {badWord} - it is a bad word. His karma now: {user.Karma}");
            }

            if (user.IsBadBoy)
            {
                Console.WriteLine($"User: {user.Name} message: {messages} is muted cuz his karma is {user.Karma} <= 0.");
            }

            if (user.IsBadBoy || badWord != "")
                return;

            messages.Add(new Message(user.Name, text));
        }
        
        public void LoadMessages(string filename)
        {
            // .txt
            // ivan hi
            // tolya mama
            // tolya zoom
            // tolya zoom
            // tolya hello - не будет
            
            // WriteMessage(userName, message);
        }

        public void AddBadWord(string newBadWord)
        {
            if (newBadWord == "")
            {
                Console.WriteLine("ERROR: U trying to add empty bad word!");
                return;
            }
            
            BadWords.Add(newBadWord);
        }

        public void LoadBadWords(string filename)
        {
            
        }

        public void SaveBadWords(string filename)
        {
            
        }

        public void SaveLog(string filename)
        {
            foreach (Message message in messages)
            {
                // message.Textify();
            }

            // ivan: hi
            // tolya: mama
        }

        public void SaveUsers(string filename)
        {
            // new JsonDocument(user);
            // json dictionary users
        }

        public void LoadUsers(string filename)
        {
            // users = loadFromJson();
            // json dictionary users
        }
    }
}