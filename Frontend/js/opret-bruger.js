const url = "https://localhost:44323/api/LoginRequest/"

const googleId = document.getElementById('google-id')
const googleStatus = document.getElementById('google-status')

window.onload = function(){
    let googleBtn = document.getElementById('google-login-btn')
    auth2.attachClickHandler(googleBtn, {},
        function(googleUser) {         
              getGoogleId(googleUser)
        }, function(error) {
          alert(JSON.stringify(error, undefined, 2));
        });
}

function init() {
    gapi.load('auth2', function() {
        /* Ready. Make a call to gapi.auth2.init or some other API */
    });
}


function getGoogleId(googleUser){
    var auth2 = gapi.auth2.getAuthInstance();
    var profile = auth2.currentUser.get().getBasicProfile();
    console.log(profile.getId())
    googleId.value = profile.getId()
    googleStatus.innerText = "google id modtaget"
    console.log(googleId.value)
}

gapi.load('auth2', function(){
    auth2 = gapi.auth2.init({
        client_id: '842417189442-1vfdnhn31bm7poc2ba3sf5qvhj3dguvj.apps.googleusercontent.com'
    });
    // This is what you use to listen for user changes
});

Vue.createApp({
    data(){
        return {
            loginRequest: {googleId: null, fornavn: null, efternavn: null, room: null},
            requestStatus: null
        }
    },
    methods: {
        async sendRequest(){
            if(googleId.value != null && this.loginRequest.fornavn != null && this.loginRequest.efternavn != null && this.loginRequest.room != null){
                this.loginRequest.googleId = googleId.value
                const response = await axios.post(url, this.loginRequest)
                this.requestStatus = await response.status
            }else{
                this.requestStatus = "Et felt mangler at blive udfyldt"
                console.log("for: " + this.loginRequest.fornavn + " efter: " + this.loginRequest.efternavn + " id: " + googleId.value + " nummer: " + this.loginRequest.room)
            }
        }
    }
}).mount("#app")