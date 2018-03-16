using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TcpMessageHelper
    {
        public static MessageBuffert Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new MessageBuffert { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(MessageBuffert message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }
    }
    public class MessageBuffert
    {
        public byte[] Data { get; set; }
    }

}
