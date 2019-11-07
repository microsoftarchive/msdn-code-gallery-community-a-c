	var code;

	function ForceNumericInput(This, event, AllowDot, AllowMinus)
	{
		if (window.event.keyCode == null)
		{
			code = event.charCode	
		} else
		{
			// IE & OPERA
			code = window.event.keyCode;
		}
		if(arguments.length == 1)
		{
        	var s = This.value;
        	// if "-" exists then it better be the 1st character
        	var i = s.lastIndexOf("-");
        	if(i == -1)
            	return;
        	if(i != 0)
           		This.value = s.substring(0,i)+s.substring(i+1);
           	return;
        }
        switch(code)
        {
            case 0:
						case 8:     // backspace
            case 37:    // left arrow
            case 39:    // right arrow
							return true;
        }
        if(code == 45)     // minus sign
        {
        	if (This.value.indexOf("-") >= 0)
        	{
        		return false;
        	}
        	if(AllowMinus == false)
        	{
                return false;
            }


            // wait until the element has been updated to see if the minus is in the right spot
            var s = "ForceNumericInput(document.getElementById('"+This.id+"'))";
            setTimeout(s, 250);
            return;
        }
        if(AllowDot && (code == 46 || code == 44))
        {
        	if (This.value.indexOf(".") >= 0 || This.value.indexOf(",") >= 0)
            {
                return false;
            }
            return true;
        }
        // allow character of between 0 and 9
        if(code >= 48 && code <= 57)
        {
            return true;
        }
        return false;
	}
