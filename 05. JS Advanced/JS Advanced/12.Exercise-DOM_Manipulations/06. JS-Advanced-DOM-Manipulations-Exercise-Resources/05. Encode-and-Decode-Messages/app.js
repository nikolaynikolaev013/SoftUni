function encodeAndDecodeMessages() {
    let encodeDivElement = document.querySelectorAll('div')[1];
    let encodeTextareaElement = encodeDivElement.querySelector('textarea');
    let encodeButtonElement = encodeDivElement.querySelector('button');

    let decodeDivElement = document.querySelectorAll('div')[2];
    let decodeTextareaElement = decodeDivElement.querySelector('textarea');
    let decodeButtonElement = decodeDivElement.querySelector('button');

    encodeButtonElement.addEventListener('click', ()=>{
        let message = encodeTextareaElement.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode((message.charCodeAt(i) + 1));
        }
        decodeTextareaElement.value = encodedMessage;
        encodeTextareaElement.value = '';
    });

    decodeButtonElement.addEventListener('click', () => {
        let message = decodeTextareaElement.value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            decodedMessage += String.fromCharCode((message.charCodeAt(i) - 1));
        }

        decodeTextareaElement.value = decodedMessage;
    });
}