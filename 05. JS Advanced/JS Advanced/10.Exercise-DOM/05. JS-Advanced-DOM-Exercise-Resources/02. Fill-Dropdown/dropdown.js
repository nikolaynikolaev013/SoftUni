function addItem() {
    let textInput = document.querySelector('#newItemText');
    let textValue = textInput.value;

    let valueInput = document.querySelector('#newItemValue');
    let valueValue = valueInput.value;

    let selectElement = document.querySelector('#menu');

    let newOptionElement = document.createElement('option');
    newOptionElement.innerHTML = textValue;
    newOptionElement.value = valueValue;

    selectElement.appendChild(newOptionElement);
    textInput.value = '';
    valueInput.value = '';
}