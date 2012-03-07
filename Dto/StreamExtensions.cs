using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  public static class StreamExtensions
  {
    public static void Serialize<T>(this Stream stream, T item)
    {
      using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
      {
        new DataContractSerializer(typeof(T)).WriteObject(writer, item);
      }
    }

    public static T Deserialize<T>(this Stream stream)
    {
      T result;

      using (XmlReader reader = XmlReader.Create(stream))
      {
        result = (T)new DataContractSerializer(typeof(T)).ReadObject(reader);
      }

      return result;
    }
  }
}