import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";


import { apiLogout } from "./api/data.js";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { myListingsPage } from "./views/myListings.js";
import { registerPage } from "./views/register.js";
import { searchPage } from "./views/search.js";

const mainEl = document.querySelector("#site-content");
document.querySelector("#logoutBtn").addEventListener("click", logout);

setNav();

page("/", decorateFunction, homePage);
page("/login", decorateFunction, loginPage);
page("/register", decorateFunction, registerPage);
page("/catalog", decorateFunction, catalogPage);
page("/create", decorateFunction, createPage);
page("/details/:id", decorateFunction, detailsPage);
page("/edit/:id", decorateFunction, editPage);
page("/listings", decorateFunction, myListingsPage);
page("/search", decorateFunction, searchPage);

page.start();


function decorateFunction(ctx, next){
    setNav();
    ctx.render = (content) => render(content, mainEl);

    next();
}

function setNav(){
    const username = sessionStorage.getItem("username");

    const guestNav = document.querySelector("#guest");
    const userNav = document.querySelector("#profile");

    if (username) {
        document.querySelector("#profile a").textContent = "Welcome " + username;
        guestNav.style.display = 'none';
        userNav.style.display = '';
    }else{
        guestNav.style.display = '';
        userNav.style.display = 'none';
    }
}

async function logout(){
    await apiLogout();
    page.redirect("/");
}
