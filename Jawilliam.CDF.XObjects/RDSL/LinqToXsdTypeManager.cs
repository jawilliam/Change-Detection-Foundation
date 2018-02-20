using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using Jawilliam.CDF.XObjects.RDSL;
using Xml.Schema.Linq;

namespace Jawilliam.CDF.XObjects.RDSL
{
    public class LinqToXsdTypeManager : ILinqToXsdTypeManager
    {

        static Dictionary<XName, System.Type> elementDictionary = new Dictionary<XName, System.Type>();

        private static XmlSchemaSet schemaSet;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        static LinqToXsdTypeManager typeManagerSingleton = new LinqToXsdTypeManager();

        static LinqToXsdTypeManager()
        {
            BuildElementDictionary();
        }

        XmlSchemaSet ILinqToXsdTypeManager.Schemas
        {
            get
            {
                if ((schemaSet == null))
                {
                    XmlSchemaSet tempSet = new XmlSchemaSet();
                    System.Threading.Interlocked.CompareExchange(ref schemaSet, tempSet, null);
                }
                return schemaSet;
            }
            set
            {
                schemaSet = value;
            }
        }

        Dictionary<XName, System.Type> ILinqToXsdTypeManager.GlobalTypeDictionary
        {
            get
            {
                return XTypedServices.EmptyDictionary;
            }
        }

        Dictionary<XName, System.Type> ILinqToXsdTypeManager.GlobalElementDictionary
        {
            get
            {
                return elementDictionary;
            }
        }

        Dictionary<System.Type, System.Type> ILinqToXsdTypeManager.RootContentTypeMapping
        {
            get
            {
                return XTypedServices.EmptyTypeMappingDictionary;
            }
        }

        public static LinqToXsdTypeManager Instance
        {
            get
            {
                return typeManagerSingleton;
            }
        }

        private static void BuildElementDictionary()
        {
            elementDictionary.Add(XName.Get("Syntax", "http://tempuri.org/XNodeTypeSystem.xsd"), typeof(Syntax));
        }

        protected internal static void AddSchemas(XmlSchemaSet schemas)
        {
            schemas.Add(schemaSet);
        }

        public static System.Type GetRootType()
        {
            return elementDictionary[XName.Get("Syntax", "http://tempuri.org/XNodeTypeSystem.xsd")];
        }
    }
}
