function openPopupForm(url)
{
    // Replace "/ControllerName/ActionName" with the URL of your form action
    //var popupUrl = "/ControllerName/ActionName";
    var popupUrl = url;
    // Set the dimensions of the popup window
    var popupWidth = 500;
    var popupHeight = 400;
    // Calculate the center of the screen
    var screenWidth = window.screen.width;
    var screenHeight = window.screen.height;
    var popupLeft = (screenWidth - popupWidth) / 2;
    var popupTop = (screenHeight - popupHeight) / 2;
    // Open the popup window with the specified dimensions and URL
    window.open(popupUrl, "", "width=" + popupWidth + ",height=" + popupHeight + ",left=" + popupLeft + ",top=" + popupTop);
}
