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
    public partial class GetPersonWithHobbiesResultParser
        : JsonResultParserBase<IGetPersonWithHobbies>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;

        public GetPersonWithHobbiesResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IGetPersonWithHobbies ParserData(JsonElement data)
        {
            return new GetPersonWithHobbies
            (
                ParseGetPersonWithHobbiesPersonWithHobbies(data, "personWithHobbies")
            );

        }

        private global::MyHobbyPal.Client.IPersonWithHobbies ParseGetPersonWithHobbiesPersonWithHobbies(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PersonWithHobbies
            (
                ParseGetPersonWithHobbiesPersonWithHobbiesPerson(obj, "person"),
                ParseGetPersonWithHobbiesPersonWithHobbiesHobbies(obj, "hobbies")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::MyHobbyPal.Client.IHobbyDetail> ParseGetPersonWithHobbiesPersonWithHobbiesHobbies(
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
                    DeserializeNullableString(element, "hobbyId"),
                    DeserializeNullableString(element, "partitionKey"),
                    DeserializeNullableString(element, "name"),
                    DeserializeNullableFloat(element, "difficulty"),
                    DeserializeNullableFloat(element, "expertiseAchieved"),
                    DeserializeNullableInt(element, "yearsPracticed"),
                    DeserializeNullableString(element, "personHobbyId")
                );

            }

            return list;
        }

        private global::MyHobbyPal.Client.IPersonDetail ParseGetPersonWithHobbiesPersonWithHobbiesPerson(
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
