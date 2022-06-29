function solve() {
   let tableDataElements = document.querySelectorAll('td');
   let searchButtonElement = document.querySelector('#searchBtn');
   let inputField = document.querySelector('#searchField');

   searchButtonElement.addEventListener('click', ()=>{
      for (const td of tableDataElements) {
         td.parentElement.classList.remove('select');
      }
      for (const td of tableDataElements) {
         if (td.textContent.includes(inputField.value)) {
            td.parentElement.classList.add('select');
         }
      }
   });
}