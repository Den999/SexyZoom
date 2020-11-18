using System;

namespace SexyZoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var chat = ZoomChat.Instance;
            chat.LoadUsers("user.json");
            chat.LoadMessages("chat.txt");
            
            chat.SaveLog("censored.txt");
            chat.SaveUsers("users.json");
        }
    }
}
