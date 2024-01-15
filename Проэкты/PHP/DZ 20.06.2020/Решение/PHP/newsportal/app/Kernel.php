<?php

namespace app;

use App;

class Kernel {

    public $defaultControllerName = 'Home';
    public $defaultActionName = 'index';

    public function run() {
        list($controllerName, $actionName, $params) = App::$router->route();
        echo $this->runAction($controllerName, $actionName, $params);
    }

    public function runAction($controllerName, $actionName, $params) {
        $controllerName = empty($controllerName) ? $this->defaultControllerName : ucfirst($controllerName);
        require_once ROOTPATH.DIRECTORY_SEPARATOR.'controllers'.DIRECTORY_SEPARATOR.$controllerName.'Controller.php';
        
        $controllerName = "\\controllers\\".$controllerName.'Controller';
        $controller = new $controllerName;

        $actionName = empty($actionName) ? $this->defaultActionName : $actionName;
        return $controller->$actionName($params);
    }

}

// localhost:81/newsportal/home/about
// Home
// newsportal/controllers/HomeController.php
// use \controllers\HomeController;