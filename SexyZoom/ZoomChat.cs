using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using static System.Text.Json.JsonSerializer;


namespace SexyZoom
{
    public class ZoomChat : Singleton<ZoomChat>
    {
        public const int KarmaPointsReducePerBadWord = 50;
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

        private void AddMessage(string userName, string messageText)
        {
            User user = null;
            foreach (User u in users)
            {
                if (u.Name == userName)
                    user = u;
            }

            if (user == null)
            {
                Console.WriteLine($"ERROR: User: {userName} not found!");
                return;
            }

            string badWord = "";
            foreach (var barWord in BadWords)
            {
                if (messageText.ToLower().IndexOf(barWord.ToLower()) != -1)
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
                Console.WriteLine($"User: {user.Name} message: {messageText} is muted cuz his karma is {user.Karma} <= 0.");
            }

            if (user.IsBadBoy || badWord != "")
                return;

            messages.Add(new Message(user.Name, messageText));
        }
        
        public void LoadMessages(string filename)
        {
            string[] raw = File.ReadAllLines(filename);

            foreach(string line in raw)
            {
                var words = line.Split();
                AddMessage(words[0], words[1]);
            }
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
            var text = File.ReadAllText(filename);
            BadWords = JsonConvert.DeserializeObject<List<string>>(text);
        }

        public void SaveBadWords(string filename)
        {
            string data = Serialize(BadWords);
            File.WriteAllText(filename, data);
        }

        public void SaveLog(string filename)
        {
            string log ="";

            foreach (Message message in messages)
            {
                log += message.Textify()+"\n";
            }

            File.WriteAllText(filename, log);

            // ivan: hi
            // tolya: mama
        }

        public void SaveUsers(string filename)
        {
            string data = Serialize(users);
            File.WriteAllText(filename, data);
        }

        public void LoadUsers(string filename)
        {
            var text = File.ReadAllText(filename);
            users = JsonConvert.DeserializeObject<List<User>>(text);
        }
        
        // ...
    }
}