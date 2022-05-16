const url = "https://localhost:44323/api/Days/"

Vue.createApp({
    data(){
        return {
            days: [],
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

    },
    async created(){
        this.Getweekdays()
    },
}).mount("#app")