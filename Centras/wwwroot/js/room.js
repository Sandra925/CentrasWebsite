document.addEventListener("DOMContentLoaded", function () {
    const checkInInput = document.getElementById("check-in");
    const checkOutInput = document.getElementById("check-out");
    const adultsInput = document.getElementById("AdultsNum");
    const kidsInput = document.querySelector("select:not(#AdultsNum)");

    document.querySelectorAll(".btn-primary").forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault();
            const form = this.closest("form");
            form.querySelector("#check-in").value = checkInInput.value;
            form.querySelector("#check-out").value = checkOutInput.value;
            form.querySelector("#AdultsNum").value = adultsInput.value;
            form.querySelector("#KidsNum").value = kidsInput.value;
            form.submit();
        });
    });
});

function showGallery(images) {
    const modal = document.getElementById("roomGalleryModal");
    const carouselInner = modal.querySelector(".carousel-inner");
    carouselInner.innerHTML = ""; // Clear previous images

    images.forEach((img, index) => {
        const isActive = index === 0 ? "active" : "";
        const carouselItem = document.createElement("div");
        carouselItem.className = `carousel-item ${isActive}`;
        carouselItem.innerHTML = `<img src="${img}" class="d-block w-100" alt="Room Image">`;
        carouselInner.appendChild(carouselItem);
    });

    const bsModal = new bootstrap.Modal(modal);
    bsModal.show();

    // Ensure modal closes properly when clicking outside
    modal.addEventListener("click", function (event) {
        if (event.target === modal) {
            bsModal.hide();
        }
    });
}
//FIND ROOM BUTTON
document.getElementById("findRoom").addEventListener("click", function (event) {
    event.preventDefault();

    let formData = new FormData(document.getElementById("room-form")); 


    let checkIn = document.getElementById("check-in").value;
    let checkOut = document.getElementById("check-out").value;
    let adults = document.getElementById("AdultsNum").value;
    let kids = document.getElementById("KidsNum").value;
    const today = new Date();
    const formatToday = today.toISOString().split('T')[0];

    if (!checkIn || !checkOut || (adults==0 && !kids==0)) {
        alert("Užpildykite kambario paieškos stulpelius!");
        return;
    }
    if (checkIn > checkOut) {
        alert("Netinkamos datos!");
        return;
    }

    fetch('/Rooms', { 
        method: 'POST',
        body: formData
    })
        .then(response => response.text())
        .then(data => {
            document.getElementById("roomsContainer").innerHTML = data; 
        })
        .catch(error => console.error("Error:", error));
});
