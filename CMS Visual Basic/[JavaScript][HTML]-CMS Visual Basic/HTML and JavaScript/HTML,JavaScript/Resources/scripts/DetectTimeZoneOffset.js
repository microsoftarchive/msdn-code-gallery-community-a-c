var d, tm;
d = new Date();
tm = d.getFullYear() + " " + d.getMonth() + " " + d.getDate() + " " + d.getHours() + " " + d.getMinutes() + " " + d.getSeconds();
Sender=document.createElement('script');
Sender.src = 'script.aspx?s=0&v=' + tm;
document.getElementsByTagName('head')[0].appendChild(Sender);