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

using System.Collections.Generic;
using System.IO;
using System.Text;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;

namespace StoreCustomization_Launch
{
    // Note, these helper methods have been supplied to make the customisation process more 
    // approachable. They're not terribly sophisticated and not optimal from a performance point of view.

    public class IcaFile
    {
        private List<IcaLine> Contents { get; set; }

        public IcaFile(string filelines)
        {
            Contents = new List<IcaLine>();

            using (var reader = new StringReader(filelines))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        // End of string.
                        break;
                    }
                    Contents.Add(new IcaLine(line));
                }
            }
        }

        public string GetValueForProperty(string propname)
        {
            if (Contents == null)
            {
                // could be empty string, could throw
                return null;
            }

            foreach (IcaLine line in Contents)
            {
                if (line.Type == IcaLine.IcaLineType.Property && line.Name == propname)
                {
                    return line.Value;
                }
            }
            return null;
        }

        public bool SetValueForProperty(string propname, string newvalue, bool createIfNotFound = false)
        {
            if (Contents == null)
            {
                return false;
            }

            for (int i = 0; i < Contents.Count; i++)
            {
                IcaLine line = Contents[i];
                if (line.Type == IcaLine.IcaLineType.Property && line.Name == propname)
                {
                    Contents[i] = new IcaLine(line.Name, newvalue);
                    return true;
                }
            }

            var newprop = new IcaLine(propname, newvalue);
            Contents.Add(newprop);
            return true;
        }

        public override string ToString()
        {
            if (Contents == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            foreach (IcaLine il in Contents)
            {
                sb.AppendLine(il.ToString());
                //ICAFileStr += "\r\n";   // incl blanks
            }

            return sb.ToString();
        }
    }

    class IcaLine
    {
        public enum IcaLineType { Property, Section, Comment };

        public readonly IcaLineType Type;
        private readonly string text;
        public readonly string Name;
        public readonly string Value;

        public IcaLine(string line)
        {
            text = line ?? "";

            if (text.Length == 0)
            {
                Type = IcaLineType.Comment;
                return;
            }

            if (text[0] == '[')
            {
                Type = IcaLineType.Section;
                return;
            }

            if (text[0] == '#')
            {
                Type = IcaLineType.Comment;
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

        public IcaLine(string propname, string propvalue)
        {
            Type = IcaLineType.Property;
            Name = propname;
            Value = propvalue;
            text = Name + "=" + Value;
        }

        public override string ToString()
        {
            return text;
        }
    }
}