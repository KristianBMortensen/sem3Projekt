const url = "https://localhost:44323/api/Days/"

Vue.createApp({
    data(){
        return {
            days: [],
            //days: [],
            //timeslots: [],
            booking: {date: null, time: null, room: null},
            bookingStatus: null,
            date: null,
            tider: null,
            room: null
        }
    }, 
    methods: {
        async createBooking(){
            const newUrl = url + this.booking.date + "/book?time="+this.booking.time+"&room="+this.booking.room
            const response = await axios.post(newUrl)
            this.bookingStatus = await response.status
        },

        dateChange(){
            this.booking.date = this.date.date
        },
    },
    async created(){
        console.log("fisk")
        const response = await axios.get(url)
        this.days = await response.data
        //this.tider = await this.days[this.date]
        //this.days = this.rawDays[0]
        /*this.rawDays[1].array.forEach(item => {
            item.array.forEach(slot => {

            })
        });*/
        console.table(this.days)
    },
}).mount("#app")