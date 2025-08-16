// Element of HTML slider
const slider = document.getElementById('slider');

// Element of HTML previous button
const prevBtn = document.getElementById('prevBtn');
// Element of HTML next button
const nextBtn = document.getElementById('nextBtn');

let images = [];
let currentIndex = 0;
let slides = [];
let photoPaths =

// Fetch images.json
    fetch('/Properties/images.json')

    // Take a list names of images from json file
    .then(response => {
        if (!response.ok) {
            throw new Error('Failed to load images.json');
        }
        return response.json();
    })

    // Check each image and create elements
    .then(data => {
        images = data;
        if (images.length === 0) {
            slider.innerHTML += '<p style="color:white; text-align:center; padding-top:180px;">No images to display</p>';
            return;
        }
        createSlides();
        showSlide(currentIndex);
    })
    // Exception
    .catch(err => {
        console.error('Error loading images:', err);
        slider.innerHTML += '<p style="color:white; text-align:center; padding-top:180px;">Unable to load images.</p>';
    });

// Create image elements for each slide
function createSlides() {
    images.forEach((src, index) => {
        // Create <img> element
        const img = document.createElement('img');
        img.src = src;
        img.alt = `Slide ${index + 1}`;

        // Add slide how child of parent element "slider"
        slider.appendChild(img);
        slides.push(img);
    });
}

// Show slide at index
function showSlide(index) {
    slides.forEach((slide, i) => {
        slide.classList.remove('active');
        if (i === index) {
            slide.classList.add('active');
        }
    });
}

// Prev Slide button
function prevSlide() {
    currentIndex = (currentIndex - 1 + slides.length) % slides.length;
    showSlide(currentIndex);
}

// Next Slide button
function nextSlide() {
    currentIndex = (currentIndex + 1) % slides.length;
    showSlide(currentIndex);
}

prevBtn.addEventListener('click', prevSlide);
nextBtn.addEventListener('click', nextSlide);

//Optional: Auto slide every 5 seconds

setInterval(() => {
  nextSlide();
}, 5000);


