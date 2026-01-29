# MyBlazorAnimation library

### Commonly used animations for Blazor applications

### Run any custom industry standard animation

### Targeting .NET 8/9/10

This light-weight Blazor library provides a component to create commonly used animations in Blazor applications.

![MyBlazorAnimation Demo](MyBlazorAnimationDemo.gif)

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

|||
|--|--|
|bounce|bounceIn|
|fadeIn|fadeOut|
|fadeInOut|fadeOutIn|
|flip|shake|
|slideUp|slideDown|
|slideLeft|slideRight|
|swing|wobble|

Eg. to animate sliding from right to left, you can use the `Animate` component with the `slideLeft` animation.

```html
<Animate Id="myAnimation" 
         Animation="@Animate.slideLeft" 
         DurationInSeconds="3"
         IterationCount="3"
         DelayInSeconds="1"
         OnAnimationTriggered="@(async () => Console.WriteLine("Animation Triggered"))>
    <div>My content</div>
</Animate>
```

You can have any markup inside the `Animate` component. The `Animate` component will animate the content based on the animation specified.

Set the IterationCount to 1 or more to play the animation only once or more. Default is 1. Set it to 0 to play the animation infinitely.

This animation will fire automatically when the component is rendered.

### Triggering animation

If you want to trigger the animation manually in code, you can set the `IsManualTrigger` property to `true`.

And, use a component instance reference (`@ref`) to call the `TriggerAnimationBeginAsync`, `TriggerAnimationAsync` & `TriggerAnimationNowAsync` methods.

For eg. When the Search button is clicked, `OnClick` event is fired. The `SearchAsync` event handler method is called which triggers the animation.

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

    private async Task SearchAsync(MouseEventArgs e)
    {        
        await searchResultsAnimation.TriggerAnimationBeginAsync();

        //Load the data for your content
        patients = await PatientService.PatientSearchAsync(search);            

        await searchResultsAnimation.TriggerAnimationAsync();
    }
}
```

### Triggering animation dynamically

You can use `AnimateSettings` class to set up your animation.

And, call the `TriggerAnimationDynamicAsync` method using the component reference (`@ref`), to run your animation.

This will reset your running animation, if any. Also, it will set the `isManualTrigger` property to `true`;

```csharp
@code {
    private Animate searchResultsAnimation;

    private async Task AnimateMe(MouseEventArgs args)
    {
        var settings = new AnimateSettings
        {
            Animation = Animate.wobble,
            DelayInSeconds = 1,
            DurationInSeconds = 3,
            IterationCount = 3,
            OnAnimationTriggered = async () => Console.WriteLine("Animation Triggered Dynamic")
        };

        await searchResultsAnimation.TriggerAnimationDynamicAsync(settings);
    }
}
```

### Animate component properties

| Property | Description |
| --- | --- |
| Id | Unique identifier for the animation. |
| Animation | The animation to apply. |
| DurationInSeconds | The duration of the animation in seconds. Default is 1. Accepts fractions. |
| IterationCount | The number of times the animation should play. Default is 1. 0 for infinite. |
| DelayInSeconds | The delay (in seconds) before the animation starts. Default is 0. Accepts fractions.|
| OnAnimationTriggered | The event is fired after the animation has been triggered. |
| IsManualTrigger | Set to true to trigger the animation manually. Default is false. |
| @ref | Component instance reference to call the `TriggerAnimationBeginAsync`, `TriggerAnimationAsync` , `TriggerAnimationNowAsync` & `TriggerAnimationDynamicAsync` methods. |


## Run any custom industry standard animation

You can also run custom animations using the `Animate` component.

Eg. say your custom animation is `slide-right-left`.

Just enter the animation name in the `Animation` property.

```html
<Animate Id="myAnimation" 
         Animation="slide-right-left"
         DurationInSeconds="3" 
         IterationCount="0">
    <div>My content</div>
</Animate>
```

In the above example, the `slide-right-left` animation will be applied to the content inside the `Animate` component.

The CSS for the custom animation should be defined in your application's CSS file.
```css
/* Custom industry standard animation */

.slide-right-left {
    animation: var(--durationInSeconds) slide-right-left var(--iterationCount) var(--delayInSeconds);
    animation-fill-mode: forwards;
    width: 100%;
}

@keyframes slide-right-left {
    0% {
        margin-left: -100%;
    }

    50% {
        margin-left: 0%;
    }

    100% {
        margin-left: -100%;
    }
}
```

You can use the `--durationInSeconds`, `--iterationCount` and `--delayInSeconds` CSS variables to set the duration, iteration count and delay for the custom animation.

These CSS variables will be set by the `Animate` component based on it's `DurationInSeconds`, `IterationCount` and `DelayInSeconds` properties.