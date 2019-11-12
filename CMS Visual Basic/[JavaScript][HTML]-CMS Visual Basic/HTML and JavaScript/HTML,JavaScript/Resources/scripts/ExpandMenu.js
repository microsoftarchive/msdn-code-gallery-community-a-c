function SwitchExpand(idm0)
{
    var Element = document.getElementById(idm0);
    if (Element.className.indexOf("contracted")!=-1) {
        var reg = new RegExp('(\\s|^)contracted(\\s|$)');
        Element.className = Element.className.replace(reg, ' ');
    } else {
        Element.className += " contracted";
    }
}


