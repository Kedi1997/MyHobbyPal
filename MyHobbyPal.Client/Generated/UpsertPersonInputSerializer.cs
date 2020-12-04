using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertPersonInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;

        public string Name { get; } = "UpsertPersonInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(UpsertPersonInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _needsInitialization = false;
        }

        public object Serialize(object value)
        {
            if (_needsInitialization)
            {
                throw new InvalidOperationException(
                    $"The serializer for type `{Name}` has not been initialized.");
            }

            if (value is null)
            {
                return null;
            }

            var input = (UpsertPersonInput)value;
            var map = new Dictionary<string, object>();

            if (input.FamilyName.HasValue)
            {
                map.Add("familyName", SerializeNullableString(input.FamilyName.Value));
            }

            if (input.GivenName.HasValue)
            {
                map.Add("givenName", SerializeNullableString(input.GivenName.Value));
            }

            if (input.PartitionKey.HasValue)
            {
                map.Add("partitionKey", SerializeNullableString(input.PartitionKey.Value));
            }

            if (input.PersonId.HasValue)
            {
                map.Add("personId", SerializeNullableString(input.PersonId.Value));
            }

            if (input.PhoneNumbers.HasValue)
            {
                map.Add("phoneNumbers", SerializeNullableListOfString(input.PhoneNumbers.Value));
            }

            return map;
        }

        private object SerializeNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _stringSerializer.Serialize(value);
        }

        private object SerializeNullableListOfString(object value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object[] result = new object[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableString(source[i]);
            }
            return result;
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
