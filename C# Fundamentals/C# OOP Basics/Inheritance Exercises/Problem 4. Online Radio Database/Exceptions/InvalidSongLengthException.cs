namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException()
            : base()
        {
        }

        public InvalidSongLengthException(string message)
            : base(message)
        {
        }
    }
}
