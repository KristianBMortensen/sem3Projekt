const URL = "https://localhost:44323/api/Days"

Vue.createApp({
    data(){
        return {
            today: null,
            roomNo: null,
            maskineStatus: "Ledig",
            greenDayTimeLeft: null,
            myRoom: null,
        }
    },

    async created(){
        this.Getall()
    },

    methods: {
        async Getall(){
            try{
                const newUrl = URL+"/"+this.checkDate()
                const response = await axios.get(newUrl)
                this.today = await response.data
                console.log(this.today)
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

            this.getARoom()
        },

        async getARoom(){
            const url = "https://localhost:44323/api/Login/"
            const id = this.getCookie()
            const newUrl = url + id + "/full"
            const response = await axios.get(newUrl)
            const data = await response.data
            this.myRoom = await data.room
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
            todayDate = "19-"+month+"-"+year
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
                if(this.checkTime(this.today.timeslots[i].resTime) && this.today.timeslots[i].roomNo){
                    this.$refs.vaskemaskine.style.backgroundColor = "var(--optaget-maskine)"
                    this.$refs.maskineStatus.innerHTML = this.today.timeslots[i].resTime
                    this.maskineStatus = "Igang" 
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
            const data = await response.data
            const isGreen = await data.key

            if(isGreen){
                this.$refs.vaskemaskine.style.backgroundColor = "var(--optaget-maskine)"
                this.greenDayTimeLeft = data.value
                this.maskineStatus = "Igang"
            }else{
                this.$refs.vaskemaskine.style.backgroundColor = "var(--ledig-maskine)"
                this.greenDayTimeLeft = null
                this.maskineStatus = "Ledig"
            }
            let timearray = this.greenDayTimeLeft.split(":")
            timearray[0] = parseInt(timearray[0])
            timearray[1] = parseInt(timearray[1])
            timearray[2] = parseInt(timearray[2])

            const maskineStatus = this.$refs.maskineStatus
            setInterval(function(){
                timearray[2]--
                
                if(timearray[2] < 0){
                    timearray[1]--
                    timearray[2] = 59
                }

                if(timearray[1] < 0){
                    timearray[0]--
                    timearray[1] = 59
                }

                if(timearray[0] <= 0){
                    timearray[0] = 0
                }

                maskineStatus.innerHTML = (timearray[0] < 10 ? "0"+timearray[0] : timearray[0])+":"+(timearray[1] < 10 ? "0"+timearray[1] : timearray[1])+":"+(timearray[2] < 10 ? "0"+timearray[2] : timearray[2])

            },1000)
        },

        getCookie(){
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
        },
        async BookTime(timeslotid){
            const loginId = this.getCookie()
            const newUrl = URL+timeslotid+"/book?loginId="+loginId
            console.log(newUrl)
            const response = await axios.post(newUrl)
            await response.data
            this.Getall()
        },
    }
}).mount("#app")