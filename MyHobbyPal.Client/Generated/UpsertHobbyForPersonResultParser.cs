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
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _intSerializer;

        public UpsertHobbyForPersonResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _floatSerializer = serializerResolver.Get("Float");
            _intSerializer = serializerResolver.Get("Int");
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
                ParseUpsertHobbyForPersonUpsertHobbyForPersonHobby(obj, "hobby")
            );
        }

        private global::MyHobbyPal.Client.IHobbyDetail ParseUpsertHobbyForPersonUpsertHobbyForPersonHobby(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new HobbyDetail
            (
                DeserializeNullableString(obj, "hobbyId"),
                DeserializeNullableString(obj, "partitionKey"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableFloat(obj, "difficulty"),
                DeserializeNullableFloat(obj, "expertiseAchieved"),
                DeserializeNullableInt(obj, "yearsPracticed"),
                DeserializeNullableString(obj, "personHobbyId")
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
    }
}
