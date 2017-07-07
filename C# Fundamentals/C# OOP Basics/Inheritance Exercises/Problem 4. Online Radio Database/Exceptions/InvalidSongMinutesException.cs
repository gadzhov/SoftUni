namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException()
            : base()
        {
        }

        public InvalidSongMinutesException(string message)
            : base(message)
        {
        }
    }
}
