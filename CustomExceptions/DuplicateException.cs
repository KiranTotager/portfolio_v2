namespace Portfolio.CustomExceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string Message) : base(Message+" already exist ,duplicate not allowed")
        {

        }
    }
}
