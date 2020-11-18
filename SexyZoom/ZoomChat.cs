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

        public void WriteMessage(string userName, string text)
        {
            User foundUser = null;
            foreach (User user in users)
            {
                if (user.Name == userName)
                    foundUser = user;
            }

            if (foundUser == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            
            foreach (var barWord in BadWords)
            {
                if (text.IndexOf(barWord) != -1)
                    foundUser.Punish();
            }

            if (foundUser.IsBadBoy)
                return;

            messages.Add(new Message(foundUser.Name, text));
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