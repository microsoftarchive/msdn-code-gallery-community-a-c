
var level=2;
var IDPage=0;
var Label="";
var Title="";
var Link="";
var Off=false;
var JoinPr=false;


Enter.onclick=function (Enter_onclick){
Submit();
}

AddPage.onclick=function (AddPage_onclick){
Submit();
}

EditPage.onclick=function (EditPage_onclick){
    Submit();
    if(ListItems.selectedIndex!=-1){
        Info();
        PageSelect.value=IDPage;
    }
}

AddItem.onclick = function (AddItem_onclick)
{
	Reset();
	level = 2;
	ResetMove();
	Label = prompt(msg101, "");
	Title = prompt(msg102, "");
	if (Label == null)
	{
		Label = ""
	}
	if (Title == null)
	{
		Title = ""
	}
	oOption = document.createElement("OPTION");
	oOption.text = Label;
	Position = ListItems.selectedIndex + 1;
	insertOption(ListItems,oOption,Position)
	ListItems.selectedIndex = Position;
	SetInfo();
	ListItemChange();
}

RemoveItem.onclick=function (RemoveItem_onclick)
{
    ResetMove();
    if(ListItems.selectedIndex!=-1)
    {
        Position=ListItems.selectedIndex;        
        Info();
        if(IDPage==0)
        {
            ListItems.remove(ListItems.selectedIndex);
            try
		    {
            ListItems.selectedIndex=Position;
            ListItemChange();
            }
            catch(err)
            {
            }            
        }
    }
}

ObjLabel.onchange = function (Label_onclick)
{
	if (ListItems.selectedIndex != -1)
	{
		Info();
		Label = cln(ObjLabel.value);
		CurrentListItem().text = Label;
		SetInfo();
	}
}

ObjTitle.onchange = function (Title_onchange)
{
    if(ListItems.selectedIndex!=-1){
        Info();
        Title=cln(ObjTitle.value);
        SetInfo();
    }
}

ObjLink.onchange = function (Link_onchange)
      {
    if(ListItems.selectedIndex!=-1){
        Info();
        Link=cln(ObjLink.value);
        SetInfo();
    }
}

ListItems.onchange=function (ListItems_onchange){
    ListItemChange();
}

ListItems.ondblclick=function (ListItems_ondblclick){
    PreciseMove();
    ListItemChange();
}

HidePage.onclick=function (HidePage_onclick){
    Info();
    Off=HidePage.checked;
    SetInfo();
}

JoinPrevious.onclick=function (JoinPrevious_onclick){
    Info();
    JoinPr=JoinPrevious.checked;
    SetInfo();
}

function cln(text){
	text = text.replace("{", "(");
	text = text.replace("[", "(");
	text = text.replace("}", ")");
	text = text.replace("]", ")");
    return text;
}
function declevel(){
    Info();
    if(level>0){ level=level-1;
    SetInfo();
	}
}
function inclevel(){
    Info();
    if(level<3){ level=level+1;
    SetInfo();
	}
}
function moveup(){
    ResetMove();
    if(ListItems.selectedIndex>0){
        Position=ListItems.selectedIndex;
        oOption=ListItems[Position];
        ListItems.remove(Position);
        insertOption(ListItems, oOption, Position-1)
        ListItems.selectedIndex=Position-1;
    }
}
function movedown(){
    ResetMove();
    if(ListItems.selectedIndex!=-1 && ListItems.selectedIndex<ListItems.length-1){
        Position=ListItems.selectedIndex;
        oOption=ListItems[Position];        
        ListItems.remove(Position);
        insertOption(ListItems, oOption, Position + 1)
        ListItems.selectedIndex = Position + 1;
    }
}
StaticPosition=-1;
function PreciseMove(){
    if(StaticPosition!=-1)
    {
        Position=ListItems.selectedIndex;
				oOption=ListItems[StaticPosition];
        ListItems.remove(StaticPosition);
        insertOption(ListItems,oOption,Position)
        ListItems.selectedIndex = Position;
        ResetMove();
    }else
    {
        StaticPosition=ListItems.selectedIndex;
        MessageAlert.firstChild.nodeValue = msg3017;
    }
}
function ResetMove(){
    if(StaticPosition!=-1){
    	StaticPosition = -1;
    	MessageAlert.firstChild.nodeValue = msg3016;
    }
}
function Reset()   	
    {
	level=0;
	IDPage=0;
	Label="";
	Title="";
	Link="";
	Off=false;
	JoinPr=false;
    }

