using Microsoft.Extensions.DependencyInjection;

namespace MyBlazorAnimation
{
    public static class Extensions
    {
        public static IServiceCollection AddMyBlazorAnimation(this IServiceCollection services)
        {
            services.AddSingleton<IAnimationJSLoader, AnimationJSLoader>();
            return services;
        }
    }
}
