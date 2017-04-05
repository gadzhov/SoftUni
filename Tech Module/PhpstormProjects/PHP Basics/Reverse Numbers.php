<!DOCTYPE html>
<html>
<head>
    <title>Reverse Numbers</title>
</head>
<body>
<form>
    <input type="text" name="delimeter">
    <input type="text" name="numbers">
    <input type="submit">
</form>
<?php
    if (isset($_GET['numbers']) && isset($_GET['delimeter'])) {
        $delimeter = $_GET['delimeter'];
        $lines = $_GET['numbers'];

        $arr = explode($delimeter, $lines);
        $arr = array_map('trim', $arr);
        for ($i = count($arr) - 1; $i >= 0; $i--) {
            echo $arr[$i] . '<br>';
        }
    }
?>
</body>
</html>