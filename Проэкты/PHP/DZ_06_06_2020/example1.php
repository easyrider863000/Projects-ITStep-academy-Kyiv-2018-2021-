<?php

    $colors = [
        "red",
        "green",
        "blue",
        "pink",
        "gray",
        "brown",
        "black"
    ];

    function remove_rand(&$arr){
        $position = array_rand($arr);
        $color = $arr[$position];
        unset($arr[$position]);
        return $color;
    }

?>

<!DOCTYPE html>
<html>
<head>
    <title>COLORS</title>
    <style>
        h5{
            display: flex;
            flex-direction: row;
            flex-flow: row;
            flex-wrap: wrap;
            margin: 10px;
        }
        div{
            width: 100px;
            height: 100px;
            margin:10px;
            border-radius: 10px;
        }
    </style>
</head>
<body>
	<h5>
		<?php for ($i = 0; $i < 4; $i++) { ?>
        <div style="background-color: <?=remove_rand($colors)?>"></div>
		<?php } ?>
	</h5>
</body>
</html>