export function triggerAnimation(id, animation) {
    var animateMe = document.getElementById(id);
        
    if (animateMe != null) {
        animateMe.classList.remove(...animateMe.classList);
        
        setTimeout(function () {
            animateMe.classList.add(animation);
        }, 0);
    }
}

export function hideContent(id) {
    var animateMe = document.getElementById(id);

    if (animateMe != null) {
        animateMe.classList.remove(...animateMe.classList);

        setTimeout(function () {
            animateMe.classList.add("hidden");
        }, 0);        
    }
}

export function setAnimatePropertes(settings) {
    const root = document.querySelector(':root');

    if (settings.durationInSeconds != undefined) {
        root.style.setProperty('--durationInSeconds', settings.durationInSeconds + 's');
    }
    if (settings.delayInSeconds != undefined) {
        root.style.setProperty('--delayInSeconds', settings.delayInSeconds + 's');
    }
    if (settings.iterationCount != undefined) {
        root.style.setProperty('--iterationCount', settings.iterationCount);
    }
}