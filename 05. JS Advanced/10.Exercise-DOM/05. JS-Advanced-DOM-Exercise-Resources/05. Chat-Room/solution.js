function solve() {
   let sendButtonElement = document.querySelector('#send');

   sendButtonElement.addEventListener('click', ()=>{
      let chatInputElement = document.querySelector('#chat_input');

      let myMessageElement = document.querySelector('.my-message');
      let chatElement = document.querySelector('#chat_messages');

      let newMyMessageElement = myMessageElement.cloneNode(true);
      newMyMessageElement.textContent = chatInputElement.value;

      chatElement.appendChild(newMyMessageElement);
      
      chatInputElement.value = '';
   });
}


