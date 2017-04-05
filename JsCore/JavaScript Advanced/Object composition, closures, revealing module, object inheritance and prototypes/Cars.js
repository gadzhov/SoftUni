function createCar(commands) {
    let map = new Map();
    let carManager = {
        create: function ([objName, , parent]) {
            parent = parent ? map.get(parent) : null;
            let newObj = Object.create(parent);
            map.set(objName, newObj);
            return newObj;
        },
        set: function ([objName, key, value]) {
            let obj = map.get(objName);
            obj[key] = value;
        },
        print: function ([objName]) {
            let obj = map.get(objName), objects = [];
            for (let key in obj) { objects.push(`${key}:${obj[key]}`); }
            console.log(objects.join(', '));
        }
    };
    for (let command of commands) {
        let commandParameters = command.split(' ');
        let action = commandParameters.shift();
        carManager[action](commandParameters);
    }
}
createCar(['create c1','create c2 inherit c1'])
