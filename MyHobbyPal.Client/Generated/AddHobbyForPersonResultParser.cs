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
    public partial class AddHobbyForPersonResultParser
        : JsonResultParserBase<IAddHobbyForPerson>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;

        public AddHobbyForPersonResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IAddHobbyForPerson ParserData(JsonElement data)
        {
            return new AddHobbyForPerson
            (
                ParseAddHobbyForPersonUpsertHobbyForPerson(data, "upsertHobbyForPerson")
            );

        }

        private global::MyHobbyPal.Client.IAddHobbyForPersonPayload ParseAddHobbyForPersonUpsertHobbyForPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new AddHobbyForPersonPayload
            (
                ParseAddHobbyForPersonUpsertHobbyForPersonHobby(obj, "hobby"),
                ParseAddHobbyForPersonUpsertHobbyForPersonPersonHobbyLink(obj, "personHobbyLink")
            );
        }

        private global::MyHobbyPal.Client.IHobby2 ParseAddHobbyForPersonUpsertHobbyForPersonHobby(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Hobby2
            (
                DeserializeNullableString(obj, "hobbyId"),
                DeserializeNullableString(obj, "partitionKey"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableFloat(obj, "difficulty")
            );
        }

        private global::MyHobbyPal.Client.IPersonHobbyLink ParseAddHobbyForPersonUpsertHobbyForPersonPersonHobbyLink(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PersonHobbyLink
            (
                DeserializeFloat(obj, "expertiseAchieved"),
                DeserializeInt(obj, "yearsPracticed")
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
        private double DeserializeFloat(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (double)_floatSerializer.Deserialize(value.GetDouble());
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
    }
}
