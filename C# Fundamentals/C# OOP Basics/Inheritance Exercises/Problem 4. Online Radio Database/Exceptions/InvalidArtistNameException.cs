namespace Problem_4.Online_Radio_Database.Exceptions
{
    class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException()
            : base()
        {
        }

        public InvalidArtistNameException(string message)
            : base(message)
        {
        }
    }
}
