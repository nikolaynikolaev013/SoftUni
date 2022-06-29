import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUserMemes } from '../api/data.js';

const profileTemplate = (user, memes) => html`
    <section id="user-profile-page" class="user-profile">
                <article class="user-info">
                    <img id="user-avatar-url" alt="user-profile" src="/images/${user.gender}.png">
                    <div class="user-content">
                        <p>Username: ${user.username}</p>
                        <p>Email: ${user.email}</p>
                        <p>My memes count: ${memes.length}</p>
                    </div>
                </article>
                <h1 id="user-listings-title">User Memes</h1>
                <div class="user-meme-listings">
                    ${memes.length == 0 ? 
                            html`<p class="no-memes">No memes in database.</p>`
                            : memes.map(memeTemplate)}
                </div>
            </section>
`;

const memeTemplate = (meme) => html`
            <div class="user-meme">
                    <p class="user-meme-title">${meme.title}</p>
                    <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
                    <a class="button" href="/details/${meme._id}">Details</a>
                </div>
`;

export async function profilePage(ctx){
    const user = 
    {
        id: sessionStorage.getItem("userId"),
        username: sessionStorage.getItem("username"),
        email: sessionStorage.getItem("email"),
        gender: sessionStorage.getItem("gender")
    }

    const memes = await getUserMemes(user.id);
    ctx.render(profileTemplate(user, memes))
}