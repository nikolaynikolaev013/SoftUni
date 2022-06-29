import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUserBooks } from "../api/data.js";
import { bookTemplate } from "./common/book.js";

const myBooksTemplate = (books) => html`
    <section id="my-books-page" class="my-books">
            <h1>My Books</h1>
            ${books.length == 0 ? html`<p class="no-books">No books in database!</p>`
            : html`
                <ul class="my-books-list">
                    ${books.map(bookTemplate)}
                </ul>
            `}
    </section>
`;

export async function myBooksPage(ctx){
    const userId = sessionStorage.getItem("userId");
    const books = await getUserBooks(userId)

    ctx.render(myBooksTemplate(books));
}