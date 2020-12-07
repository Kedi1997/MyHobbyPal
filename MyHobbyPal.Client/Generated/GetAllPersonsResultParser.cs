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
        private readonly IValueSerializer _booleanSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;

        public GetAllPersonsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _booleanSerializer = serializerResolver.Get("Boolean");
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IGetAllPersons ParserData(JsonElement data)
        {
            return new GetAllPersons
            (
                ParseGetAllPersonsPersons(data, "persons")
            );

        }

        private global::MyHobbyPal.Client.IPersonTypeConnection ParseGetAllPersonsPersons(
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

            return new PersonTypeConnection
            (
                ParseGetAllPersonsPersonsNodes(obj, "nodes"),
                ParseGetAllPersonsPersonsPageInfo(obj, "pageInfo")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IPersonType> ParseGetAllPersonsPersonsNodes(
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
            var list = new global::MyHobbyPal.Client.IPersonType[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new PersonType
                (
                    ParseGetAllPersonsPersonsNodesHobbies(element, "hobbies"),
                    DeserializeNullableString(element, "personId"),
                    DeserializeNullableString(element, "partitionKey"),
                    DeserializeNullableString(element, "familyName"),
                    DeserializeNullableString(element, "givenName"),
                    DeserializeNullableListOfString(element, "phoneNumbers")
                );

            }

            return list;
        }

        private global::MyHobbyPal.Client.IPageInfo ParseGetAllPersonsPersonsPageInfo(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PageInfo
            (
                DeserializeBoolean(obj, "hasNextPage"),
                DeserializeBoolean(obj, "hasPreviousPage"),
                DeserializeNullableString(obj, "startCursor"),
                DeserializeNullableString(obj, "endCursor")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> ParseGetAllPersonsPersonsNodesHobbies(
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
                    ParseGetAllPersonsPersonsNodesHobbiesHobby(element, "hobby"),
                    DeserializeNullableFloat(element, "expertiseAchieved"),
                    DeserializeNullableInt(element, "yearsPracticed"),
                    DeserializeNullableString(element, "personHobbyId")
                );

            }

            return list;
        }

        private global::MyHobbyPal.Client.IHobby ParseGetAllPersonsPersonsNodesHobbiesHobby(
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
        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
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
