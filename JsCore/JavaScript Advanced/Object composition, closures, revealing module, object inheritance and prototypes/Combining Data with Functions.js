let rect = {
    width: 10,
    height: 4,
    grow: function (w, h) {
        rect.width += w;
        rect.height += h;
    }
};
rect.grow(5, 14);
console.log(rect);