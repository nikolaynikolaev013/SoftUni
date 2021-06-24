function toggle() {
    let buttonElement = document.querySelector('.button');
    let extraElement = document.querySelector('#extra');

    if (buttonElement.innerHTML === 'More') {
        buttonElement.innerHTML = 'Less';
        extraElement.style.display = 'block';
    }
    else{
        buttonElement.innerHTML = 'More';
        extraElement.style.display = 'none';
    }
}