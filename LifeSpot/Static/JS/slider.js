const slider = document.getElementById('slider');
const prevBtn = document.getElementById('prevBtn');
const nextBtn = document.getElementById('nextBtn');

let images = [];
let currentIndex = 0;
let slides = [];
let photoPaths =

// Fetch images.json
    fetch('/Properties/images.json')
    .then(response => {
        if (!response.ok) {
            throw new Error('Failed to load images.json');
        }
        return response.json();
    })
    .then(data => {
        images = data;
        if (images.length === 0) {
            slider.innerHTML += '<p style="color:white; text-align:center; padding-top:180px;">No images to display</p>';
            return;
        }
        createSlides();
        showSlide(currentIndex);
    })
    .catch(err => {
        console.error('Error loading images:', err);
        slider.innerHTML += '<p style="color:white; text-align:center; padding-top:180px;">Unable to load images.</p>';
    });

// Create image elements for each slide
function createSlides() {
    images.forEach((src, index) => {
        const img = document.createElement('img');
        img.src = src;
        img.alt = `Slide ${index + 1}`;
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

// Prev Slide
function prevSlide() {
    currentIndex = (currentIndex - 1 + slides.length) % slides.length;
    showSlide(currentIndex);
}

// Next Slide
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


