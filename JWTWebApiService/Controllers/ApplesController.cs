using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JWTWebApiService.Entities;
using JWTWebApiService.Repositories;

namespace JWTWebApiService.Controllers
{
    public class ApplesController : ApiController
    {
        private readonly ApplesRepository _applesRepository;

        public ApplesController(ApplesRepository applesRepository)
        {
            _applesRepository = applesRepository;
        }

        public List<Apple> Get()
        {
            return _applesRepository.ListAll();
        }

        [Authorize]
        public HttpResponseMessage Get(string id)
        {
            var apple =  _applesRepository.GetById(id);
            return apple == null ? 
                Request.CreateResponse(HttpStatusCode.NotFound) 
                : Request.CreateResponse(HttpStatusCode.Found, apple, Configuration);
        }
    }
}