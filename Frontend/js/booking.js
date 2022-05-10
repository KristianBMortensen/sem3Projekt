const url = "https://localhost:44323/api/Days/"

Vue.createApp({
    data(){
        return {
            days: [],
            //days: [],
            //timeslots: [],
            bookingDate: null,
            timeId: null,
            bookingStatus: null,
            date: null,
            tider: null
        }
    }, 
    methods: {
        async createBooking(){
            const googleId = this.getGoogleId()
            if(googleId != ""){
                const newUrl = url + this.timeId + "/book?LoginId="+googleId
                console.log(newUrl)
                const response = await axios.post(newUrl)
                this.bookingStatus = await response.status
            }else{
                console.log("googleId is empty")
            }
        },

        dateChange(){
            this.bookingDate = this.date.date
            console.table(this.date.timeslots[0].resTime)
        },

        getGoogleId(){
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
    },
    async created(){
        console.log("fisk")
        const response = await axios.get(url)
        this.days = await response.data
        console.table(this.days[0])
        //console.table(this.days[0].timeslots)
        //this.tider = await this.days[this.date]
        //this.days = this.rawDays[0]
        /*this.rawDays[1].array.forEach(item => {
            item.array.forEach(slot => {

            })
        });*/
    },
}).mount("#app")