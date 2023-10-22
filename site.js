const url = 'http://localhost:5201/api/shippers'
let shippers = []

function getShippers() {
    fetch(url)
        .then(response => response.json())
        .then(data => displayShippers(data)
        )
}

function displayShippers(data) {
    let tableData = [];
    $(data).each(function (index, value) {

        tableData.push('<tr><td>' + value.shipperId + '</td><td>' + value.companyName + '</td><td>' + value.phone + '</td>  <td></td></tr>');
    });

    $("table tbody").html(tableData.join(''));
}


function addShipper() {

    let companyName = $("#companyName").val();
    let phone = $("#phone").val();

    fetch(url, {
        method: 'post',
        headers: {
            "Accept": "application/json",
            "Content-type": "application/json",
        },
        body: JSON.stringify({
            companyName: companyName,
            phone: phone
        })
    })
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.log(error));

}

getShippers();