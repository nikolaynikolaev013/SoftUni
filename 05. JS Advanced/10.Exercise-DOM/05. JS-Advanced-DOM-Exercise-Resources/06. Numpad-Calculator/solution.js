function solve() {
    let expressionOutputElement = document.querySelector('#expressionOutput');
    let resultOutputElement = document.querySelector('#resultOutput');

    let buttons = document.querySelectorAll('button');

    for (const x of buttons) {
        x.addEventListener('click', ()=>{
            if (x.value !== '=' && x.value !== 'Clear' && x.value !== '*' && x.value !== '/' && x.value !== '-' && x.value !== '+') {
                expressionOutputElement.textContent += x.value;
            }
            else if (x.value === '*' || x.value === '/' || x.value === '-' || x.value === '+') {
                expressionOutputElement.textContent += ` ${x.value} `;
            }
            else if (x.value === 'Clear') {
                expressionOutputElement.textContent = '';
                resultOutputElement.textContent = '';
            }
            else if (x.value === '=') {
                let expression = expressionOutputElement.innerHTML;

                let firstNumber = '';
                let secondNumber = '';
                let operand = '';

                for (const x of expression.replace(/\s/g,'')) {
                    if (!isNaN(x) || x === '.') {
                        if (operand === '') {
                            firstNumber += x;
                        }
                        else{
                            secondNumber += x;
                        }
                    }
                    else{
                        operand += x;
                    }
                }

                let stop = false;

                if (firstNumber === '' || secondNumber === '') {
                    stop = true;
                }

                firstNumber = Number(firstNumber);
                secondNumber = Number(secondNumber);
                
                let result = '';

                if (!isNaN(firstNumber) && !isNaN(secondNumber) && operand.length === 1 && !stop) {
                    
                    switch (operand) {
                        case '+':
                            result = firstNumber + secondNumber;
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            break;
                        case '*':
                            result = firstNumber * secondNumber;
                            break;
                        case '/':
                            result = firstNumber / secondNumber;
                            break;
                    }

                }
                else{
                    result = 'NaN';
                }
                resultOutputElement.textContent = result;
            }
        });
    };
}