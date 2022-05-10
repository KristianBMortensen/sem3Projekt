window.onload = function(){
    checkCookie()
}

function checkCookie(){
    let sPath = window.location.pathname
    if(sPath != "/login/"){
        
        if(getCookie() == ""){
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
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

Vue.createApp({
    data(){
        return{
            adminAllowed: true
        }
    },
    async created(){
        if(getCookie() != "")
        {
            this.adminAllowed = true
        }else{
            console.log("admin not allowed")
        }
    },
    methods: {

    }
}).mount("#navigation")