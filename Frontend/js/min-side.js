const daysURL = "https://localhost:44323/api/Days/"
const loginUrl = "https://localhost:44323/api/Login/"

Vue.createApp({
    data(){
        return{
            today: null,
            futureDays: null,
            myLogin: null,
            vaskeTidTilSletningId: null
        }
    },methods:{
        async getAll(){      
            const loginId = this.getCookie()      
            const loginResponse = await axios.get(loginUrl+loginId+"/full")
            this.myLogin = await loginResponse.data

            const date = this.getDate(0)
            const dateUrl = (daysURL+date)
            const response = await axios.get(dateUrl)
            const result = await response.data
            
            this.today = result

            const futureResponse = await axios.get(daysURL+"?room="+this.myLogin.room)
            const futureData = await futureResponse.data

            let futureDaysArray = []

           for(let i = 0; i < futureData.length; i++){
                if(this.checkStringDate(futureData[i].resDate)){
                    futureDaysArray.push(futureData[i])
                }
            }
            this.futureDays = futureDaysArray
        },

        getDate(future){
            const date = new Date()
            const year = date.getFullYear()
            date.setDate(date.getDate() + future)
            date.setMonth(date.getMonth()+1)

            let day = date.getDate()
            let month = date.getMonth()

            if(day < 10){
                day = "0"+day
            }

            if(month < 10){
                month = "0"+month
            }
            
            todayDate = day+"-"+month+"-"+year

            return todayDate
        },

        checkStringDate(date){
            let day = date.split('-')[0]
            let month = date.split('-')[1]
            let year = date.split('')[2]

            day = parseInt(day)
            month = parseInt(month)
            year = parseInt(year)

            const today = new Date()

            if(day <= today.getDate())
                return false
            
            if(month <= today.getMonth())
                return false

            if(year < today.getFullYear())
                return false
            
            return true
        },
        getTime(){
            const date = new Date()
            const hour = date.getUTCHours()+2
            const minutes = date.getUTCMinutes()

            return hour+":"+minutes
        },

        checkTime(times){
            const timeArray = times.split("-")
            const time = this.getTime()

            let newTimeArray = time.split(':')

            for(let i = 0; i < timeArray.length; i++){
                let newDataTimeArray = timeArray[i].split(':')
                if(parseInt(newTimeArray[0]) >= parseInt(newDataTimeArray[0]) && parseInt(newTimeArray[1]) >= parseInt(newDataTimeArray[1])){
                    console.log(newDataTimeArray[0]+":"+newDataTimeArray[1]+" | "+time)
                }else{
                    return true
                }
            }

            return false
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

        showModel(id){
            this.$refs.adminModal.style.display = "block"
            this.vaskeTidTilSletningId = id
        },

        closeModal(){
            this.$refs.adminModal.style.display = "none"
        },

        async removeVasketid(){
            const response = await axios.delete(daysURL+this.vaskeTidTilSletningId+"/book")
            this.getAll()
            this.closeModal()
        }
    },
    created(){
        this.getAll()
    }
}).mount("#app")