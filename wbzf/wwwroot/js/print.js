function printPage() {
    var printContent = document.getElementById('printArea');
    var printWindow = window.open('', '', 'width=720,height=1080');
    printWindow.document.open();
    printWindow.document.write('<html><head><title>Print</title>');
    // Add the styles from the original document
    var styles = Array.prototype.slice.call(document.styleSheets)
        .map(styleSheet => {
            if (styleSheet.href) {
                return '<link rel="stylesheet" href="' + styleSheet.href + '">';
            } else {
                return '<style>' + styleSheet.ownerNode.textContent + '</style>';
            }
        })
        .join('\n');
    printWindow.document.write(styles);
    printWindow.document.write('</head><body>');
    printWindow.document.write(printContent.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.print();
    printWindow.close();
}