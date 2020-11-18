using System;

namespace SexyZoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var chat = ZoomChat.Instance;
            
            // Variant 1
            chat.AddUser(new User("misha", 100));
            chat.AddUser(new User("rob", 50));
            // Variant 2
            chat.LoadUsers("users.json");
            
            // Variant 1
            chat.AddBadWord("kek");
            chat.AddBadWord("lol");
            // Variant 2
            chat.LoadBadWords("bads.json");
            
            chat.LoadMessages("chat.txt");
            
            chat.SaveLog("censored.txt");
            chat.SaveUsers("users.json");
        }
    }
}
