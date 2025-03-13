document.addEventListener("DOMContentLoaded", function () {
    const checkInInput = document.getElementById("check-in");
    const checkOutInput = document.getElementById("check-out");
    const adultsInput = document.getElementById("AdultNum");
    const kidsInput = document.querySelector("select:not(#AdultNum)");

    document.querySelectorAll(".btn-primary").forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault();
            const form = this.closest("form");
            form.querySelector("#CheckInDate").value = checkInInput.value;
            form.querySelector("#CheckOutDate").value = checkOutInput.value;
            form.querySelector("#AdultsNum").value = adultsInput.value;
            form.querySelector("#KidsNum").value = kidsInput.value;
            form.submit();
        });
    });
});

    document.addEventListener("DOMContentLoaded", function () {
        const thumbnails = document.querySelectorAll(".room-thumbnail");

        // Room-specific gallery
        thumbnails.forEach(thumbnail => {
            thumbnail.addEventListener("click", function () {
                showGallery(this.getAttribute("data-images").split(","));
            });
        });

        // Show all photos button
        const showAllPhotosBtn = document.querySelector(".btn-show-all-photos");
        if (showAllPhotosBtn) {
            showAllPhotosBtn.addEventListener("click", function () {
                const allImages = [...thumbnails]
                    .map(thumb => thumb.getAttribute("data-images").split(","))
                    .flat(); // Merge all image arrays

                showGallery(allImages);
            });
        }

        function showGallery(images) {
            const modal = document.getElementById("roomGalleryModal");
            const carouselInner = modal.querySelector(".carousel-inner");
            carouselInner.innerHTML = ""; // Clear previous images

            images.forEach((img, index) => {
                console.log(`Adding image ${index + 1}:`, img); // Log each image
                const isActive = index === 0 ? "active" : "";
                carouselInner.innerHTML += `
                <div class="carousel-item ${isActive}">
                    <img src="${img}" class="d-block w-100" alt="Room Image">
                </div>`;
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
    });

//FIND ROOM BUTTON
document.getElementById("findRoom").addEventListener("click", function (event) {
    event.preventDefault();

    let formData = new FormData(document.querySelector("form")); 

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
