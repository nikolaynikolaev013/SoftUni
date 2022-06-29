let notificationBox = document.querySelector("#errorBox");

export function notify(message){
    notificationBox.innerHTML = `<span>${message}</span>`;
    notificationBox.style.display = "block";

    setTimeout(() => notificationBox.style.display = 'none', 3000);
}