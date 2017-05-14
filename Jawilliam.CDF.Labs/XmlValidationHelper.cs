using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Jawilliam.CDF.Labs
{
    public class XmlValidationHelper
    {
        private const string webLineSeparator = "<br/>";
        private string _errorMessages = string.Empty;


        private XmlValidationHelper()
        {
            //private constructor to disable default public constructor
        }

        private void Validate(string xmlFile, string xmlSchemaFileName)
        {
            try
            {
                StringReader sr = new StringReader(xmlFile);

                // Set the validation settings on the XmlReaderSettings object.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null, xmlSchemaFileName);
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                // Create a validating reader that wraps the XmlNodeReader object.
                XmlReader reader = XmlReader.Create(sr, settings);

                // Parse the XML file.
                while (reader.Read()) ;
            }
            catch (Exception e)
            {
                throw new Exception("Exception during schema validation:" + e.Message + ":" + e.Source);
            }

        }

        public void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                return;
            }

            string newError = args.Message;  //it is possible also to use args.Exception to get more detailed information
            _errorMessages += newError; //probably there will be not too many messages to use StringBuilder
        }


        /// <summary>
        /// Static method to provide one-line access to this class.
        /// </summary>
        /// <param name="xmlFile">Xml document as string.</param>
        /// <param name="xmlSchemaFileName">Xml schema file name (absolute file name, not url).</param>
        /// <returns>Error message (void in case of success).</returns>
        public static string ValidateXml(string xmlDoc, string xmlSchemaFileName)
        {
            XmlValidationHelper helper = new XmlValidationHelper();
            helper.Validate(xmlDoc, xmlSchemaFileName);
            return helper._errorMessages;
        }
    }
}
