using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SexyZoom
{
    public class ZoomChat : Singleton<ZoomChat>
    {
        public const int KarmaPointsReducePerBadWord = -50;
        public const string BadWord = "Zoom";
        
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
            
            if (text.IndexOf(BadWord) != -1)
                foundUser.Punish();
            
            if (foundUser.IsBadBoy)
                return;

            messages.Add(new Message(foundUser.Name, text));
        }
        
        public void LoadMessages(string filename)
        {
            // .txt
            // write ivan hi
            // write tolya mama
            // write tolya zoom
            // write tolya hello - не будет
            
            // WriteMessage(userName, message);
        }

        public void SaveLog(string filename)
        {
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