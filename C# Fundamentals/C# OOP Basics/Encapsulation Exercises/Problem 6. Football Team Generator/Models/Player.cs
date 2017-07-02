using System;

namespace Problem_6.Football_Team_Generator.Models
{
    class Player
    {
        private string _name;
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

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

        public int Endurance
        {
            get => this._endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100. ");
                }
                this._endurance = value;
            }
        }

        public int Sprint
        {
            get => this._sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100. ");
                }
                this._sprint = value;
            }
        }

        public int Dribble
        {
            get => this._dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100. ");
                }
                this._dribble = value;
            }
        }

        public int Passing
        {
            get => this._passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100. ");
                }
                this._passing = value;
            }
        }

        public int Shooting
        {
            get => this._shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100. ");
                }
                this._shooting = value;
            }
        }
    }
}
