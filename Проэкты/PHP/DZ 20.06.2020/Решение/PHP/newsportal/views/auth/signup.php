<?php
$title = 'Регистрация';
?>
<div id="main_box" class="container">
    <h3>Регистрация</h3>
    <hr>
    <form id="form1" action="logupform" method="post">
        <div class="form-group">
            <label for="login">Логин:</label><br>
            <input type="text" id="login" name="login" class="form-control" required>
        </div>
        <div class="form-group">
            <label for="pass1">Пароль:</label><br>
            <input type="password" id="pass1" name="pass1" class="form-control" required>
        </div>
        <div class="form-group">
            <label for="pass2">Повтор:</label><br>
            <input type="password" id="pass2" name="pass2" class="form-control" required>
        </div>
        <div class="form-group">
            <label for="email">E-Mail:</label><br>
            <input type="email" id="email" name="email" class="form-control" required>
        </div>
        <div class="form-group">
            <input type="submit" id="submit" name="submit" value="Отправить" class="btn btn-success">
            <input type="reset" id="reset" name="reset" value="Очистить" class="btn btn-success">
        </div>
    </form>
</div>