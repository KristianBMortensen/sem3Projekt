const url = "https://vasklet.azurewebsites.net//api/Days/"

Vue.createApp({
    data(){
        return{
            today: null
        }
    },methods:{
        async getAll(){
            const date = this.getDate(-1)
            const response = await axios.get(url+date)
            const result = await response.data
            console.log(result)
        },

        getDate(future){
            const date = new Date()
            const year = date.getFullYear()
            let day = date.setDate(date.getDate() + future)
            let month = date.getMonth()+1

            if(month < 10)
                month = "0"+month
            
            if(day < 10)
                day = "0"+day
            
            todayDate = day+"-"+month+"-"+year

            return todayDate
        }
    },
    created(){
        this.getAll()
    }
}).mount("#app")