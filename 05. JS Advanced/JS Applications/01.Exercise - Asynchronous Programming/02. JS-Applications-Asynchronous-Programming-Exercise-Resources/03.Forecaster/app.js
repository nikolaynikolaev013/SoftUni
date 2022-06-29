function attachEvents() {
    let submitBtn = document.querySelector("#submit");
    submitBtn.addEventListener("click", () => {
        let locationInputValue = document.querySelector("#location").value;

        clearOldWeatherDivs();

        if (locationInputValue) {
            fetch("http://localhost:3030/jsonstore/forecaster/locations")
                .then(body => body.json())
                .then(res => {
                    let currLocation = res.find(x => x.name.toLowerCase() === locationInputValue.toLowerCase());
                    document.querySelector("#content").setAttribute("locationCode", currLocation.code);

                    return fetch(`http://localhost:3030/jsonstore/forecaster/today/${currLocation.code}`)
                })
                .then(res => res.json())
                .then(res => {
                    let currLocation = document.querySelector("#content").getAttribute("locationCode");
                    document.querySelector("#forecast").style.display = "";
                    fillUpCurrentWeather(res);
                    return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${currLocation}`);
                })
                .then(res => res.json())
                .then(res => {
                    fillUpThreeDayWeather(res);
                    resetVisibility();

                })
                .catch(err => {
                    setVisibilityForError();
                    let forecastEl = document.querySelector("#forecast");
                    forecastEl.style.display = "";
                    forecastEl.appendChild(createElement("div", "error", "Error"));

                });
        }
        function setVisibilityForError() {
            document.querySelector("#forecast").style.display = "";
            document.querySelector("#current").style.display = "none";
            document.querySelector("#upcoming").style.display = "none";
        }
        function resetVisibility() {
            document.querySelector("#forecast").style.display = "";
            document.querySelector("#current").style.display = "";
            document.querySelector("#upcoming").style.display = "";
        }
        function clearOldWeatherDivs() {
            let currentWeatherEl = document.querySelector("#current");

            Array.from(currentWeatherEl.querySelectorAll("div")).forEach((x, i) => {
                i !== 0 ? x.remove() : x;
            })

            let upcomingWeatherEl = document.querySelector("#upcoming");

            Array.from(upcomingWeatherEl.querySelectorAll("div")).forEach((x, i) => {
                i !== 0 ? x.remove() : x;
            })

            Array.from(document.querySelectorAll(".error")).forEach(x => x.remove());

        }
        function createUpcomingElement(lowTemp, highTemp, condition) {
            let newUpcomingEl = createElement("div", "upcoming");

            newUpcomingEl.appendChild(createElement("span", "symbol", chooseSymbol(condition)));
            newUpcomingEl.appendChild(createElement("span", "forecast-data", `${lowTemp}&#176;/${highTemp}&#176;`));
            newUpcomingEl.appendChild(createElement("span", "forecast-data", condition));

            return newUpcomingEl;

        }
        function fillUpThreeDayWeather(res) {
            let upcomingDiv = document.querySelector("#upcoming");

            Object.keys(res.forecast).forEach(x => upcomingDiv.appendChild(createUpcomingElement(res.forecast[x].low, res.forecast[x].high, res.forecast[x].condition)));

        }
        function fillUpCurrentWeather(res) {
            let currentWeatherEl = document.querySelector("#current");

            let forecastsDivEl = createElement("div", "forecasts");
            currentWeatherEl.appendChild(forecastsDivEl);

            forecastsDivEl.appendChild(createElement("span", "condition symbol", chooseSymbol(res.forecast.condition)));

            let conditionSpanEl = createElement("span", "condition");
            conditionSpanEl.appendChild(createElement("span", "forecast-data", res.name));
            conditionSpanEl.appendChild(createElement("span", "forecast-data", `${res.forecast.low}&#176;/${res.forecast.high}&#176;`));
            conditionSpanEl.appendChild(createElement("span", "forecast-data", res.forecast.condition));

            forecastsDivEl.appendChild(conditionSpanEl);

            currentWeatherEl.appendChild(forecastsDivEl);
        }
        function createElement(elType, classes, textContent) {
            let newElement = document.createElement(elType);

            if (classes) {
                newElement.className += classes;
            }

            if (textContent) {
                newElement.innerHTML = textContent;
            }

            return newElement;
        }
        function chooseSymbol(weather) {
            switch (weather.toLowerCase()) {
                case 'sunny':
                    return '&#x2600;';
                    break;
                case 'partly sunny':
                    return '&#x26C5; ';
                    break;
                case 'overcast':
                    return '&#x2601;';
                    break;
                case 'rain':
                    return '&#x2614;';
                    break;
                case 'degrees':
                    return '&#176;';
                    break;
            }
        }
    })
}

attachEvents();