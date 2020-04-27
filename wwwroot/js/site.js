const uri = 'api/Telegrams';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const p1box = document.getElementById('textBox_p1');
    const p2box = document.getElementById('textBox_p2');
    const p3box = document.getElementById('textBox_p3');
    const p4box = document.getElementById('textBox_p4');
    const p5box = document.getElementById('textBox_p5');
    const t1box = document.getElementById('textBox_t1');

    var d = new Date();

    const item = {
       
        p1: Number.parseFloat(p1box.value),
        p2: Number.parseFloat(p2box.value), 
        p3: Number.parseFloat(p3box.value), 
        p4: Number.parseFloat(p4box.value), 
        p5: Number.parseFloat(p5box.value), 
        t1: t1box.value,
        date: d
    };

    
   
        fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
            body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            
            getItems();
            textBox_p1.value = '';
            textBox_p2.value = '';
            textBox_p3.value = '';
            textBox_p4.value = '';
            textBox_p5.value = '';
            textBox_t1.value = '';
        })
        .catch(error => alert('Unable to add item.', error));
    
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'telegram' : 'telegrams';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        //let isCompleteCheckbox = document.createElement('input');
        //isCompleteCheckbox.type = 'checkbox';
        //isCompleteCheckbox.disabled = true;
        //isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        //td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode("ID=" + item.id + " Date: " + item.date + " p1=" + item.p1 + " p2=" + item.p2 + " p3=" + item.p3 + " p4=" + item.p4 + " p5=" + item.p5 + " t1=" + item.t1);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        //td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    todos = data;
}