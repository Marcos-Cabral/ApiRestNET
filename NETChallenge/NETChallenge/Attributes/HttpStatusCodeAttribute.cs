namespace NETChallenge.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class HttpStatusCodeAttribute : Attribute
    {
        public int StatusCode { get; }

        public HttpStatusCodeAttribute(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
