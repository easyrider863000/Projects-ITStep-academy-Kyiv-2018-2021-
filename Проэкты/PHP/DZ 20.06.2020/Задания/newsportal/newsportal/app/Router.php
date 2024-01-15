<?php

namespace app;

class Router {

    public function route() {
        $route = $_SERVER['REQUEST_URI'];
        $route = explode('/', $route);
        array_shift($route);
        array_shift($route);
        array_shift($route);
        $fragment[0] = array_shift($route);
        $fragment[1] = array_shift($route);
        $fragment[2] = $route;
        return $fragment;
    }

}

// localhost:81/newsportal/home/about