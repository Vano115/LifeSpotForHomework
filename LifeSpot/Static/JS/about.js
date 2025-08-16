/*
* Request user input and save this text in object
* 
* */
function getReview() {
    // Create object
    let review = {}
    
    // Save name of property
    review["userName"] = prompt("Как вас зовут ?")
    if(review["userName"] == null){
        return
    }
    
    // Save text of review
    review["comment"] = prompt("Напишите свой отзыв")
    if(review["comment"] == null){
        return
    }
    
    // Save current time
    review["date"] = new Date().toLocaleString()
    
    // Add on the page
    writeReview(review)
}

/*
* Write review on the page
* 
* */
// Created new <div> with the review
const writeReview = review => {
    document.getElementsByClassName('reviews')[0].innerHTML += '    <div class="review-text">\n' +
        `<p> <i> <b>${review['userName']}</b>  ${review['date']}</i></p>` +
        `<p>${review['comment']}</p>`  +
        '</div>';
}
