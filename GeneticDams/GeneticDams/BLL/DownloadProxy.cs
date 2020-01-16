using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace GeneticDams.BLL
{
    /// <summary>
    /// Interface for the proxy
    /// </summary>
    public interface IDownload{
        FileContentResult DownloadFile(string fileName, bool login);
}
    /// <summary>
    /// Proxy class with smart reference to count downloads.
    /// </summary>
    public class DownloadProxy : IDownload
    {
        private static int countDownloads = 0;
        readonly DownloadServer Server;
        public DownloadProxy(DownloadServer server)
        {
            this.Server = server;
        }
        /// <summary>
        /// Call the server to download checking user and data
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="login">Indicates if user is logged</param>
        /// <returns>File result</returns>
        public FileContentResult DownloadFile(string fileName,bool login)
        {
            // Check if user is logged
            if (login)
            {
                // Check if file has a good name
                if (fileName != "" || fileName != null)
                    return Server.DownloadFile(fileName, true);
                else
                    return null;
            } else
            {
                return null;
            }
            
        }
        public int Count()
        {
            return countDownloads++;
        }
    }
    /// <summary>
    /// Real server who downloads the files.
    /// </summary>
    public class DownloadServer : Controller, IDownload
    {
        public FileContentResult DownloadFile(string fileName, bool login)
        {
            // Download the file from the path
            if (System.IO.File.Exists(fileName)) {
                return File(System.IO.File.ReadAllBytes(fileName), "application/octet-stream", Path.GetFileName(fileName));
            } 
            else
            { 
                return null;
            }
        }
    }
}
