using System.Xml;

namespace LibraryNotifier.Core.Factories
{
    public class XmlReaderFactory:IFactory<string,XmlReader>
    {
        public XmlReader Create(string inputUri)
        {
            return XmlReader.Create(inputUri);
        }
    }
}