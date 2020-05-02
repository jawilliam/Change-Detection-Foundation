using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    partial class Delta
    {
        /// <summary>
        /// Gets or sets the annotations as an XML document.
        /// </summary>
        public virtual XDeltaAnnotations XAnnotations
        {
            get { return XDeltaAnnotations.Read(this.Annotations, Encoding.Unicode); }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this.Annotations = value.WriteXmlColumn();
            }
        }

        /// <summary>
        /// Gets or sets the detection result.
        /// </summary>
        public virtual object DetectionResult
        {
            get
            {
                return this.GetNativeGumTreeResult();
            }
            set
            {
                this.SetNativeGumTreeResult(value);
            }
        }

        private void SetNativeGumTreeResult(object value)
        {
            var detectionResult = value as DetectionResult;
            if (detectionResult == null)
                throw new ApplicationException("The value is expected to be a detection result.");

            var writeXmlColumn = detectionResult.WriteXmlColumn();
            var result = XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
            this.Matching = AsSqlXColumn(new XDocument(result.Element("Matches")));
            this.Differencing = AsSqlXColumn(new XDocument(result.Element("Actions")));

            if (!string.IsNullOrEmpty(detectionResult.Error))
                this.Report = result.ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><");
        }

        /// <summary>
        /// Optimizes the <see cref="object.ToString()"/>'s value to be stored as an XML column in an SQL database.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AsSqlXColumn(XNode source)
        {
            return new StringBuilder(source.ToString(SaveOptions.DisableFormatting))
                                .Replace("\r\n", "")
                                .Replace(" />  <", "/><")
                                .Replace(">  <", "><")
                                .ToString();
        }

        private object GetNativeGumTreeResult()
        {
            Debug.Assert(this.Matching != null && this.Differencing != null, "Why are we analyzing this element");
            XElement matches = XElement.Parse(this.Matching ?? "<Matches/>");
            XElement actions = XElement.Parse("<Actions/>");
            XElement result = new XElement("Result",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                matches, actions);

            var dMatches = CDF.Approach.DetectionResult.Read(result.ToString(SaveOptions.DisableFormatting), Encoding.Unicode);

            matches = XElement.Parse("<Matches/>");
            actions = XElement.Parse(this.Differencing ?? "<Actions/>");
            result = new XElement("Result",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                matches, actions);

            var dActions = CDF.Approach.DetectionResult.Read(result.ToString(SaveOptions.DisableFormatting), Encoding.Unicode);
            dActions.Matches = dMatches.Matches;

            return dActions;
        }

        /// <summary>
        /// Returns a specified node of the original tree.
        /// </summary>
        /// <param name="id">a key to specify the node of interest.</param>
        /// <returns>the node with the given key on the original tree.</returns>
        public virtual ElementTree GetOriginalNode(string id)
        {
            if(this.OriginalTree == null) throw new InvalidOperationException("Original tree information not found!");
            var tree = ElementTree.Read(this.OriginalTree, Encoding.Unicode);

            return tree.PostOrder(t => t.Children).First(t => t.Root.Id == id);
        }

        /// <summary>
        /// Returns a specified node of the modified tree.
        /// </summary>
        /// <param name="id">a key to specify the node of interest.</param>
        /// <returns>the node with the given key on the modified tree.</returns>
        public virtual ElementTree GetModifiedNode(string id)
        {
            if (this.ModifiedTree == null) throw new InvalidOperationException("Modified tree information not found!");
            var tree = ElementTree.Read(this.ModifiedTree, Encoding.Unicode);

            return tree.PostOrder(t => t.Children).First(t => t.Root.Id == id);
        }
    }
}
