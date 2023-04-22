using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BarrageGrab.Utils
{
    internal class Douyu
    {
        private byte[] StringToByte(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return bytes;
        }
        private string EscapeString(string str)
        {
            return str.Replace("@", "@A").Replace("/", "@S");
        }

        public string Serialize(object obj)
        {
            if (obj is JObject)
            {
                return SerializeDictionary(((JObject)obj).ToObject<Dictionary<string, object>>());
            }
            else if (obj is JArray)
            {
                return SerializeList(((JArray)obj).ToObject<List<object>>());
            }
            else
            {
                return EscapeString(obj.ToString());
            }
        }

        private string SerializeDictionary(IDictionary dict)
        {
            var sb = new StringBuilder();
            foreach (DictionaryEntry entry in dict)
            {
                string key = EscapeString(entry.Key.ToString());
                string value = Serialize(entry.Value);
                sb.Append(key).Append("@=").Append(value).Append("/");
            }
            return sb.ToString();
        }

        private string SerializeList(IList list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(Serialize(item)).Append("/");
            }
            return sb.ToString();
        }


        public byte[] STTSerialize(string json)
        {
            var raw = JsonConvert.DeserializeObject(json);
            var str = Serialize(raw);
            return StringToByte(str);
        }

    }
}
