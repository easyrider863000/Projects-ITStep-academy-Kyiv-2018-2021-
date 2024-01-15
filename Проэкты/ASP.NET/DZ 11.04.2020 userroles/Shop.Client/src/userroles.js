
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


function getAllUserRoles() {
    let usersUrl = 'http://localhost:5000/api/users';
    let rolesUrl = 'http://localhost:5000/api/roles';

    let token = window.localStorage.getItem('shopapitoken');
    fetch(usersUrl, {
        headers: {
            'Authorization': `bearer ${token}`
        }
    })
        .then(x => {
            x.json()
                .then(users => {
                    fetch(rolesUrl) 
                        .then(y => {
                            y.json().then(roles => {
                                console.log(users);
                                console.log(roles);
                                renderUserRolesTable(users.data, roles.data);
                            }); 
                        });
                    
                });
        });
}



function renderUserRolesTable(usersObj, rolesObj) {

    let tableContent = "";
    for (let user of usersObj) {
        let listRoles = "";
        for (let role of rolesObj) {
            let checked = user.role.includes(role.name) ? "checked" : "";

            listRoles += `
    
                <div class="form-check">
                    <input class="roleId" type="hidden" value="${role.id}" />
                    
                    <label class="form-check-label">
                        <input type="checkbox" class="checkrole" class="form-check-input roleCheck" ${checked} /> 
                            <span>${role.name}</span>
                    </label>
                </div>
            `
        }
        tableContent += `
        <tr>
            <td>${user.id}</td>
            <td>${user.login}</td>
            <td>${listRoles}</td>
        </tr>
        `;
    }

    let usersTable = `
    <table class="table">
        <thead>
            <th>Id</th>
            <th>Login</th>
            <th>Roles</th>
        </thead>
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;



    $('#userRolesTable #tableData').html(usersTable);
    $('#userRolesTable').removeClass("d-none");

    let checks = document.getElementsByClassName("checkrole");
for(let i = 0;i<checks.length;i++){
    checks[i].addEventListener("change",(e) => {
        
        
        
        let idRole = parseInt(event.target.parentElement.parentElement.getElementsByTagName("input")[0].value);
        let idUser = parseInt(event.target.parentElement.parentElement.parentElement.parentElement.getElementsByTagName("td")[0].innerHTML);
        let token = window.localStorage.getItem('shopapitoken');
        let url = 'http://localhost:5000/api/userroles';
        let newUserRoles = {
        "userid": idUser,
        "roleid": idRole
        };
        if(event.target.checked){
            fetch(url, {
                method: 'POST',
                body: JSON.stringify(newUserRoles),
                headers: {
                    'Authorization': `bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            })
        }
        else{
            fetch(url, {
                method: 'DELETE',
                body: JSON.stringify(newUserRoles),
                headers: {
                    'Authorization': `bearer ${token}`,
                    'Content-Type': 'application/json'
                }
            })
        }
        getAllUserRoles();
        getAllUserRoles();
    });
}

}




$(document).ready(function () {
    getAllUserRoles();
});