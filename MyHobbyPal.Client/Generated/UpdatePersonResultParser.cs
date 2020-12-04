﻿using System;
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
    public partial class UpdatePersonResultParser
        : JsonResultParserBase<IUpdatePerson>
    {
        private readonly IValueSerializer _stringSerializer;

        public UpdatePersonResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IUpdatePerson ParserData(JsonElement data)
        {
            return new UpdatePerson1
            (
                ParseUpdatePersonUpdatePerson(data, "updatePerson")
            );

        }

        private global::MyHobbyPal.Client.IPersonPayload1 ParseUpdatePersonUpdatePerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PersonPayload1
            (
                ParseUpdatePersonUpdatePersonPerson(obj, "person")
            );
        }

        private global::MyHobbyPal.Client.IPerson1 ParseUpdatePersonUpdatePersonPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Person1
            (
                DeserializeNullableString(obj, "partitionKey"),
                DeserializeNullableString(obj, "personId"),
                DeserializeNullableString(obj, "givenName"),
                DeserializeNullableString(obj, "familyName"),
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
