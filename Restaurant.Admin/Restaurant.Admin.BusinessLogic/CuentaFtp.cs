using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class CuentaFtp
    {
        private DC.CuentaFtp data = null;
        public CuentaFtp()
        {
            this.data = new DC.CuentaFtp();
        }

        public BE.CuentaFtp ObtenerCuentaFtp(BE.CuentaFtp cuenta)
        {
            return data.ObtenerCuentaFtp(cuenta);
        }

        public bool SubirImagenPorFTP(BE.CuentaFtp cuenta, string nombreArchivo, byte[] archivo)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(cuenta.Servidor + nombreArchivo);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(cuenta.Usuario, cuenta.Password);

                request.ContentLength = archivo.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(archivo, 0, archivo.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarSiExisteImagen(BE.CuentaFtp cuenta, string nombreArchivo)
        {
            WebRequest request = WebRequest.Create(cuenta.Servidor + nombreArchivo);
            request.Credentials = new NetworkCredential(cuenta.Usuario, cuenta.Password);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            try
            {
                request.GetResponse();
                return true;
            }
            catch (WebException e)
            {
                FtpWebResponse response = (FtpWebResponse)e.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
