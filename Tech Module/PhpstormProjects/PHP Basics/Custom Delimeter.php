<!DOCTYPE html>
<html>
<head>
    <title>Custom Delimeter</title>
</head>
<body>
<form>
    Delimeter:<input type="text" name="delimeter">
    Input: <textarea name="lines"></textarea>
    <input type="submit">
</form>
<?php
    if (isset($_GET['lines']) && isset($_GET['delimeter'])) {
        $lines = $_GET['lines'];
        $delimeter = $_GET['delimeter'];

        $arr = explode($delimeter, $lines);
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