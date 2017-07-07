using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4.Online_Radio_Database.Models
{
    public class Radio
    {
        public Radio()
        {
            this.Songs = new List<Song>();
        }
        private List<Song> Songs { get; set; }

        public void AddSong(Song song)
        {
            this.Songs.Add(song);
            Console.WriteLine("Song added.");
        }

        public override string ToString()
        {
            var totalTime = TimeSpan.FromSeconds(this.Songs.Sum(s => s.GetSeconds()));
            var sb = new StringBuilder();
            sb.Append("Songs added: ").AppendLine(this.Songs.Count.ToString())
                .Append("Playlist length: ").Append($"{totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");

            return  sb.ToString();
        }
    }
}
