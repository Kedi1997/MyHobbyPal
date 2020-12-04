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
    public partial class UpsertHobbyForPersonResultParser
        : JsonResultParserBase<IUpsertHobbyForPerson>
    {
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _stringSerializer;

        public UpsertHobbyForPersonResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IUpsertHobbyForPerson ParserData(JsonElement data)
        {
            return new UpsertHobbyForPerson1
            (
                ParseUpsertHobbyForPersonUpsertHobbyForPerson(data, "upsertHobbyForPerson")
            );

        }

        private global::MyHobbyPal.Client.IUpsertHobbyForPersonPayload ParseUpsertHobbyForPersonUpsertHobbyForPerson(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new UpsertHobbyForPersonPayload
            (
                ParseUpsertHobbyForPersonUpsertHobbyForPersonHobbyType(obj, "hobbyType")
            );
        }

        private global::MyHobbyPal.Client.IHobbyDetail ParseUpsertHobbyForPersonUpsertHobbyForPersonHobbyType(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new HobbyDetail
            (
                ParseUpsertHobbyForPersonUpsertHobbyForPersonHobbyTypeHobby(obj, "hobby"),
                DeserializeNullableFloat(obj, "expertiseAchieved"),
                DeserializeNullableInt(obj, "yearsPracticed"),
                DeserializeNullableString(obj, "personHobbyId")
            );
        }

        private global::MyHobbyPal.Client.IHobby ParseUpsertHobbyForPersonUpsertHobbyForPersonHobbyTypeHobby(
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
    }
}
