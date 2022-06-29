function solve() {
   //setToDefaults();

   let btn = document.querySelector("section:nth-child(1) > form > button");

   let archived = [];
   let posts = [];

   btn.addEventListener("click", (e) => {
      e.preventDefault();
      let values = getElementsValuesAsArray();

      posts.push(({ title: values.title, author: values.author, category: values.category, content: values.content }));
      generatePosts(posts, archived);

   })


   function generatePosts(posts, archived) {

      let postsEl = document.querySelector("body main > section");

      clearChildren(postsEl, 'article');

      for (const post of posts) {
         let articleEl = document.createElement("article");

         articleEl.appendChild(createTitle(post.title));

         articleEl.appendChild(createP('Category', post.category));

         articleEl.appendChild(createP('Creator', post.author));

         articleEl.appendChild(createContent(post.content));

         let buttonsDiv = document.createElement("div");
         buttonsDiv.classList.add("buttons");


         buttonsDiv.appendChild(createBtn("Delete", "delete"));

         buttonsDiv.appendChild(createBtn("Archive", "archive"));

         articleEl.appendChild(buttonsDiv);

         postsEl.appendChild(articleEl);

         articleEl.addEventListener("click", (e) => {
            if (e.target.classList.contains("delete") || e.target.classList.contains("archive")) {
               let title = e.target.closest("article").querySelector("h1").textContent;
               let postToDelete;

               for (const post of posts) {
                  if (post.title === title) {
                     postToDelete = post;
                     break;
                  }
               }

               posts.pop(postToDelete);
               generatePosts(posts, archived);

               if (e.target.classList.contains("archive")) {
                  archived.push(title);
                  generateArchive(archived);
               }
            }
         })
      }
   }
   function generateArchive(archived) {
      let archiveEl = document.querySelector("body aside > section.archive-section > ol");

      clearChildren(archiveEl, 'li');

      for (const archivedPost of archived.sort()) {
         let newArchiveLi = document.createElement("li");
         newArchiveLi.textContent = archivedPost;

         archiveEl.appendChild(newArchiveLi);
      }
   }
   function clearChildren(parent, customTag) {
      let elementsToRemove = parent.getElementsByTagName(customTag);
      while (elementsToRemove.length) {
         parent.removeChild(elementsToRemove[0]);
      }
   }
   function createBtn(textContent, customClass) {
      let newBtn = document.createElement("button");
      newBtn.classList.add("btn");
      newBtn.classList.add(customClass);
      newBtn.textContent = textContent;
      return newBtn;
   }
   function createContent(content) {
      let contentPEl = document.createElement("p");
      contentPEl.textContent = content;
      return contentPEl;
   }
   function createP(type, textContent) {
      let newPEl = document.createElement("p");
      newPEl.textContent = `${type}:`
      let strongEl = document.createElement("strong");
      strongEl.textContent = textContent;
      newPEl.appendChild(strongEl);
      return newPEl;
   }
   function createTitle(title) {
      let titleEl = document.createElement("h1");
      titleEl.textContent = title;
      return titleEl;
   }
   function getElementsValuesAsArray() {
      let values = {};

      let authorElement = document.querySelector("#creator");
      let titleElement = document.querySelector("#title");
      let categoryElement = document.querySelector("#category");
      let contentElement = document.querySelector("#content");

      values.author = authorElement.value;
      values.title = titleElement.value;
      values.category = categoryElement.value;
      values.content = contentElement.value;

      return values;
   }

   function setToDefaults() {

      let authorElement = document.querySelector("#creator").value = "" //'Nikolay(author)';
      let titleElement = document.querySelector("#title").value = "" //"Javascript(title)";
      let categoryElement = document.querySelector("#category").value = "" // "JS(Category)";
      let contentElement = document.querySelector("#content").value = ""//"content(content)";

   }
}