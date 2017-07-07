namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException()
            : base()
        {
        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }
    }
}
