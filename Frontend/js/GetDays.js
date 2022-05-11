const URL = "https://localhost:44323/api/Days"

Vue.createApp({
    data(){
        return {
            today: null,
            maskineStatus: "Ledig",
        }
    },

    async created(){
        this.Getall()
    },

    methods: {
        async Getall(){
            try{
                const newUrl = URL+"/"+this.checkDate()
                console.log(newUrl)
                const response = await axios.get(URL+"/"+this.checkDate())
                this.today = await response.data
                if(!this.today.greenDay){
                    await this.updateMaskine()
                }
                else{
                    await this.greenDayHandler()
                }
            }
            catch(e){
                console.log(e.message)
            }
        },

        checkDate(){
            const date = new Date()
            const year = date.getFullYear()
            let month = date.getMonth()+1
            let day = date.getDate()
            if(month <10){
                month = "0"+month
            }

            if(day < 10){
                day = "0"+day
            }
            todayDate = "12-"+month+"-"+year
            console.log(todayDate)

            return todayDate
        },

        getTime(){
            const date = new Date()
            const hour = date.getUTCHours()+2
            const minutes = date.getUTCMinutes()

            return hour+":"+minutes
        },

        checkTime(times){
            const timeArray = times.split("-")
            if(timeArray[0] < this.getTime() && timeArray[1] > this.getTime()){
                return true
            }
            return false
        },

        updateMaskine(){
            for(let i = 0; i < this.today.timeslots.length; i++){
                if(this.checkTime(this.today.timeslots[i].resTime)){
                    this.$refs.vaskemaskine.style.backgroundColor = "var(--optaget-maskine)"
                    this.$refs.maskineStatus.innerHTML = "12:00-13:30"
                    this.maskineStatus = "Igang"
                    console.log("fisk")
                    return
                }
            }
            this.$refs.vaskemaskine.style.backgroundColor = "var(--ledig-maskine)"
            this.$refs.maskineStatus.innerHTML = ""
            this.maskineStatus = "Ledig"
        },

        async greenDayHandler(){
            const greenUrl = "https://localhost:44323/api/GreenDays"
            const response = await axios.get(greenUrl)
            const isGreen = await response.data

            if(isGreen){
                this.$refs.vaskemaskine.style.backgroundColor = "var(--optaget-maskine)"
                this.$refs.maskineStatus.innerHTML = "12:00-13:30"
                this.maskineStatus = "Igang"
            }else{
                this.$refs.vaskemaskine.style.backgroundColor = "var(--ledig-maskine)"
                this.$refs.maskineStatus.innerHTML = ""
                this.maskineStatus = "Ledig"
            }
        }
    }
}).mount("#app")