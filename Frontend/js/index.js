const loginID = "102474468596296399731"

window.onload = function(){
    checkCookie()
}

function init() {
    gapi.load('auth2', function() {
        /* Ready. Make a call to gapi.auth2.init or some other API */
    });
}


function onSignIn(googleUser) {
    console.log("logger ind")
    var auth2 = gapi.auth2.getAuthInstance();
    var profile = auth2.currentUser.get().getBasicProfile();
    console.log('ID: ' + profile.getId());
    console.log('Full Name: ' + profile.getName());
    console.log('Given Name: ' + profile.getGivenName());
    console.log('Family Name: ' + profile.getFamilyName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());

    console.log("loged ind")
    setCookie(profile.getId())
    console.log("cookie: "+getCookie())
    googleUser.disconnect()
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
    document.cookie = "vasklet="
    window.location.href="/Frontend/login_test/login/"
}

gapi.load('auth2', function(){
    auth2 = gapi.auth2.init({
        client_id: '842417189442-1vfdnhn31bm7poc2ba3sf5qvhj3dguvj.apps.googleusercontent.com'
    });
    auth2.attachClickHandler('signin-button', {}, onSuccess, onFailure);

    auth2.isSignedIn.listen(signinChanged);
    auth2.currentUser.listen(userChanged); // This is what you use to listen for user changes
});

var onSuccess = function (){
    getCookie()
}

var signinChanged = function (val) {
    /*console.log('Signin state changed to ', val);
    if(sPath == "/3.semProjekt/login/"){
        window.location.href="/3.semProjekt/"
    }
    document.getElementById('logged_in').innerHTML = "logged in"
    document.getElementById('logged_in').style.color = "green"*/
}

var userChanged = function (user) {
    /*if(user.getId()){
      console.log(user.getId())
      document.getElementById('logged_in').innerHTML = "logged in"
        document.getElementById('logged_in').style.color = "green"
    }*/
}

var onFailure = function(){
    /*let sPath = window.location.pathname
    let sPage = sPath.substring(sPath.lastIndexOf('/') + 1)
    if(sPath != "/3.semProjekt/login/"){
        window.location.href="/3.semProjekt/login/"
    }*/
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
        return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(id){
    document.cookie = "vasklet="+id+";path=/"
}

function checkCookie(){
    let sPath = window.location.pathname
    if(sPath != "/Frontend/login_test/login/"){
        
        if(getCookie() != loginID){
            console.log("cookie: " + getCookie() + " id: "+ loginID)
            window.location.href = "/Frontend/login_test/file.html"
        }            
    }
    console.log("cookie: "+getCookie())
}

