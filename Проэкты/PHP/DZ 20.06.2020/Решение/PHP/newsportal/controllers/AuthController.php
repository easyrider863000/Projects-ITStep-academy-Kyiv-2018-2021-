<?php

namespace controllers;

use providers\MySqlProvider;

class AuthController extends Controller
{

    public function login()
    {
        return $this->renderContent('auth', 'signin');
    }

    public function logout()
    {
        return $this->renderContent('auth', 'signout');
    }

    public function logup()
    {
        return $this->renderContent('auth', 'signup');
    }

    public function logupform()
    {
        date_default_timezone_set('Europe/Kiev');

        $login = trim(htmlspecialchars($_POST['login']));
        $pass1 = trim(htmlspecialchars($_POST['pass1']));
        $pass2 = trim(htmlspecialchars($_POST['pass2']));
        $email = trim(htmlspecialchars($_POST['email']));

        echo ('<div id="report_box" class="container">');
        echo ('<h2>Отчет о результатах регистрации</h2>');
        echo ('<hr><h5>');

        $passw = md5($pass1);

        $mys = new MySqlProvider('localhost', 'root', 'root', 'newsportal');
        $query = "INSERT INTO users (login, passw, email) VALUES (:login, :passw, :email)";
        $mys->execute($query, [':login', $login, ':passw', $passw, ':email', $email]);

        echo ('<span style="color: green">Регистрация успешно завершена </span><br>');
        echo ('<a href="../">На главную</a>');
        echo ('</h5></div>');
    }

    public function loginform()
    {
        $login = trim(htmlspecialchars($_POST['login']));
        $pass1 = trim(htmlspecialchars($_POST['pass1']));

        echo ('<div id="report_box" class="container">');
        echo ('<h2>Отчет о результатах регистрации</h2>');
        echo ('<hr><h5>');

        $passw = md5($pass1);

        $mys = new MySqlProvider('localhost', 'root', 'root', 'newsportal');
        $query = "SELECT login,passw FROM users where login='$login'";
        $res = $mys->execute($query);
        $name = $res[0]['login'];
        if($res[0]['passw'] = $passw){
            $_SESSION['user'] = $name;
            echo ("<span style='color: green'>Добро пожаловать, $name !</span><br>");
            
        }
        echo ('<a href="../">На главную</a>');
        echo ('</h5></div>');
    }
    public function logoutform(){
        $_SESSION['user'] = "";
        echo ('<div id="report_box" class="container">');
        echo ('<hr><h5>');
        echo ('<a href="../">На главную</a>');
        echo ('</h5></div>');
    }
}

