using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotelDBConsole21.Models;
using HotelDBConsole21.Services;

namespace HotelDBConsole21
{
    public static class MainMenu
    {
        //Lav selv flere menupunkter til at vælge funktioner for Rooms
        public static void showOptions()
        {
            Console.Clear();
            Console.WriteLine("Vælg et menupunkt");
            Console.WriteLine("1) List hoteller");
            Console.WriteLine("1a) List hoteller async");
            Console.WriteLine("2) Opret nyt Hotel");
            Console.WriteLine("3) Fjern Hotel");
            Console.WriteLine("4) Søg efter hotel udfra hotelnr");
            Console.WriteLine("5) Opdater et hotel");
            Console.WriteLine("6) List alle værelser");
            Console.WriteLine("7) List alle værelser til et bestemt hotel");
            Console.WriteLine("8) Flere menupunkter kommer snart :) ");
            Console.WriteLine("Q) Afslut");
        }

        public static bool Menu()
        {
            showOptions();
            switch (Console.ReadLine())
            {
                case "1":
                    ShowHotels();
                    return true;
                case "1a":
                    ShowHotelsAsync();
                    DoSomething();
                    return true;
                case "2":
                    CreateHotel();
                    return true;
                case "Q": 
                case "q": return false;
                default: return true;
            }

        }

        private static void DoSomething()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i + " i GUI");
            }
        }

        private async static Task ShowHotelsAsync()
        {
            Console.Clear();
            HotelServiceAsync hs = new HotelServiceAsync();
            List<Hotel> hotels = await hs.GetAllHotelAsync();
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine($"HotelNr {hotel.HotelNr} Name {hotel.HotelNr} Address {hotel.Adresse}");
            }
        }

        private static void CreateHotel()
        {
            //Indlæs data
            Console.Clear();
            Console.WriteLine("Indlæs hotelnr");
            int hotelnr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indlæs hotelnavn");
            string navn = Console.ReadLine();
            Console.WriteLine("Indlæs hotel adresse");
            string adresse = Console.ReadLine();

            //Kalde hotelservice vise resultatet
            HotelService hs = new HotelService();
            bool ok = hs.CreateHotel(new Hotel(hotelnr, navn, adresse));
            if (ok)
            {
                Console.WriteLine("Hotellet blev oprettet!");
            }
            else
            {
                Console.WriteLine("Fejl. Hotellet blev ikke oprettet!");
            }

        }

        private static void ShowHotels()
        {
            Console.Clear();
            HotelService hs = new HotelService();
            List<Hotel> hotels = hs.GetAllHotel();
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine($"HotelNr {hotel.HotelNr} Name {hotel.Navn} Address {hotel.Adresse}");
            }
        }
    }
}
