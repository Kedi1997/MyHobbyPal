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
    public partial class GetAllPersonsResultParser
        : JsonResultParserBase<IGetAllPersons>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _floatSerializer;

        public GetAllPersonsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _intSerializer = serializerResolver.Get("Int");
            _floatSerializer = serializerResolver.Get("Float");
        }

        protected override IGetAllPersons ParserData(JsonElement data)
        {
            return new GetAllPersons
            (
                ParseGetAllPersonsPersons(data, "persons")
            );

        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType> ParseGetAllPersonsPersons(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            int objLength = obj.GetArrayLength();
            var list = new global::MyHobbyPal.Client.IPersonType[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new PersonType
                (
                    DeserializeNullableString(element, "personId"),
                    DeserializeNullableString(element, "partitionKey"),
                    DeserializeNullableString(element, "familyName"),
                    DeserializeNullableString(element, "givenName"),
                    DeserializeNullableListOfString(element, "phoneNumbers"),
                    ParseGetAllPersonsPersonsHobbies(element, "hobbies")
                );

            }

            return list;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyType> ParseGetAllPersonsPersonsHobbies(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new global::MyHobbyPal.Client.IHobbyType[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new HobbyType
                (
                    ParseGetAllPersonsPersonsHobbiesHobby(element, "hobby"),
                    DeserializeNullableInt(element, "yearsPracticed"),
                    DeserializeNullableFloat(element, "expertiseAchieved")
                );

            }

            return list;
        }

        private global::MyHobbyPal.Client.IHobby ParseGetAllPersonsPersonsHobbiesHobby(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new Hobby
            (
                DeserializeNullableString(obj, "name"),
                DeserializeNullableFloat(obj, "difficulty")
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

        private IReadOnlyList<string> DeserializeNullableListOfString(JsonElement obj, string fieldName)
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
                listList[i] = (string)_stringSerializer.Deserialize(element.GetString());
            }
            return listList;
        }
        private int? DeserializeNullableInt(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (int?)_intSerializer.Deserialize(value.GetInt32());
        }

        private double? DeserializeNullableFloat(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (double?)_floatSerializer.Deserialize(value.GetDouble());
        }
    }
}
