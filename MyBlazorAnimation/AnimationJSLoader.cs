using Microsoft.JSInterop;
namespace MyBlazorAnimation
{
    public interface IAnimationJSLoader
    {
        ValueTask DisposeAsync();
        Task HideContentAsync(string id);
        Task TriggerAnimationAsync(string id, string animation);
        Task SetAnimatePropertesAsync(AnimateSettings settings);
    }

    public class AnimationJSLoader : IAsyncDisposable, IAnimationJSLoader
    {
        private readonly Lazy<Task<IJSObjectReference>> _loadJSTask;

        private IJSRuntime JSRuntime { get; set; }

        public AnimationJSLoader(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;

            _loadJSTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/MyBlazorAnimation/animation.js").AsTask());
        }

        public async Task TriggerAnimationAsync(string id, string animation)
        {
            var module = await _loadJSTask.Value;
            await module.InvokeVoidAsync("triggerAnimation", id, animation);
        }

        public async Task HideContentAsync(string id)
        {
            var module = await _loadJSTask.Value;
            await module.InvokeVoidAsync("hideContent", id);
        }

        public async Task SetAnimatePropertesAsync(AnimateSettings settings)
        {
            var module = await _loadJSTask.Value;
            await module.InvokeVoidAsync("setAnimatePropertes", settings);
        }

        public async ValueTask DisposeAsync()
        {
            if (_loadJSTask.IsValueCreated)
            {
                var module = await _loadJSTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
