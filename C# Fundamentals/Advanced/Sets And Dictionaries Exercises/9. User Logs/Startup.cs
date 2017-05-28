using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.User_Logs
{
    class Startup
    {
        static void Main(string[] args)
        {
            // IP={IP.Address} message=’{A&sample&message}’ user={username}
            // IP=192.23.30.40 message='Hello&derps.' user=destroyer
            var input = Console.ReadLine();
            var messageDict = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var arrayData = input.Split(' ');
                var ipDataSplit = arrayData[0].Split('=');
                var messageDaSplit = arrayData[1].Split('=');
                var userDaSplit = arrayData[2].Split('=');
                var ip = ipDataSplit[1];
                var message = messageDaSplit[1];
                var user = userDaSplit[1];

                if (!messageDict.ContainsKey(user))
                {
                    messageDict.Add(user, new Dictionary<string, int>());
                   continue;
                }
                if (messageDict[user].ContainsKey(ip))
                {
                    messageDict[user][ip]++;
                }
                else
                {
                    messageDict[user].Add(ip, 1);
                }


                input = Console.ReadLine();
            }

            foreach (var msg in messageDict)
            {
                Console.WriteLine($"{msg.Key}: ");
                foreach (var ip in msg.Value)
                {
                    if (ip.Key != msg.Value.Keys.Last())
                    {
					    Console.Write($"{ip.Key} => {ip.Value}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{ip.Key} => {ip.Value}.");
                    }
                }
            }
        }
    }
}
