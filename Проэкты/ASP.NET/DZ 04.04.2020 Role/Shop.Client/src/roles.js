let edit_id = 1;

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


function getAllRoles() {
    let url = 'http://localhost:5000/api/roles';

    let token = window.localStorage.getItem('shopapitoken');
    fetch(url, {
        headers: {
            'Authorization': `bearer ${token}`
        }})
        .then(x => {

            if (!x.ok) {
                $('#infoBlock')
                    .removeClass('d-none')
                        .text(x.statusText);
               
            } else {
                $('#infoBlock').addClass('d-none')
                x.json()
                    .then(result => renderRolesTable(result));
                    
            }
        });
}



function renderRolesTable(rolesObj) {

    let tableContent = "";
    for (let role of rolesObj) {
        tableContent += `
        <tr>
            <td>${role.id}</td>
            <td>${role.name}</td>
            <td>
                <div data-id=${role.id} class="btnEdit" data-toggle="modal" data-target="#EditModal">
                    <img src="https://img.icons8.com/color/32/000000/edit.png"/>
                </div>
            </td>
            <td>
                <div data-id=${role.id} class="btnRemove">
                    <img src="https://img.icons8.com/color/32/000000/filled-trash.png"/>
                </div>
            </td>
        </tr>
        `;
    }

    let rolesTable = `
    <table class="table">
        <thead>
            <th>Id</th>
            <th>Name</th>
        </thead>
   
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;

    $('#rolesTable #tableData').html(rolesTable);
    $('#rolesTable').removeClass("d-none");


    $('.btnEdit').click(function() {
        edit_id = $(this).attr("data-id");
    });

    $('.btnRemove').click(function() {
        let id = $(this).data('id');
        let removeUrl = `http://localhost:5000/api/roles/${id}`;
        let token = window.localStorage.getItem('shopapitoken');
        fetch(removeUrl, {
            method: 'DELETE',
            headers: {
                'Authorization': `bearer ${token}`
            }
        })
        .then(x => getAllRoles());

    });

   

    
}


function editRole(id) {

    let url = `http://localhost:5000/api/roles/${id}`;
    let newRole = {
        "name": $('#enameForm').val()
    };
    let token = window.localStorage.getItem('shopapitoken');

    fetch(url, {
        method: 'PUT',
        body: JSON.stringify(newRole),
        headers: {
            'Authorization': `bearer ${token}`,
            'Content-Type': 'application/json'
        }
    })
        .then(x => {
            $('#EditModal').modal('hide');
            getAllRoles();
        });

};


function createRole() {

    let url = 'http://localhost:5000/api/roles';
    let newRole = {
        "name": $('#nameForm').val()
    };
    let token = window.localStorage.getItem('shopapitoken');

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newRole),
        headers: {
            'Authorization': `bearer ${token}`,
            'Content-Type': 'application/json'
        }
    })
        .then(x => {
            $('#createRoleModal').modal('hide');
            getAllRoles();
        });

};




$(document).ready(function () {
   
    $('#saveChangesBtn').click(function () {
        createRole();
        $('#createRoleModal input').val('');
    });



    getAllRoles();
});

$(document).ready(function () {
   
    $('#saveChangesEditBtn').click(function () {
        editRole(edit_id);
        $('#EditModal input').val('');
    });



    getAllRoles();
});