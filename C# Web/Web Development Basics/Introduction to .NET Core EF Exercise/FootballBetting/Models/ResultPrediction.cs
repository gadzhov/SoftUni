namespace FootballBetting.Models
{
    using System;

    public class ResultPrediction
    {
        private string prediction;

        public int Id { get; set; }

        public string Prediction
        {
            get => this.prediction;
            set
            {
                if (value == "Home Team Win" || value == "Draw Game" || value == "Away Team Win")
                {
                    this.prediction = value;
                }
                else
                {
                    throw new ArgumentException("Invalid ResultPrediction!");
                }
            }
        }
    }
}
