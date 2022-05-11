Vue.component("navigationbar",{
    template:`
    <nav id="navigation">
    <div class="logo">
        <h4>
            VaskLet
        </h4>
    </div>
    <ul class="nav-links">
        <li>
            <a href="/">HOME</a>
        </li>
        <li>
            <a href="/booking/">OVERSIGT</a>
        </li>
        <li>
            <a href="/Minside.html">MIN SIDE</a>
        </li>
        <li>
            <a href="/login/logud.html">LOGUD</a>
        </li>
        <li>
            <a href="/Kontakt.html">KONTAKT</a>
        </li>
        <template v-if="adminAllowed">
            <li>
                <a href="/admin/">ADMIN</a>
            </li>
        </template>

    </ul>
    <div class="burger">
        <div class="line1"></div>
        <div class="line2"></div>
        <div class="line3"></div>
    </div>

</nav>`,
data(){
    
}
})