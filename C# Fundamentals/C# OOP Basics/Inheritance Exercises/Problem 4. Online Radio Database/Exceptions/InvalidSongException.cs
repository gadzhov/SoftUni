using System;

namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidSongException : Exception
    {
        public InvalidSongException()
            : base()
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }
    }
}
