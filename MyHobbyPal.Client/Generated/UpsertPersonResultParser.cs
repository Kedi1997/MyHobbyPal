using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertPersonResultParser
        : JsonResultParserBase<IUpsertPerson>
    {
        private readonly IValueSerializer _stringSerializer;

        public UpsertPersonResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IUpsertPerson ParserData(JsonElement data)
        {
            return new UpsertPerson1
            (
                ParseUpsertPersonUpsertPerson(data, "upsertPerson")
            );

        }

        private global::MyHobbyPal.Client.IPersonPayload ParseUpsertPersonUpsertPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PersonPayload
            (
                ParseUpsertPersonUpsertPersonPerson(obj, "person")
            );
        }

        private global::MyHobbyPal.Client.IPersonDetail ParseUpsertPersonUpsertPersonPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PersonDetail
            (
                DeserializeNullableString(obj, "personId"),
                DeserializeNullableString(obj, "partitionKey"),
                DeserializeNullableString(obj, "familyName"),
                DeserializeNullableString(obj, "givenName"),
                DeserializeNullableListOfNullableString(obj, "phoneNumbers")
            );
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private IReadOnlyList<string> DeserializeNullableListOfNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement list))
            {
                return null;
            }

            if (list.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int listLength = list.GetArrayLength();
            var listList = new string[listLength];

            for (int i = 0; i < listLength; i++)
            {
                JsonElement element = list[i];
                if (element.ValueKind == JsonValueKind.Null)
                {
                    listList[i] = null;
                }
                else
                {
                    listList[i] = (string)_stringSerializer.Deserialize(element.GetString());
                }
            }
            return listList;
        }
    }
}
