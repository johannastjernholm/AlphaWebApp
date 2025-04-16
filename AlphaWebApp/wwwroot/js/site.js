//Validera form
document.addEventListener("DOMContentLoaded", function () {
    const validator = new JustValidate("form");

    validator.addField("#ProjectName", [
        {
            rule: "required",
            errorMessage: "Project name is required"
        }
    ])
        .addField("#ClientName", [
            {
                rule: "required",
                errorMessage: "Client name is required"
            }

        ])
        .addField("#Description", [
            {
                rule: "required",
                errorMessage: "Description is required"
            }

        ])
        .addField("#StartDate", [
            {
                rule: "required",
                errorMessage: "A start date is required"
            }
        ])
        .addField("#Budget", [
            {
                rule: "required",
                errorMessage: "Budget is required"
            }

        ])
        .addField("#Status", [
            {
                rule: "required",
                errorMessage: "Status on project is required"
            }

        ])
        // tillåt skicka
        .onSuccess((event) => {
            event.target.submit();
        });

});

// TODO: Skickas det eller låser validate formuläret?
document.querySelector("form").addEventListener("submit", () => {
    console.log("formuläret försöker skickas");
});


// Rediger projekt
function toggleMenu(button) {
    const menu = button.nextElementSibling;
    menu.style.display = menu.style.display === "block" ? "none" : "block";

    // Stäng andra öppna menyer
    document.querySelectorAll(".menu-options").forEach(m => {
        if (m !== menu) m.style.display = "none";
    });
}

document.addEventListener("click", function (e) {
    if (!e.target.closest(".dropdown")) {
        document.querySelectorAll(".menu-options").forEach(m => m.style.display = "none");
    }
});