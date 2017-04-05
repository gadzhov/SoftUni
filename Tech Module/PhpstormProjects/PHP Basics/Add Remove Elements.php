<!DOCTYPE html>
<html>
<head>
    <title>Add/Remove Elements</title>
</head>
<body>
<form>
    <textarea name="commands"></textarea>
    <input type="text" name="delimiter">
    <input type="submit">
</form>
<?php
    if (isset($_GET['commands']) && isset($_GET['delimiter'])) {
        $commands = explode("\n", $_GET['commands']);
        $delimiter = $_GET['delimiter'];
        $arrayResult = [];

        foreach ($commands as $cmd) {
            $line = explode($delimiter, $cmd);
            $addRemove = $line[0];
            $value = $line[1];
            if ($addRemove == "add") {
                array_push($arrayResult, $value);
            }
            else if ($addRemove == "remove") {
                array_splice($arrayResult, $value, 1);
            }
        }
        for ($i = 0; $i < count($arrayResult); $i++) {
            echo $arrayResult[$i] . '<br>';
        }
    }
?>
</body>
</html>