function Info()   	
	{
	Reset();
    if(ListItems.selectedIndex!=-1)
    	{
        Record=ListItems.value;
        while(Record.substr(level,1) == ".")
        {
            level = level + 1;
        }
        p1 = Record.indexOf("[")+1;
        p2=1;
        if(p1)
        	{
            p2 = Record.indexOf("]",p1)+1;
            Field = Record.substr(p1, p2 - p1 - 1);
            if(Field.substr(0,1) == "#")
            	{
                IDPage = parseInt(Field.substr(1));
            	}
            p1 = Record.indexOf("[",p2-1)+1;
            if(p1)
            	{
                p2 = Record.indexOf("]",p1)+1;
                Label = Record.substr(p1, p2 - p1 - 1);
                p1 = Record.indexOf("[",p2-1)+1;
                if(p1)
                	{
                    p2 = Record.indexOf("]",p1)+1;
                    Title = Record.substr(p1, p2 - p1 - 1);
                    p1 = Record.indexOf("[",p2-1)+1;
                    if(p1)
                    	{
                        p2 = Record.indexOf("]",p1)+1;
                        Link = Record.substr(p1, p2 - p1 - 1);
                    	}
                	}
            	}
        	}
        Off = Record.indexOf("{off}", p2-1)>-1;
        JoinPr = Record.indexOf("{join}", p2-1)>-1;
    	}
	}
function SetInfo(){
    if(ListItems.selectedIndex!=-1){
        Record="...........".substr(0,level);
        if(IDPage == 0){
            Record = Record + "[]";
        }else{
            Record = Record + "[#" + IDPage + "]";
        }
        Record = Record + "[" + Label + "][" + Title + "]";
        if(Link != ""){ Record = Record + "[" + Link + "]";}
        if(Off){ Record = Record + "{off}";}
        if(JoinPr){ Record = Record + "{join}";}
        ListItem=CurrentListItem();
        ListItem.value = Record;
        SetVisualization(ListItem,level,Off,JoinPr);
    }else{
        EditPage.disabled=true;
        DisabletextModify();
    }
}
function SetVisualization(ListItem,level,Off,JoinPr){
  ListItem.text = ">>>>>>>>>>".substr(0, level) + removeIdent(ListItem.text);
	switch (level)
	{
	case 0:
	  ListItem.style.color = "Red";
	  ListItem.style.backgroundColor = "Yellow";
	  break;
	case 1:
	  ListItem.style.color = "Black";
	  ListItem.style.backgroundColor = "Yellow";
	  break;
	default:
	  ListItem.style.color = "Black";
	  ListItem.style.backgroundColor = "White";
	}
    if(Off){
        ListItem.style.color = "Gray";
        ListItem.style.backgroundColor = "White";
    }
    if(JoinPr){
        ListItem.style.color = "Blue";
    }
  }

function removeIdent(stringa) {
  while (stringa.substring(0, 1) == '>')
  { stringa = stringa.substring(1, stringa.length); }
  return stringa;
}


function trim(stringa){
	while (stringa.substring(0,1) == ' ')
		{stringa = stringa.substring(1, stringa.length);}
	while (stringa.substring(stringa.length-1, stringa.length) == ' ')
		{stringa = stringa.substring(0,stringa.length-1);}
	return stringa;
}
function CurrentListItem(){
    if(ListItems.selectedIndex!=-1){
    var SelectedId=ListItems[ListItems.selectedIndex];
   	return SelectedId;
	}
}
function ListItemChange(){
    Info();
    HidePage.checked=Off;
    JoinPrevious.checked=JoinPr;
    if(IDPage){
        DisabletextModify();
        EditPage.disabled=false;
        EditPage.style.visibility = "";
      } else {
        ObjTitle.disabled=false;
        ObjLabel.disabled=false;
        ObjLink.disabled=false;
        ObjTitle.value=Title;
        ObjLabel.value=Label;
        ObjLink.value=Link;
        RemoveItem.disabled=false;
        RemoveItem.style.visibility = "";
        EditPage.disabled = true;
        EditPage.style.visibility = "hidden";
      }
}
function DisabletextModify(){
    ObjTitle.disabled=true;
    ObjLabel.disabled=true;
    ObjLink.disabled=true;
    ObjTitle.value="";
    ObjLabel.value="";
    ObjLink.value="";
    RemoveItem.disabled=true;
    RemoveItem.style.visibility = "hidden";
  }
function AbjustListVisualization(){
	for (n=1;n<=ListItems.length;n++) {
        ListItems.selectedIndex=n-1;
        Info();
        SetInfo();
    }
    ListItemChange();
}
function Submit(){
	text=""
	for (n=0;n<=ListItems.length-1;n++) {
        text = text + ListItems[n].value + '\r\n';
    }
    CodeMenu.value=text;
}
AbjustListVisualization();

function insertOption(list,option,position)
{
	try
	{
		var OptionPosition = list.options[position];
		list.add(option, OptionPosition);
	}
	catch (ex)
	{
		list.add(option, position);
	}
}

