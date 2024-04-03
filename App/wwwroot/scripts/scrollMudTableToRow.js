async function scrollMudTableToRow(rowIndex) {
    var tableElement = document.querySelector("div.mud-table-container");
    var tableHeight = tableElement.offsetHeight;
    var tableOffset = tableElement.scrollTop;
    var tableRowHeight = tableElement.querySelector("tr.mud-table-row").scrollHeight;

    // Element is above view - scroll so it is at top
    if (rowIndex * tableRowHeight < tableOffset) {
        tableElement.scrollTo(0, rowIndex * tableRowHeight);
    }
    // Element is below view - scroll so that it is at bottom
    else if ((rowIndex + 1) * tableRowHeight > tableOffset + tableHeight) {
        tableElement.scrollTo(0, (rowIndex + 1) * tableRowHeight - tableHeight);
    }    
}