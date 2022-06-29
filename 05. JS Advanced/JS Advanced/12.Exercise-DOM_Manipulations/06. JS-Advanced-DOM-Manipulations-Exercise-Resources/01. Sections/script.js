function create(words) {
   let contentElement = document.querySelector('#content');

   words.forEach(word => {
      let newDivElement = document.createElement('div');
      let newPElement = document.createElement('p');
      
      newPElement.textContent = word;
      newPElement.style.display = 'none';
      newDivElement.appendChild(newPElement);

      contentElement.appendChild(newDivElement);
   });

   contentElement.addEventListener('click', (e)=>{
      if (e.target !== e.currentTarget) {
         e.target.firstChild.style.display = 'block';
      }
   })
}