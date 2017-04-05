using System;

namespace Football_Betting.Models
{
    public class ResultPrediction
    {
        private string _prediction;
        public int Id { get; set; }

        public string Prediction
        {
            get { return _prediction; }
            set
            {
                if (value == "Home Team Win" || value == "Draw Game" || value == "Away Team Win")
                {
                    _prediction = value;
                }
                else
                {
                    throw new ArgumentException("Invalid ResultPrediction!");
                }
            }
        }
    }
}
