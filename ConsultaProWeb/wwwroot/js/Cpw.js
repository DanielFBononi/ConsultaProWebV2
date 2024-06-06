window.onload = function () {
    populateAvailableDates();
};

function openModal() {
    var modal = document.getElementById('myModal');


    modal.style.display = 'block'

    console.log("aaaaaaaaaaaaaaaaaaa")

    var closeModalBtn = document.getElementById('closeModal')
    closeModalBtn.onclick = function () {
        modal.style.display = 'none'
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = 'none'
        }
    }
}

function populateAvailableDates() {
    const currentDate = new Date();
    let currentDateObj = new Date(currentDate);
    const option = document.createElement("option");
    option.value = currentDateObj.toISOString().split("T")[0];
    option.text = currentDateObj.toLocaleDateString("pt-BR", { day: "numeric", month: "short", year: "numeric" });
    currentDateObj.setDate(currentDateObj.getDate() + 1);
}


function toggleMenu() {
    var menu = document.getElementById("menu-dropdown");
    menu.classList.toggle("show");
}

window.onclick = function (event) {
    if (!event.target.matches('.user-icon')) {
        var dropdowns = document.getElementsByClassName("menu-dropdown");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}
