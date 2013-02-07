//===============================================================================
// Microsoft Exception Management Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/emab-rm.asp
//
// ExceptionManager.cs
// This file contains the ExceptionManager class, which manages all publishing 
// of exceptions, and the default publisher class, which publishes exception 
// information to the Event Log.
//
// For more information see the Implementing the Exception Manager Component
// section of the Exception Management Application Block Implementation Overview. 
//===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Threading;
using System.Collections.Specialized;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;
namespace CedServicios.EX
{
	#region ExceptionManager Class
	/// <summary>
	/// The Exception Manager class manages the publishing of exception information based on settings in the configuration file.
	/// </summary>
	public sealed class ExceptionManager
	{
		/// <summary>
		/// Private constructor to restrict an instance of this class from being created.
		/// </summary>
		private ExceptionManager()
		{
		}

		// Member variable declarations
		private const string EXCEPTIONMANAGEMENT_CONFIG_SECTION = "exceptionManagement";
		private readonly static string EXCEPTIONMANAGER_NAME = typeof(ExceptionManager).Name;

		// Resource Manager for localized text.
		private static ResourceManager resourceManager = new ResourceManager(typeof(ExceptionManager).Namespace + ".ExceptionManagerText",Assembly.GetAssembly(typeof(ExceptionManager)));
				
		/// <summary>
		/// Static method to publish the exception information.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		public static void Publish(Exception exception)
		{			
			ExceptionManager.Publish(exception, null);					
		}

