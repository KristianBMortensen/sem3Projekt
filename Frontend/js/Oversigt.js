const url = "https://localhost:44323/api/Days/"

Vue.createApp({
    data(){
        return {
            days: [],
            loginid: null,
        }
    }, 
    methods: {
        async Getweekdays(){
            const newUrl = url+"week?numdays=8"
            console.log(newUrl)
            const response = await axios.get(newUrl)
            this.days = await response.data
            console.log(this.days)
        },

        async BookTime(timeslotid){
            const newUrl = url+timeslotid+"/book?loginid="+this.loginid
            console.log(newUrl)
            const response = await axios.post(newUrl, null)
            await response.data
            this.Getweekdays()
        },

        async GetLogin(){
            let name = "vasklet=";
            let decodedCookie = decodeURIComponent(document.cookie);
            let ca = decodedCookie.split(';');
            for(let i = 0; i < ca.length; i++) {
                let c = ca[i];
                while (c.charAt(0) == ' ') {
                c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    this.loginid = c.substring(name.length, c.length);
                }
            }
        },

    },
    async created(){
        this.Getweekdays()
        this.GetLogin()
    },
}).mount("#app")