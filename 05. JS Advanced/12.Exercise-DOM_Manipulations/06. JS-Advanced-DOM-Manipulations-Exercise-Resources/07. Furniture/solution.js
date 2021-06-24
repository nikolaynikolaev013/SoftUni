function solve() {
  let generateButton = document.querySelector('#exercise button');
  let itemsInputElement = document.querySelector('#exercise textarea') 
  let tableElement = document.querySelector('.table');
  generateButton.addEventListener('click', ()=>{
    let elements = JSON.parse(itemsInputElement.value);
    
    for (const item of elements) {
      let rowCount = tableElement.rows.length;

      let row = tableElement.insertRow(rowCount);

      let cell1 = row.insertCell(0);
      cell1.innerHTML = `<img src="${item.img}">`

      let cell2 = row.insertCell(1);
      cell2.innerHTML = `<p>${item.name}</p>`;
      
      let cell3 = row.insertCell(2);
      cell3.innerHTML = `<p>${item.price}</p>`;

      let cell4 = row.insertCell(3);
      cell4.innerHTML = `<p>${item.decFactor}</p>`;

      let cell5 = row.insertCell(4);
      cell5.innerHTML = `<input type="checkbox"/>`;
    }
  })

  let buyButtonElement = document.querySelectorAll('button')[1];
  let boughtTextareaElement = document.querySelectorAll('textarea')[1];


  buyButtonElement.addEventListener('click', ()=>{
    let boughtObjects = [];
    let msg = '';
    let totalPrice = 0;
    let avgDecorationFactor = 0;

    boughtTextareaElement.value = '';

    for (const td of tableElement.rows) {
      if (td.querySelector('input:checked')) {
        boughtObjects.push(td);
      }
    }
    
    msg += `Bought furniture: `;
    for (let i = 0; i < boughtObjects.length; i++) {
      msg += i + 1 < boughtObjects.length ? `${boughtObjects[i].querySelectorAll('p')[0].textContent}, ` : 
                                    `${boughtObjects[i].querySelectorAll('p')[0].textContent}`;
      totalPrice += Number(boughtObjects[i].querySelectorAll('p')[1].textContent);
      avgDecorationFactor += Number(boughtObjects[i].querySelectorAll('p')[2].textContent);
    }

    avgDecorationFactor /= boughtObjects.length;

    msg += `\nTotal price: ${totalPrice.toFixed(2)}`;
    msg += `\nAverage decoration factor: ${avgDecorationFactor.toFixed(1)}`;
    boughtTextareaElement.value = msg;
  });
}