		/// <summary>
		/// Static method to publish the exception information and any additional information.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		/// <param name="additionalInfo">A collection of additional data that should be published along with the exception information.</param>
		public static void Publish(Exception exception, NameValueCollection additionalInfo)
		{
			try
			{
				#region Load the AdditionalInformation Collection with environment data.
				// Create the Additional Information collection if it does not exist.
				if (null == additionalInfo) additionalInfo = new NameValueCollection();

				// Add environment information to the information collection.
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", Environment.MachineName);
				}
				catch(SecurityException)
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}
					
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp", DateTime.Now.ToString());
				}
				catch(SecurityException)
				{					
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp",resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}					
									
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", Assembly.GetExecutingAssembly().FullName);
				}
				catch(SecurityException)
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}	
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}
					
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName", AppDomain.CurrentDomain.FriendlyName);
				}
				catch(SecurityException)
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}
						
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity", Thread.CurrentPrincipal.Identity.Name);
				}
				catch(SecurityException)
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}
				
				try
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", WindowsIdentity.GetCurrent().Name);
				}
				catch(SecurityException)
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED"));
				}
				catch
				{
					additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION"));
				}
											
				#endregion

				#region Publish the exception based on Configuration Settings
				// Check for any settings in config file.
				if (System.Configuration.ConfigurationManager.GetSection(EXCEPTIONMANAGEMENT_CONFIG_SECTION) == null)
				{
					// Publish the exception and additional information to the default publisher if no settings are present.
					PublishToDefaultPublisher(exception, additionalInfo);
				}
				else
				{
					// Get settings from config file
					ExceptionManagementSettings config = (ExceptionManagementSettings)System.Configuration.ConfigurationManager.GetSection(EXCEPTIONMANAGEMENT_CONFIG_SECTION);

					// If the mode is not equal to "off" call the Publishers, otherwise do nothing.
					if (config.Mode == ExceptionManagementMode.On)
					{
						// If no publishers are specified, use the default publisher.
						if (config.Publishers == null || config.Publishers.Count == 0)
						{
							// Publish the exception and additional information to the default publisher if no mode is specified.
							PublishToDefaultPublisher(exception, additionalInfo);
						}
						else
						{
							#region Iterate through the publishers
							// Loop through the publisher components specified in the config file.
							foreach(PublisherSettings Publisher in config.Publishers)
							{
								// Call the Publisher component specified in the config file.
								try
								{
									// Verify the publishers mode is not set to "OFF".
									// This publisher will be called even if the mode is not specified.  
									// The mode must explicitly be set to OFF to not be called.
									if (Publisher.Mode == PublisherMode.On)
									{
										if (exception == null || !Publisher.IsExceptionFiltered(exception.GetType()))
										{
											// Publish the exception and any additional information
											PublishToCustomPublisher(exception, additionalInfo, Publisher);
										}
									} 
								} 
									// Catches any failure to call a custom publisher.
								catch(Exception e)
								{
									// Publish the exception thrown when trying to call the custom publisher.
									PublishInternalException(e,null);

									// Publish the original exception and additional information to the default publisher.
									PublishToDefaultPublisher(exception, additionalInfo);

								} // End Catch block.

							} // End foreach loop through publishers.
							#endregion
						} // End else statement when custom publishers are in the config settings.

					} // End else statement where config settings are not set to "OFF"

				} // End else statement when config settings are provided.
				#endregion
			}
			catch(Exception e)
			{
				// Publish the exception thrown within the ExceptionManager.
				PublishInternalException(e,null);

				// Publish the original exception and additional information to the default publisher.
//				PublishToDefaultPublisher(exception, additionalInfo);
			}
		} // End Publish(Exception exception, NameValueCollection AdditionalInfo)

		/// <summary>
		/// Private static helper method to publish the exception information to a custom publisher.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		/// <param name="additionalInfo">A collection of additional data that should be published along with the exception information.</param>
		/// <param name="publisher">The PublisherSettings that contains the values of the publishers configuration.</param>
		private static void PublishToCustomPublisher(Exception exception, NameValueCollection additionalInfo, PublisherSettings publisher)
		{
			try
			{
				// Check if the exception format is "xml".
				if (publisher.ExceptionFormat == PublisherFormat.Xml)
				{
					// If it is load the IExceptionXmlPublisher interface on the custom publisher.
 
					// Instantiate the class
					IExceptionXmlPublisher XMLPublisher = (IExceptionXmlPublisher)Activate(publisher.AssemblyName, publisher.TypeName);

					// Publish the exception and any additional information
					XMLPublisher.Publish(SerializeToXml(exception, additionalInfo),publisher.OtherAttributes);
				}
					// Otherwise load the IExceptionPublisher interface on the custom publisher.
				else
				{
					// Instantiate the class
					IExceptionPublisher Publisher = (IExceptionPublisher)Activate(publisher.AssemblyName, publisher.TypeName);

					// Publish the exception and any additional information
					Publisher.Publish(exception, additionalInfo, publisher.OtherAttributes);
				}
			}
			catch(Exception e)
			{
				CustomPublisherException publisherException = new CustomPublisherException(resourceManager.GetString("RES_CUSTOM_PUBLISHER_FAILURE_MESSAGE"), publisher.AssemblyName, publisher.TypeName, publisher.ExceptionFormat, e);
				publisherException.AdditionalInformation.Add(publisher.OtherAttributes);

				throw(publisherException);
			}
		}

		/// <summary>
		/// Private static helper method to publish the exception information to the default publisher.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		/// <param name="additionalInfo">A collection of additional data that should be published along with the exception information.</param>
		private static void PublishToDefaultPublisher(Exception exception, NameValueCollection additionalInfo)
		{
			// Get the Default Publisher
			// En Cedeira no se escribe al Log
			IExceptionPublisher Publisher=new ExceptionPublisher();
				
			// Publish the exception and any additional information
			Publisher.Publish(exception, additionalInfo, null);
		}

		/// <summary>
		/// Private static helper method to publish the exception information to the default publisher.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		/// <param name="additionalInfo">A collection of additional data that should be published along with the exception information.</param>
		internal static void PublishInternalException(Exception exception, NameValueCollection additionalInfo)
		{
			// Get the Default Publisher
			IExceptionPublisher Publisher = new MailExceptionPublisher();
				
			// Publish the exception and any additional information
			Publisher.Publish(exception, additionalInfo, null);
		}

		/// <summary>
		/// Private helper function to assist in run-time activations. Returns
		/// an object from the specified assembly and type.
		/// </summary>
		/// <param name="assembly">Name of the assembly file (w/out extension)</param>
		/// <param name="typeName">Name of the type to create</param>
		/// <returns>Instance of the type specified in the input parameters.</returns>
		private static object Activate(string assembly, string typeName)
		{
			return AppDomain.CurrentDomain.CreateInstanceAndUnwrap(assembly, typeName);
		}

		/// <summary>
		/// Public static helper method to serialize the exception information into XML.
		/// </summary>
		/// <param name="exception">The exception object whose information should be published.</param>
		/// <param name="additionalInfo">A collection of additional data that should be published along with the exception information.</param>
		public static XmlDocument SerializeToXml(Exception exception, NameValueCollection additionalInfo)
		{
			try
			{
				// Variables representing the XmlElement names.
				
				string ROOT = resourceManager.GetString("RES_XML_ROOT");
				string ADDITIONAL_INFORMATION = resourceManager.GetString("RES_XML_ADDITIONAL_INFORMATION");
				string EXCEPTION = resourceManager.GetString("RES_XML_EXCEPTION");
				string STACK_TRACE = resourceManager.GetString("RES_XML_STACK_TRACE");
								
				// Create a new XmlDocument.
				XmlDocument xmlDoc = new XmlDocument();

				// Create the root node.
				XmlElement root = xmlDoc.CreateElement(ROOT);
				xmlDoc.AppendChild(root);

				// Variables to hold values while looping through the exception chain.
				XmlElement element;
				XmlElement exceptionAddInfoElement;
				XmlElement stackTraceElement;
				XmlText stackTraceText;
				XmlAttribute attribute;

				#region Add values from AdditionalInfo to the XML Doc
				// Check if the collection has values.
				if (additionalInfo != null && additionalInfo.Count > 0)
				{
					// Create the element for the collection.
					element = xmlDoc.CreateElement(ADDITIONAL_INFORMATION);
				
					// Loop through the collection and add the values as attributes on the element.
					foreach (string i in additionalInfo)
					{
						attribute = xmlDoc.CreateAttribute(i.Replace(" ", "_"));
						attribute.Value = additionalInfo.Get(i);
						element.Attributes.Append(attribute);
					}

					// Add the element to the root.
					root.AppendChild(element);
				}
				#endregion

				if (exception == null)
				{
					// Create an empty exception element.
					element = xmlDoc.CreateElement(EXCEPTION);

					// Append to the root node.
					root.AppendChild(element);
				}
				else
				{
					#region Loop through each exception class in the chain of exception objects and record its information
					// Loop through each exception class in the chain of exception objects.
					Exception currentException = exception;	// Temp variable to hold InnerException object during the loop.
					XmlElement parentElement = null;	// Temp variable to hold the parent exception node during the loop.
					do
					{
						// Create the exception element.
						element = xmlDoc.CreateElement(EXCEPTION);

						// Add the exceptionType as an attribute.
						attribute = xmlDoc.CreateAttribute("ExceptionType");
						attribute.Value = currentException.GetType().FullName;
						element.Attributes.Append(attribute);
				
						#region Loop through the public properties of the exception object and record their value
						// Loop through the public properties of the exception object and record their value.
						PropertyInfo[] aryPublicProperties = currentException.GetType().GetProperties();
						NameValueCollection currentAdditionalInfo;
						foreach (PropertyInfo p in aryPublicProperties)
						{
							// Do not log information for the InnerException or StackTrace. This information is 
							// captured later in the process.
							if (p.Name != "InnerException" && p.Name != "StackTrace")
							{
								// Only record properties whose value is not null.
								if (p.GetValue(currentException,null) != null)
								{
									// Check if the property is AdditionalInformation and the exception type is a BaseApplicationException.
									if (p.Name == "AdditionalInformation" && currentException is BaseApplicationException)
									{
										// Verify the collection is not null.
										if (p.GetValue(currentException,null) != null)
										{
											// Cast the collection into a local variable.
											currentAdditionalInfo = (NameValueCollection)p.GetValue(currentException,null);

											// Verify the collection has values.
											if (currentAdditionalInfo.Count > 0)
											{
												// Create element.
												exceptionAddInfoElement = xmlDoc.CreateElement(ADDITIONAL_INFORMATION);

												// Loop through the collection and add values as attributes.
												foreach (string i in currentAdditionalInfo)
												{
													attribute = xmlDoc.CreateAttribute(i.Replace(" ", "_"));
													attribute.Value = currentAdditionalInfo.Get(i);
													exceptionAddInfoElement.Attributes.Append(attribute);
												}

												element.AppendChild(exceptionAddInfoElement);
											}
										}
									}
										// Otherwise just add the ToString() value of the property as an attribute.
									else
									{
										attribute = xmlDoc.CreateAttribute(p.Name);
										attribute.Value = p.GetValue(currentException,null).ToString();
										element.Attributes.Append(attribute);
									}
								}
							}
						}
						#endregion

						#region Record the exception StackTrace
						// Record the StackTrace within a separate element.
						if (currentException.StackTrace != null)
						{
							// Create Stack Trace Element.
							stackTraceElement = xmlDoc.CreateElement(STACK_TRACE);

							stackTraceText = xmlDoc.CreateTextNode(currentException.StackTrace.ToString());

							stackTraceElement.AppendChild(stackTraceText);

							element.AppendChild(stackTraceElement);
						}
						#endregion

						// Check if this is the first exception in the chain.
						if (parentElement == null)
						{
							// Append to the root node.
							root.AppendChild(element);
						}
						else
						{
							// Append to the parent exception object in the exception chain.
							parentElement.AppendChild(element);
						}
				
						// Reset the temp variables.
						parentElement = element;
						currentException = currentException.InnerException;

						// Continue looping until we reach the end of the exception chain.
					} while (currentException != null);
					#endregion
				}
				// Return the XmlDocument.
				return xmlDoc;
			}
			catch(Exception e)
			{
				throw new SerializationException(resourceManager.GetString("RES_EXCEPTIONMANAGEMENT_XMLSERIALIZATION_EXCEPTION"),e);
			}
		}
	}
	#endregion
}