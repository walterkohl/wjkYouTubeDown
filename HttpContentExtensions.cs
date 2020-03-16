using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Net.Http;

namespace wjkYouTupe
{
    public static class HttpContentExtensions
    {
        public static Task ReadAsFileAsync(this HttpContent content, string filename, bool overwrite = false)
        {
            string pathname = Path.GetFullPath(filename);
            if (!overwrite && File.Exists(filename))
            {
                throw new InvalidOperationException(string.Format("File {0} already exists.", pathname));
            }

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None);
                return content.CopyToAsync(fileStream).ContinueWith(
                    (copyTask) =>
                    {
                        fileStream.Close();
                    });
            }
            catch
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }

                throw;
            }
        }
    }
}
