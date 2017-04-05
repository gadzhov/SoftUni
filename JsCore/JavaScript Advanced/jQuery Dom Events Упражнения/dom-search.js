function domSearch(selector, boolean) {
    let container = $(selector);
    let fragment = document.createDocumentFragment();

    let addControl = $("<div>")
        .attr("class", "add-controls")
        .append($("<label>Enter text:</label>")
            .append($("<input>")))
        .append($("<a>Add</a>")
            .attr("class", "button"));

    let searchControl = $("<div>")
        .attr("class", "search-control")
        .append($("<label>Search:</label>")
            .append($("<input>")));

    let resultControl = $("<div>")
        .attr("class", "result-control")
        .append($("<ul>")
            .attr("class", "items-list"));

    $("div input").val();
    $("div a").click(function () {
        alert(" ")
    })

    addControl.appendTo(fragment);
    searchControl.appendTo(fragment);
    resultControl.appendTo(fragment);
    container.append(fragment);

}