using System;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class ColorService
    {
        public bool IsColorExist(string color)
        {
            Color result;
            return Enum.TryParse(color, out result);
        }

        public Color GetColorByName(string color)
        {
            Color result;
            Enum.TryParse(color, out result);
            return result;
        }
    }
}
