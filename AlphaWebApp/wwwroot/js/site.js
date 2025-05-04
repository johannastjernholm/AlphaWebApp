//Kod skriven i samarbete med AI

//Validera formulär med just validate 
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
document.querySelector("#projectForm")?.addEventListener("submit", () => {
    console.log("Projektformuläret försöker skickas");
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


//function toggleSettingsMenu(button) {
//    const menu = button.nextElementSibling;
//    menu.style.display = menu.style.display === "block" ? "none" : "block";

//    document.querySelectorAll(".settings-menu").forEach(m => {
//        if (m !== menu) m.style.display = "none";
//    });
//}

function toggleSettingsMenu(button) {
    const menu = button.nextElementSibling;
    if (menu) {
        const isVisible = menu.style.display === "block";
        menu.style.display = isVisible ? "none" : "block";
    }
}

document.addEventListener("click", function (e) {
    const isInsideMenu = e.target.closest(".dropdown");

    if (!isInsideMenu) {
        document.querySelectorAll(".settings-menu").forEach(menu => {
            menu.style.display = "none";
        });
    }
});

const logoutForm = document.getElementById("logoutForm");
if (logoutForm) {
    logoutForm.addEventListener("submit", (event) => {
        console.log("Logout-form skickas!");
    });
}