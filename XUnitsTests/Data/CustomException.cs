namespace XUnitsTests.Data
{
    public class CustomException : Exception
    { 
        public void ThrowArgumentException()
        {
            throw new ArgumentException(Messages.ArgumentExceptionMessage);
        }

        public void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException(Messages.InvalidOperationExceptionMessage);
        }
         public void ThrowDivideByZeroException()
        {
            throw new DivideByZeroException(Messages.DivideByZeroExceptionMessage);
        }

        public void ThrowNullReferenceException()
        {
            throw new NullReferenceException(Messages.NullReferenceExceptionMessage);
        }

        public void ThrowIndexOutOfRangeException()
        {
            throw new IndexOutOfRangeException(Messages.IndexOutOfRangeExceptionMessage);
        }

      
    }
}
