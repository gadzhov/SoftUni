<!DOCTYPE html>
<html>
<head>
    <title>Array Indexes</title>
</head>
<body>
<form>
    <textarea name="key"></textarea>
    <input type="text" name="delimiter">
    <input type="text" name="size">
    <input type="submit">
</form>
<?php
if(isset($_GET['delimiter']) && isset($_GET['size']) && isset($_GET['key'])){
    $delimiter = $_GET['delimiter'];
    $lines = explode("\n", $_GET['key']);
    $resultArray = [];
    for($i = 0; $i < $_GET['size']; $i++){
        $resultArray[$i] = 0;
    }

    foreach ($lines as $line){
        $keyValue = explode($delimiter, $line);
        $resultArray[$keyValue[0]] = $keyValue[1];
    }

    foreach ($resultArray as $resultLine){
        echo ($resultLine .'<br>');
    }
}
?>
</body>
</html>