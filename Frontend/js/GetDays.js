const URL = "https://localhost:44323/api/Days"

Vue.createApp({
    data(){
        return {
            days : null,
        }
    },

    async created(){
        this.Getall()
    },

    methods: {
        async Getall(){
            try{
                const response = await axios.get(URL)
                this.days = await response.data
                console.log(this.days[0])
            }
            catch(e){
                console.log(e.message)
            }
        },
    }
}).mount("#app")