import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteListing, getCarById } from "../api/data.js";

const detailsTemplate = (listing, isOwner, deleteBtn) => html`
    <section id="listing-details">
            <h1>Details</h1>
            <div class="details-info">
                <img src="${listing.imageUrl}">
                <hr>
                <ul class="listing-props">
                    <li><span>Brand:</span>${listing.brand}</li>
                    <li><span>Model:</span>${listing.model}</li>
                    <li><span>Year:</span>${listing.year}</li>
                    <li><span>Price:</span>${listing.price}$</li>
                </ul>

                <p class="description-para">${listing.description}</p>

                ${isOwner ? 
                    html`
                        <div class="listings-buttons">
                        <a href="/edit/${listing._id}" class="button-list">Edit</a>
                        <a @click=${deleteBtn} href="javascript:void(0)" class="button-list">Delete</a>
                        </div>
                    ` : ``}
            </div>
        </section>
`;

export async function detailsPage(ctx){
    const listingId = ctx.params.id;
    const listing = await getCarById(listingId);
    const isOwner = sessionStorage.getItem("userId") === listing._ownerId;
    ctx.render(detailsTemplate(listing, isOwner, deleteBtn));

    async function deleteBtn(){
        deleteListing(listingId);
        ctx.page.redirect("/catalog")
    }
}