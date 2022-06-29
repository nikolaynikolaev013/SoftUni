class Story {
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes(){
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }
        else if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        }
        else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`
        }
    }

    like(username){
        if (this._likes.find(x=>x == username)) {
            throw new Error(`You can't like the same story twice!`);
        }else if (this.creator == username) {
            throw new Error(`You can't like your own story!`);
        }else{
            this._likes.push(username)
            return `${username} liked ${this.title}!`
        }
    }

    dislike(username){
        if (!this._likes.find(x=>x == username)) {
            throw new Error(`You can't dislike this story!`);
        }
        else{
            let newLikes = [];

            for (let i = 0; i < this._likes.length; i++) {
                if (this._likes[i] == username) {
                    continue;
                }
                newLikes.push(this._likes[i]);
            }
            this._likes = newLikes;

            return `${username} disliked ${this.title}`;
        }
    }

    comment(username, content, id){
        //
        if (id && this._comments.find(x=>x.id == id)) {
            let currComment = this._comments.find(x=>x.id == id);
            let reply = {
                id: `${id}.${currComment.replies.length + 1}`,
                content: content,
                username: username
            }
            currComment.replies.push(reply);

            return `You replied successfully`;
        }else{
            if (!id) {
                this._comments.push({id: this._comments.length + 1, content: content, username: username, replies: []});
            }else{
                this._comments.push({id: id, content: content, username: username, replies: []})
            }

            return `${username} commented on ${this.title}`
        }
    }

    toString(sortingType){
        let result = '';

        result += `Title: ${this.title}\n`;
        result += `Creator: ${this.creator}\n`;
        result += `Likes: ${this._likes.length}\n`;
        
        result += `Comments:\n`;
        if (sortingType == 'asc' ) {
            for (const comment of this._comments) {
                result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`

                if (comment.replies.length > 0) {
                    for (const reply of comment.replies) {
                    result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }
        }else if (sortingType == 'desc' ) {
            let reversedComments = this._comments.sort((a,b) => (b.id - a.id));
            for (const comment of reversedComments) {
                result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`
                
                if (comment.replies.length > 0) {
                    let reversedReplies = comment.replies.sort((a,b) => (b.id - a.id));
                    for (const reply of reversedReplies) {
                    result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }
        }else if (sortingType == 'username' ) {
            for (const comment of this._comments.sort((a,b) => (a.username > b.username) ? 1 : ((b.username > a.username) ? -1 : 0))) {
                result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`

                if (comment.replies.length > 0) {
                    for (const reply of comment.replies.sort((a,b) => (a.username > b.username) ? 1 : ((b.username > a.username) ? -1 : 0))) {
                    result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }
        }
        return result;
    }
}

// let art = new Story("My Story", "Anny");
// art.like("John");
// console.log(art.likes);
// art.dislike("John");
// console.log(art.likes);
// art.comment("Sammy", "Some Content");
// console.log(art.comment("Ammy", "New Content"));
// art.comment("Zane", "Reply", 1);
// art.comment("Jessy", "Nice :)");
// console.log(art.comment("SAmmy", "Reply@", 1));
// console.log()
// console.log(art.toString('username'));
// console.log()
// art.like("Zane");
// console.log(art.toString('desc'));
