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
            List<Hotel> hoteller = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.Connection.Open();//Synkront
                        SqlDataReader reader = command.ExecuteReader();//Synkront
                        while (reader.Read())
                        {
                            int hotelNr = reader.GetInt32(0);
                            String hotelNavn = reader.GetString(1);
                            String hotelAdr = reader.GetString(2);
                            Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                            hoteller.Add(hotel);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine("Database error " + sqlEx.Message);
                        return null;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Generel fejl" + exp.Message);
                        return null;
                    }
                    finally{
                        // Her kommer man lige meget hvad.
                    }

                }
            }
            return hoteller;
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@ID", hotel.HotelNr);
                command.Parameters.AddWithValue("@Navn", hotel.Navn);
                command.Parameters.AddWithValue("@Adresse", hotel.Adresse);
                command.Connection.Open();

                int noOfRows = command.ExecuteNonQuery();//bruges ved update, delete, insert
                if (noOfRows == 1)
                {
                    return true; 
                }
                return false;
            }
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
