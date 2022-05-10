const url = "https://localhost:44323/api/LoginRequest/"

Vue.createApp({
    data(){
        return{
            requests: null,
            requestId: null,
        }
    },
    methods: {
        async loadAll(){
            const response = await axios.get(url)
            this.requests = await response.data
        },
        async remove(){
            if(this.requestId != null){
                const response = await axios.delete(url + this.requestId)
                this.loadAll()
                this.closeModal()
            }
        },

        async accept(id,room){
            if(id != null && room != null){
                const response = await axios.put(url + id+"?room="+room)
                console.log("noget er null: id " + id + " room "+room)
                this.loadAll()
            }else{
                console.log("noget er null: id " + id + " room "+room)
            }
        },

        showModal(id){
            this.$refs.adminModal.style.display = "block"
            this.requestId = id
        },

        closeModal(){
            this.$refs.adminModal.style.display = "none"
        }
    },
    async created(){
        this.loadAll()
    }
}).mount("#app")