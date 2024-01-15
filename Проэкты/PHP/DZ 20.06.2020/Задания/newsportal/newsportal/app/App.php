<?php

class App {

    public static $router;
    public static $kernel;

    public static function init() {
        spl_autoload_register(['static', 'loadClass']);
        static::initialize();
    }

    public static function initialize() {
        static::$router = new app\Router();
        static::$kernel = new app\Kernel();
    }

    public static function loadClass($className) {
        $className = str_replace('\\', DIRECTORY_SEPARATOR, $className);
        require_once ROOTPATH.DIRECTORY_SEPARATOR.$className.'.php';
    }

}