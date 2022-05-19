Vue.createApp({
    data(){
        return {
            username: null,
            password: null
        }
    },
    methods: {
        login(){
            console.log("hallo")
            if(this.username == "admin" && this.password == "1234"){
                setCookie("10")
                window.location.href = "/";
            }else{
                console.log("error")
            }
        }
    }
}).mount("#loginForm")