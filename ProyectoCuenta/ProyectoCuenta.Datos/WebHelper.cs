using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;
using ProyectoCuenta.Entidades;

namespace ProyectoCuenta.Datos
{
    public static class WebHelper
    {
        static WebClient _webClient;
        static string _rutaBase = string.Empty;
        static string _registro = string.Empty;

        static WebHelper()
        {
            _webClient = new WebClient();
            _webClient.Encoding = Encoding.UTF8;
            _webClient.Headers.Add("ContentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _rutaBase = ConfigurationManager.AppSettings["URL_API"];
            _registro = ConfigurationManager.AppSettings["REGISTRO"];
            if (_registro != string.Empty)
                _registro = "/" + _registro;
        }

        public static string Get(string url)
        {
            return _webClient.DownloadString(_rutaBase + url);
        }

        public static string Post(string url, NameValueCollection param)
        {
            try
            {
                byte[] response = _webClient.UploadValues(_rutaBase + url, param);
                return Encoding.Default.GetString(response);
            }
            catch (Exception)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }

        public static string Put(string url, NameValueCollection param)
        {
            try
            {
                byte[] response = _webClient.UploadValues(_rutaBase + url, "PUT", param);
                return Encoding.Default.GetString(response);
            }
            catch (Exception)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }

        public static string Delete(string url, NameValueCollection param)
        {
            try
            {
                byte[] response = _webClient.UploadValues(_rutaBase + url, "DELETE", param);
                return Encoding.Default.GetString(response);
            }
            catch (Exception)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }
    }
}
