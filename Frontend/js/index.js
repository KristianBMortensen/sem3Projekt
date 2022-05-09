const url = "https://localhost:44323/api/Login/"
window.onload = function(){
    let googleBtn = document.getElementById('google-login-btn')
    auth2.attachClickHandler(googleBtn, {},
        function(googleUser) {
          document.getElementById('login-btn-text').innerText = "Signed in: " +
              googleUser.getBasicProfile().getName();
              onSignIn(googleUser)
        }, function(error) {
          alert(JSON.stringify(error, undefined, 2));
        });
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
    document.getElementById('login-btn-text').innerText = "SIGN IN WITH GOOGLE"
}

gapi.load('auth2', function(){
    auth2 = gapi.auth2.init({
        client_id: '842417189442-1vfdnhn31bm7poc2ba3sf5qvhj3dguvj.apps.googleusercontent.com'
    });
    // This is what you use to listen for user changes
});

function setCookie(id){
    document.cookie = "vasklet="+id+";path=/"
}

async function checkGoogleID(id){
    const newUrl = url+id
    const response = await axios.get(newUrl)
    const data = await response.data

    if(data == id)
    {
        setCookie(id)
        console.log("loged in successfully")
        document.location.href = "/"
    }else{
        console.log("no user was found!")
        signOut()
    }
}
