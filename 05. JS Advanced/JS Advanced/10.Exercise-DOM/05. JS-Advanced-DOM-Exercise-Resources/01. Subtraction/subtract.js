function subtract() {
    let firstValue = Number(document.querySelector('#firstNumber').value);
    let secondValue = Number(document.querySelector('#secondNumber').value);

    let resultElement = document.querySelector('#result');
    resultElement.innerHTML = firstValue - secondValue;
}