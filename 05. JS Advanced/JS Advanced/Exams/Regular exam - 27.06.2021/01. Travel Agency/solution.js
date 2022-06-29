window.addEventListener('load', solution);

function solution() {
  let userInfo;

  let btns = {
    submitBtn: document.querySelector("#submitBTN"),
    editBtn: document.querySelector("#editBTN"),
    continueBtn: document.querySelector("#continueBTN"),
  }

  btns.submitBtn.addEventListener('click', () => {
    userInfo = getUserDataAsAnObject();

    if (userInfo.fullName != '' && userInfo.email != '') {
      clearOutInputFields();
      setBtnsForPreview(btns);
      fillUpPreviewUl(userInfo);
    }
  });

  btns.editBtn.addEventListener("click", () => {
    setBtnsForEdit(btns);
    setInputFields(userInfo);
    clearAllChildren("#infoPreview");
  })

  btns.continueBtn.addEventListener("click", () => {
    clearAllChildren("#block");
    
    let blockEl = document.querySelector("#block");
    blockEl.appendChild(generateItem('h3', 'Thank you for your reservation!'));
  })
  
  function setBtnsForEdit(btns){
    btns.submitBtn.disabled = false;
    btns.editBtn.disabled = true;
    btns.continueBtn.disabled = true;
  }

  function setBtnsForPreview(btns){
    btns.submitBtn.disabled = true;
    btns.editBtn.disabled = false;
    btns.continueBtn.disabled = false;
  }

  function generateItem(itemTag, textContent){
    let newItem = document.createElement(itemTag);
    newItem.textContent = textContent;
    return newItem;
  } 

  function clearAllChildren(query){
    let previewUl = document.querySelector(query);

    while (previewUl.firstChild) {
      previewUl.removeChild(previewUl.firstChild);
    }
  }

  function fillUpPreviewUl(userInfo){
    let previewUl = document.querySelector("#infoPreview");
    previewUl.appendChild(generateItem('li', `Full Name: ${userInfo.fullName}`));
    previewUl.appendChild(generateItem('li', `Email: ${userInfo.email}`));
    previewUl.appendChild(generateItem('li', `Phone Number: ${userInfo.phone}`));
    previewUl.appendChild(generateItem('li', `Address: ${userInfo.address}`));
    previewUl.appendChild(generateItem('li', `Postal code: ${userInfo.postcode}`));

  }
  function setInputFields(userInfo){
    let fullNameEl = document.querySelector("#fname").value = userInfo.fullName;
    let emailEl = document.querySelector("#email").value = userInfo.email;
    let phoneEl = document.querySelector("#phone").value = userInfo.phone;
    let addressEl = document.querySelector("#address").value = userInfo.address;
    let postcodeEl = document.querySelector("#code").value = userInfo.postcode;
  }

  function clearOutInputFields(){
    let fullNameEl = document.querySelector("#fname").value = '';
    let emailEl = document.querySelector("#email").value = "";
    let phoneEl = document.querySelector("#phone").value = "";
    let addressEl = document.querySelector("#address").value = "";
    let postcodeEl = document.querySelector("#code").value = "";
  }

  function getUserDataAsAnObject(){
    let fullNameEl = document.querySelector("#fname");
    let emailEl = document.querySelector("#email");
    let phoneEl = document.querySelector("#phone");
    let addressEl = document.querySelector("#address");
    let postcodeEl = document.querySelector("#code");


    let userInfo = {
      fullName: fullNameEl.value,
      email: emailEl.value,
      phone: phoneEl.value,
      address: addressEl.value,
      postcode: postcodeEl.value,
    }

    return userInfo;
  }
}
