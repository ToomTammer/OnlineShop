namespace Shopping.Controllers
{
    public class HttpPostFileBase
    {
        public int ContentLength { get; internal set; }
        public object InputStream { get; internal set; }
    }
}