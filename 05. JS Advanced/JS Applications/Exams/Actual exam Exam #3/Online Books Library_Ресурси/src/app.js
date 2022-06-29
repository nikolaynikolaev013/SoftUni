import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";

import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { logout } from "./api/data.js";
import { createPage } from "./views/create.js";
import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { myBooksPage } from "./views/myBooks.js";

const mainEl = document.querySelector("#site-content");
document.querySelector("#logoutBtn").addEventListener("click", logoutBtn);

setNav();


page("/", populateMain, redirectToDashboard)
page("/dashboard", populateMain, dashboardPage)
page("/login", populateMain, loginPage);
page("/register", populateMain, registerPage);
page("/create", populateMain, createPage);
page("/details/:id", populateMain, detailsPage);
page("/edit/:id", populateMain, editPage);
page("/my-books/", populateMain, myBooksPage);

page.start();

function redirectToDashboard(){
    page.redirect("/dashboard");
}

function setNav(){
    const userEmail = sessionStorage.getItem("email");

    const guestNav = document.querySelector("#guest");
    const userNav = document.querySelector("#user");

    if (userEmail) {
        document.querySelector("#user span").textContent = `Welcome, ${userEmail}`;
        userNav.style.display = '';
        guestNav.style.display = 'none';
    }else{
        userNav.style.display = 'none';
        guestNav.style.display = '';
    }
}

async function logoutBtn(){
    setNav();
    await logout();
    page.redirect("/dashboard");
}

function populateMain(ctx, next){
    ctx.render = (content) => render(content, mainEl);
    ctx.setNav = setNav();

    next();
}