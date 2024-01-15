<?php

define('ROOTPATH', __DIR__);
session_start();
require __DIR__.'/app/App.php';
App::init();
App::$kernel->run();
