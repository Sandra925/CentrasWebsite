document.addEventListener("DOMContentLoaded", function () {
    const checkInInput = document.getElementById("check-in");
    const checkOutInput = document.getElementById("check-out");
    const adultsInput = document.getElementById("AdultsNum");
    const kidsInput = document.querySelector("select:not(#AdultsNum)");

    adultsInput.addEventListener('change', updateKidsOptions);
    updateKidsOptions();
    function updateKidsOptions() {
        const adults = parseInt(adultsInput.value);
        const currentKidValue = parseInt(kidsInput.value);

        // Reset kids options
        kidsInput.innerHTML = `
            <option value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
        `;

        // Remove invalid options based on adult count
        if (adults === 2) {
            // Remove option 2 from kids dropdown
            const kidOption2 = kidsInput.querySelector('option[value="2"]');
            if (kidOption2) kidOption2.remove();

            // Reset to max allowed if previous selection was invalid
            if (currentKidValue > 1) {
                kidsInput.value = "1";
            }
        } else if (adults === 0) {
            // Remove all options except 0
            const kidOption1 = kidsInput.querySelector('option[value="1"]');
            const kidOption2 = kidsInput.querySelector('option[value="2"]');
            if (kidOption1) kidOption1.remove();
            if (kidOption2) kidOption2.remove();
            kidsInput.value = "0";
        }
    }
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
