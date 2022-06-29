import { html } from "../../node_modules/lit-html/lit-html.js";
import { checkIfUserLikedABook, deleteBook, getSingleBook, getTotalBookLikes, likeBook } from "../api/data.js";

const detailsTemplate = (book, delBook, isOwner, isLoggedIn, totalBookLikes, like, isLikedByUser) => html`
    <section id="details-page" class="details">
            <div class="book-information">
                <h3>${book.title}</h3>
                <p class="type">Type: ${book.type}</p>
                <p class="img"><img src=${book.imageUrl}></p>
                <div class="actions">
                    
                    ${!isOwner ? html``
                    : html`
                        <a class="button" href="/edit/${book._id}">Edit</a>
                        <a @click=${delBook} class="button" href="javascript:void(0)">Delete</a>
                    `}
                    ${isLoggedIn && !isOwner && isLikedByUser == 0 ?
                        html`<a @click=${like} class="button" href="javascript:void(0)">Like</a>`
                        :  html``}

                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: ${totalBookLikes}</span>
                    </div>
                </div>
            </div>
            <div class="book-description">
                <h3>Description:</h3>
                <p>${book.description}</p>
            </div>
        </section>
`;

export async function detailsPage(ctx){
    const bookId = ctx.params.id;
    const book = await getSingleBook(bookId);

    const bookOwnerId = book._ownerId;
    const currUserId = sessionStorage.getItem("userId");
    const isOwner = currUserId == bookOwnerId
    const isLoggedIn = currUserId;

    let totalBookLikes = await getTotalBookLikes(bookId);
    const isLikedByUser = await checkIfUserLikedABook(bookId, currUserId)


    ctx.render(detailsTemplate(book, delBook, isOwner, isLoggedIn, totalBookLikes, like, isLikedByUser));

    async function delBook(){
        await deleteBook(bookId);
        ctx.page.redirect("/dashboard");
    }

    async function like(){
        await likeBook(bookId);
        totalBookLikes = await getTotalBookLikes(bookId);
        document.querySelector("#total-likes").textContent = `Likes: ${totalBookLikes}`
        ctx.render(detailsTemplate(book, delBook, isOwner, isLoggedIn, totalBookLikes, like));
    }
}
