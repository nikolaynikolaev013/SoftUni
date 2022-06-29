import { html } from "../../node_modules/lit-html/lit-html.js";
import { getListingsByYear } from "../api/data.js";

const searchTemplate = (listings) => html`
    <section id="search-cars">
            <h1>Filter by year</h1>

            <div class="container">
                <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
                <button class="button-list">Search</button>
            </div>

            <h2>Results:</h2>
            <div class="listings">
                ${listings.length == 0 ? html`<p class="no-cars"> No results.</p>`
                : listings.map(listingTemplate)}
            </div>
        </section>
`;

const listingTemplate = (listing) => html`
                <div class="listing">
                    <div class="preview">
                        <img src="${listing.imageUrl}">
                    </div>
                    <h2>${listing.brand} ${listing.model}</h2>
                    <div class="info">
                        <div class="data-info">
                            <h3>Year: ${listing.year}</h3>
                            <h3>Price: ${listing.price} $</h3>
                        </div>
                        <div class="data-buttons">
                            <a href="/details/${listing._id}" class="button-carDetails">Details</a>
                        </div>
                    </div>
                </div>
`;


export async function searchPage(ctx){
    let result = [];
    ctx.render(searchTemplate(result));

    document.querySelector(".button-list").addEventListener("click", onSubmit);

    async function onSubmit(event){
        event.preventDefault();

        const input = document.querySelector("#search-input").value;
        result = await getListingsByYear(input);
        ctx.render(searchTemplate(result));
    }
}