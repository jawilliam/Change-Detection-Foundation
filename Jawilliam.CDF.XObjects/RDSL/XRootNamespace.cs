using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace Jawilliam.CDF.XObjects.RDSL
{
    public partial class XRootNamespace
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XDocument doc;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XTypedElement rootObject;


        public Syntax Syntax { get { return rootObject as Syntax; } }

        private XRootNamespace()
        {
        }

        public XRootNamespace(Syntax root)
        {
            this.doc = new XDocument(root.Untyped);
            this.rootObject = root;
        }

        public XDocument XDocument
        {
            get
            {
                return doc;
            }
        }

        public static XRootNamespace Load(string xmlFile)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlFile);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Load(string xmlFile, LoadOptions options)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlFile, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Load(TextReader textReader)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(textReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Load(TextReader textReader, LoadOptions options)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(textReader, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Load(XmlReader xmlReader)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Parse(string text)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Parse(text);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public static XRootNamespace Parse(string text, LoadOptions options)
        {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Parse(text, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null))
            {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }

        public virtual void Save(string fileName)
        {
            doc.Save(fileName);
        }

        public virtual void Save(TextWriter textWriter)
        {
            doc.Save(textWriter);
        }

        public virtual void Save(XmlWriter writer)
        {
            doc.Save(writer);
        }

        public virtual void Save(TextWriter textWriter, SaveOptions options)
        {
            doc.Save(textWriter, options);
        }

        public virtual void Save(string fileName, SaveOptions options)
        {
            doc.Save(fileName, options);
        }
    }
}
