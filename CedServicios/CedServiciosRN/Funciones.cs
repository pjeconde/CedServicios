using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using CaptchaDotNet2.Security.Cryptography;
using System.IO;

namespace CedServicios.RN
{
    public class Funciones
    {
        public static bool EsEmail(string value)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(value))
                return (true);
            else
                return (false);
        }
        public static string CreateMD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }
        public static string Encriptar(string texto)
        {
            return Encryptor.Encrypt(texto, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
        }
        public static string Desencriptar(string texto)
        {
            return Encryptor.Decrypt(texto, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
        }
        public static string HexToString(string Hex)
        {
            Hex = Hex.Replace("%", "");
            int numberChars = Hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(Hex.Substring(i, 2), 16);
            }
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(bytes);
            str = SacarEntityName(str);
            return str;
        }
        private static string SacarEntityName(string texto)
        {
            texto = texto.Replace("&aacute;", "á");
            texto = texto.Replace("&eacute;", "é");
            texto = texto.Replace("&iacute;", "í");
            texto = texto.Replace("&oacute;", "ó");
            texto = texto.Replace("&uacute;", "ú");
            texto = texto.Replace("&ordm;", "º");
            texto = texto.Replace("&agrave;", "à");
            texto = texto.Replace("&egrave;", "è");
            texto = texto.Replace("&igrave;", "ì");
            texto = texto.Replace("&ograve;", "ò");
            texto = texto.Replace("&ugrave;", "ù");
            texto = texto.Replace("&ntilde;", "ñ");
            texto = texto.Replace("&#36", "$");
            //Mayúsculas
            texto = texto.Replace("&Aacute;", "Á");
            texto = texto.Replace("&Eacute;", "É");
            texto = texto.Replace("&Iacute;", "Í");
            texto = texto.Replace("&Oacute;", "Ó");
            texto = texto.Replace("&Uacute;", "Ú");
            texto = texto.Replace("&Agrave;", "À");
            texto = texto.Replace("&Egrave;", "È");
            texto = texto.Replace("&Igrave;", "Ì");
            texto = texto.Replace("&Ograve;", "Ò");
            texto = texto.Replace("&Ugrave;", "Ù");
            texto = texto.Replace("&Ntilde;", "Ñ");
            return texto;
        }
        public static string ConvertToHex(string asciiString)
        {
            asciiString = PonerEntityName(asciiString);
            byte[] b = Encoding.ASCII.GetBytes(asciiString);
            string salida = "";
            for (int i = 0; i < b.Length; i++)
            {
                string ascii = b[i].ToString();
                int n = Convert.ToInt32(ascii);
                string r = n.ToString("x");
                salida += "%" + r;
            }
            return salida;
        }
        public static string PonerEntityName(string texto)
        {
            texto = texto.Replace("á", "&aacute;");
            texto = texto.Replace("é", "&eacute;");
            texto = texto.Replace("í", "&iacute;");
            texto = texto.Replace("ó", "&oacute;");
            texto = texto.Replace("ú", "&uacute;");
            texto = texto.Replace("º", "&ordm;");
            texto = texto.Replace("à", "&agrave;");
            texto = texto.Replace("è", "&egrave;");
            texto = texto.Replace("ì", "&igrave;");
            texto = texto.Replace("ò", "&ograve;");
            texto = texto.Replace("ù", "&ugrave;");
            texto = texto.Replace("ñ", "&ntilde;");
            texto = texto.Replace("$", "&#36");
            //Mayúsculas
            texto = texto.Replace("Á", "&Aacute;");
            texto = texto.Replace("É", "&Eacute;");
            texto = texto.Replace("Í", "&Iacute;");
            texto = texto.Replace("Ó", "&Oacute;");
            texto = texto.Replace("Ú", "&Uacute;");
            texto = texto.Replace("À", "&Agrave;");
            texto = texto.Replace("È", "&Egrave;");
            texto = texto.Replace("Ì", "&Igrave;");
            texto = texto.Replace("Ò", "&Ograve;");
            texto = texto.Replace("Ù", "&Ugrave;");
            texto = texto.Replace("Ñ", "&Ntilde;");
            return texto;
        }
        public static bool IsValidEmail(string strMailAddress)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
        public static void ValidarListaDeMails(string Lista)
        {
            string[] elementos = Lista.Split(',');
            for (int i = 0; i < elementos.Length; i++)
            {
                if (!IsValidEmail(elementos[i].Trim()))
                {
                    throw new Exception((i+1).ToString());
                }
            }
        }
        public static bool IsValidNroIB(string strNroIB)
        {
            return Regex.IsMatch(strNroIB, @"[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}|[0-9]{11}");
        }
        public static bool IsValidNumeric(string strNro)
        {
            return Regex.IsMatch(strNro, @"[0-9]+");
        }
        public static bool IsValidNumericDecimals(string strNro)
        {
            return Regex.IsMatch(strNro, @"[0-9]+(\.[0-9]+)?");
        }
        public static bool IsValidNumericFijo(string strNro, string strCantidad)
        {
            return Regex.IsMatch(strNro, @"[0-9]{" + strCantidad + "}");
        }
        public static void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(HttpContext.Current.Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
        public static bool ValidarFechaYYYYMMDD(string Fecha)
        {
            if (Fecha.Length != 8) 
            { 
                return false; 
            }
            try
            {
                DateTime a = Convert.ToDateTime(Fecha.Substring(6, 2) + "/" + Fecha.Substring(4, 2) + "/" + Fecha.Substring(0, 4));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
