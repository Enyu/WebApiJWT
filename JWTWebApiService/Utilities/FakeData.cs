using System.Collections.Generic;
using JWTWebApiService.Entities;

namespace JWTWebApiService.Utilities
{
    public static class FakeData
    {
        public static List<Apple> Apples = new List<Apple>()
        {
            new Apple{AppleId = "1" ,AppleName = "red apple"},
            new Apple{AppleId = "2" ,AppleName = "blue apple"},
            new Apple{AppleId = "3" ,AppleName = "black apple"}
        };  
    }
}