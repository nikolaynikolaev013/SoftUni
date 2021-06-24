function lockedProfile() {

    let buttons = document.querySelectorAll('button');

    for (const button of buttons) {
        button.addEventListener('click', showOrHide);
    }

    function showOrHide(e){
        let button = e.target;
        let profile = e.target.parentElement;
        let isLocked = profile.querySelector('input[type="radio"]:checked').value === 'lock' ? true : false;
        let hiddenInformation = profile.querySelector('div');

        if (!isLocked) {
            if (button.textContent === 'Show more') {
                hiddenInformation.style.display = 'block';
                button.textContent = 'Hide it';
            }else if (button.textContent === 'Hide it') {
                hiddenInformation.style.display = 'none';
                button.textContent = 'Show more';
            }
        }

        
    }
}