<?php

define('ROOTPATH', __DIR__);

require __DIR__.'/app/App.php';

App::init();
App::$kernel->run();
