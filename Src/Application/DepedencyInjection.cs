using Application.Core.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DepedencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        public static void AddUseCases(IServiceCollection services)
        {
            var baseType = typeof(IUseCase);
            var types = Assembly.GetExecutingAssembly().GetTypes();

            var useCases = types
                .Where(baseType.IsAssignableFrom)
                .Where(t => baseType != t)
                .Where(t => t.IsInterface)
                .ToList();

            foreach (var useCase in useCases) 
            {
                var impl = types
                    .Where(useCase.IsAssignableFrom)
                    .Where(t => useCase != t)
                    .FirstOrDefault(t => t.IsClass);

                if (impl == null)
                {
                    throw new Exception($"Nenhuma implementação encontrada para a interface {useCase}");
                }
                services.AddTransient(useCase, impl);
            }

        }
    }
}
