using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertHobbyForPersonInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _floatSerializer;
        private IValueSerializer _stringSerializer;
        private IValueSerializer _intSerializer;

        public string Name { get; } = "UpsertHobbyForPersonInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(UpsertHobbyForPersonInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _floatSerializer = serializerResolver.Get("Float");
            _stringSerializer = serializerResolver.Get("String");
            _intSerializer = serializerResolver.Get("Int");
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

            var input = (UpsertHobbyForPersonInput)value;
            var map = new Dictionary<string, object>();

            if (input.Difficulty.HasValue)
            {
                map.Add("difficulty", SerializeNullableFloat(input.Difficulty.Value));
            }

            if (input.ExpertiseAchieved.HasValue)
            {
                map.Add("expertiseAchieved", SerializeNullableFloat(input.ExpertiseAchieved.Value));
            }

            if (input.HobbyId.HasValue)
            {
                map.Add("hobbyId", SerializeNullableString(input.HobbyId.Value));
            }

            if (input.HobbyName.HasValue)
            {
                map.Add("hobbyName", SerializeNullableString(input.HobbyName.Value));
            }

            if (input.PartitionKey.HasValue)
            {
                map.Add("partitionKey", SerializeNullableString(input.PartitionKey.Value));
            }

            if (input.PersonHobbyId.HasValue)
            {
                map.Add("personHobbyId", SerializeNullableString(input.PersonHobbyId.Value));
            }

            if (input.PersonId.HasValue)
            {
                map.Add("personId", SerializeNullableString(input.PersonId.Value));
            }

            if (input.YearsPracticed.HasValue)
            {
                map.Add("yearsPracticed", SerializeNullableInt(input.YearsPracticed.Value));
            }

            return map;
        }

        private object SerializeNullableFloat(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _floatSerializer.Serialize(value);
        }
        private object SerializeNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _stringSerializer.Serialize(value);
        }
        private object SerializeNullableInt(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _intSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
