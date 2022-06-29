function solve() {

    let selectMenuElement = document.querySelector('#selectMenuTo');

    let binaryOptionElement = document.createElement('option');
    binaryOptionElement.textContent = 'Binary';
    binaryOptionElement.value = 'binary'

    let hexadecimalOptionElement = binaryOptionElement.cloneNode(true);
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    hexadecimalOptionElement.value = 'hexadecimal';

    selectMenuElement.removeChild(selectMenuElement.children[0]);
    selectMenuElement.appendChild(binaryOptionElement);
    selectMenuElement.appendChild(hexadecimalOptionElement);

    let convertButtonElement = document.querySelector('button');

    let numberToConvertElement = document.querySelector('#input');
    let resultElement = document.querySelector('#result');

    convertButtonElement.addEventListener('click', () => {
        if (numberToConvertElement.value !== '') {
            if (selectMenuElement.value == 'binary') {
                resultElement.value = Number(numberToConvertElement.value).toString(2);
            }else if (selectMenuElement.value == 'hexadecimal') {
                resultElement.value = Number(numberToConvertElement.value).toString(16).toUpperCase();
            }
        }
    });
}