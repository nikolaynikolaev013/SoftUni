import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import {logout as apiLogout } from './api/api.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { profilePage } from './views/profile.js';

setNav();

const main = document.querySelector("main");
document.querySelector("#logoutBtn").addEventListener("click", logout);

page('/', decorateFunction, homePageOnlyForGuests, homePage);
page('/login', decorateFunction, loginPage);
page('/register', decorateFunction, registerPage);
page('/catalog', decorateFunction, catalogPage);
page('/details/:id', decorateFunction, detailsPage);
page('/edit/:id', decorateFunction, editPage);
page('/profile', decorateFunction, profilePage);
page('/create', decorateFunction, createPage);

page.start();

function homePageOnlyForGuests(ctx, next){
    let token = sessionStorage.getItem("authToken");
    if (token != null) {
        return ctx.page.redirect("/catalog");
    }
    next();
}

function decorateFunction(ctx, next){
    ctx.setNav = setNav;
    ctx.render = (content) => render(content, main);

    next();
}

function setNav(){
    let email = sessionStorage.getItem("email");
    let userNav = document.querySelector(".user");
    let guestNav = document.querySelector(".guest");

    if (email) {
        document.querySelector('div.profile > span').textContent = `Welcome, ${email}`;
        userNav.style.display = '';
        guestNav.style.display = 'none';
    }else{
        userNav.style.display = 'none';
        guestNav.style.display = '';
    }
}

async function logout(){
    await apiLogout();
    setNav();
    await page.redirect('/');
}