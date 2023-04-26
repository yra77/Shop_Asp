

window.onload = function () {

    //found all image(slads)
    const slides = document.querySelectorAll(".slide");
    // found prev button
    const prevSlide = document.querySelector(".btn-prev");
    // slide counter
    let curSlide = 0;
    // found next button
    const nextSlide = document.querySelector(".btn-next");
    const max = slides.length - 1;
    let isRight = true;


    slides.forEach((slide, indx) => {
        slide.style.transform = `translateX(${indx * 100}%)`;
    })

    // add event listener and next slide functionality
    nextSlide.addEventListener("click", function () {

        curSlide++;
        slides.forEach((slide, indx) => {
            slide.style.transform = `translateX(${100 * (indx - curSlide)}%)`;
        });

        if (curSlide == max) {
            curSlide = -1;
        }
    });


    prevSlide.addEventListener("click", function () {
        MoveLeft();
    });

    function MoveLeft() {
        // check if current slide is the first and reset current slide to last
        if (curSlide === 0) {
            curSlide = max;
        } else {
            curSlide--;
        }

        //   move slide by 100%
        slides.forEach((slide, indx) => {
            slide.style.transform = `translateX(${100 * (indx - curSlide)}%)`;
        });
    }

    
    //auto left right
    setInterval(() => {
        if (isRight)
        {
            curSlide++;
            if (curSlide === max) { isRight = false; }
        }
        else 
        {
            curSlide--;
            if (curSlide === 0) { isRight = true; }
        }

        //   move slide by 100%
        slides.forEach((slide, indx) => {
            slide.style.transform = `translateX(${100 * (indx - curSlide)}%)`;
        });
}, 5000);

};