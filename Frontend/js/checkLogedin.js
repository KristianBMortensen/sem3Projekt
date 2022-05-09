const loginID = "102474468596296399731"

window.onload = function(){
    checkCookie()
}

function checkCookie(){
    let sPath = window.location.pathname
    if(sPath != "/login.html"){
        
        if(getCookie() != loginID){
            console.log("cookie: " + getCookie() + " id: "+ loginID)
            window.location.href = "/access_denied/fail.html"
        }            
    }
}


function getCookie(){
    let name = "vasklet=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for(let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
        c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            console.log(c.substring(name.length, c.length))
        return c.substring(name.length, c.length);
        }
    }
    return "";
}