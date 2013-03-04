using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services; 
using System.Xml;
using System.Web.Services.Protocols;

namespace CedServiciosWeb
{
    public class ExcepcionesSOAP
    {
        public static SoapException RaiseException(string uri, string webServiceNamespace,

                                        string errorMessage,

                                        string errorNumber,

                                        string errorSource,

                                        FaultCode code)
        {

            XmlQualifiedName faultCodeLocation = null;

            //Identify the location of the FaultCode

            switch (code)
            {

                case FaultCode.Client:

                    faultCodeLocation = SoapException.ClientFaultCode;

                    break;

                case FaultCode.Server:

                    faultCodeLocation = SoapException.ServerFaultCode;

                    break;

            }

            XmlDocument xmlDoc = new XmlDocument();

            //Create the Detail node

            XmlNode rootNode = xmlDoc.CreateNode(XmlNodeType.Element,

                                          SoapException.DetailElementName.Name,

                                          SoapException.DetailElementName.Namespace);

            //Build specific details for the SoapException

            //Add first child of detail XML element.

            XmlNode errorNode = xmlDoc.CreateNode(XmlNodeType.Element, "Error",

                                                  webServiceNamespace);

            //Create and set the value for the ErrorNumber node

            XmlNode errorNumberNode =

              xmlDoc.CreateNode(XmlNodeType.Element, "ErrorNumber",

                                webServiceNamespace);

            errorNumberNode.InnerText = errorNumber;

            //Create and set the value for the ErrorMessage node

            XmlNode errorMessageNode = xmlDoc.CreateNode(XmlNodeType.Element,

                                                        "ErrorMessage",

                                                        webServiceNamespace);

            errorMessageNode.InnerText = errorMessage;

            //Create and set the value for the ErrorSource node

            XmlNode errorSourceNode =

              xmlDoc.CreateNode(XmlNodeType.Element, "ErrorSource",

                                webServiceNamespace);

            errorSourceNode.InnerText = errorSource;

            //Append the Error child element nodes to the root detail node.

            errorNode.AppendChild(errorNumberNode);

            errorNode.AppendChild(errorMessageNode);

            errorNode.AppendChild(errorSourceNode);

            //Append the Detail node to the root node

            rootNode.AppendChild(errorNode);

            //Construct the exception

            SoapException soapEx = new SoapException(errorMessage,

                                                     faultCodeLocation, uri,

                                                     rootNode);

            //Raise the exception  back to the caller

            return soapEx;

        }
    }
    public enum FaultCode
    {
        Client = 0,
        Server = 1
    }
}
