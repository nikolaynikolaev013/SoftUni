function attachEventsListeners() {
    let mainContainterElement = document.querySelector('main');

    let daysInputElement = document.querySelector('#days');
    let hoursInputElement = document.querySelector('#hours');
    let minutesInputElement = document.querySelector('#minutes');
    let secondsInputElement = document.querySelector('#seconds');
    
    mainContainterElement.addEventListener('click', (e) => {
        if (e.target.id === 'daysBtn') {
            hoursInputElement.value = Number(daysInputElement.value) * 24;
            minutesInputElement.value = Number(hoursInputElement.value) * 60;
            secondsInputElement.value = Number(minutesInputElement.value) * 60;
        }else if (e.target.id === 'hoursBtn') {
            daysInputElement.value = Number(hoursInputElement.value) / 24;
            minutesInputElement.value = Number(hoursInputElement.value) * 60;
            secondsInputElement.value = Number(minutesInputElement.value) * 60;
            
        }else if (e.target.id === 'minutesBtn') {
            secondsInputElement.value = Number(minutesInputElement.value) * 60;
            hoursInputElement.value = Number(minutesInputElement.value) / 60;
            daysInputElement.value = Number(hoursInputElement.value) / 24;
            
        }else if (e.target.id === 'secondsBtn') {
            minutesInputElement.value = Number(secondsInputElement.value) / 60;
            hoursInputElement.value = Number(minutesInputElement.value) /60;
            daysInputElement.value = Number(hoursInputElement.value) / 24;
            
        }
    })
}