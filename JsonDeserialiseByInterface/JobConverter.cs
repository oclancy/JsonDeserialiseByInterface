using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace JsonDeserialiseByInterface
{
    internal class JobConverter : JsonConverter<Job[]>
    {
        public override Job[] ReadJson(JsonReader reader, Type objectType, Job[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var fields = new List<Job>();
            var jsonArray = JArray.Load(reader);


            foreach (var item in jsonArray)
            {
                var jsonObject = item as JObject;
                var strType = jsonObject["type"].ToString();
                var instance = (Job)InstantiateFieldByType(strType);


                serializer.Populate(jsonObject.CreateReader(), instance);
                fields.Add(instance);

            }

            return fields.ToArray();


        }

        private object InstantiateFieldByType(string strType)
        {
            switch (strType)
            {
                case "SendMsg": return new SendMsg();
                case "Price": return new Price();
                default: throw new ArgumentException("Unknown job type:" + strType);
            }
        }

        public override void WriteJson(JsonWriter writer, Job[] value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}