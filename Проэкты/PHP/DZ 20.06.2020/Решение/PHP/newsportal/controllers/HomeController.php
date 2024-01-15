<?php

namespace controllers;

class HomeController extends Controller {

    public function index() {
        return $this->renderContent('home', 'index');
    }

    public function about() {
        return $this->renderContent('home', 'about');
    }

    public function contact() {
        return $this->renderContent('home', 'contact');
    }

}