﻿namespace FootballBetting.Models
{
    public class CountriesContinets
    {
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
    }
}
