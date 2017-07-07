namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException()
            : base()
        {
        }

        public InvalidSongNameException(string message)
            : base(message)
        {
        }
    }
}
