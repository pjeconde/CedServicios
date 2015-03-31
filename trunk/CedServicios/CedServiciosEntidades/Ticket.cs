using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Ticket
    {
        private string cuit;
        private string service;
        private string uniqueId;
        private DateTime generationTime;
        private DateTime expirationTime;
        private string sign;
        private string token;

        public string Cuit
        {
            set
            {
                cuit = value;
            }
            get
            {
                return cuit;
            }
        }
        public string Service
        {
            set
            {
                service = value;
            }
            get
            {
                return service;
            }
        }
        public string UniqueId
        {
            set
            {
                uniqueId = value;
            }
            get
            {
                return uniqueId;
            }
        }
        public DateTime GenerationTime
        {
            set
            {
                generationTime = value;
            }
            get
            {
                return generationTime;
            }
        }

        public DateTime ExpirationTime
        {
            set
            {
                expirationTime = value;
            }
            get
            {
                return expirationTime;
            }
        }
        public string Sign
        {
            set
            {
                sign = value;
            }
            get
            {
                return sign;
            }
        }
        public string Token
        {
            set
            {
                token = value;
            }
            get
            {
                return token;
            }
        }
    }
}

