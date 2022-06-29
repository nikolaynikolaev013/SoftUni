window.addEventListener('load', solve);


function solve() {
    const addButton = document.getElementById("add");
 
    const furnitureListElement = document.getElementById("furniture-list");
 
    const model = document.getElementById("model");
    const year = document.getElementById("year");
    const description = document.getElementById("description");
    const price = document.getElementById("price");
 
 
    addButton.addEventListener("click", (event) => {
        event.preventDefault();
 
        if (!model.value.trim()
            || !year.value.trim() || Number(year.value) < 0
            || !description.value.trim()
            || !price.value.trim() || Number(price.value) < 0) {
            return;
        }
 
        const modelValue = model.value;
        const yearValue = year.value;
        const descriptionValue = description.value;
        const priceValue = price.value;
 
        const mainTrElement = document.createElement('tr');
        mainTrElement.classList.add('info');
 
 
        const titleTdElement = document.createElement('td');
        titleTdElement.textContent = modelValue;
 
        const priceTdElement = document.createElement('td');
        priceTdElement.textContent = Number(priceValue).toFixed(2);
 
        const buttonsTdElement = document.createElement('td');
 
        const moreInfoButton = document.createElement('button');
        moreInfoButton.textContent = 'More Info';
        moreInfoButton.classList.add('moreBtn');
 
        const buyButton = document.createElement('button');
        buyButton.textContent = 'Buy it';
        buyButton.classList.add('buyBtn');
 
        buttonsTdElement.appendChild(moreInfoButton);
        buttonsTdElement.appendChild(buyButton);
      
        mainTrElement.appendChild(titleTdElement);
        mainTrElement.appendChild(priceTdElement);
        mainTrElement.appendChild(buttonsTdElement);
 
        const moreInfoTrElement = document.createElement('tr');
        moreInfoTrElement.classList.add('hide');
 
        const yearTdElement = document.createElement('td');
        yearTdElement.textContent = `Year: ${yearValue}`;
 
        const descriptionTdElement = document.createElement('td');
        descriptionTdElement.textContent = `Description: ${descriptionValue}`;
        descriptionTdElement.setAttribute('colspan', '3');
 
        moreInfoTrElement.appendChild(yearTdElement);
        moreInfoTrElement.appendChild(descriptionTdElement);
 
        furnitureListElement.appendChild(mainTrElement);
        furnitureListElement.appendChild(moreInfoTrElement);
 
 
        moreInfoButton.addEventListener("click", () => {
            let moreInfoButtonTextContent = moreInfoButton.textContent;
 
            if (moreInfoButtonTextContent == "More Info") {
                moreInfoButton.textContent = "Less Info";
                moreInfoTrElement.style.display = 'contents';
            }
            else {
                moreInfoButton.textContent = "More Info";
                moreInfoTrElement.style.display = 'none';
            }
        });
 
        buyButton.addEventListener("click", () => {
            let totalPriceElement = document.querySelector("td.total-price");
 
            const currTotalPrice = Number(totalPriceElement.textContent);
            const newPrice = (Number(currTotalPrice) + Number(priceTdElement.textContent)).toFixed(2);
            totalPriceElement.textContent = newPrice;
 
            mainTrElement.parentElement.removeChild(moreInfoTrElement);
            mainTrElement.parentElement.removeChild(mainTrElement);
        });
 
        model.value = '';
        year.value = '';
        price.value = '';
        description.value = '';
    });
}