using System;
using Problem_4.Online_Radio_Database.Exceptions;

namespace Problem_4.Online_Radio_Database.Models
{
    public class Song
    {
        private string _artistName;
        private string _songName;
        private string _songLenght;

        public Song(string artistName, string songName, string songLenght)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongLenght = songLenght;
        }

        private string ArtistName
        {
            get => this._artistName;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
                }
                _artistName = value;
            }
        }

        private string SongName
        {
            get => this._songName;
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongException("Song name should be between 3 and 30 symbols.");
                }
                _songName = value;
            }
        }

        private string SongLenght
        {
            get => this._songLenght;
            set
            {
                var timeArgs = value.Split(':');
                int minutes;
                int seconds;
                if (timeArgs.Length > 2 || !int.TryParse(timeArgs[0], out minutes) || !int.TryParse(timeArgs[1], out seconds))
                {
                    throw new InvalidSongException("Invalid song length.");
                }
                
                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
                }
                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
                }
                _songLenght = value;
            }
        }

        public double GetSeconds()
        {
            return TimeSpan.Parse($"0:{this.SongLenght}").TotalSeconds;
        }
    }
}
