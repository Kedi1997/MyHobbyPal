using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;

namespace MyHobbyPal.Client
{
    public class GetAllPersonsResultParser
        : JsonResultParserBase<IGetAllPersons>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetAllPersonsResultParser(IEnumerable<IValueSerializer> serializers)
        {
            IReadOnlyDictionary<string, IValueSerializer> map = serializers.ToDictionary();

            if (!map.TryGetValue("String", out IValueSerializer serializer))
            {
                throw new ArgumentException(
                    "There is no serializer specified for `String`.",
                    nameof(serializers));
            }
            _stringSerializer = serializer;
        }

        protected override IGetAllPersons ParserData(JsonElement data)
        {
            return new GetAllPersons
            (
                ParseGetAllPersonsPersons(data, "persons")
            );

        }

        private IReadOnlyList<IPersonType> ParseGetAllPersonsPersons(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            int objLength = obj.GetArrayLength();
            var list = new IPersonType[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new PersonType
                (
                    DeserializeString(element, "personId"),
                    DeserializeString(element, "partitionKey"),
                    DeserializeString(element, "familyName"),
                    DeserializeString(element, "givenName"),
                    DeserializeListOfString(element, "phoneNumbers")
                );

            }

            return list;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private IReadOnlyList<string> DeserializeListOfString(JsonElement obj, string fieldName)
        {
            JsonElement list = obj.GetProperty(fieldName);
            int listLength = list.GetArrayLength();
            var listList = new string[listLength];

            for (int i = 0; i < listLength; i++)
            {
                JsonElement element = list[i];
                    list[i] = (string)_stringSerializer.Deserialize(element.GetString());
            }
        }
    }
}
