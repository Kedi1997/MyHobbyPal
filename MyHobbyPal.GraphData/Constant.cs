using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHobbyPal.GraphData
{
    public static class Constant
    {
        public static class EnvironmentName
        {
            public static string LocalDevelopment => nameof(LocalDevelopment);
        }

        public static class VertexLabel
        {
            public static string Person => nameof(Person);
            public static string Hobby => nameof(Hobby);
        }

        public static class EdgeLabel
        {
            public static string HasHobby => nameof(HasHobby);
        }

        public static class FieldName
        {
            public static string GivenName => nameof(GivenName);
            public static string FamilyName => nameof(FamilyName);
            public static string Name => nameof(Name);
        }

    }
}
