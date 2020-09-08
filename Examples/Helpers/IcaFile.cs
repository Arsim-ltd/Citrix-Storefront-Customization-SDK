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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;

namespace Examples.Helpers
{
    // Note, these helper methods have been supplied to make the customisation process more 
    // approachable. They're not terribly sophisticated and not optimal from a performance point of view.
    public class IcaFile
    {
        /// <summary>
        /// A special value that can be used as the section name when reading or writing application section property values.
        /// The real section name depends upon the name of the application being launched.
        /// </summary>
        public const string ApplicationSection = "_Application_";

        private readonly List<IcaLine> preamble = new List<IcaLine>();
        private readonly List<IcaSection> sections = new List<IcaSection>();
        private readonly string applicationSectionName;

        public IcaFile(string icaFileContent)
        {
            IcaSection currentSection = null;
            foreach (IcaLine line in GetLines(icaFileContent))
            {
                switch (line.Type)
                {
                    case IcaLine.IcaLineType.Section:
                        currentSection = new IcaSection(line.Name);
                        sections.Add(currentSection);
                        break;
                    case IcaLine.IcaLineType.Comment:
                    case IcaLine.IcaLineType.Property:
                        (currentSection != null ? currentSection.Lines : preamble).Add(line);
                        break;
                }
            }

            // now find the application section name
            var applicationServersSection = FindSection("ApplicationServers");
            if (applicationServersSection != null)
            {
                var nameProperty = applicationServersSection.Lines.Find(line => line.Type == IcaLine.IcaLineType.Property);
                if (nameProperty != null)
                {
                    applicationSectionName = nameProperty.Name;
                }
            }
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The value of the property; or <c>null</c> if the section or property were not found.</returns>
        public string GetPropertyValue(string sectionName, string propertyName)
        {
            var section = FindSection(sectionName);
            return section != null ? section.GetPropertyValue(propertyName) : null;
        }

        /// <summary>
        /// Sets the property value, updating an existing line or adding a new one as needed.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <returns><c>true</c> if successful; otherwise <c>false</c>.</returns>
        public bool SetPropertyValue(string sectionName, string propertyName, string value)
        {
            var section = FindSection(sectionName);
            return section != null && section.SetPropertyValue(propertyName, value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in preamble)
            {
                sb.AppendLine(line.ToString());
            }

            foreach (IcaSection section in sections)
            {
                section.WriteToStringBuilder(sb);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private IcaSection FindSection(string sectionName)
        {
            string realSectionName = sectionName == ApplicationSection ? applicationSectionName : sectionName;
            return sections.FirstOrDefault(section => section.Name.Equals(realSectionName, StringComparison.InvariantCultureIgnoreCase));
        }

        private IEnumerable<IcaLine> GetLines(string content)
        {
            using (var reader = new StringReader(content))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        yield return new IcaLine(line);
                    }
                }
            }
        }

        private class IcaSection
        {
            public IcaSection(string name)
            {
                Name = name;
                Lines = new List<IcaLine>();
            }

            public string Name { get; private set; }

            public List<IcaLine> Lines { get; private set; }

            public void WriteToStringBuilder(StringBuilder sb)
            {
                sb.AppendFormat("[{0}]", Name);
                sb.AppendLine();
                foreach (var line in Lines)
                {
                    sb.AppendLine(line.ToString());
                }
            }

            public string GetPropertyValue(string propertyName)
            {
                int index = FindPropertyIndex(propertyName);
                return index == -1 ? null : Lines[index].Value;
            }

            public bool SetPropertyValue(string propertyName, string propertyValue)
            {
                var newProperty = new IcaLine(propertyName, propertyValue);

                // insert or replace the new line as appropriate
                int index = FindPropertyIndex(propertyName);
                if (index == -1)
                {
                    Lines.Add(newProperty);
                }
                else
                {
                    Lines[index] = newProperty;
                }

                return true;
            }

            private int FindPropertyIndex(string propertyName)
            {
                return Lines.FindIndex(
                    line => line.Type == IcaLine.IcaLineType.Property 
                            && line.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        private class IcaLine
        {
            public enum IcaLineType
            {
                Property,
                Section,
                Comment
            };

            public readonly IcaLineType Type;

            private readonly string text;

            public readonly string Name;

            public readonly string Value;

            public IcaLine(string line)
            {
                text = line ?? string.Empty;

                if (text.Length == 0 || text[0] == '#' || text[0] == ';')
                {
                    Type = IcaLineType.Comment;
                    return;
                }

                if (text[0] == '[')
                {
                    Type = IcaLineType.Section;
                    Name = text.Substring(1).Trim().TrimEnd(']');
                    return;
                }

                int eqidx = text.IndexOf('=');
                if (eqidx != -1)
                {
                    Type = IcaLineType.Property;
                    Name = text.Substring(0, eqidx);
                    Value = text.Substring(eqidx + 1);
                }
                else
                {
                    Tracer.TraceInfo("IcaLine: unexpected linestyle for: " + text);
                    Type = IcaLineType.Comment;
                }
            }

            public IcaLine(string propertyName, string value)
            {
                Type = IcaLineType.Property;
                Name = propertyName;
                Value = value;
                text = Name + "=" + Value;
            }

            public override string ToString()
            {
                return text;
            }
        }
    }
}