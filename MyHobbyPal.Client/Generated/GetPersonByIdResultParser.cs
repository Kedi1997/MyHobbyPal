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
    public partial class GetPersonByIdResultParser
        : JsonResultParserBase<IGetPersonById>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;

        public GetPersonByIdResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IGetPersonById ParserData(JsonElement data)
        {
            return new GetPersonById
            (
                ParseGetPersonByIdPerson(data, "person")
            );

        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType1> ParseGetPersonByIdPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            int objLength = obj.GetArrayLength();
            var list = new global::MyHobbyPal.Client.IPersonType1[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new PersonType1
                (
                    ParseGetPersonByIdPersonHobbies(element, "hobbies"),
                    DeserializeNullableString(element, "personId"),
                    DeserializeNullableString(element, "partitionKey"),
                    DeserializeNullableString(element, "familyName"),
                    DeserializeNullableString(element, "givenName"),
                    DeserializeNullableListOfString(element, "phoneNumbers")
                );

            }

            return list;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> ParseGetPersonByIdPersonHobbies(
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
            var list = new global::MyHobbyPal.Client.IHobbyDetail[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new HobbyDetail
                (
                    ParseGetPersonByIdPersonHobbiesHobby(element, "hobby"),
                    DeserializeNullableFloat(element, "expertiseAchieved"),
                    DeserializeNullableInt(element, "yearsPracticed")
                );

            }

            return list;
        }

        private global::MyHobbyPal.Client.IHobby ParseGetPersonByIdPersonHobbiesHobby(
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
                DeserializeNullableString(obj, "hobbyId"),
                DeserializeNullableString(obj, "partitionKey"),
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
    }
}
