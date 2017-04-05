function attachEvents() {
    $('a.button').on('click', buttonClicked);
    function buttonClicked() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
        // "this" is the event source (the hyperlink clicked)
    }
}
