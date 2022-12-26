using Medibox.Service.Api;
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace Medibox.Service.Net
{
    public class WebHost : IDisposable
    {
        //Private
        private WebServiceHost mAPIService;

        private bool Disposed;
        private HttpListenerHost HttpListenerHost { get; set; }
        private ConcurrentDictionary<string, string> _extensionToMimeType;
        private ConcurrentDictionary<string, string> ExtensionToMimeType
        {
            get
            {
                return this._extensionToMimeType = this._extensionToMimeType ?? new ConcurrentDictionary<string, string>();
            }
        }

        //Public
        public int Port { get; set; }                           //Cổng web server
        public String Host { get; set; }                        //Địa chỉ web server
        public bool EnableRemote { get; set; }                  //Cho phép truy cập web từ xa
        public string[] Prefixes { get; set; }
        public string RootDirectoryPath { get; set; }
        public bool EnableHTTPS { get; set; }                   //Dùng giao thức HTTPS
        public bool Running
        {
            get
            {
                if (HttpListenerHost != null)
                {
                    return HttpListenerHost.Running;
                }
                return false;
            }
        }

        private WebHttpBinding CreateWebHttpBinding()
        {
            WebHttpBinding webHttpBinding = new WebHttpBinding();

            //SSL
            if (EnableHTTPS)
            {
                webHttpBinding.Security.Mode = WebHttpSecurityMode.Transport;
                webHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            }

            if (!EnableRemote)
            {
                webHttpBinding.HostNameComparisonMode = HostNameComparisonMode.Exact;
            }

            webHttpBinding.TransferMode = TransferMode.StreamedResponse;
            webHttpBinding.CrossDomainScriptAccessEnabled = false;
            webHttpBinding.MaxBufferSize = 2147483647;
            webHttpBinding.MaxReceivedMessageSize = 2147483647;
            webHttpBinding.MaxBufferPoolSize = 2147483647;
            webHttpBinding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas();
            webHttpBinding.ReaderQuotas.MaxArrayLength = 2147483647;
            webHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            webHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
            webHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
            webHttpBinding.ReaderQuotas.MaxDepth = 2147483647;
            return webHttpBinding;
        }

        private void RefreshFolder(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                {
                }
            }
            if (Directory.Exists(path))
            {
                return;
            }
            Directory.CreateDirectory(path);
        }

        public void Start()
        {
            if (Running)
            {
                return;
            }
            if (Port == 0)
            {
                throw new NullReferenceException();
            }

            //Enable remote
            EnableHTTPS = true;
            EnableRemote = true;
            Host = "localhost";

            
        }

        public void Dispose()
        {
            if (Disposed)
            {
                return;
            }
            Disposed = true;

            //LoginService
            if (mAPIService != null)
            {
                mAPIService.Close();
                mAPIService = (WebServiceHost)null;
            }

            //HttpListenerHost
            if (HttpListenerHost != null)
            {
                HttpListenerHost.Stop();
                HttpListenerHost = (HttpListenerHost)null;
            }
        }

        public string ConvertExtensionToMimeType(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                return "application/octet-stream";
            }
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }
            string strExtension;
            if (ExtensionToMimeType.TryGetValue(extension, out strExtension))
            {
                return strExtension;
            }
            switch (extension)
            {
                case ".html":
                case ".htm":
                    strExtension = "text/html; charset=UTF-8";
                    break;
                case ".css":
                    strExtension = "text/css; charset=UTF-8";
                    break;
                case ".js":
                    strExtension = "application/javascript; charset=UTF-8";
                    break;
                case ".json":
                    strExtension = "application/json; charset=UTF-8";
                    break;
                case ".map":
                case ".txt":
                    strExtension = "text/plain; charset=UTF-8";
                    break;
                case ".xml":
                    strExtension = "text/xml; charset=UTF-8";
                    break;
                case ".jpeg":
                case ".jpg":
                    strExtension = "image/jpeg";
                    break;
                case ".png":
                    strExtension = "image/png";
                    break;
                case ".gif":
                    strExtension = "image/gif";
                    break;
                case ".ico":
                    strExtension = "image/x-icon";
                    break;
                default:
                    using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extension, false))
                    {
                        object obj = registryKey != null ? registryKey.GetValue("Content Type", (object)null) : (object)null;
                        strExtension = obj != null ? obj.ToString() : "application/octet-stream";
                        break;
                    }
            }
            ExtensionToMimeType.TryAdd(extension, strExtension);
            return strExtension;
        }
    }
}
