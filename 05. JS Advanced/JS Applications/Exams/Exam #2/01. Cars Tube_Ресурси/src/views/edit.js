import { html } from "../../node_modules/lit-html/lit-html.js";
import { editListing, getCarById } from "../api/data.js";

const editTemplate = (listing, onSubmit) => html`
  <section id="edit-listing">
            <div class="container">

                <form @submit=${onSubmit} id="edit-form">
                    <h1>Edit Car Listing</h1>
                    <p>Please fill in this form to edit an listing.</p>
                    <hr>

                    <p>Car Brand</p>
                    <input type="text" placeholder="Enter Car Brand" name="brand" .value="${listing.brand}">

                    <p>Car Model</p>
                    <input type="text" placeholder="Enter Car Model" name="model" .value="${listing.model}">

                    <p>Description</p>
                    <input type="text" placeholder="Enter Description" name="description" .value="${listing.description}">

                    <p>Car Year</p>
                    <input type="number" placeholder="Enter Car Year" name="year" .value="${listing.year}">

                    <p>Car Image</p>
                    <input type="text" placeholder="Enter Car Image" name="imageUrl" .value="${listing.imageUrl}">

                    <p>Car Price</p>
                    <input type="number" placeholder="Enter Car Price" name="price" .value="${listing.price}">

                    <hr>
                    <input type="submit" class="registerbtn" value="Edit Listing">
                </form>
            </div>
        </section>  
`;


export async function editPage(ctx){
    const listingId = ctx.params.id;
    const listing = await getCarById(listingId);
    ctx.render(editTemplate(listing, onSubmit));

    async function onSubmit(event){
        event.preventDefault();

        const formData = new FormData(event.target);

        const brand = formData.get("brand");
        const model = formData.get("model");
        const description = formData.get("description");
        const year = Number(formData.get("year"));
        const imageUrl = formData.get("imageUrl");
        const price = Number(formData.get("price"));

        if (!brand || !model || !description || !year || !imageUrl || !price) {
            return alert("All fields are required!");
        }else if (year < 0) {
            return alert("Year cannot be a negative number");
        }else if (price < 0) {
            return alert("Price cannot be a negative number");
        }

        editListing(listingId, {brand, model, description, year, imageUrl, price});
        ctx.page.redirect("/Details/" + listingId);
    }
}