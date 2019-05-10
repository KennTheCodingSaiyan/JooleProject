
//Function To Display Popup
function popUp_show() {
document.getElementById('abc').style.display = "block";
}
//Function to Hide Popup
window.onload = function () {
    document.getElementById('close').onclick = function () {
        document.getElementById('abc').style.display = "none";
        return false;
    };
};
// Picture Display
function HandleBrowseClick(input_image) {
    var fileinput = document.getElementById('input_image');
    fileinput.click();
}