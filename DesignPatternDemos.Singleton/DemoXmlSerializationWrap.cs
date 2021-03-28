using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DesignPatternDemos.Singleton
{
    /// <summary>
    /// Класс-обертка над XmlSerializer и XmlSchemaSet.
    /// Обеспечивает наличие в системе только одного экземпляра объекта XML-сериализатора и набора XSD-схем (для валидации).
    /// Наличие одного объекта обуславливается тем, что экземпляр является "тяжеловесным" и согласно описанию к типу не рекомендуется
    /// частое создание таких объектов.
    /// </summary>
    public static class DemoXmlSerializationWrap
    {
        private static readonly Lazy<XmlSchemaSet> _schemaSet = new Lazy<XmlSchemaSet>(() =>
        {
            // https://docs.microsoft.com/en-us/archive/blogs/xmlteam/xmlschemaset-thread-safety
            var xmlSchemaSet = new XmlSchemaSet();
            using TextReader streamReader = new StreamReader("../../../../DesignPatternDemos.Singleton/demo.xsd");
            xmlSchemaSet.Add("http://www.w3.org/2001/XMLSchema", XmlReader.Create(streamReader));
            xmlSchemaSet.Compile();
            return xmlSchemaSet;
        });

        public static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Country));

        public static XmlSchemaSet SchemaSet => _schemaSet.Value;
    }
}