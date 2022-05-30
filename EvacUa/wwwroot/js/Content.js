const uri = 'Vehicles';
const url = 'Getplace';
let vehicles = [];
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}
function _displayItems(data) {
    data.forEach(item => {
        document.getElementById('Vehicles').insertAdjacentHTML('beforeEnd', getCoordHTML(item));
    });

    vehicles = data;
}
function getCoordHTML(obj) {
    return (
        '<div class="container">' +
        '<div class="left">' +
        '<div class="fromWhere">' + (obj.fromWhere || "") + '</div>' +'<br>'+
        '<div class="time">' + '<div class="text">ДАТА</div>' + (obj.time || "") + '</div>' +
        '</div>' +
        '<div class="middle">' + '<div class="text">МІСЦЯ</div>' + (obj.places || "0") + '<br>' + '<button class="Getplaces" onclick="getPlacesOfVehicle(' + obj.id + ')">Забронювати</button>' +
        '</div > ' +
        '<div class="right">'+
        '<div class="toWhere">' + (obj.toWhere || "") + '</div>' + '<br>' +
        '<div class="vehicleId">' + '<div class="text">ІМ`Я</div>' + (obj.ownerName || "") + '</div>'+
        '</div>' +
        '<div id="hr"><hr></div>' +
        '</div>'
    );
}
function clearArea() {
    document.getElementById('ConteinerOfvehicles').innerHTML = '';
}
function getPlacesOfVehicle(id) {
    console.log(id);
    document.getElementById('ConteinerOfvehicles').style.display = "block";
    clearArea();
    document.getElementById('ConteinerOfvehicles').insertAdjacentHTML('beforeEnd', getForm(id));
    document.getElementById('Booking').insertAdjacentHTML('beforeEnd', getbutton());
}
function getForm(id) {
    return (
        '<form id="Booking" action="javascript:void(0);" method="POST" onsubmit="addItem('+id+')">'+
        '<div id="seats"></div>'+
        '</form>'
    )
}
function getbutton() {
    return (
        '<div id="formNew">' +
        'Email:<input type="email" id="EmailPas" pattert=".+@gmail\.com" placeholder="@gmail.com" required>' + '<br>' +
        'Ім`я:<input type="text" id="Name" placeholder="Ім`я" required>' + '<br>' +
        'Тел.:<input type="tel" id="Phone" name="PhoneOas"  placeholder="123-456-7890" required">' + '<br>' +
        '<input type="submit" value="Забронювати">' +
        '</div >'
        )
}
function addItem(id) {
    const addEmailTextbox = document.getElementById('EmailPas');
    const addNameTextbox = document.getElementById('Name');
    const addPhoneTextbox = document.getElementById('Phone');
    console.log('${url}${id}');
    const item = {
        name: addNameTextbox.value,
        email: addEmailTextbox.value,
        telephone: addPhoneTextbox.value
    };

    fetch(`${uri}/${url}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    });
    alert("Подальші інструкціі відправлені на ваш gmail");
    setTimeout(func1(), 5000);
}
function func1() {
    window.location.reload(true);
    console.log("reloaded");
}