using System.IO;

namespace Shopping.Models.db
{
    public class HttpPostedFileBase
    {
        public Stream InputStream { get; internal set; }
        public int ContentLength { get; internal set; }
    }
}