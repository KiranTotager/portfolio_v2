namespace Portfolio.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message + " not found")
        {
        }
    }
}
