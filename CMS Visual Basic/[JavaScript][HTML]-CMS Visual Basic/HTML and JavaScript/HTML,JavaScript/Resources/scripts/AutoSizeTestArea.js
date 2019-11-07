var LastKeyCode=0;
function saveKeyCode(event)
{
	// MSIE hack
	if (window.event)
	{
		LastKeyCode = window.event.keyCode;
	} else
	{
		LastKeyCode = event.charCode
	}
}


function checkRows(textArea)
{
	switch (LastKeyCode)
	{
	case 0:
	case 13:     // backspace
		textArea.style.height = '';
		textRows=textArea.value.split('\n').length-1;
		rows=textRows
		if (rows < 1){rows=1};
		textArea.rows = rows;
		textArea.style.height = textArea.scrollHeight + 'px';
		if (navigator.userAgent.indexOf("Firefox")!=-1) {
			if (textRows == 0){textArea.style.height = textArea.scrollHeight/2 + 'px'
			};
		};
		return;
	}
}
