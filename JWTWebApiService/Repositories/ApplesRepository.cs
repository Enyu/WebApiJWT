using System.Collections.Generic;
using System.Linq;
using JWTWebApiService.Entities;
using JWTWebApiService.Utilities;

namespace JWTWebApiService.Repositories
{
    public class ApplesRepository
    {
        private readonly List<Apple> _apples = FakeData.Apples;

        public virtual List<Apple> ListAll()
        {
            return _apples;
        }

        public virtual Apple GetById(string id)
        {
            return _apples.FirstOrDefault(apple => apple.AppleId == id);
        }
    }
}