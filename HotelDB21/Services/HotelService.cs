using System;
using System.Collections.Generic;
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
        private string insertSql;
        private string deleteSql;
        private string updateSql;
        // lav selv sql strengene færdige og lav gerne yderligere sqlstrings


        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hoteller = new List<Hotel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int hotelNr = reader.GetInt32(0);
                    String hotelNavn = reader.GetString(1);
                    String hotelAdr = reader.GetString(2);
                    Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                    hoteller.Add(hotel);
                }
            }
            return hoteller;
        }

        

        
        

        

        
    }
}
