using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public static class SerializeServer
    {
        public static byte[] Serialize(MyServer server)
        {
            byte[] bytes;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, server);
                bytes = stream.ToArray();
            }
            return bytes;
        }
        public static MyServer Deserialize(byte[] bytes)
        {
            MyServer server;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                server = formatter.Deserialize(stream) as MyServer;
            }
            return server;
        }
        public static bool IsDeserializeble(byte[] bytes)
        {
            try
            {
                Deserialize(bytes);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
