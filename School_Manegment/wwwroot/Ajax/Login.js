$.ajaxSetup({
    beforeSend: function (xhr) {

        const token = localStorage.getItem("token");

        if (token) {
            xhr.setRequestHeader(
                "Authorization",
                "Bearer " + token
            );
        }
    }
});

function togglePassword() {

    const password =
        document.getElementById("password");

    const icon =
        document.getElementById("passwordIcon");


    if (password.type === "password") {

        password.type = "text";

        icon.classList.remove("bi-eye");

        icon.classList.add("bi-eye-slash");

    }
    else {

        password.type = "password";

        icon.classList.remove("bi-eye-slash");

        icon.classList.add("bi-eye");

    }

}
// =======================Login
$("#loginForm").on("submit", function (e) {

    e.preventDefault();

    const login = {
        email: $("#email").val(),
        password: $("#password").val()
    };

    console.log("Sending:", login);

    $.ajax({
        url: "/api/Login/Autrize",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(login),

        success: function (response) {

            console.log("Response:", response);

            if (response.success) {

                localStorage.setItem(
                    "token",
                    response.token
                );

                sessionStorage.setItem(
                    "toastMessage",
                    response.message || "Login successful!"
                );

                window.location.href =
                    "/Home/Index";

            } else {

                showToast(
                    response.message || "Invalid email or password",
                    "error"
                );
            }
        },

        error: function (xhr) {

            console.log("Status:", xhr.status);
            console.log("Response:", xhr.responseText);

            $("#message")
                .text("Something went wrong!")
                .css("color", "red");
        }
    });
});