using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace labwork3
{
    public static class DataProvider
    {
        const string DataDir = @"D:\A_Labs\2\Tech\Lab_3\labwork3\";

        public class Room
        {
            public int number_of_room { get; set; }

            public int floor { get; set; }

            public int spots_in_room { get; set; }

            public string daily_fee { get; set; }
        }

        public class Client
        {
            public string surname { get; set; }

            public int number_of_room { get; set; }

            public string check_in_date { get; set; }

            public string check_out_date { get; set; }
        }

        public static Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
        public static Dictionary<string, Client> Clients = new Dictionary<string, Client>();
        public static List<Client> ClientsList = new List<Client>();
        public static void ReadData()
        {
            Rooms = new Dictionary<int, Room>();
            Clients = new Dictionary<string, Client>();
            ClientsList = new List<Client>();

            foreach (var line in File.ReadAllLines(DataDir + "rooms.txt"))
            {
                var info = Regex.Split(line, @"\s+");
                var number = int.Parse(info[0]);
                Rooms.Add(number, new Room 
                { 
                    number_of_room = number, 
                    floor = int.Parse(info[1]), 
                    spots_in_room = int.Parse(info[2]), 
                    daily_fee = info[3]
                });
            }
            foreach (var line in File.ReadAllLines(DataDir + "clients.txt", Encoding.GetEncoding(1251)))
            {
                var info = Regex.Split(line.Trim(), @"\s+");
                var second_name = info[0];
                Clients.Add(second_name, new Client
                {
                    surname = second_name,
                    number_of_room = int.Parse(info[1]),
                    check_in_date = DateTime.Parse(info[2]).ToShortDateString(),
                    check_out_date = info.Length == 4 ? DateTime.Parse(info[3]).ToShortDateString() : "didn`t move out"
                });
            }

            foreach (var line in File.ReadAllLines(DataDir + "clients.txt", Encoding.GetEncoding(1251)))
            {
                var info = Regex.Split(line.Trim(), @"\s+");
                ClientsList.Add(new Client
                {
                    surname = info[0],
                    number_of_room = int.Parse(info[1]),
                    check_in_date = DateTime.Parse(info[2]).ToShortDateString(),
                    check_out_date = info.Length == 4 ? DateTime.Parse(info[3]).ToShortDateString() : "didn`t move out"
                });
            }
        }
    }
}