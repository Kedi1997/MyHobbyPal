using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace MyHobbyPal.Client
{
    public class Queries
        : IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            109,
            107,
            99,
            114,
            79,
            107,
            116,
            90,
            116,
            77,
            112,
            81,
            55,
            121,
            87,
            81,
            72,
            112,
            68,
            57,
            57,
            103,
            61,
            61
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            103,
            101,
            116,
            65,
            108,
            108,
            80,
            101,
            114,
            115,
            111,
            110,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            112,
            101,
            114,
            115,
            111,
            110,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            112,
            101,
            114,
            115,
            111,
            110,
            73,
            100,
            32,
            112,
            97,
            114,
            116,
            105,
            116,
            105,
            111,
            110,
            75,
            101,
            121,
            32,
            102,
            97,
            109,
            105,
            108,
            121,
            78,
            97,
            109,
            101,
            32,
            103,
            105,
            118,
            101,
            110,
            78,
            97,
            109,
            101,
            32,
            112,
            104,
            111,
            110,
            101,
            78,
            117,
            109,
            98,
            101,
            114,
            115,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query getAllPersons {
              persons {
                personId
                partitionKey
                familyName
                givenName
                phoneNumbers
              }
            }";
    }
}
