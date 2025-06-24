using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace MultipleMice
{
    // A class that saves the mice data to an Xml file. Should not be changed.
    class XmlParser
    {
        // The Location the xml will be saved at.
        private static string directoryLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Multiple Mice";
        private static string saveLocation = directoryLocation + "\\Mice Positions.xml";

        // The name of the main Xml node in the Xml file.
        private const string documentNodeName = "MiceList";

        // The name of each Mouse node in the Xml file.
        private const string mouseNodeName = "Mouse";

        // The name of the handle Attribute for each Mouse node in the Xml file.
        private const string handleAttributeName = "handle";

        // The name of the position Attribute for each Mouse node in the Xml file.
        private const string positionAttributeName = "position";

        // The name of the mouse's name Attribute for each Mouse node in the Xml file.
        private const string nameAttributeName = "name";


        private readonly XmlDocument xmlDocument;

        // The main xml node in the xml file.
        private XmlNode documentNode;

        public XmlParser()
        {
            xmlDocument = new XmlDocument();
            if (File.Exists(saveLocation))
            {
                try
                {
                    xmlDocument.Load(saveLocation);
                    documentNode = xmlDocument.FirstChild;
                }
                catch (Exception)
                {
                    Directory.CreateDirectory(directoryLocation); // If the file couldn't be read, create the directory for it.
                    documentNode = null;
                }
            }
            else
            {
                Directory.CreateDirectory(directoryLocation); // If the file doesn't exist, create the directory for it.
                documentNode = null;
            }

            if (documentNode == null || documentNode.Name != documentNodeName) // If the Xml doesn't exist, or doesn't match the format, create a new Xml file.
            {
                xmlDocument = new XmlDocument();
                documentNode = xmlDocument.CreateNode(XmlNodeType.Element, documentNodeName, xmlDocument.NamespaceURI);
                xmlDocument.AppendChild(documentNode);
            }
            xmlDocument.Save(saveLocation);
        }

        // Saves the array of the active mice to the Xml file.
        public void Save(Mouse[] mice)
        {
            SetMiceArrayToXml(mice);
            xmlDocument.Save(saveLocation);
        }

        // Parses the Mice data to the Xml file.
        private void SetMiceArrayToXml(Mouse[] mice)
        {
            documentNode.RemoveAll(); // Clears the Xml file.

            if (mice != null)
            {
                for (int i = 0; i < mice.Length; i++)
                {
                    if (mice[i] != null) // For each mouse in the array, the method creates an Xml node with the Mouse's handle, position, and name attributes.
                    {
                        XmlNode node = xmlDocument.CreateNode(XmlNodeType.Element, mouseNodeName, xmlDocument.NamespaceURI);
                        node.Attributes.Append(CreateAttribute(handleAttributeName, mice[i].Handle.ToString()));
                        node.Attributes.Append(CreateAttribute(positionAttributeName, mice[i].Rotation.ToString()));
                        node.Attributes.Append(CreateAttribute(nameAttributeName, mice[i].MouseName));
                        documentNode.AppendChild(node);
                    }
                }
            }
        }

        // A class to create an attribute using the attribute's name and value.
        private XmlAttribute CreateAttribute(string attributeName, string attributeValue)
        {
            XmlAttribute attribute = xmlDocument.CreateAttribute(attributeName);
            attribute.Value = attributeValue;
            return attribute;
        }

        // Searches for the Mouse in the Xml file using the Mouse's name attribute.
        public bool TryGetMouseFromName(string mouseName, IntPtr handle, out Mouse mouse)
        {
            mouse = null;
            foreach (XmlNode node in documentNode.ChildNodes)
            {
                XmlAttribute attribute = node.Attributes[nameAttributeName];
                if (attribute == null)
                    return false;
                if (attribute.Value == mouseName) // If the Mouse's name is found
                {
                    mouse = ParseMouseFromNode(node, mouseName, handle);
                    return true;
                }
            }
            return false;
        }

        // Creates a Mouse instance using the attributes in the Xml Node.
        private Mouse ParseMouseFromNode(XmlNode node, string name, IntPtr handle)
        {
            if (!TryGetValueFromAttribute(node, positionAttributeName, out Mouse.MousePosition mousePosition))
                throw NodeParsingException(node);

            return new Mouse(handle, name, mousePosition);
        }

        // A General Method to get an Xml Node attribute's value using the attribute's name.
        private bool TryGetValueFromAttribute<T>(XmlNode node, string attributeName, out T returnValue) where T : struct, IConvertible
        {
            returnValue = default(T);
            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute == null)
                return false;
            if (!Enum.TryParse(attribute.Value, out returnValue))
                return false;
            return true;
        }

        private bool TryGetValueFromAttribute(XmlNode node, string attributeName, out int returnValue)
        {
            returnValue = 0;
            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute == null)
                return false;
            if (!int.TryParse(attribute.Value, out returnValue))
                return false;
            return true;
        }

        private Exception NodeParsingException(XmlNode node)
        {
            return new Exception(string.Format("Couldn't parse XML node \"{0}\" Node with inner text \"{1}\" at \"{2}\"", node.Name, node.InnerText, GetNodeXpath(node)));
        }

        private string GetNodeXpath(XmlNode node)
        {
            string xPath = "";
            while (node != null)
            {
                xPath = string.Format("{0}\\{1}", node.Name, xPath);
                node = node.ParentNode;
            }
            return xPath;
        }
    }
}
