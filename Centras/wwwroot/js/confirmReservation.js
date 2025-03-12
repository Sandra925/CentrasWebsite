document.addEventListener("DOMContentLoaded", function () {
    fetch("https://restcountries.com/v3.1/all")
        .then(response => response.json())
        .then(data => {
            const select = document.getElementById("inputState");
            data.sort((a, b) => a.name.common.localeCompare(b.name.common));
            data.forEach(country => {
                let option = document.createElement("option");
                option.value = country.name.common;
                option.textContent = country.name.common;
                select.appendChild(option);
            });
        })
        .catch(error => console.error("Error loading countries:", error));
});
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("reservationForm").addEventListener("submit", function (event) {
        event.preventDefault();

        let formData = new FormData(this);

        fetch("/ConfirmReservation", {
            method: "POST",
            body: formData
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = "/ReservationSuccess";
                } else {
                    return response.text().then(text => { throw new Error(text); });
                }
            })
            .catch(error => {
                console.error("Error submitting reservation:", error);
                alert("Įvyko klaida! Bandykite dar kartą.");
            });
    });
});