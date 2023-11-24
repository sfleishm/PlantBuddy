/*
REF:
    copied from: https://codepen.io/Hyperplexed/pen/BaxROox
    video: https://www.youtube.com/watch?v=Jt3A2lNN2aE&t=142s&ab_channel=Hyperplexed
*/

const images = document.getElementsByClassName("image");

let globalIndex = 0,
    last = { x: 0, y: 0 };

const activate = (image, x, y) => {
    image.style.left = `${x}px`;
    image.style.top = `${y}px`;
    image.style.zIndex = globalIndex;

    image.dataset.status = "active";

    last = { x, y };
}

const distanceFromLast = (x, y) => {
    return Math.hypot(x - last.x, y - last.y);
}

const closeToEdge = (x, y, percent) => {
    let minWidth = 0;
    let minHeight = 0;
    let maxWidth = window.innerWidth;
    let maxHeight = window.innerHeight;

    let widthRange = maxWidth * (percent / 100);
    let heightRange = maxHeight * (percent / 100);

    if (x < minWidth + widthRange) return true;
    else if (x > maxWidth - widthRange) return true;
    else if (y < minHeight + heightRange) return true;
    else if (y > maxHeight - heightRange) return true;

    return false;
}

const handleOnMove = e => {
    if ((distanceFromLast(e.clientX, e.clientY) > (window.innerWidth / 20)) && !closeToEdge(e.clientX, e.clientY, 10)) {
        const lead = images[globalIndex % images.length],
            tail = images[(globalIndex - 5) % images.length];

        activate(lead, e.clientX, e.clientY);

        if (tail) tail.dataset.status = "inactive";

        globalIndex++;
    }
}

window.onmousemove = e => handleOnMove(e);

window.ontouchmove = e => handleOnMove(e.touches[0]);