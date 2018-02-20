using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Jawilliam.CDF.XObjects.RDSL
{
    /// <summary>
    /// <para>
    /// Regular expression: (Nodes)
    /// </para>
    /// </summary>
    public partial class Syntax : XTypedElement, IXMetaData
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string languageFixedValue = "C#";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ContentModelEntity contentModel;

        public static explicit operator Syntax(XElement xe) { return XTypedServices.ToXTypedElement<Syntax>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        static Syntax()
        {
            BuildElementDictionary();
            contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Nodes", "http://tempuri.org/XNodeTypeSystem.xsd")));
        }

        /// <summary>
        /// <para>
        /// Regular expression: (Nodes)
        /// </para>
        /// </summary>
        public Syntax()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: required
        /// </para>
        /// <para>
        /// Regular expression: (Nodes)
        /// </para>
        /// </summary>
        public NodesLocalType Nodes
        {
            get
            {
                XElement x = this.GetElement(XName.Get("Nodes", "http://tempuri.org/XNodeTypeSystem.xsd"));
                return ((NodesLocalType)(x));
            }
            set
            {
                this.SetElement(XName.Get("Nodes", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: required
        /// </para>
        /// </summary>
        public string language
        {
            get
            {
                return languageFixedValue;
            }
            set
            {
                if (value.Equals(languageFixedValue))
                {
                }
                else {
                    throw new Xml.Schema.Linq.LinqToXsdFixedValueException(value, languageFixedValue);
                }
                this.SetAttribute(XName.Get("language", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
        {
            get
            {
                return localElementDictionary;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("Syntax", "http://tempuri.org/XNodeTypeSystem.xsd");
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        SchemaOrigin IXMetaData.TypeOrigin
        {
            get
            {
                return SchemaOrigin.Element;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILinqToXsdTypeManager IXMetaData.TypeManager
        {
            get
            {
                return LinqToXsdTypeManager.Instance;
            }
        }

        public void Save(string xmlFile)
        {
            XTypedServices.Save(xmlFile, Untyped);
        }

        public void Save(System.IO.TextWriter tw)
        {
            XTypedServices.Save(tw, Untyped);
        }

        public void Save(System.Xml.XmlWriter xmlWriter)
        {
            XTypedServices.Save(xmlWriter, Untyped);
        }

        public static Syntax Load(string xmlFile)
        {
            return XTypedServices.Load<Syntax>(xmlFile);
        }

        public static Syntax Load(System.IO.TextReader xmlFile)
        {
            return XTypedServices.Load<Syntax>(xmlFile);
        }

        public static Syntax Parse(string xml)
        {
            return XTypedServices.Parse<Syntax>(xml);
        }

        public override XTypedElement Clone()
        {
            return XTypedServices.CloneXTypedElement<Syntax>(this);
        }

        private static void BuildElementDictionary()
        {
            localElementDictionary.Add(XName.Get("Nodes", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(NodesLocalType));
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return contentModel;
        }

        /// <summary>
        /// <para>
        /// Regular expression: (Type*)
        /// </para>
        /// </summary>
        public partial class NodesLocalType : XTypedElement, IXMetaData
        {

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private XTypedList<TypeLocalType> TypeField;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private static ContentModelEntity contentModel;

            public static explicit operator NodesLocalType(XElement xe) { return XTypedServices.ToXTypedElement<NodesLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

            static NodesLocalType()
            {
                BuildElementDictionary();
                contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd")));
            }

            /// <summary>
            /// <para>
            /// Regular expression: (Type*)
            /// </para>
            /// </summary>
            public NodesLocalType()
            {
            }

            /// <summary>
            /// <para>
            /// Occurrence: optional, repeating
            /// </para>
            /// <para>
            /// Regular expression: (Type*)
            /// </para>
            /// </summary>
            public IList<Syntax.NodesLocalType.TypeLocalType> Type
            {
                get
                {
                    if ((this.TypeField == null))
                    {
                        this.TypeField = new XTypedList<TypeLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"));
                    }
                    return this.TypeField;
                }
                set
                {
                    if ((value == null))
                    {
                        this.TypeField = null;
                    }
                    else {
                        if ((this.TypeField == null))
                        {
                            this.TypeField = XTypedList<TypeLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        }
                        else {
                            XTypedServices.SetList<TypeLocalType>(this.TypeField, value);
                        }
                    }
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
            {
                get
                {
                    return localElementDictionary;
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            XName IXMetaData.SchemaName
            {
                get
                {
                    return XName.Get("Nodes", "http://tempuri.org/XNodeTypeSystem.xsd");
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            SchemaOrigin IXMetaData.TypeOrigin
            {
                get
                {
                    return SchemaOrigin.Fragment;
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            ILinqToXsdTypeManager IXMetaData.TypeManager
            {
                get
                {
                    return LinqToXsdTypeManager.Instance;
                }
            }

            public override XTypedElement Clone()
            {
                return XTypedServices.CloneXTypedElement<NodesLocalType>(this);
            }

            private static void BuildElementDictionary()
            {
                localElementDictionary.Add(XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(TypeLocalType));
            }

            ContentModelEntity IXMetaData.GetContentModel()
            {
                return contentModel;
            }

            /// <summary>
            /// <para>
            /// Regular expression: (Properties?, Rules?, Annotations?)
            /// </para>
            /// </summary>
            public partial class TypeLocalType : XTypedElement, IXMetaData
            {

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool @abstractDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool tokenDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static ContentModelEntity contentModel;

                public static explicit operator TypeLocalType(XElement xe) { return XTypedServices.ToXTypedElement<TypeLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                static TypeLocalType()
                {
                    BuildElementDictionary();
                    contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd")));
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Properties?, Rules?, Annotations?)
                /// </para>
                /// </summary>
                public TypeLocalType()
                {
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// <para>
                /// Regular expression: (Properties?, Rules?, Annotations?)
                /// </para>
                /// </summary>
                public PropertiesLocalType Properties
                {
                    get
                    {
                        XElement x = this.GetElement(XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        return ((PropertiesLocalType)(x));
                    }
                    set
                    {
                        this.SetElement(XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// <para>
                /// Regular expression: (Properties?, Rules?, Annotations?)
                /// </para>
                /// </summary>
                public RulesLocalType Rules
                {
                    get
                    {
                        XElement x = this.GetElement(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        return ((RulesLocalType)(x));
                    }
                    set
                    {
                        this.SetElement(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// <para>
                /// Regular expression: (Properties?, Rules?, Annotations?)
                /// </para>
                /// </summary>
                public AnnotationsLocalType Annotations
                {
                    get
                    {
                        XElement x = this.GetElement(XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        return ((AnnotationsLocalType)(x));
                    }
                    set
                    {
                        this.SetElement(XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: required
                /// </para>
                /// </summary>
                public string name
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("name", ""));
                        return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("name", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public bool @abstract
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("abstract", ""));
                        return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, @abstractDefaultValue);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("abstract", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public string @base
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("base", ""));
                        return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("base", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public bool token
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("token", ""));
                        return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, tokenDefaultValue);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("token", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                    }
                }

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
                {
                    get
                    {
                        return localElementDictionary;
                    }
                }

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                XName IXMetaData.SchemaName
                {
                    get
                    {
                        return XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd");
                    }
                }

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                SchemaOrigin IXMetaData.TypeOrigin
                {
                    get
                    {
                        return SchemaOrigin.Fragment;
                    }
                }

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                ILinqToXsdTypeManager IXMetaData.TypeManager
                {
                    get
                    {
                        return LinqToXsdTypeManager.Instance;
                    }
                }

                public override XTypedElement Clone()
                {
                    return XTypedServices.CloneXTypedElement<TypeLocalType>(this);
                }

                private static void BuildElementDictionary()
                {
                    localElementDictionary.Add(XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(PropertiesLocalType));
                    localElementDictionary.Add(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(RulesLocalType));
                    localElementDictionary.Add(XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(AnnotationsLocalType));
                }

                ContentModelEntity IXMetaData.GetContentModel()
                {
                    return contentModel;
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Property+)
                /// </para>
                /// </summary>
                public partial class PropertiesLocalType : XTypedElement, IXMetaData
                {

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<PropertyLocalType> PropertyField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private static ContentModelEntity contentModel;

                    public static explicit operator PropertiesLocalType(XElement xe) { return XTypedServices.ToXTypedElement<PropertiesLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                    static PropertiesLocalType()
                    {
                        BuildElementDictionary();
                        contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd")));
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (Property+)
                    /// </para>
                    /// </summary>
                    public PropertiesLocalType()
                    {
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required, repeating
                    /// </para>
                    /// <para>
                    /// Regular expression: (Property+)
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType> Property
                    {
                        get
                        {
                            if ((this.PropertyField == null))
                            {
                                this.PropertyField = new XTypedList<PropertyLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.PropertyField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.PropertyField = null;
                            }
                            else {
                                if ((this.PropertyField == null))
                                {
                                    this.PropertyField = XTypedList<PropertyLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<PropertyLocalType>(this.PropertyField, value);
                                }
                            }
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
                    {
                        get
                        {
                            return localElementDictionary;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    XName IXMetaData.SchemaName
                    {
                        get
                        {
                            return XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd");
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    SchemaOrigin IXMetaData.TypeOrigin
                    {
                        get
                        {
                            return SchemaOrigin.Fragment;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    ILinqToXsdTypeManager IXMetaData.TypeManager
                    {
                        get
                        {
                            return LinqToXsdTypeManager.Instance;
                        }
                    }

                    public override XTypedElement Clone()
                    {
                        return XTypedServices.CloneXTypedElement<PropertiesLocalType>(this);
                    }

                    private static void BuildElementDictionary()
                    {
                        localElementDictionary.Add(XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(PropertyLocalType));
                    }

                    ContentModelEntity IXMetaData.GetContentModel()
                    {
                        return contentModel;
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (Text, Children, Matching?, EditScript)
                    /// </para>
                    /// </summary>
                    public partial class PropertyLocalType : XTypedElement, IXMetaData
                    {

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static bool @readOnlyDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static bool optionalDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static bool changepointDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static bool inheritedDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static string multiplicityDefaultValue = "Single";

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static ContentModelEntity contentModel;

                        public static explicit operator PropertyLocalType(XElement xe) { return XTypedServices.ToXTypedElement<PropertyLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        static PropertyLocalType()
                        {
                            BuildElementDictionary();
                            contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Text", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Children", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Matching", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("EditScript", "http://tempuri.org/XNodeTypeSystem.xsd")));
                        }

                        /// <summary>
                        /// <para>
                        /// Regular expression: (Text, Children, Matching?, EditScript)
                        /// </para>
                        /// </summary>
                        public PropertyLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// <para>
                        /// Regular expression: (Text, Children, Matching?, EditScript)
                        /// </para>
                        /// </summary>
                        public TextLocalType Text
                        {
                            get
                            {
                                XElement x = this.GetElement(XName.Get("Text", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                return ((TextLocalType)(x));
                            }
                            set
                            {
                                this.SetElement(XName.Get("Text", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// <para>
                        /// Regular expression: (Text, Children, Matching?, EditScript)
                        /// </para>
                        /// </summary>
                        public ChildrenLocalType Children
                        {
                            get
                            {
                                XElement x = this.GetElement(XName.Get("Children", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                return ((ChildrenLocalType)(x));
                            }
                            set
                            {
                                this.SetElement(XName.Get("Children", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// <para>
                        /// Regular expression: (Text, Children, Matching?, EditScript)
                        /// </para>
                        /// </summary>
                        public MatchingLocalType Matching
                        {
                            get
                            {
                                XElement x = this.GetElement(XName.Get("Matching", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                return ((MatchingLocalType)(x));
                            }
                            set
                            {
                                this.SetElement(XName.Get("Matching", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// <para>
                        /// Regular expression: (Text, Children, Matching?, EditScript)
                        /// </para>
                        /// </summary>
                        public EditScriptLocalType EditScript
                        {
                            get
                            {
                                XElement x = this.GetElement(XName.Get("EditScript", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                return ((EditScriptLocalType)(x));
                            }
                            set
                            {
                                this.SetElement(XName.Get("EditScript", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string name
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("name", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("name", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string kind
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("kind", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("kind", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public int index
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("index", ""));
                                return XTypedServices.ParseValue<int>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("index", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public bool @readOnly
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("readOnly", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, @readOnlyDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("readOnly", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public bool optional
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("optional", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, optionalDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("optional", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public bool changepoint
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("changepoint", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, changepointDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("changepoint", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public bool inherited
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("inherited", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, inheritedDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("inherited", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public string multiplicity
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("multiplicity", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype, multiplicityDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("multiplicity", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public string collectionType
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("collectionType", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("collectionType", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public string collectionSeparator
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("collectionSeparator", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("collectionSeparator", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
                        {
                            get
                            {
                                return localElementDictionary;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<PropertyLocalType>(this);
                        }

                        private static void BuildElementDictionary()
                        {
                            localElementDictionary.Add(XName.Get("Text", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(TextLocalType));
                            localElementDictionary.Add(XName.Get("Children", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(ChildrenLocalType));
                            localElementDictionary.Add(XName.Get("Matching", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(MatchingLocalType));
                            localElementDictionary.Add(XName.Get("EditScript", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(EditScriptLocalType));
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return contentModel;
                        }

                        public partial class TextLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool valueDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            public static explicit operator TextLocalType(XElement xe) { return XTypedServices.ToXTypedElement<TextLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            public TextLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool value
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("value", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, valueDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("value", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string prefix
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("prefix", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("prefix", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string postfix
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("postfix", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("postfix", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string @fixed
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("fixed", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("fixed", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            XName IXMetaData.SchemaName
                            {
                                get
                                {
                                    return XName.Get("Text", "http://tempuri.org/XNodeTypeSystem.xsd");
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            SchemaOrigin IXMetaData.TypeOrigin
                            {
                                get
                                {
                                    return SchemaOrigin.Fragment;
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            ILinqToXsdTypeManager IXMetaData.TypeManager
                            {
                                get
                                {
                                    return LinqToXsdTypeManager.Instance;
                                }
                            }

                            public override XTypedElement Clone()
                            {
                                return XTypedServices.CloneXTypedElement<TextLocalType>(this);
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return ContentModelEntity.Default;
                            }
                        }

                        public partial class ChildrenLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool fineDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool coarseDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            public static explicit operator ChildrenLocalType(XElement xe) { return XTypedServices.ToXTypedElement<ChildrenLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            public ChildrenLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool fine
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("fine", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, fineDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("fine", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool coarse
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("coarse", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, coarseDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("coarse", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            XName IXMetaData.SchemaName
                            {
                                get
                                {
                                    return XName.Get("Children", "http://tempuri.org/XNodeTypeSystem.xsd");
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            SchemaOrigin IXMetaData.TypeOrigin
                            {
                                get
                                {
                                    return SchemaOrigin.Fragment;
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            ILinqToXsdTypeManager IXMetaData.TypeManager
                            {
                                get
                                {
                                    return LinqToXsdTypeManager.Instance;
                                }
                            }

                            public override XTypedElement Clone()
                            {
                                return XTypedServices.CloneXTypedElement<ChildrenLocalType>(this);
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return ContentModelEntity.Default;
                            }
                        }

                        public partial class MatchingLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool signatureDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool meaningfulDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool jaggedDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool valueDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            public static explicit operator MatchingLocalType(XElement xe) { return XTypedServices.ToXTypedElement<MatchingLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            public MatchingLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: required
                            /// </para>
                            /// </summary>
                            public string criterion
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("criterion", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("criterion", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string changeDistillerCriterion
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("changeDistillerCriterion", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("changeDistillerCriterion", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool signature
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("signature", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, signatureDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("signature", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public System.Nullable<int> signatureLevel
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("signatureLevel", ""));
                                    if ((x == null))
                                    {
                                        return null;
                                    }
                                    return XTypedServices.ParseValue<int>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("signatureLevel", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool meaningful
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("meaningful", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, meaningfulDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("meaningful", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool jagged
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("jagged", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, jaggedDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("jagged", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool value
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("value", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, valueDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("value", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string prefix
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("prefix", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("prefix", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public string postfix
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("postfix", ""));
                                    return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("postfix", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            XName IXMetaData.SchemaName
                            {
                                get
                                {
                                    return XName.Get("Matching", "http://tempuri.org/XNodeTypeSystem.xsd");
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            SchemaOrigin IXMetaData.TypeOrigin
                            {
                                get
                                {
                                    return SchemaOrigin.Fragment;
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            ILinqToXsdTypeManager IXMetaData.TypeManager
                            {
                                get
                                {
                                    return LinqToXsdTypeManager.Instance;
                                }
                            }

                            public override XTypedElement Clone()
                            {
                                return XTypedServices.CloneXTypedElement<MatchingLocalType>(this);
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return ContentModelEntity.Default;
                            }
                        }

                        public partial class EditScriptLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool insertDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool deleteDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool updateDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool updatemodifyDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool updatereplaceDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool alignDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool alignswapDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool moveDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            public static explicit operator EditScriptLocalType(XElement xe) { return XTypedServices.ToXTypedElement<EditScriptLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            public EditScriptLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool insert
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("insert", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, insertDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("insert", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool delete
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("delete", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, deleteDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("delete", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool update
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("update", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, updateDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("update", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool updatemodify
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("update-modify", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, updatemodifyDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("update-modify", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool updatereplace
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("update-replace", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, updatereplaceDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("update-replace", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool align
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("align", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, alignDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("align", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool alignswap
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("align-swap", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, alignswapDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("align-swap", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool move
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("move", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, moveDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("move", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            XName IXMetaData.SchemaName
                            {
                                get
                                {
                                    return XName.Get("EditScript", "http://tempuri.org/XNodeTypeSystem.xsd");
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            SchemaOrigin IXMetaData.TypeOrigin
                            {
                                get
                                {
                                    return SchemaOrigin.Fragment;
                                }
                            }

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            ILinqToXsdTypeManager IXMetaData.TypeManager
                            {
                                get
                                {
                                    return LinqToXsdTypeManager.Instance;
                                }
                            }

                            public override XTypedElement Clone()
                            {
                                return XTypedServices.CloneXTypedElement<EditScriptLocalType>(this);
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return ContentModelEntity.Default;
                            }
                        }
                    }
                }

                /// <summary>
                /// <para>
                /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                /// </para>
                /// </summary>
                public partial class RulesLocalType : XTypedElement, IXMetaData
                {

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<IfNullThenNullLocalType> IfNullThenNullField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<IfNullThenNotNullLocalType> IfNullThenNotNullField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<IfNotNullThenNullLocalType> IfNotNullThenNullField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<IfNotNullThenNotNullLocalType> IfNotNullThenNotNullField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                    public static explicit operator RulesLocalType(XElement xe) { return XTypedServices.ToXTypedElement<RulesLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                    static RulesLocalType()
                    {
                        BuildElementDictionary();
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                    /// </para>
                    /// </summary>
                    public RulesLocalType()
                    {
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required, choice
                    /// </para>
                    /// <para>
                    /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.RulesLocalType.IfNullThenNullLocalType> IfNullThenNull
                    {
                        get
                        {
                            if ((this.IfNullThenNullField == null))
                            {
                                this.IfNullThenNullField = new XTypedList<IfNullThenNullLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("IfNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.IfNullThenNullField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.IfNullThenNullField = null;
                            }
                            else {
                                if ((this.IfNullThenNullField == null))
                                {
                                    this.IfNullThenNullField = XTypedList<IfNullThenNullLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("IfNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<IfNullThenNullLocalType>(this.IfNullThenNullField, value);
                                }
                            }
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required, choice
                    /// </para>
                    /// <para>
                    /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.RulesLocalType.IfNullThenNotNullLocalType> IfNullThenNotNull
                    {
                        get
                        {
                            if ((this.IfNullThenNotNullField == null))
                            {
                                this.IfNullThenNotNullField = new XTypedList<IfNullThenNotNullLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("IfNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.IfNullThenNotNullField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.IfNullThenNotNullField = null;
                            }
                            else {
                                if ((this.IfNullThenNotNullField == null))
                                {
                                    this.IfNullThenNotNullField = XTypedList<IfNullThenNotNullLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("IfNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<IfNullThenNotNullLocalType>(this.IfNullThenNotNullField, value);
                                }
                            }
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required, choice
                    /// </para>
                    /// <para>
                    /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.RulesLocalType.IfNotNullThenNullLocalType> IfNotNullThenNull
                    {
                        get
                        {
                            if ((this.IfNotNullThenNullField == null))
                            {
                                this.IfNotNullThenNullField = new XTypedList<IfNotNullThenNullLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("IfNotNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.IfNotNullThenNullField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.IfNotNullThenNullField = null;
                            }
                            else {
                                if ((this.IfNotNullThenNullField == null))
                                {
                                    this.IfNotNullThenNullField = XTypedList<IfNotNullThenNullLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("IfNotNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<IfNotNullThenNullLocalType>(this.IfNotNullThenNullField, value);
                                }
                            }
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required, choice
                    /// </para>
                    /// <para>
                    /// Regular expression: (IfNullThenNull | IfNullThenNotNull | IfNotNullThenNull | IfNotNullThenNotNull)+
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.RulesLocalType.IfNotNullThenNotNullLocalType> IfNotNullThenNotNull
                    {
                        get
                        {
                            if ((this.IfNotNullThenNotNullField == null))
                            {
                                this.IfNotNullThenNotNullField = new XTypedList<IfNotNullThenNotNullLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("IfNotNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.IfNotNullThenNotNullField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.IfNotNullThenNotNullField = null;
                            }
                            else {
                                if ((this.IfNotNullThenNotNullField == null))
                                {
                                    this.IfNotNullThenNotNullField = XTypedList<IfNotNullThenNotNullLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("IfNotNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<IfNotNullThenNotNullLocalType>(this.IfNotNullThenNotNullField, value);
                                }
                            }
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
                    {
                        get
                        {
                            return localElementDictionary;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    XName IXMetaData.SchemaName
                    {
                        get
                        {
                            return XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd");
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    SchemaOrigin IXMetaData.TypeOrigin
                    {
                        get
                        {
                            return SchemaOrigin.Fragment;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    ILinqToXsdTypeManager IXMetaData.TypeManager
                    {
                        get
                        {
                            return LinqToXsdTypeManager.Instance;
                        }
                    }

                    public override XTypedElement Clone()
                    {
                        return XTypedServices.CloneXTypedElement<RulesLocalType>(this);
                    }

                    private static void BuildElementDictionary()
                    {
                        localElementDictionary.Add(XName.Get("IfNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(IfNullThenNullLocalType));
                        localElementDictionary.Add(XName.Get("IfNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(IfNullThenNotNullLocalType));
                        localElementDictionary.Add(XName.Get("IfNotNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(IfNotNullThenNullLocalType));
                        localElementDictionary.Add(XName.Get("IfNotNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(IfNotNullThenNotNullLocalType));
                    }

                    ContentModelEntity IXMetaData.GetContentModel()
                    {
                        return ContentModelEntity.Default;
                    }

                    public partial class IfNullThenNullLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator IfNullThenNullLocalType(XElement xe) { return XTypedServices.ToXTypedElement<IfNullThenNullLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public IfNullThenNullLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string principal
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("principal", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("principal", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string dependent
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("dependent", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("dependent", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("IfNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<IfNullThenNullLocalType>(this);
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return ContentModelEntity.Default;
                        }
                    }

                    public partial class IfNullThenNotNullLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator IfNullThenNotNullLocalType(XElement xe) { return XTypedServices.ToXTypedElement<IfNullThenNotNullLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public IfNullThenNotNullLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string principal
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("principal", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("principal", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string dependent
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("dependent", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("dependent", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("IfNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<IfNullThenNotNullLocalType>(this);
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return ContentModelEntity.Default;
                        }
                    }

                    public partial class IfNotNullThenNullLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator IfNotNullThenNullLocalType(XElement xe) { return XTypedServices.ToXTypedElement<IfNotNullThenNullLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public IfNotNullThenNullLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string principal
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("principal", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("principal", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string dependent
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("dependent", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("dependent", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("IfNotNullThenNull", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<IfNotNullThenNullLocalType>(this);
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return ContentModelEntity.Default;
                        }
                    }

                    public partial class IfNotNullThenNotNullLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator IfNotNullThenNotNullLocalType(XElement xe) { return XTypedServices.ToXTypedElement<IfNotNullThenNotNullLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public IfNotNullThenNotNullLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string principal
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("principal", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("principal", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string dependent
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("dependent", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("dependent", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("IfNotNullThenNotNull", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<IfNotNullThenNotNullLocalType>(this);
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return ContentModelEntity.Default;
                        }
                    }
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Annotation)+
                /// </para>
                /// </summary>
                public partial class AnnotationsLocalType : XTypedElement, IXMetaData
                {

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<AnnotationLocalType> AnnotationField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                    public static explicit operator AnnotationsLocalType(XElement xe) { return XTypedServices.ToXTypedElement<AnnotationsLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                    static AnnotationsLocalType()
                    {
                        BuildElementDictionary();
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (Annotation)+
                    /// </para>
                    /// </summary>
                    public AnnotationsLocalType()
                    {
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: required
                    /// </para>
                    /// <para>
                    /// Regular expression: (Annotation)+
                    /// </para>
                    /// </summary>
                    public IList<NodesLocalType.TypeLocalType.AnnotationsLocalType.AnnotationLocalType> Annotation
                    {
                        get
                        {
                            if ((this.AnnotationField == null))
                            {
                                this.AnnotationField = new XTypedList<AnnotationLocalType>(this, LinqToXsdTypeManager.Instance, XName.Get("Annotation", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.AnnotationField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.AnnotationField = null;
                            }
                            else {
                                if ((this.AnnotationField == null))
                                {
                                    this.AnnotationField = XTypedList<AnnotationLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Annotation", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else {
                                    XTypedServices.SetList<AnnotationLocalType>(this.AnnotationField, value);
                                }
                            }
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    Dictionary<XName, System.Type> IXMetaData.LocalElementsDictionary
                    {
                        get
                        {
                            return localElementDictionary;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    XName IXMetaData.SchemaName
                    {
                        get
                        {
                            return XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd");
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    SchemaOrigin IXMetaData.TypeOrigin
                    {
                        get
                        {
                            return SchemaOrigin.Fragment;
                        }
                    }

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    ILinqToXsdTypeManager IXMetaData.TypeManager
                    {
                        get
                        {
                            return LinqToXsdTypeManager.Instance;
                        }
                    }

                    public override XTypedElement Clone()
                    {
                        return XTypedServices.CloneXTypedElement<AnnotationsLocalType>(this);
                    }

                    private static void BuildElementDictionary()
                    {
                        localElementDictionary.Add(XName.Get("Annotation", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(AnnotationLocalType));
                    }

                    ContentModelEntity IXMetaData.GetContentModel()
                    {
                        return ContentModelEntity.Default;
                    }

                    public partial class AnnotationLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator AnnotationLocalType(XElement xe) { return XTypedServices.ToXTypedElement<AnnotationLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public AnnotationLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string context
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("context", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("context", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public string role
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("role", ""));
                                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("role", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        XName IXMetaData.SchemaName
                        {
                            get
                            {
                                return XName.Get("Annotation", "http://tempuri.org/XNodeTypeSystem.xsd");
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        SchemaOrigin IXMetaData.TypeOrigin
                        {
                            get
                            {
                                return SchemaOrigin.Fragment;
                            }
                        }

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        ILinqToXsdTypeManager IXMetaData.TypeManager
                        {
                            get
                            {
                                return LinqToXsdTypeManager.Instance;
                            }
                        }

                        public override XTypedElement Clone()
                        {
                            return XTypedServices.CloneXTypedElement<AnnotationLocalType>(this);
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return ContentModelEntity.Default;
                        }
                    }
                }
            }
        }
    }
}
