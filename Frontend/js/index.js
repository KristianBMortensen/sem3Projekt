const url = "https://localhost:44323/api/Login/"

window.onload = function(){
    checkCookie()
}

function init() {
    gapi.load('auth2', function() {
        /* Ready. Make a call to gapi.auth2.init or some other API */
    });
}


function onSignIn(googleUser) {
    var auth2 = gapi.auth2.getAuthInstance();
    var profile = auth2.currentUser.get().getBasicProfile();
    /*console.log('ID: ' + profile.getId());
    console.log('Full Name: ' + profile.getName());
    console.log('Given Name: ' + profile.getGivenName());
    console.log('Family Name: ' + profile.getFamilyName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());*/
    checkGoogleID(profile.getId())
    console.log(profile.getId())
    googleUser.disconnect()
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
    document.cookie = "vasklet=;path=/;expires=Thu, 01 Jan 1970 00:00:01 GMT;"
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
    //skal være for ikke at få fejl, men ellers ligegyldig
    //Bollsjen
}

var userChanged = function (user) {
    //skal være for ikke at få fejl, men ellers ligegyldig
    //Bollsjen
}

var onFailure = function(){
    //skal være for ikke at få fejl, men ellers ligegyldig
    //Bollsjen
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
    console.log(getCookie())
}

function checkCookie(){
    let sPath = window.location.pathname
    console.log("cookie: (" + getCookie()+")")
    if(sPath != "/Frontend/login_test/login/"){
        
        if(getCookie() == ""){
            window.location.href = "/Frontend/login_test/fail.html"
        }            
    }
}

async function checkGoogleID(id){
    const newUrl = url+id
    const response = await axios.get(newUrl)
    const data = await response.data

    if(data == id)
    {
        setCookie(id)
        console.log("loged in successfully")
        document.location.href = "/Frontend/login_test/"
    }else{
        console.log("no user was found!")
        signOut()
    }
}

