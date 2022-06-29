function getInfo() {
    let busId = document.querySelector("#stopId").value;
    let stopNameEl = document.querySelector("#stopName");
    let busesUl = document.querySelector("#buses");
    
    clearResults(busesUl);

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busId}`)
    .then(body => body.json())
    .then(res => {
        stopNameEl.textContent = res.name;

        Object.keys(res.buses).forEach(key => {
            let newLi = document.createElement("li");
            newLi.textContent = `Bus ${key} arrives in ${res.buses[key]}`;
            busesUl.appendChild(newLi);
        })
    })
    .catch(err =>{
        stopNameEl.textContent = "Error";
    })

    function clearResults(parent){
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }
    }
}