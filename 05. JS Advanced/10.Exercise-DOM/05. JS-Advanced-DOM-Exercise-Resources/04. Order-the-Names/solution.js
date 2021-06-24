function solve() {
    let addButtonElement = document.getElementsByTagName('button')[0];

    addButtonElement.addEventListener('click', () => {
        let nameInputElement = document.querySelector('input');
        let nameInputValue = nameInputElement.value;

        let firstLetter = nameInputValue[0].toUpperCase();
        
        let numberIndex = firstLetter.charCodeAt(0) - 65;
        
        let olElement = document.querySelector('ol');

        let neededLiElement = olElement.children[numberIndex];

        neededLiElement.innerHTML = neededLiElement.innerHTML === '' ? 
                                neededLiElement.innerHTML = nameInputValue : neededLiElement.innerHTML += `, ${nameInputValue}`;
                                
        nameInputElement.value = '';
    });
}