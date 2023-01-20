using System;

namespace System
{
    class Zadanie1
    {
        public static Collections.Generic.SortedDictionary<String, Int32> UserTime = new Collections.Generic.SortedDictionary<String, Int32>();
        public static Collections.Generic.SortedDictionary<String, Collections.Generic.SortedSet<String>> UserIPs = new Collections.Generic.SortedDictionary<String, Collections.Generic.SortedSet<String>>();
        public static void Main()
        {
            //Get num of lines
            int numOfEntries = int.Parse(Console.ReadLine());

            //Read all incoming data
            for (int i = 0; i < numOfEntries; i++)
            {
                //Get and split input
                string[] input = Console.ReadLine().Split(' ');

                //Test if users was already added and act accordingly
                if (UserTime.ContainsKey(input[1])) //Existing user
                {
                    //Time
                    UserTime[input[1]] = UserTime[input[1]] + int.Parse(input[2]);

                    //IPs
                    UserIPs[input[1]].Add(input[0]);
                }
                else //New user
                {
                    //Time
                    UserTime.Add(input[1], int.Parse(input[2]));

                    //IPs
                    Collections.Generic.SortedSet<String> newSet = new Collections.Generic.SortedSet<String>();
                    newSet.Add(input[0]);
                    UserIPs.Add(input[1], newSet);
                }
            }

            //Display data
            foreach (var user in UserTime)
            {
                //Time
                Console.Write(String.Format("{0}: {1} ", user.Key, user.Value));

                //IPs
                string IPs = "";
                foreach (var ip in UserIPs[user.Key])
                {
                    if (IPs == "")
                        IPs = String.Format("[{0}", ip);
                    else
                        IPs = String.Format("{0}, {1}", IPs, ip);
                }
                IPs = String.Format("{0}]", IPs);
                Console.Write(IPs);

                //Go next line
                Console.WriteLine();
            }
        }
    }
}