<!DOCTYPE html>
<html>
<head>
    <title>Print Lines</title>
</head>
<body>
<form>
    Input <textarea name="lines"></textarea>
    <input type="submit">
</form>
<?php
if (isset($_GET['lines'])) {
    $lines = $_GET['lines'];
    $arr = explode("\n", $lines);
    $arr = array_map('trim', $arr);
    for ($i = 0; $i < count($arr); $i++) {
        if ($arr[$i] == 'Stop') {
            break;
        }
        else {
            echo $arr[$i] . '<br>';
        }
    }
}
?>
</body>
</html>