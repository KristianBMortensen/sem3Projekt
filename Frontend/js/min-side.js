const daysURL = "https://localhost:44323/api/Days/"
const loginUrl = "https://localhost:44323/api/Login/"

Vue.createApp({
    data(){
        return{
            today: null,
            futureDays: null,
            myLogin: null
        }
    },methods:{
        async getAll(){      
            const loginId = this.getCookie()      
            const loginResponse = await axios.get(loginUrl+loginId)
            this.myLogin = await loginResponse.data

            const date = this.getDate(1)
            const dateUrl = (daysURL+date)
            console.log(date)
            const response = await axios.get(dateUrl)
            const result = await response.data
            
            this.today = result

            const futureResponse = await axios.get(daysURL+this.myLogin.room)
            const futureData = await futureResponse.data

            let futureDaysArray = []

            futureData.foreach(item => {
                if(this.checkStringDate(item.resDate)){
                    futureDaysArray.push(item)
                }
            })
            console.table(futureDaysArray)
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
            console.log(todayDate)

            return todayDate
        },

        checkStringDate(date){
            let day = date.split('-')[0]
            let month = date.split('-')[1]
            let year = date.spliut('')[2]

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
        }
    },
    created(){
        this.getAll()
    }
}).mount("#app")