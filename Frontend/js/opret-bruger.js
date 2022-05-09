const url = "https://localhost:44323/api/Login/"

const googleId = document.getElementById('google-id')
const googleStatus = document.getElementById('google-status')

window.onload = function(){
    let googleBtn = document.getElementById('google-login-btn')
    auth2.attachClickHandler(googleBtn, {},
        function(googleUser) {
          document.getElementById('login-btn-text').innerText = "Signed in: " +
              googleUser.getBasicProfile().getName();
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
    googleId.value = profile.getId()
    googleStatus.innerText = "google id modtaget"
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
            googleId: null,
            fornavn: null,
            efternavn: null,
            lejlighedsnummer: null,
            requestStatus: null
        }
    },
    methods: {
        async sendRequest(){
            const newUrl = url + this.googleId +"/opretRequest?fornavn="+this.fornavn+"&efternavn="+this.efternavn+"&lejlighedsnummer="+this.lejlighedsnummer
            const response = await axios.post(newUrl)
            this.requestStatus = await response.status
        }
    }
}).mount("#app")