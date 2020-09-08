/*************************************************************************
*
* Copyright (c) 2013-2015 Citrix Systems, Inc. All Rights Reserved.
* You may only reproduce, distribute, perform, display, or prepare derivative works of this file pursuant to a valid license from Citrix.
*
* THIS SAMPLE CODE IS PROVIDED BY CITRIX "AS IS" AND ANY EXPRESS OR IMPLIED
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*
*************************************************************************/

using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Examples.Helpers
{
    /// <summary>
    /// Helper class for writing and reading XML from/to an XML-serializable type.
    /// </summary>
    /// <typeparam name="T">The XML-serializable type.</typeparam>
    public class XmlSerializationHelper<T>
    {
        private readonly XmlSerializer xmlSerializer;

        public XmlSerializationHelper()
        {
            xmlSerializer = new XmlSerializer(typeof(T));
        }

        /// <summary>
        /// Creates an object from the supplied XML string.
        /// </summary>
        /// <param name="xml">The XML string.</param>
        /// <returns>A new object parsed from the XML.</returns>
        public T Deserialize(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serializes the specified object to an XML string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The XML string.</returns>
        public string Serialize(T obj)
        {
            var sb = new StringBuilder();
            using (var writer = new Utf8StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }

        public class Utf8StringWriter : StringWriter
        {
            public Utf8StringWriter(StringBuilder sb)
                : base(sb)
            {
            }

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}