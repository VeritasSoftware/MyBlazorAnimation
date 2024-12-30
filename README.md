# MyBlazorAnimation library

### Targeting .NET 8/9

This library is a Blazor library that provides a component to create animations in Blazor applications.

## Installation

You can install the library via NuGet package manager.
```bash
Install-Package MyBlazorAnimation
```

## Usage

To use the library in your Blazor project, add the library to the dependency injection container.
```csharp
services.AddMyBlazorAnimation();
```

Then, you can use the provided `Animate` component in your Blazor components.

The supported animations are:
* fadeIn
* fadeOut
* fadeInOut
* fadeOutIn
* slideUp
* slideDown
* slideLeft
* slideRight

Eg. to animate sliding from right to left, you can use the `Animate` component with the `slideLeft` animation.

```html
<Animate Id="myPageAnimation" Animation="@Animate.slideLeft" DurationInSeconds="1">
    <div>My page content</div>
</Animate>
```

You can have any markup inside the `Animate` component. The `Animate` component will animate the content based on the animation specified.

This animation will fire automatically when the component is rendered. 

If you want to trigger the animation manually in code, you can set the `IsManualTrigger` property to `true`.

And, use a component instance reference (`@ref`) to call the `TriggerAnimationBeginAsync` & `TriggerAnimationAsync` methods.

```html
<Animate Id="mySearchResultsAnimation" 
         Animation="@Animate.slideLeft" 
         DurationInSeconds="0.5"
         IsManualTrigger="true"
         @ref="searchResultsAnimation">
    <div>My search results content</div>
</Animate>
```

```csharp
@code {
    private Animate searchResultsAnimation;
    private async Task Search()
    {        
        await searchResultsAnimation.TriggerAnimationBeginAsync();

        //Load the data for your content
        patients = await PatientService.PatientSearchAsync(search);            

        await searchResultsAnimation.TriggerAnimationAsync();
    }
}
```

Another method to trigger the animation instantly is `TriggerAnimationNowAsync`.