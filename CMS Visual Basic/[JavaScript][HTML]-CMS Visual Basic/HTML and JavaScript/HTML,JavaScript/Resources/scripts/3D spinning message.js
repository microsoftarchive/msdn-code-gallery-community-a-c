//custom
// var message=new Array("Text 1", "Text 2", "Text 3", "Text..")
var outlinecolor=new Array("black", "black")
var fillcolor1=new Array("gray", "green", "white", "green")
var fillcolor2=new Array("blue", "olive", "black", "lime")
var circlemark=new Array("-")
var strkweight=2
var pause=2
var strengthopacity="60%"
var circlesize=0.5
var keepinview="yes"
mytruebody=(!window.opera && document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body //Dynamicdrive added object
var outerwidth=mytruebody.clientWidth
var outerheight=mytruebody.clientHeight
var innerwidth=Math.floor(circlesize*outerwidth)
var innerheight=Math.floor(circlesize*outerheight)
var posleft=(outerwidth-innerwidth)/2
var postop=(outerheight-innerheight)/2
var path=new Array()
var i_message=0
var i_outlinecolor=0
var i_fillcolor1=0
var i_fillcolor2=0
var i_messagelength=0
var longestmessage=0
pause*=1000
var ie=document.getElementById&&document.all?1:0 
for (i=0;i<=message.length-1;i++) {
	if (message[i].length>longestmessage) {
		longestmessage=message[i].length
	}
	longestmessage+=4
}
for (i=0;i<=message.length-1;i++) {
	var emptyspace=""
	var i_emptyspace=(longestmessage-message[i].length)/2
	for (ii=0;ii<=i_emptyspace;ii++) {
		emptyspace+=circlemark
	}
	message[i]=emptyspace+" "+message[i]+" "+emptyspace
}
function changeform() {
	if (keepinview=="yes") //DD added
	document.getElementById("roofid").style.top=mytruebody.scrollTop //DD added
	if (i_outlinecolor >= outlinecolor.length) {i_outlinecolor=0}
	if (i_fillcolor1 >= fillcolor1.length) {i_fillcolor1=0}
	if (i_fillcolor2 >= fillcolor2.length) {i_fillcolor2=0}
	document.getElementById('strokeid').color=outlinecolor[i_outlinecolor]
	document.getElementById('fillid').color=fillcolor1[i_fillcolor1]
	document.getElementById('fillid').color2=fillcolor2[i_fillcolor2]
	if (i_message < message.length) {tick()}
	else {document.getElementById('textpathid').string=""
	document.getElementById("roofid").style.display="none" //DD added
	}
}
function tick() {
	if (i_messagelength <= message[i_message].length) {
		var messagestringend=""
		var messagestring=message[i_message].substring(0, i_messagelength)+messagestringend
		document.getElementById('textpathid').string=messagestring
		var timer=setTimeout("tick()",50)
		i_messagelength++
	}
	else {
		clearTimeout(timer)
		i_messagelength=0
		i_message++
		i_outlinecolor++	
		i_fillcolor1++	
		i_fillcolor2++	
		var timer=setTimeout("changeform()",pause)
	}
}

if (ie) {
	document.write('<div id="roofid" style="position:absolute;left:0px;top:0px;width:'+outerwidth+'px;height:'+outerheight+'px;overflow:hidden;">')
	document.write('<v:oval id="tc" style="position:absolute;top:'+postop+'px;left:'+posleft+'px;width:'+innerwidth+'px;height:'+innerheight+'px">')
	document.write('<v:shadow on="t" opacity="'+strengthopacity+'"/>')
	document.write('<v:stroke id="strokeid" weight="'+strkweight+'pt" color="blue"/>')
	document.write('<v:fill id="fillid" on="True" color="'+fillcolor1[0]+'" color2="'+fillcolor2[0]+'" opacity="'+strengthopacity+'" opacity2="'+strengthopacity+'" type="gradient"/>')
	document.write('<v:path textpathok="t"/>')
	document.write('<v:textpath id="textpathid" on="t" id="mytp" style="font-family:\'Arial Black\'; " fitpath="t" string=""/>')
	document.write('</v:oval></div>')
	if (window.attachEvent) //DD added code
	window.attachEvent("onload", changeform) //DD added code
	else
	window.onload=changeform
}