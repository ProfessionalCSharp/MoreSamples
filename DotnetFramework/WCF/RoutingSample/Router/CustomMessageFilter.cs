using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace Router
{
  public class CustomMessageFilter : MessageFilter
  {
    private string filterParam;
    public CustomMessageFilter(string filterParam)
    {
      this.filterParam = filterParam;
    }

    public override bool Match(Message message)
    {
      return true;
    }

    public override bool Match(MessageBuffer buffer)
    {
      XPathExpression expr = XPathExpression.Compile(string.Format("////value == {0}", filterParam));
    
      XPathNavigator navigator = buffer.CreateNavigator();
      return navigator.Matches(expr);
      //XDocument doc = await GetMessageEnvelope(buffer);
      //return Match(doc);
    }

    private bool Match(XDocument doc)
    {
      string result = doc.Elements("value").Where(x => x.Value == "HelloA").SingleOrDefault().Value;
      return result != null;
    }

    private async Task<XDocument> GetMessageEnvelope(MessageBuffer buffer)
    {
      using (var stream = new MemoryStream())
      {
        var msg = buffer.CreateMessage();
        XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream);
        msg.WriteMessage(writer);
        await writer.FlushAsync();
        stream.Seek(0, SeekOrigin.Begin);
        XDocument doc = XDocument.Load(stream);
        return doc;

      }
    }
  }
}
