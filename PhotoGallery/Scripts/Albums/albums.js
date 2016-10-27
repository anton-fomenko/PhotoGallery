$(function() {
    $(".copyToClipboardButton")
        .click(function() {
            copyToClipboard($(this).data('url'));
        });
});

function copyToClipboard(text) {
    window.prompt("Copy to clipboard: Ctrl+C, Enter", text);
}