
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

// function getAllUsers() {
//     let url = 'http://localhost:5000/api/users';

//     let token = window.localStorage.getItem('shopapitoken');
//     fetch(url, {
//         headers: {
//             'Authorization': `bearer ${token}`
//         }})
//         .then(x => {

//             if (!x.ok) {
//                 $('#infoBlock')
//                     .removeClass('d-none')
//                         .text(x.statusText);

//             } else {
//                 $('#infoBlock').addClass('d-none')
//                 x.json()
//                     .then(result => renderUsersTable(result));

//             }
//         });
// }

async function getAllUsers() {
    let url = 'http://localhost:5000/api/users';

    let token = window.localStorage.getItem('shopapitoken');
    let response = await fetch(url, { headers: { 'Authorization': `bearer ${token}` } });

    if (!response.ok) {
        $('#infoBlock').removeClass('d-none').text(response.statusText);
    } else {
        $('#infoBlock').addClass('d-none')
        let json = await response.json();
        renderUsersTable(json.data);
    }

}



function renderUsersTable(usersObj) {

    let tableContent = "";
    for (let user of usersObj) {
        tableContent += `
        <tr>
            <td>${user.id}</td>
            <td class="userName">${user.firstname}</td>
            <td>${user.lastname}</td>
            <td>${user.login}</td>
            <td>${user.role}</td>
            <td>
                <div data-id=${user.id} class="btnEdit">
                    <img src="https://img.icons8.com/color/32/000000/edit.png"/>
                </div>
            </td>
            <td>
                <div data-id=${user.id} class="btnRemove">
                    <img src="https://img.icons8.com/color/32/000000/filled-trash.png"/>
                </div>
            </td>
        </tr>
        `;
    }

    let usersTable = `
    <table class="table">
        <thead>
            <th>Id</th>
            <th>Firstname</th>
            <th>Lastname</th>
            <th>Login</th>
            <th>Role</th>
            <th>Edit</th>
            <th>Remove</th>
        </thead>
   
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;

    $('#usersTable #tableData').html(usersTable);
    $('#usersTable').removeClass("d-none");


    $('.btnEdit').click(function () {
        let elem = $(this).parent().prev();
        let userName = elem.text();
        elem.html(`<input type='text' value=${userName} />`);
    });

    $('.btnRemove').click(async function () {
        let id = $(this).data('id');
        let removeUrl = `http://localhost:5000/api/users/${id}`;
        let token = window.localStorage.getItem('shopapitoken');
        let response = await fetch(removeUrl, {
            method: 'DELETE',
            headers: {
                'Authorization': `bearer ${token}`
            }
        });
          
        getAllUsers();

    });




}


function createUser() {

    let url = 'http://localhost:5000/api/users';
    let newUser = {
        "firstname": $('#nameForm').val(),
        "lastname": $('#lastnameForm').val(),
        "login": $('#loginForm').val(),
        "password": $('#passwordForm').val(),
        "role": $('#roleForm').val()
    };

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newUser),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(x => {
            $('#createUserModal').modal('hide');
            getAllUsers();
        });

};




$(document).ready(function () {

    $('#saveChangesBtn').click(function () {
        createUser();
        $('#createUserModal input').val('');
    });



    getAllUsers();
});