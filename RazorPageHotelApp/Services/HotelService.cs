using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RazorPageHotelApp.Interfaces;
using RazorPageHotelApp.Models;

namespace RazorPageHotelApp.Services
{
    public class HotelService: Connection, IHotelService
    {

        private String queryString = "select * from po22_Hotel";
        private String queryNameString = "select * from po22_Hotel where  Name like @Navn";
        private String queryStringFromID = "select * from po22_Hotel where Hotel_No = @ID";
        private String insertSql = "insert into po22_Hotel Values (@ID, @Navn, @Adresse)";
        private String deleteSql = "delete from po22_Hotel where Hotel_No = @ID";
        private String updateSql = "update po22_Hotel " +
                                   "set Hotel_No= @HotelID, Name=@Navn, Address=@Adresse " +
                                   "where Hotel_No = @ID";


        public HotelService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<Hotel>> GetAllHotelAsync()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        int hotelNr = reader.GetInt32(0);
                        String hotelNavn = reader.GetString(1);
                        String hotelAdr = reader.GetString(2);
                        Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                        hoteller.Add(hotel);
                    }
                }
            }
            return hoteller;
        }

        public Task<Hotel> GetHotelFromIdAsync(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateHotelAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotelAsync(Hotel hotel, int hotelNr)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> DeleteHotelAsync(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotelsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
