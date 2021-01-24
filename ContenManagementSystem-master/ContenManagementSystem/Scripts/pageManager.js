function onPageSelectedChange(val) {
    let data = {pageName=val}
    fetch(window.location.protocol + "//" + window.location.host + "/Page/pageSections", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(data => {
            let section = document.getElementById('section');
            while (section.hasChildNodes()) {
                section.removeChild(section.lastChild);
            }
            for (let index = 0; index < data.pageSec; index++) {
                let option = document.createElement("option");
                option.value = index;
                option.text = index;
                section.appendChild(option);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function onSectionSelectedChange() {
    let val = document.getElementById('page').value + "&" +  document.getElementById('section').value
    let data = {pageSectionNumber=val}
    fetch(window.location.protocol + "//" + window.location.host + "/Page/pageDivisions", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(data => {
            let division = document.getElementById('division');
            while (division.hasChildNodes()) {
                division.removeChild(division.lastChild);
            }
            for (let index = 0; index < data.divisions; index++) {
                let option = document.createElement("option");
                option.value = index;
                option.text = index;
                division.appendChild(option);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}