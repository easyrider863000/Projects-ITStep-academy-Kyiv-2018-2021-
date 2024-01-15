<?php
header('Content-Type: text/html; charset=utf-8');
date_default_timezone_set('Europe/Moscow');

function print_date($mon){
    if($mon<1||$mon>12){
        return "Month does not exist...";
    }
    $y = date('Y');
    $m = date($mon);
    $count_day = cal_days_in_month(CAL_GREGORIAN, $m, $y);
    $w = 1;
    ?>
<table>
    <thead>
        <th>Пн</th>
        <th>Вт</th>
        <th>Ср</th>
        <th>Чт</th>
        <th>Пт</th>
        <th class="red">Сб</th>
        <th class="red">Вс</th>
    </thead>
    <tbody>
        <?php for ($i = 1; $i <= $count_day; $i++) {
            if ($w == 1) { ?>
                <tr>
            <?php }
            if ($i < 10) {
                $d = '0' . $i;
            } else {
                $d = $i;
            }
            $d_n = date('N', mktime(0, 0, 0, $m, $d, $y));
            if ($d_n != $w) {
                $c = $d_n - $w;
                for ($q = 0; $q < $c; $q++) { ?>
                    <td></td>
                    <?php $w++;
                }
            } ?>
            <td>
                <?php echo $i; ?>
            </td>
            <?php if ($w == 7) { ?>
                </tr>
            <?php }
            if ($w < 7) {
                $w++;
            } else {
                $w = 1;
            }
        }?>
        </tbody>
    </table>
<?php }?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DATA</title>
    <style>
        table{
            margin: 30px;
            
        }
        th{
            font-style: italic;
        }
        .red{
            color:orangered;
        }
        td{
            width: 100px;
            text-align: center;
            border-radius: 30px;
            border-color:black;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</head>
<body>
    <?=print_date(6);?>
</body>
</html>



