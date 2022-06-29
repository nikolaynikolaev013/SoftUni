function notify(message) {
    let notificationElement = document.querySelector('#notification');

    notificationElement.textContent = message;

    notificationElement.style.display = 'block';

    setTimeout(()=>{
        notificationElement.style.display = 'none';
    }, 2000);
}