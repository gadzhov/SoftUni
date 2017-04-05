function processCommands(comands) {
    let commandProcessor = (function () {
        let result = [];
        return {
            add: (newItem) => result.push(newItem),
            remove: (item) => result = result.filter(w => w != item),
            print: () => console.log(result)
        }
    })();
    for (let cmd of comands) {
        let [cmdName, arg] = cmd.split(' ');
        commandProcessor[cmdName](arg);
    }
}
processCommands(['add hello', 'add again', 'remove hello', 'add again', 'print']);