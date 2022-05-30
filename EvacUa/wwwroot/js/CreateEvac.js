const uri = 'Vehicles';
function addItem() {
    const addOwnerNameTextbox = document.getElementById('OwnerName');
    const addOwnerEmailTextbox = document.getElementById('OwnerEmail');
    const addOwnerTelTextbox = document.getElementById('OwnerTel');
    const addPlacesTextbox = document.getElementById('Places');
    const addFromWhereTextbox = document.getElementById('FromWhere');
    const addToWhereTextbox = document.getElementById('ToWhere');
    const Time = document.getElementById('Time');
    const item = {
        ownerName: addOwnerNameTextbox.value.trim(),
        ownerEmail: addOwnerEmailTextbox.value.trim(),
        ownerTel: addOwnerTelTextbox.value.trim(),
        places: addPlacesTextbox.value.trim(),
        fromWhere: addFromWhereTextbox.value.trim(),
        toWhere: addToWhereTextbox.value.trim(),
        time: Time.value.trim()
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
    alert("Подальші інструкціі відправлені на ваш gmail");
    setTimeout(func1(), 5000);
}
function func1() {
    window.location.reload(true);
    console.log("reloaded");
}