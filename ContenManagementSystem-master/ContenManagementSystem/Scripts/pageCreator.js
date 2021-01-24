function onChangeNumberOfSections() {
    let numberOfSections = document.getElementById('numberOfSections');
    // let sectionNumber = document.getElementById('sectionNumber');
    // while(sectionNumber.hasChildNodes()){
    //     sectionNumber.removeChild(sectionNumber.lastChild);
    // }
    // for (let index = 0; index < numberOfSections.value; index++) {
    //     let option = document.createElement("option");
    //     option.value = index;
    //     option.text = index;
    //     sectionNumber.appendChild(option);
    // }
    let sectionDivisions = document.getElementById("sectionDivisions");
    while (sectionDivisions.hasChildNodes()) {
        sectionDivisions.removeChild(sectionDivisions.lastChild);
    }
    for (let i = 0; i < numberOfSections.value; i++) {
        let sectionLabel = document.createElement("label");
        sectionLabel.innerHTML = "Divisions inside Section : " + i + "<br/>";
        sectionDivisions.appendChild(sectionLabel);
        let divisionsDropDown = document.createElement("select");
        divisionsDropDown.id = "section" + i;
        divisionsDropDown.onchange = onChangeNumberOfDivs;
        for (let j = 0; j < divisions.length; j++) {
            let option = document.createElement("option");
            option.value = divisions[j];
            option.text = divisions[j];
            divisionsDropDown.appendChild(option);
        }
        sectionDivisions.appendChild(divisionsDropDown);
        var br = document.createElement("br");
        sectionDivisions.appendChild(br)
        var divData = document.createElement("div");
        divData.id = "divsection" + i;
        sectionDivisions.appendChild(divData)
    }
}
const divisions = [1, 2, 3, 4, 6, 12];
const divisionTypes = ["text/html", "image", "video"];

onChangeNumberOfDivs = (e) => {
    let divData = document.getElementById('div' + e.target.id);
    while (divData.hasChildNodes()) {
        divData.removeChild(divData.lastChild);
    }
    for (let i = 0; i < e.target.value; i++) {
        let sectionLabel = document.createElement("label");
        sectionLabel.innerHTML = "Type of Div Data : " + i + "<br/>";
        divData.appendChild(sectionLabel);
        divData.appendChild(document.createElement("p"));
        let divisionTypeDropDown = document.createElement("select");
        divisionTypeDropDown.id = e.target.id + "_" + "division" + i;
        for (let j = 0; j < divisionTypes.length; j++) {
            let option = document.createElement("option");
            option.value = divisionTypes[j];
            option.text = divisionTypes[j];
            divisionTypeDropDown.appendChild(option);
        }
        divData.appendChild(divisionTypeDropDown);
        var br = document.createElement("br");
        divData.appendChild(br);
        divData.appendChild(document.createElement("p"));
        //let input = document.createElement("input");
        //input.id = e.target.id + "_" + "division" + i + "_content";
        //input.placeholder = "Enter the details of the division type";
        //divData.appendChild(input);

        let textArea = document.createElement("textarea");
        textArea.id = e.target.id + "_" + "division" + i + "_content";
        textArea.placeholder = "Enter the details of the division type";
        textArea.maxLength = "5000";
        textArea.cols = "80";
        textArea.rows = "5";
        divData.appendChild(textArea);

        divData.appendChild(br);
    }

}


// function onChangeNumberOfDivisions() {
//     let numberOfDivisions = document.getElementById('numberOfDivisions');
//     let divisionNumber = document.getElementById('divisionNumber');
//     while (divisionNumber.hasChildNodes()) {
//         divisionNumber.removeChild(divisionNumber.lastChild);
//     }
//     for (let index = 0; index < numberOfDivisions.value; index++) {
//         let option = document.createElement("option");
//         option.value = index;
//         option.text = index;
//         divisionNumber.appendChild(option);
//     }
// }



function save2() {
    let sectionsToSave = [];
    for (let index = 0; index < numberOfSections.value; index++) {
        let divs = [];
        for (let j = 0; j < document.getElementById('section' + index).value; j++) {
            divs.push({
                divnumber: j,
                divtype: document.getElementById('section' + index + "_" + "division" + j).value,
                divData: document.getElementById('section' + index + "_" + "division" + j + "_content").value
            });
        }
        sectionsToSave.push({sectionNumber:index,divs:divs});
    }

    let modData = {
        pageName: document.getElementById('pageName').value,
        sections: sectionsToSave
    }

    fetch(window.location.protocol + "//" + window.location.host + "/Page/saveNewPage", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(modData),
    }).then(response => {
        if (response["status"] == 400) {
                alert("Error");
                let errors = document.getElementById("errors");
                while (errors.hasChildNodes()) {
                    errors.removeChild(errors.lastChild);
                }
            let listError = document.createElement("ul");
            JSON.parse(response["statusText"]).map((e) => {
                    let errorItem = document.createElement("li");
                    errorItem.innerHTML = e;
                    listError.appendChild(errorItem);
                });
            errors.appendChild(listError);
            if ('scrollRestoration' in history) {
                history.scrollRestoration = 'manual';
            }
            window.scrollTo(0, 0);
                return;
            }
            let a = document.createElement("a");
            a.setAttribute("href", window.location.protocol + "//" + window.location.host + "/Page/Index/"+modData.pageName)
            a.click();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}



function save() {
    let ktemp = [];
    for (let index = 0; index < numberOfSections.value; index++) {
        ktemp.push({ sectionNumber: index, divisions: document.getElementById('section' + index).value });
    }

    let modData = {
        pageName: document.getElementById('pageName').value,
        sectionDetails: ktemp
    }

    // let data = { 
    //     pageName: document.getElementById('pageName').value,
    //     numberOfSections:document.getElementById('numberOfSections').value,
    //     sectionNumber:document.getElementById('sectionNumber').value,
    //     numberOfDivisions:document.getElementById('numberOfDivisions').value,
    //     divisionNumber:document.getElementById('divisionNumber').value,
    //     divisionType: document.getElementById('divisionType').value
    // };

    fetch(window.location.protocol + "//" + window.location.host + "/Page/savePageSettings", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(modData),
    })
        .then(data => {
            let a = document.createElement("a");
            a.setAttribute("href", window.location.protocol + "//" + window.location.host + "/Page/Index/test")
            a.click();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

