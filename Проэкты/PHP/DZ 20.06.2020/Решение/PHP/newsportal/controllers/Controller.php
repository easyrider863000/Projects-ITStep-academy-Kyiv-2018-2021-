<?php

namespace controllers;

class Controller {

    public $base_tpl = 'views/layout/base.php';

    public function renderTemplate($content) {
        ob_start();
        require ROOTPATH.DIRECTORY_SEPARATOR.'views'.DIRECTORY_SEPARATOR.'layout'.DIRECTORY_SEPARATOR.'base.php';
        return ob_get_clean();
    }

    public function renderContent($dirName, $viewName, array $params=[]) {
        $viewFile = ROOTPATH.DIRECTORY_SEPARATOR.'views'.DIRECTORY_SEPARATOR.$dirName.DIRECTORY_SEPARATOR.$viewName.'.php';
        
        extract($params);
        ob_start();
        require $viewFile;

        $content = ob_get_clean();
        ob_end_clean();
        return $this->renderTemplate($content);
    }

}