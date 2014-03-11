using Ninject;

namespace JWTWebApiService.Utilities
{
    public static class IocContainer
    {
        public static IKernel Initialize()
        {
            const string assemblyName = "StructureMapService";

            var kernel = new StandardKernel();
            kernel.Load(assemblyName);
            return kernel;
        }
    }
}