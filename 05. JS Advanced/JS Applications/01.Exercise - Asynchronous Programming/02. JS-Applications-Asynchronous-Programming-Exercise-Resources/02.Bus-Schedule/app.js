function solve() {
    let departBtnEl = document.querySelector("#depart");
    let arriveBtnEl = document.querySelector("#arrive");
    let infoEl = document.querySelector("#info .info");

    function depart() {
        let nextStopId = infoEl.getAttribute('nextStopId') == undefined ? 'depot' : infoEl.getAttribute("nextStopId");

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`)
            .then(body => body.json())
            .then(nextStop => {
                departBtnEl.disabled = true;
                arriveBtnEl.disabled = false;
                infoEl.setAttribute("nextStopId", nextStop.next);
                infoEl.setAttribute("currStopName", nextStop.name);

                infoEl.textContent = `Next stop ${nextStop.name}`;
            })
            .catch(err => {
                infoEl.textContent = "Error";
                departBtnEl.disabled = true;
                arriveBtnEl.disabled = true;

            })
    }

    function arrive() {
        let nextStopId = infoEl.getAttribute('nextStopId');

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`)
            .then(body => body.json())
            .then(currStop => {
                departBtnEl.disabled = false;
                arriveBtnEl.disabled = true;
                infoEl.textContent = `Arriving at ${infoEl.getAttribute("currStopName")}`;

            }).catch(err => {
                infoEl.textContent = "Error";
                departBtnEl.disabled = true;
                arriveBtnEl.disabled = true;
            })
    }

    return {
        depart,
        arrive
    };
}

let result = solve();