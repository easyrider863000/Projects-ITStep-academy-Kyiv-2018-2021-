
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};


function getAllCategories() {
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
                    .then(result => renderCategoriesTable(result));
            }
        });
}

function renderCategoriesTable(categoriesObj) {

    let token = window.localStorage.getItem('shopapitoken');
    let isAdmin = parseJwt(token).role == "admin";
    if(isAdmin){
        document.getElementById("categoriesTable").innerHTML= `<div id="addBtn">
            <img src="https://img.icons8.com/color/32/000000/plus-2-math.png" />
            </div>
            <div id="tableData"></div>`;
            $('#addBtn').on('click',function() {
                let createUrl = 'http://localhost:5000/api/categories';
                let categoryName = prompt("Input category name");
        
                let newCategory = {
                    "name" : categoryName
                };
        
                let token = window.localStorage.getItem('shopapitoken');
                fetch(createUrl, {
                    method: 'POST',
                    headers: {
                        'Authorization': `bearer ${token}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(newCategory)
                })
                    .then(x => x.json())    
                        .then(result => getAllCategories());
                                           
        
            });
    }
    else{
        document.getElementById("categoriesTable").innerHTML= `
            <div id="tableData"></div>`
    }
    let tableContent = "";
    for (let category of categoriesObj) {
        tableContent += `
        <tr>
            <td>${category.id}</td>
            <td class="categoryName">${category.name}</td>`
            if(isAdmin){
                tableContent+=`<td>
                    <div data-id=${category.id} class="btnEdit">
                        <img src="https://img.icons8.com/color/32/000000/edit.png"/>
                    </div>
                </td>
                <td>
                    <div data-id=${category.id} class="btnRemove">
                        <img src="https://img.icons8.com/color/32/000000/filled-trash.png"/>
                    </div>
                </td>`
            }

        tableContent+=`</tr>`;
    }

    let categoriesTable = `
    <table class="table">
        <thead>
            <th>Id</th>
            <th>Name</th>`
            if(isAdmin){
                categoriesTable+=`
                <th>Edit</th>
                <th>Remove</th>`
            }
        
        categoriesTable+=`</thead>
   
        <tbody>
            ${tableContent}
        </tbody>
    </table>
    `;

    $('#categoriesTable #tableData').html(categoriesTable);
    $('#categoriesTable').removeClass("d-none");

    


    $('.btnEdit').click(function() {
        let elem = $(this).parent().prev();
        let categoryName = elem.text();

        let htmltext = `<input type='text' id="NewName" value=${categoryName} />
            <button type="button" id="saveEditBtn" class="btn btn-success">Save</button>
            <button type="button" id="cancelEditBtn" class="btn btn-danger">Cancel</button>`
        
            elem.html(htmltext);
            
            $('#saveEditBtn').click(function(){
                let id = $(this).parent().prev().text();
                let Url = `http://localhost:5000/api/categories/${id}`;
                let newCategory = {
                        "name": $('#NewName').val()
                };
                let token = window.localStorage.getItem('shopapitoken');
                fetch(Url, {
                        method: 'PUT',
                        body: JSON.stringify(newCategory),
                        headers: {
                            'Authorization': `bearer ${token}`,
                            'Content-Type': 'application/json'
                        }
                });
                getAllCategories();
            });
            
            $('#cancelEditBtn').click(function(){
                getAllCategories();
            });
            
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
        .then(x => getAllCategories());

    });  
}



$(document).ready(function () {
   
    $('#addBtn').on('click',function() {
        let createUrl = 'http://localhost:5000/api/categories';
        let categoryName = prompt("Input category name");

        let newCategory = {
            "name" : categoryName
        };

        let token = window.localStorage.getItem('shopapitoken');
        fetch(createUrl, {
            method: 'POST',
            headers: {
                'Authorization': `bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newCategory)
        })
            .then(x => x.json())    
                .then(result => getAllCategories());
                                   

    });

    $("#logoutBtn").click(function() {
        window.localStorage.removeItem('shopapitoken');
        $('#userInfo').addClass("d-none");
        $('#categoriesTable').addClass("d-none");
    });


    let token = window.localStorage.getItem('shopapitoken');

    if (token != null) {
        let userInfo = parseJwt(token);
        $("#userName").text(userInfo.unique_name);
        $('#userInfo').removeClass("d-none");
    }


    getAllCategories();
});