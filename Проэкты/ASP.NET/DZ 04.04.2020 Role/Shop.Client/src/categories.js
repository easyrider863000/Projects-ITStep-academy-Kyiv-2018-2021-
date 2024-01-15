let edit_id = 1;

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


function getAllCategorys() {
    let url = 'http://localhost:5000/api/categories';

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
                    .then(result => renderCategorysTable(result));
                    
            }
        });
}



function renderCategorysTable(categoriesObj) {

    let tableContent = "";
    for (let category of categoriesObj) {
        tableContent += `
        <tr>
            <td>${category.id}</td>
            <td>${category.name}</td>
            <td>
                <div data-id=${category.id} class="btnEdit" data-toggle="modal" data-target="#EditModal">
                    <img src="https://img.icons8.com/color/32/000000/edit.png"/>
                </div>
            </td>
            <td>
                <div data-id=${category.id} class="btnRemove">
                    <img src="https://img.icons8.com/color/32/000000/filled-trash.png"/>
                </div>
            </td>
        </tr>
        `;
    }

    let categoriesTable = `
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

    $('#categoriesTable #tableData').html(categoriesTable);
    $('#categoriesTable').removeClass("d-none");


    $('.btnEdit').click(function() {
        edit_id = $(this).attr("data-id");
    });

    $('.btnRemove').click(function() {
        let id = $(this).data('id');
        let removeUrl = `http://localhost:5000/api/categories/${id}`;
        let token = window.localStorage.getItem('shopapitoken');
        fetch(removeUrl, {
            method: 'DELETE',
            headers: {
                'Authorization': `bearer ${token}`
            }
        })
        .then(x => getAllCategorys());

    });

   

    
}


function editCategory(id) {

    let url = `http://localhost:5000/api/categories/${id}`;
    let newCategory = {
        "name": $('#enameForm').val()
    };
    let token = window.localStorage.getItem('shopapitoken');

    fetch(url, {
        method: 'PUT',
        body: JSON.stringify(newCategory),
        headers: {
            'Authorization': `bearer ${token}`,
            'Content-Type': 'application/json'
        }
    })
        .then(x => {
            $('#EditModal').modal('hide');
            getAllCategorys();
        });

};


function createCategory() {

    let url = 'http://localhost:5000/api/categories';
    let newCategory = {
        "name": $('#nameForm').val()
    };
    let token = window.localStorage.getItem('shopapitoken');

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newCategory),
        headers: {
            'Authorization': `bearer ${token}`,
            'Content-Type': 'application/json'
        }
    })
        .then(x => {
            $('#createCategoryModal').modal('hide');
            getAllCategorys();
        });

};




$(document).ready(function () {
   
    $('#saveChangesBtn').click(function () {
        createCategory();
        $('#createCategoryModal input').val('');
    });



    getAllCategorys();
});

$(document).ready(function () {
   
    $('#saveChangesEditBtn').click(function () {
        editCategory(edit_id);
        $('#EditModal input').val('');
    });



    getAllCategorys();
});