using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using HotelDBConsole21.Interfaces;
using HotelDBConsole21.Models;
using Microsoft.Data.SqlClient;

namespace HotelDBConsole21.Services
{
    public class HotelService : Connection, IHotelService
    {
        private string queryString = "select * from Hotel";
        private String queryStringFromID = "select * from Hotel where Hotel_No = @ID";
        private string insertSql ="insert into Hotel Values(@ID, @Navn, @Adresse)";
        private string deleteSql;
        private string updateSql;
        // lav selv sql strengene færdige og lav gerne yderligere sqlstrings


        public List<Hotel> GetAllHotel()
        {
            throw new NotImplementedException();
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public bool CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr)
        {
            throw new NotImplementedException();
        }

        public Hotel DeleteHotel(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetHotelsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
