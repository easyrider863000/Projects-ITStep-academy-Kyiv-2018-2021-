<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MVC-Demo</title>
</head>
<body>
    <header>
        <h1>MVC-Demo</h1>
        <hr>
    </header>
    <nav>
        |
        <a href="/php/newsportal/home/index">Главная</a>
        |
        <a href="/php/newsportal/home/about">Про сайт</a>
        |
        <a href="/php/newsportal/home/contact">Контакты</a>
        |
        <?php
            if(strlen($_SESSION['user'])>0){
                echo("<a href='/php/newsportal/auth/logout'>Выход</a>");
            }
            else{
                echo("<a href='/php/newsportal/auth/login'>Вход</a>");
            }
        ?>
        |
        <a href="/php/newsportal/auth/logup">Регистрация</a>
        |
        <?php
            $user = $_SESSION['user'];
            echo("Привет ☺☺☺ $user");?>
    </nav>
    <main>
        <hr>
        <?=$content?>
    </main>
</body>
</html>