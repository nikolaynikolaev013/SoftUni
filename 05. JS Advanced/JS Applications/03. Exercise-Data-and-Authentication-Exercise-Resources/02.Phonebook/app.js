function attachEvents() {
    let baseUrl = 'http://localhost:3030/jsonstore/phonebook';

    let createBtnEl = document.querySelector("#btnCreate");
    let loadBtnEl = document.querySelector("#btnLoad");

    createBtnEl.addEventListener("click", () => {
        let personNameEl = document.querySelector("#person");
        let personPhoneEl = document.querySelector("#phone");

        let personNameValue = personNameEl.value;
        let personPhoneValue = personPhoneEl.value;

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ person: personNameValue, phone: personPhoneValue })
        })
            .then(res => res.json())
            .then(res => {
                console.log(res);
                loadTextBook();
            })
    })

    loadBtnEl.addEventListener("click", loadTextBook);

    function loadTextBook() {
        let ulEl = document.querySelector("#phonebook");

        while (ulEl.lastChild) {
            ulEl.removeChild(ulEl.lastChild);
        }


        fetch(baseUrl)
            .then(result => result.json())
            .then(res => {

                for (const person in res) {
                    let newLiEl = document.createElement("li");
                    let newBtnEl = document.createElement("button");
                    newBtnEl.textContent = "Delete";
                    newBtnEl.id = "deleteBtn";
                    newBtnEl.setAttribute("_id", res[person]._id)

                    newLiEl.innerHTML = `${res[person].person}: ${res[person].phone} ${newBtnEl.outerHTML}`;
                    ulEl.appendChild(newLiEl);

                    newLiEl.addEventListener("click", (e) => {
                        console.log();
                        if (e.target.id === "deleteBtn") {
                            let id = e.target.getAttribute("_id");
                            fetch(`${baseUrl}/${id}`, {
                                method: 'DELETE'
                            }).then(ress => ress.json())
                                .then(ress => {
                                    console.log(ress);
                                    loadTextBook();
                                });
                        }
                    })
                }
            })
    }
}

attachEvents();