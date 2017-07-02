using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6.Football_Team_Generator.Models
{
    class Team
    {
        private double _rating;
        private string _name;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        private List<Player> Players { get; set; }

        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this._name = value;
            }
        }

        public double Rating
        {
            get => this._rating;
            set
            {
                var average = (this.Players.Sum(p => p.Dribble) + this.Players.Sum(p => p.Endurance) +
                                       this.Players.Sum(p => p.Passing) + this.Players.Sum(p => p.Shooting) +
                                       this.Players.Sum(p => p.Sprint)) / 5.0;
                this._rating = Math.Round(average);
            }
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
            this.Rating = this._rating;
        }

        public void RemovePlayer(string playerName)
        {
            if (this.Players.Any(p => p.Name == playerName))
            {
                var player = this.Players.FirstOrDefault(p => p.Name == playerName);
                this.Players.Remove(player);
                this.Rating = this._rating;
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
