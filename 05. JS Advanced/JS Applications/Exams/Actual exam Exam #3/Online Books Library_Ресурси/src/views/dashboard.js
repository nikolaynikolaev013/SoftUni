import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllBooks } from "../api/data.js";

import { bookTemplate } from "./common/book.js";

const dashboardTemplate = (books) => html`
    <section id="dashboard-page" class="dashboard">
            <h1>Dashboard</h1>
            <!-- Display ul: with list-items for All books (If any) -->
            ${books.length == 0 ? html`<p class="no-books">No books in database!</p>`
            : html`
                <ul class="other-books-list">
                    ${books.map(bookTemplate)}
                </ul>
            `}
        </section>
`;

export async function dashboardPage(ctx){
    const books = await getAllBooks();

    ctx.render(dashboardTemplate(books));
}