/*
* The session is now created in the shared viewport.
* Will be captured by three functions
* 
* */ 
let session =  new Map();

/*
* Save session immidiately
* 
* */
function handleSession(){
    // Save time starting session
    session.set("startDate", new Date().toLocaleString())
    // Save UserAgent
    session.set("userAgent", window.navigator.userAgent)
}

/*
* Check user age
* 
* */
function checkAge(){
    session.set("age", prompt("Пожалуйста, введите ваш возраст?"))
    
    if(session.get("age") >= 18){
        alert("Приветствуем на LifeSpot! " + '\n' +  "Текущее время: " + new Date().toLocaleString() );
    }
    else{
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. ВыL будете перенаправлены");
        window.location.href = "http://www.google.com"
    }
}


/*
* Output in console
* 
* */
let sessionLog = function () {
    for (let result of session){
        console.log(result)
    }
}

/*
* A function for filtering content
* Will be called due to the attribute oninput на index.html
* 
* */

function filterContent(){
    let elements = document.getElementsByClassName('video-container');

    for (let i = 0; i <= elements.length; i++ ){
        let videoText = elements[i].getElementsByTagName('h3')[0].innerText;

        if(!videoText.toLowerCase().includes(inputParseFunction().toLowerCase())){
            elements[i].style.display = 'none';
        } else {
            elements[i].style.display = 'inline-block';
        }
    }
}

/*
* Всплывающее окно будет показано по таймауту
* 
* */
// setTimeout(() =>
//     alert("Нравится LifeSpot? " + '\n' +  "Подпишитесь на наш Instagram @lifespot999!" ),
// 7000);




