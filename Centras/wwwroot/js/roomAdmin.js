document.addEventListener("DOMContentLoaded", function () {
    const submitBtn = document.getElementById("admin-reservation-btn");
    const form = document.getElementById("admin-reservation-form");
    const checkInInput = document.getElementById("admin-reservation-arrival");
    const checkOutInput = document.getElementById("admin-reservation-departure");

    [checkInInput, checkOutInput].forEach(field => {
        field.addEventListener("focus", function () {
            if (!this.value) {
                const today = new Date();
                this.value = today.toISOString().split("T")[0];
            }
        });
    });

    submitBtn.addEventListener("click", function (event) {
        event.preventDefault(); 

        if (!checkInInput.value || !checkOutInput.value) {
            alert("Įveskite atvykimo ir išvykimo datas!");
            return;
        }

        const formData = new FormData(form);

        fetch(window.location.pathname, {
            method: "POST",
            body: formData
        })
            .then(response => {
                if (response.redirected) {
                    window.location.href = response.url;
                } else {
                    return response.text();
                }
            })
            .then(data => {
             
                if (data) {
                    document.body.innerHTML = data;
                }
            })
            .catch(error => console.error("Error:", error));
    });
});
