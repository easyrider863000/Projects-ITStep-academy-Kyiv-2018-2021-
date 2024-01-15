<?php

namespace providers;

class MySqlProvider
{

    public $pdo;

    public function __construct()
    {
        $settings = $this->getPDOSettings();
        $this->pdo = new \PDO($settings['conn_str'], $settings['user'], $settings['pass'], null);
    }

    public function getPDOSettings()
    {
        $config = include ROOTPATH . DIRECTORY_SEPARATOR . 'config' . DIRECTORY_SEPARATOR . 'db_config.php';
        $result['conn_str'] = "{$config['type']}:host={$config['host']};dbname={$config['dbname']};charset={$config['charset']}";
        $result['user'] = $config['user'];
        $result['pass'] = $config['pass'];
        return $result;
    }

    public function execute($query, array $params = null)
    {
        if (is_null($params)) {
            $stmt = $this->pdo->prepare($query);
            $stmt->execute();
            $result = $stmt->fetchAll();
            return $result;
        }
        else{

            $stmt = $this->pdo->prepare($query);
            for($i = 0;$i<count($params);$i+=2){
                $stmt->bindValue($params[$i], $params[$i+1]);
            }
            $stmt->execute();
        }
    }
}
