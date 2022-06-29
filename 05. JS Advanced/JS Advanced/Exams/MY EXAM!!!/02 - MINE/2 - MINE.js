class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.listOfArticles = [];
        this.guests = [];
        this.possibleArticles = { picture: 200,photo: 50,item: 250, }
    }

    addArticle(articleModel, articleName, quantity) {



        if (!(Object.keys(this.possibleArticles)).includes(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }
        
        let currArticle = this.listOfArticles.find(x => x.articleName.toLowerCase() == articleName.toLowerCase() && x.articleModel.toLowerCase() == articleModel.toLowerCase());

        if (currArticle ) {
            currArticle.quantity = currArticle.quantity + quantity;
        }
        else {
            this.listOfArticles.push( {quantity, articleName, articleModel: articleModel.toLowerCase(), });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }

    inviteGuest(guestName, personality) {
        let currGuest = this.guests.find(x => x.guestName == guestName);
        
        if (currGuest) {
            throw new Error(`${guestName} has already been invited.`);
        }

        let points = 0;

        if (personality.toLowerCase() == 'middle') {
            points = 250;
        }
        else if (personality.toLowerCase() == 'vip') {
            points = 500;
        } else{
            points = 50;
        }

        this.guests.push({ guestName, purchaseArticle: 0, points, });

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        let currArticle = this.listOfArticles.find(x => x.articleModel.toLowerCase() == articleModel.toLowerCase() && x.articleName.toLowerCase() == articleName.toLowerCase());
        
        if (!currArticle) {
            throw new Error("This article is not found.");
        }
        if (currArticle.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

         let currGuest = this.guests.find(x => x.guestName.toLowerCase() == guestName.toLowerCase());
        if (!currGuest) {
            return "This guest is not invited.";
        }

        let pointsNeeded = this.possibleArticles[currArticle.articleModel.toLowerCase()]

        if (currGuest.points < pointsNeeded) {
            return "You need to more points to purchase the article.";
        }

        currArticle.quantity = currArticle.quantity-1;
        currGuest.purchaseArticle= currGuest.purchaseArticle+1;
        currGuest.points = currGuest.points - pointsNeeded;

        return (`${guestName} successfully purchased the article worth ${pointsNeeded} points.`);
    }

    showGalleryInfo(criteria) {
        let str = '';
        if (criteria == 'article') {
            str += "Articles information:\n"
            for (const article of this.listOfArticles) {
                str += `${article.articleModel} - ${article.articleName} - ${article.quantity}\n`;
            }
        }

        else if (criteria == 'guest') {
            str += "Guests information:\n";
            for (const guest of this.guests) {
                str += `${guest.guestName} - ${guest.purchaseArticle}\n`;
            }
        }

        return str.trim();
    }
}

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));
