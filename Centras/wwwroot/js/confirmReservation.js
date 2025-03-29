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
    const phoneInput = document.getElementById('inputPhone');
    const phoneError = document.createElement('div');
    phoneError.className = 'invalid-feedback';
    phoneInput.parentNode.appendChild(phoneError);

    // Validate on blur
    phoneInput.addEventListener('blur', function () {
        validatePhoneNumber();
    });

    // Clear error on input
    phoneInput.addEventListener('input', function () {
        if (this.classList.contains('is-invalid')) {
            phoneError.textContent = '';
            this.classList.remove('is-invalid');
        }
    });

    function validatePhoneNumber() {
        const phoneRegex = /^[+]?[\s]?[(]?[0-9]{1,4}[)]?[-\s.]?[0-9]{1,4}[-\s.]?[0-9]{2,6}[-\s.]?[0-9]{2,6}$/;
        const isValid = phoneRegex.test(phoneInput.value.trim());

        if (phoneInput.value.trim() === '') {
            phoneError.textContent = 'Phone number is required';
            phoneInput.classList.add('is-invalid');
            return false;
        } else if (!isValid) {
            phoneError.textContent = 'Please enter a valid international phone number (e.g., +370 123 4567)';
            phoneInput.classList.add('is-invalid');
            return false;
        } else {
            phoneError.textContent = '';
            phoneInput.classList.remove('is-invalid');
            return true;
        }
    }

    document.getElementById("reservationForm").addEventListener("submit", function (event) {
        event.preventDefault();

        // Validate phone number before submission
        const isPhoneValid = validatePhoneNumber();

        if (!isPhoneValid) {
            // Scroll to the phone input to show the error
            phoneInput.scrollIntoView({ behavior: 'smooth', block: 'center' });
            phoneInput.focus();
            return;
        }

        let formData = new FormData(this);

        fetch("/ConfirmReservation", {
            method: "POST",
            body: formData
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = "/ReservationSuccess";
                } else {
                    return response.json().then(err => {
                        // Handle server-side validation errors
                        if (err.errors) {
                            Object.entries(err.errors).forEach(([field, messages]) => {
                                const input = document.querySelector(`[name="${field}"]`);
                                const errorDiv = input.nextElementSibling || input.parentNode.querySelector('.invalid-feedback');
                                if (input && errorDiv) {
                                    input.classList.add('is-invalid');
                                    errorDiv.textContent = messages.join(', ');
                                }
                            });
                        } else {
                            throw new Error(err.title || 'An error occurred');
                        }
                    });
                }
            })
            .catch(error => {
                console.error("Error submitting reservation:", error);
                alert(error.message || "An error occurred! Please try again.");
            });
    });
});