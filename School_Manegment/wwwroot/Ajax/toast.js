(function () {

    function initToast() {

        let container = document.getElementById("toastContainer");

        // Container already exists nahi hai to create karo
        if (!container) {

            container = document.createElement("div");

            container.id = "toastContainer";

            document.body.appendChild(container);
        }


        // Global Toast Function
        window.showToast = function (
            message,
            type = "success",
            duration = 4000
        ) {

            const toast = document.createElement("div");

            toast.className = `app-toast ${type}`;


            let icon = "bi-check-circle-fill";

            if (type === "error") {
                icon = "bi-x-circle-fill";
            }
            else if (type === "warning") {
                icon = "bi-exclamation-triangle-fill";
            }
            else if (type === "info") {
                icon = "bi-info-circle-fill";
            }


            toast.innerHTML = `
                <div class="toast-icon">
                    <i class="bi ${icon}"></i>
                </div>

                <div class="toast-content">

                    <div class="toast-title">
                        ${getToastTitle(type)}
                    </div>

                    <div class="toast-message">
                        ${message}
                    </div>

                </div>

                <button
                    type="button"
                    class="toast-close">

                    <i class="bi bi-x"></i>

                </button>
            `;


            container.appendChild(toast);


            // Show animation
            setTimeout(function () {

                toast.classList.add("show");

            }, 10);


            // Close button
            const closeButton =
                toast.querySelector(".toast-close");

            if (closeButton) {

                closeButton.addEventListener(
                    "click",
                    function () {

                        removeToast(toast);

                    }
                );

            }


            // Auto close
            const timer = setTimeout(function () {

                removeToast(toast);

            }, duration);


            // Pause timer on hover
            toast.addEventListener(
                "mouseenter",
                function () {

                    clearTimeout(timer);

                }
            );

        };


        function getToastTitle(type) {

            switch (type) {

                case "success":
                    return "Success";

                case "error":
                    return "Error";

                case "warning":
                    return "Warning";

                case "info":
                    return "Information";

                default:
                    return "Notification";
            }

        }


        function removeToast(toast) {

            if (!toast) return;

            toast.classList.remove("show");

            setTimeout(function () {

                if (toast && toast.parentNode) {

                    toast.remove();

                }

            }, 400);

        }

    }


    // IMPORTANT:
    // Body load hone ke baad initialize karo

    if (document.readyState === "loading") {

        document.addEventListener(
            "DOMContentLoaded",
            initToast
        );

    }
    else {

        initToast();

    }

})();