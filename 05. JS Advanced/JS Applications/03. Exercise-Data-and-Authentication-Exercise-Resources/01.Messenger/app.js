function attachEvents() {

    let baseUrl = 'http://localhost:3030/jsonstore/messenger';
    let allMessagesTextAreaEl = document.querySelector("#messages");

    let sendButton = document.querySelector("#submit");
    let refreshButton = document.querySelector("#refresh");

    sendButton.addEventListener("click", () => {
        let authorEl = document.getElementsByName("author");
        let contentEl = document.getElementsByName("content");

        let authorValue = authorEl[0].value;
        let contentValue = contentEl[0].value;

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ author: authorValue, content: contentValue })
        })
    })

    refreshButton.addEventListener("click", () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(res => {
                let messages = "";

                for (const message in res) {
                    messages += `${res[message].author}: ${res[message].content}\n`;
                }

                allMessagesTextAreaEl.value = messages;
            });
    });

}

attachEvents();