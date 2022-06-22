const adminUrl = "https://vasklet.azurewebsites.net/api/LoginRequest"

Vue.createApp({
    data(){
        return{
            requests: null,
            requestId: null,
        }
    },
    methods: {
        async loadAll(){
            const response = await axios.get(adminUrl)
            this.requests = await response.data
            console.log(this.requests)
        },
        async remove(){
            if(this.requestId != null){
                const response = await axios.delete(adminUrl+"/" + this.requestId)
                this.loadAll()
                this.closeModal()
            }
        },

        async accept(id){
            if(id != null && id != ""){

                const response = await axios.put(adminUrl + id)
                console.log("noget er null: id " + id)
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