function lockedProfile() {

    let mainProfileEl = document.querySelector(".profile");
    let mainEl = document.querySelector("#main");

    fetch("http://localhost:3030/jsonstore/advanced/profiles")
        .then(body => body.json())
        .then(res => {
            for (const profile in res) {
                mainEl.appendChild(createNewProfile(res[profile]));
            }
        })

    function createNewProfile(profileInfo) {
        let newProfileEl = createElement("div", "profile");

        let imgEl = createElement("img", "userIcon");
        imgEl.src = "./iconProfile2.png";
        newProfileEl.appendChild(imgEl);

        //Lock and unlock radio btns
        newProfileEl.appendChild(createElement("label", null, "Lock"));
        newProfileEl.appendChild(createElement("input", null, null, "radio", `${profileInfo.username}Locked`, "lock", true));

        newProfileEl.appendChild(createElement("label", null, "Unlock"));
        newProfileEl.appendChild(createElement("input", null, null, "radio", `${profileInfo.username}Locked`, "unlock"));

        newProfileEl.appendChild(createElement("br"));
        newProfileEl.appendChild(createElement("hr"));

        newProfileEl.appendChild(createElement("label", null, "Username"));
        newProfileEl.appendChild(createElement("input", null, null, "text", `${profileInfo.username}Username`, profileInfo.username, null, true, true));

        let hiddenFieldsDivEl = createElement("div");
        hiddenFieldsDivEl.id = `${profileInfo.username}HiddenFields`;

        hiddenFieldsDivEl.appendChild(createElement("hr"));
        hiddenFieldsDivEl.appendChild(createElement("label", null, "Email:"));
        hiddenFieldsDivEl.appendChild(createElement("input", null, null, "email", `${profileInfo.username}Email`, profileInfo.email, null, true, true));

        hiddenFieldsDivEl.appendChild(createElement("label", null, "Age:"));

        newProfileEl.appendChild(hiddenFieldsDivEl);

        let btn = createElement("button", null, "Show more");

        btn.addEventListener("click", (e) => {
            console.log(e.parentElement);
        })

        newProfileEl.appendChild(btn);


        return newProfileEl;
    }

    function createElement(elType, classes, textContent, type, name, value, isChecked, isDisabled, isReadonly) {
        let newElement = document.createElement(elType);

        if (classes) {
            newElement.className += classes;
        }

        if (textContent) {
            newElement.innerHTML = textContent;
        }

        if (type) {
            newElement.type = type;
        }

        if (name) {
            newElement.name = name;
        }

        if (value) {
            newElement.value = value;
        }

        if (isChecked) {
            newElement.checked = isChecked;
        }

        if (isDisabled) {
            newElement.disabled = isDisabled;
        }

        if (isReadonly) {
            newElement.readOnly = true;
        }

        return newElement;
    }
}