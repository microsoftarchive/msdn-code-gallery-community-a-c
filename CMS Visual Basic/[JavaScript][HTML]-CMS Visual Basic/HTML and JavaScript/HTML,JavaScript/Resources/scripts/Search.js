function WebSearch() {
if (navigator.appName!='Microsoft Internet Explorer') {
	var t = document.getSelection();
	od(t);
	}
else {
	var t = document.selection.createRange();
	if(document.selection.type == 'Text' && t.text>'') {
		document.selection.empty();
		od(t.text);}
   }
function od(t) {
while (t.substr(t.length-1,1)==' ') 
	t=t.substr(0,t.length-1)
while (t.substr(0,1)==' ') 
	t=t.substr(1)
if (t) window.open('DomainName'+encodeURIComponent(t), 'dict', 'width=700,height=500,resizable=1,menubar=1,scrollbars=1,status=1,titlebar=1,toolbar=1,location=1,personalbar=1');
}   
}
document.ondblclick=WebSearch 
