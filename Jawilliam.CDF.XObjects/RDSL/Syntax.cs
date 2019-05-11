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
                else
                {
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
                    else
                    {
                        if ((this.TypeField == null))
                        {
                            this.TypeField = XTypedList<TypeLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        }
                        else
                        {
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
            /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
            /// </para>
            /// </summary>
            public partial class TypeLocalType : XTypedElement, IXMetaData
            {

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool @abstractDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool tokenDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool @operatorDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool @readonlyDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static bool symbolicDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                private static ContentModelEntity contentModel;

                public static explicit operator TypeLocalType(XElement xe) { return XTypedServices.ToXTypedElement<TypeLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                static TypeLocalType()
                {
                    BuildElementDictionary();
                    contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Properties", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Annotations", "http://tempuri.org/XNodeTypeSystem.xsd")));
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
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
                /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
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
                /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
                /// </para>
                /// </summary>
                public OptionsLocalType Options
                {
                    get
                    {
                        XElement x = this.GetElement(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"));
                        return ((OptionsLocalType)(x));
                    }
                    set
                    {
                        this.SetElement(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// <para>
                /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
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
                /// Regular expression: (Properties?, Options?, Rules?, Annotations?)
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

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public bool @operator
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("operator", ""));
                        return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, @operatorDefaultValue);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("operator", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public bool @readonly
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("readonly", ""));
                        return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, @readonlyDefaultValue);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("readonly", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                    }
                }

                /// <summary>
                /// <para>
                /// Occurrence: optional
                /// </para>
                /// </summary>
                public bool symbolic
                {
                    get
                    {
                        XAttribute x = this.Attribute(XName.Get("symbolic", ""));
                        return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, symbolicDefaultValue);
                    }
                    set
                    {
                        this.SetAttribute(XName.Get("symbolic", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                    localElementDictionary.Add(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(OptionsLocalType));
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
                    public IList<Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType> Property
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
                            else
                            {
                                if ((this.PropertyField == null))
                                {
                                    this.PropertyField = XTypedList<PropertyLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Property", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else
                                {
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
                    /// Regular expression: (Options?, Rules?)
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
                        private static bool invisibleDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                        private static ContentModelEntity contentModel;

                        public static explicit operator PropertyLocalType(XElement xe) { return XTypedServices.ToXTypedElement<PropertyLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        static PropertyLocalType()
                        {
                            BuildElementDictionary();
                            contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd")));
                        }

                        /// <summary>
                        /// <para>
                        /// Regular expression: (Options?, Rules?)
                        /// </para>
                        /// </summary>
                        public PropertyLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// <para>
                        /// Regular expression: (Options?, Rules?)
                        /// </para>
                        /// </summary>
                        public OptionsLocalType Options
                        {
                            get
                            {
                                XElement x = this.GetElement(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                return ((OptionsLocalType)(x));
                            }
                            set
                            {
                                this.SetElement(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// <para>
                        /// Regular expression: (Options?, Rules?)
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

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public System.Nullable<bool> keyword
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("keyword", ""));
                                if ((x == null))
                                {
                                    return null;
                                }
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("keyword", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public System.Nullable<bool> @operator
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("operator", ""));
                                if ((x == null))
                                {
                                    return null;
                                }
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("operator", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public System.Nullable<bool> puntuaction
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("puntuaction", ""));
                                if ((x == null))
                                {
                                    return null;
                                }
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("puntuaction", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public bool invisible
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("invisible", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, invisibleDefaultValue);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("invisible", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                            localElementDictionary.Add(XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(OptionsLocalType));
                            localElementDictionary.Add(XName.Get("Rules", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(RulesLocalType));
                        }

                        ContentModelEntity IXMetaData.GetContentModel()
                        {
                            return contentModel;
                        }

                        /// <summary>
                        /// <para>
                        /// Regular expression: (Kind*)
                        /// </para>
                        /// </summary>
                        public partial class OptionsLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private XTypedList<PropertyLabelOption> KindField;

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static bool labelingDefaultValue = System.Xml.XmlConvert.ToBoolean("false");

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static ContentModelEntity contentModel;

                            public static explicit operator OptionsLocalType(XElement xe) { return XTypedServices.ToXTypedElement<OptionsLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            static OptionsLocalType()
                            {
                                BuildElementDictionary();
                                contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Kind", "http://tempuri.org/XNodeTypeSystem.xsd")));
                            }

                            /// <summary>
                            /// <para>
                            /// Regular expression: (Kind*)
                            /// </para>
                            /// </summary>
                            public OptionsLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional, repeating
                            /// </para>
                            /// <para>
                            /// Regular expression: (Kind*)
                            /// </para>
                            /// </summary>
                            public IList<PropertyLabelOption> Kind
                            {
                                get
                                {
                                    if ((this.KindField == null))
                                    {
                                        this.KindField = new XTypedList<PropertyLabelOption>(this, LinqToXsdTypeManager.Instance, XName.Get("Kind", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    }
                                    return this.KindField;
                                }
                                set
                                {
                                    if ((value == null))
                                    {
                                        this.KindField = null;
                                    }
                                    else
                                    {
                                        if ((this.KindField == null))
                                        {
                                            this.KindField = XTypedList<PropertyLabelOption>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Kind", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                        }
                                        else
                                        {
                                            XTypedServices.SetList<PropertyLabelOption>(this.KindField, value);
                                        }
                                    }
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public System.Nullable<bool> exclusive
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("exclusive", ""));
                                    if ((x == null))
                                    {
                                        return null;
                                    }
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("exclusive", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public bool labeling
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("labeling", ""));
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, labelingDefaultValue);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("labeling", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                                    return XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd");
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
                                return XTypedServices.CloneXTypedElement<OptionsLocalType>(this);
                            }

                            private static void BuildElementDictionary()
                            {
                                localElementDictionary.Add(XName.Get("Kind", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(PropertyLabelOption));
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return contentModel;
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                        /// </para>
                        /// </summary>
                        public partial class RulesLocalType : XTypedElement, IXMetaData
                        {

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                            private static ContentModelEntity contentModel;

                            public static explicit operator RulesLocalType(XElement xe) { return XTypedServices.ToXTypedElement<RulesLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                            static RulesLocalType()
                            {
                                BuildElementDictionary();
                                contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Pairwise", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Topology", "http://tempuri.org/XNodeTypeSystem.xsd")));
                            }

                            /// <summary>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public RulesLocalType()
                            {
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public KeyRules Signature
                            {
                                get
                                {
                                    XElement x = this.GetElement(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    return ((KeyRules)(x));
                                }
                                set
                                {
                                    this.SetElement(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public NameLocalType Name
                            {
                                get
                                {
                                    XElement x = this.GetElement(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    return ((NameLocalType)(x));
                                }
                                set
                                {
                                    this.SetElement(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public SuitabilityRule Hint
                            {
                                get
                                {
                                    XElement x = this.GetElement(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    return ((SuitabilityRule)(x));
                                }
                                set
                                {
                                    this.SetElement(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public PairwiseRules Pairwise
                            {
                                get
                                {
                                    XElement x = this.GetElement(XName.Get("Pairwise", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    return ((PairwiseRules)(x));
                                }
                                set
                                {
                                    this.SetElement(XName.Get("Pairwise", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// <para>
                            /// Regular expression: (Signature?, Name?, Hint?, Pairwise?, Topology?)
                            /// </para>
                            /// </summary>
                            public TopologyRules Topology
                            {
                                get
                                {
                                    XElement x = this.GetElement(XName.Get("Topology", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                    return ((TopologyRules)(x));
                                }
                                set
                                {
                                    this.SetElement(XName.Get("Topology", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                                }
                            }

                            /// <summary>
                            /// <para>
                            /// Occurrence: optional
                            /// </para>
                            /// </summary>
                            public System.Nullable<bool> essential
                            {
                                get
                                {
                                    XAttribute x = this.Attribute(XName.Get("essential", ""));
                                    if ((x == null))
                                    {
                                        return null;
                                    }
                                    return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                                }
                                set
                                {
                                    this.SetAttribute(XName.Get("essential", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                                localElementDictionary.Add(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(KeyRules));
                                localElementDictionary.Add(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(NameLocalType));
                                localElementDictionary.Add(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(SuitabilityRule));
                                localElementDictionary.Add(XName.Get("Pairwise", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(PairwiseRules));
                                localElementDictionary.Add(XName.Get("Topology", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(TopologyRules));
                            }

                            ContentModelEntity IXMetaData.GetContentModel()
                            {
                                return contentModel;
                            }

                            /// <summary>
                            /// <para>
                            /// Regular expression: (Equality?, Similarity?)
                            /// </para>
                            /// </summary>
                            public partial class NameLocalType : global::Jawilliam.CDF.XObjects.RDSL.KeyRules, IXMetaData
                            {

                                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                                static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                                private static ContentModelEntity contentModel;

                                public static explicit operator NameLocalType(XElement xe) { return XTypedServices.ToXTypedElement<NameLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                                static NameLocalType()
                                {
                                    BuildElementDictionary();
                                    contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd")));
                                }

                                /// <summary>
                                /// <para>
                                /// Regular expression: (Equality?, Similarity?)
                                /// </para>
                                /// </summary>
                                public NameLocalType()
                                {
                                }

                                /// <summary>
                                /// <para>
                                /// Occurrence: optional
                                /// </para>
                                /// </summary>
                                public string conventionPattern
                                {
                                    get
                                    {
                                        XAttribute x = this.Attribute(XName.Get("conventionPattern", ""));
                                        return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
                                    }
                                    set
                                    {
                                        this.SetAttribute(XName.Get("conventionPattern", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
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
                                        return XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd");
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
                                    return XTypedServices.CloneXTypedElement<NameLocalType>(this);
                                }

                                private static void BuildElementDictionary()
                                {
                                    localElementDictionary.Add(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(EqualityOrSimilarityRules));
                                    localElementDictionary.Add(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(EqualityOrSimilarityRules));
                                }

                                ContentModelEntity IXMetaData.GetContentModel()
                                {
                                    return contentModel;
                                }
                            }
                        }
                    }
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Type*)
                /// </para>
                /// </summary>
                public partial class OptionsLocalType : XTypedElement, IXMetaData
                {

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private XTypedList<TypeLabelOption> TypeField;

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private static ContentModelEntity contentModel;

                    public static explicit operator OptionsLocalType(XElement xe) { return XTypedServices.ToXTypedElement<OptionsLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                    static OptionsLocalType()
                    {
                        BuildElementDictionary();
                        contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd")));
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (Type*)
                    /// </para>
                    /// </summary>
                    public OptionsLocalType()
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
                    public IList<TypeLabelOption> Type
                    {
                        get
                        {
                            if ((this.TypeField == null))
                            {
                                this.TypeField = new XTypedList<TypeLabelOption>(this, LinqToXsdTypeManager.Instance, XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            }
                            return this.TypeField;
                        }
                        set
                        {
                            if ((value == null))
                            {
                                this.TypeField = null;
                            }
                            else
                            {
                                if ((this.TypeField == null))
                                {
                                    this.TypeField = XTypedList<TypeLabelOption>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else
                                {
                                    XTypedServices.SetList<TypeLabelOption>(this.TypeField, value);
                                }
                            }
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// </summary>
                    public System.Nullable<bool> exclusive
                    {
                        get
                        {
                            XAttribute x = this.Attribute(XName.Get("exclusive", ""));
                            if ((x == null))
                            {
                                return null;
                            }
                            return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                        }
                        set
                        {
                            this.SetAttribute(XName.Get("exclusive", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                            return XName.Get("Options", "http://tempuri.org/XNodeTypeSystem.xsd");
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
                        return XTypedServices.CloneXTypedElement<OptionsLocalType>(this);
                    }

                    private static void BuildElementDictionary()
                    {
                        localElementDictionary.Add(XName.Get("Type", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(TypeLabelOption));
                    }

                    ContentModelEntity IXMetaData.GetContentModel()
                    {
                        return contentModel;
                    }
                }

                /// <summary>
                /// <para>
                /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                /// </para>
                /// </summary>
                public partial class RulesLocalType : XTypedElement, IXMetaData
                {

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

                    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                    private static ContentModelEntity contentModel;

                    public static explicit operator RulesLocalType(XElement xe) { return XTypedServices.ToXTypedElement<RulesLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                    static RulesLocalType()
                    {
                        BuildElementDictionary();
                        contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Alias", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Compatibility", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Granularity", "http://tempuri.org/XNodeTypeSystem.xsd")));
                    }

                    /// <summary>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public RulesLocalType()
                    {
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public KeyRules Signature
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((KeyRules)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public KeyRules Name
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((KeyRules)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public SuitabilityRule Hint
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((SuitabilityRule)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public SuitabilityRule Alias
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Alias", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((SuitabilityRule)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Alias", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public SuitabilityRule Compatibility
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Compatibility", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((SuitabilityRule)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Compatibility", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
                        }
                    }

                    /// <summary>
                    /// <para>
                    /// Occurrence: optional
                    /// </para>
                    /// <para>
                    /// Regular expression: (Signature?, Name?, Hint?, Alias?, Compatibility?, Granularity?)
                    /// </para>
                    /// </summary>
                    public GranularityLocalType Granularity
                    {
                        get
                        {
                            XElement x = this.GetElement(XName.Get("Granularity", "http://tempuri.org/XNodeTypeSystem.xsd"));
                            return ((GranularityLocalType)(x));
                        }
                        set
                        {
                            this.SetElement(XName.Get("Granularity", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
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
                        localElementDictionary.Add(XName.Get("Signature", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(KeyRules));
                        localElementDictionary.Add(XName.Get("Name", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(KeyRules));
                        localElementDictionary.Add(XName.Get("Hint", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(SuitabilityRule));
                        localElementDictionary.Add(XName.Get("Alias", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(SuitabilityRule));
                        localElementDictionary.Add(XName.Get("Compatibility", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(SuitabilityRule));
                        localElementDictionary.Add(XName.Get("Granularity", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(GranularityLocalType));
                    }

                    ContentModelEntity IXMetaData.GetContentModel()
                    {
                        return contentModel;
                    }

                    public partial class GranularityLocalType : XTypedElement, IXMetaData
                    {

                        public static explicit operator GranularityLocalType(XElement xe) { return XTypedServices.ToXTypedElement<GranularityLocalType>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

                        public GranularityLocalType()
                        {
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: optional
                        /// </para>
                        /// </summary>
                        public System.Nullable<bool> fine
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("fine", ""));
                                if ((x == null))
                                {
                                    return null;
                                }
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                            set
                            {
                                this.SetAttribute(XName.Get("fine", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
                            }
                        }

                        /// <summary>
                        /// <para>
                        /// Occurrence: required
                        /// </para>
                        /// </summary>
                        public bool coarse
                        {
                            get
                            {
                                XAttribute x = this.Attribute(XName.Get("coarse", ""));
                                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
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
                                return XName.Get("Granularity", "http://tempuri.org/XNodeTypeSystem.xsd");
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
                            return XTypedServices.CloneXTypedElement<GranularityLocalType>(this);
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
                    public IList<Syntax.NodesLocalType.TypeLocalType.AnnotationsLocalType.AnnotationLocalType> Annotation
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
                            else
                            {
                                if ((this.AnnotationField == null))
                                {
                                    this.AnnotationField = XTypedList<AnnotationLocalType>.Initialize(this, LinqToXsdTypeManager.Instance, value, XName.Get("Annotation", "http://tempuri.org/XNodeTypeSystem.xsd"));
                                }
                                else
                                {
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

    public partial class TypeLabelOption : XTypedElement, IXMetaData
    {

        public static explicit operator TypeLabelOption(XElement xe) { return XTypedServices.ToXTypedElement<TypeLabelOption>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public TypeLabelOption()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("TypeLabelOption", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<TypeLabelOption>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }

    public partial class PropertyLabelOption : global::Jawilliam.CDF.XObjects.RDSL.TypeLabelOption, IXMetaData
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static bool @readonlyDefaultValue = System.Xml.XmlConvert.ToBoolean("true");

        public static explicit operator PropertyLabelOption(XElement xe) { return XTypedServices.ToXTypedElement<PropertyLabelOption>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public PropertyLabelOption()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public string type
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("type", ""));
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("type", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> keyword
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("keyword", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("keyword", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> @operator
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("operator", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("operator", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> puntuaction
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("puntuaction", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("puntuaction", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> expression
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("expression", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("expression", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> literal
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("literal", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("literal", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> identifier
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("identifier", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("identifier", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public bool @readonly
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("readonly", ""));
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype, @readonlyDefaultValue);
            }
            set
            {
                this.SetAttribute(XName.Get("readonly", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("PropertyLabelOption", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<PropertyLabelOption>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }

    public partial class EqualityOrSimilarityRules : XTypedElement, IXMetaData
    {

        public static explicit operator EqualityOrSimilarityRules(XElement xe) { return XTypedServices.ToXTypedElement<EqualityOrSimilarityRules>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public EqualityOrSimilarityRules()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> full
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("full", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("full", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> partial
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("partial", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("partial", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("EqualityOrSimilarityRules", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<EqualityOrSimilarityRules>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }

    /// <summary>
    /// <para>
    /// Regular expression: (Equality?, Similarity?)
    /// </para>
    /// </summary>
    public partial class KeyRules : XTypedElement, IXMetaData
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        static Dictionary<XName, System.Type> localElementDictionary = new Dictionary<XName, System.Type>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ContentModelEntity contentModel;

        public static explicit operator KeyRules(XElement xe) { return XTypedServices.ToXTypedElement<KeyRules>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        static KeyRules()
        {
            BuildElementDictionary();
            contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd")), new NamedContentModelEntity(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd")));
        }

        /// <summary>
        /// <para>
        /// Regular expression: (Equality?, Similarity?)
        /// </para>
        /// </summary>
        public KeyRules()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// <para>
        /// Regular expression: (Equality?, Similarity?)
        /// </para>
        /// </summary>
        public EqualityOrSimilarityRules Equality
        {
            get
            {
                XElement x = this.GetElement(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd"));
                return ((EqualityOrSimilarityRules)(x));
            }
            set
            {
                this.SetElement(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// <para>
        /// Regular expression: (Equality?, Similarity?)
        /// </para>
        /// </summary>
        public EqualityOrSimilarityRules Similarity
        {
            get
            {
                XElement x = this.GetElement(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd"));
                return ((EqualityOrSimilarityRules)(x));
            }
            set
            {
                this.SetElement(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd"), value);
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
                return XName.Get("KeyRules", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<KeyRules>(this);
        }

        private static void BuildElementDictionary()
        {
            localElementDictionary.Add(XName.Get("Equality", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(EqualityOrSimilarityRules));
            localElementDictionary.Add(XName.Get("Similarity", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(EqualityOrSimilarityRules));
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return contentModel;
        }
    }

    public partial class SuitabilityRule : XTypedElement, IXMetaData
    {

        public static explicit operator SuitabilityRule(XElement xe) { return XTypedServices.ToXTypedElement<SuitabilityRule>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public SuitabilityRule()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> suitable
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("suitable", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("suitable", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("SuitabilityRule", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<SuitabilityRule>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }

    public partial class PairwiseRules : XTypedElement, IXMetaData
    {

        public static explicit operator PairwiseRules(XElement xe) { return XTypedServices.ToXTypedElement<PairwiseRules>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public PairwiseRules()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> tunneling
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("tunneling", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("tunneling", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> discriminant
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("discriminant", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("discriminant", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<byte> priority
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("priority", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<byte>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedByte).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("priority", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedByte).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("PairwiseRules", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<PairwiseRules>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }

    public partial class TopologyRules : XTypedElement, IXMetaData
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static byte relevancyDefaultValue = System.Xml.XmlConvert.ToByte("0");

        public static explicit operator TopologyRules(XElement xe) { return XTypedServices.ToXTypedElement<TopologyRules>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

        public TopologyRules()
        {
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> relevant
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("relevant", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("relevant", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public byte relevancy
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("relevancy", ""));
                return XTypedServices.ParseValue<byte>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedByte).Datatype, relevancyDefaultValue);
            }
            set
            {
                this.SetAttribute(XName.Get("relevancy", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedByte).Datatype);
            }
        }

        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public System.Nullable<bool> leaf
        {
            get
            {
                XAttribute x = this.Attribute(XName.Get("leaf", ""));
                if ((x == null))
                {
                    return null;
                }
                return XTypedServices.ParseValue<bool>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
            set
            {
                this.SetAttribute(XName.Get("leaf", ""), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean).Datatype);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        XName IXMetaData.SchemaName
        {
            get
            {
                return XName.Get("TopologyRules", "http://tempuri.org/XNodeTypeSystem.xsd");
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
            return XTypedServices.CloneXTypedElement<TopologyRules>(this);
        }

        ContentModelEntity IXMetaData.GetContentModel()
        {
            return ContentModelEntity.Default;
        }
    }
}
