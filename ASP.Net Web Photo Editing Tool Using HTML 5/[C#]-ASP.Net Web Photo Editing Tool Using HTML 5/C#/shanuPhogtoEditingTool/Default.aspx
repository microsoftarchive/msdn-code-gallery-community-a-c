<%@ Page Title="홈 페이지" Language="C#"  AutoEventWireup="true" EnableViewState="false"
    CodeBehind="Default.aspx.cs" Inherits="shanuPhotoEditor2010._Default" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>SHANU - > Web Painting TOOL using HTML 5 CANVAS</title>
  
      <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.0)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.0)" />

   <meta http-equiv="x-ua-compatible" content="IE=9" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
   <script type="text/javascript" src="jscolor.js"></script>
    <script type="text/javascript" src="webcam.js"></script>
   
     <link href="Styles/myStyle.css" rel="stylesheet" type="text/css" />
<SCRIPT>
    //public Canvas object to use in all the functions.

    //Main canvas declaration 
    var canvas;
    var ctx;

    var canvasEffect;
    var ctxEffect;
    var x = 75;
    var y = 50;
    //Width and Height of the canvas
    var WIDTH = 200;
    var HEIGHT = 252;
    //    var dragok = false;
    //Global color variable which will be used to store the selected color name.
    var Colors = "";
    var newPaint = false;
    var DrawingTypes = "";

    //Circle default radius size
    var radius = 30;
    var radius_New = 30;
    var stickerWidth = 40, stickerHeight = 40;
    // Rectangle array
    rect = {},
    //drag= false defult to test for the draging
drag = false;

    // Array to store all the old Shanpes drawing details
    var rectStartXArray = new Array();
    var rectStartYArray = new Array();
    var rectWArray = new Array();
    var rectHArray = new Array();
    var rectColor = new Array();
    var DrawType_ARR = new Array();
    var radius_ARR = new Array();

    var Text_ARR = new Array();

    // Declared for the Free hand pencil Drawing.
    var prevX = 0,
    currX = 0,
    prevY = 0,
    currY = 0;


    //to add the Image
    var ImageNames = new Array();
    var imageCount = 0;
    var imageObj = new Image();
    var imageObj_BG = new Image();
    //to clear the Canvas
    function clear() {
        ctx.clearRect(0, 0, WIDTH, HEIGHT);
    }
    var newImagename = '';
    var isEffectadded = 'NO';
    var EffectType = 'black';
    var DrawBorder = "No";
    //Initialize the Canvas and Mouse events for Canvas
    function init(DrawType, ImageName) {
        newPaint = true;
        canvas = document.getElementById("canvas");
        ctx = canvas.getContext("2d");

        canvasEffect = document.getElementById("canvas");
        ctxEffect = canvasEffect.getContext("2d");

        x = 5;
        y = 5;
        if (ImageName) {

            ImageNames[imageCount] = ImageName;

            imageCount = imageCount + 1;
        }

        DrawingTypes = DrawType;


        if (DrawType = 'BG') {

            ctx.drawImage(imageObj_BG, 1, 1, canvas.width - 1, canvas.height - 1);
            
        }

        if (DrawingTypes == 'Effects') {
            isEffectadded = 'YES';
            EffectType = ImageName;
            Effects();
        }


        radius = 30;
        radius_New = radius;
        canvas.addEventListener('mousedown', mouseDown, false);
        canvas.addEventListener('mouseup', mouseUp, false);
        canvas.addEventListener('mousemove', mouseMove, false);



        return setInterval(draw, 10);
    }

    //Mouse down event method
    function mouseDown(e) {
        rect.startX = e.pageX - this.offsetLeft;
        rect.startY = e.pageY - this.offsetTop;
        radius_New = radius;
        prevX = e.clientX - canvas.offsetLeft;
        prevY = e.clientY - canvas.offsetTop;
        currX = e.clientX - canvas.offsetLeft;
        currY = e.clientY - canvas.offsetTop;
        drag = true;
    }

    //Mouse UP event Method
    function mouseUp() {

        rectStartXArray[rectStartXArray.length] = rect.startX;
        rectStartYArray[rectStartYArray.length] = rect.startY;
        rectWArray[rectWArray.length] = rect.w;
        rectHArray[rectHArray.length] = rect.h;
        Colors = document.getElementById("SelectColor").value;
        imageObj.src = ImageNames[imageCount - 1];
        rectColor[rectColor.length] = "#" + Colors;
        DrawType_ARR[DrawType_ARR.length] = DrawingTypes
        radius_ARR[radius_ARR.length] = radius_New;
        Text_ARR[Text_ARR.length] = $('#txtInput').val();
        drag = false;

    }


    //mouse Move Event method
    function mouseMove(e) {
        if (drag) {
            rect.w = (e.pageX - this.offsetLeft) - rect.startX;

            rect.h = (e.pageY - this.offsetTop) - rect.startY;

            drawx = e.pageX - this.offsetLeft;
            drawy = e.pageY - this.offsetTop;

            prevX = currX;
            prevY = currY;
            currX = e.clientX - canvas.offsetLeft;
            currY = e.clientY - canvas.offsetTop;
            if (drag = true) {
                radius_New += 2;

            }
            draw();
            if (DrawingTypes == "FreeDraw" || DrawingTypes == "Erase") {
            }
            else {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
            }

        }
        if (isEffectadded == 'YES') {
            Effects();
        }
        drawOldShapes();

    }

    //Darw all Shaps,Text and add images 
    function draw() {

        ctx.beginPath();
        Colors = document.getElementById("SelectColor").value;
        ctx.fillStyle = "#" + Colors;
        switch (DrawingTypes) {
            case "Border":
                ctx.strokeStyle = "#" + Colors;
                ctx.lineWidth = 10;
                ctx.strokeRect(0, 0, canvas.width, canvas.height)
                DrawBorder = "YES";
                //     ctx.rect(canvas.width - 4, 0, canvas.width - 4, canvas.height);
                break;

            case "Images":

                imageObj.src = ImageNames[imageCount - 1];
                ctx.drawImage(imageObj, rect.startX, rect.startY, rect.w, rect.h);
                //  ctx.drawImage(imageObj, rect.startX, rect.startY, stickerWidth, stickerHeight);
                break;
            case "DrawText":
                ctx.font = '40pt Calibri';
                ctx.fillText($('#txtInput').val(), drawx, drawy);

                break;

        }
        ctx.fill();
        // ctx.stroke();
    }

    //Redraw all shapes and images
    function drawOldShapes() {
        ctx.drawImage(imageObj_BG, 1, 1, canvas.width - 1, canvas.height - 1);
        if (isEffectadded == 'YES') {
            Effects();
        }

        if (DrawingTypes == "ClearAll") {
            return;
        }

        Colors = document.getElementById("SelectColor").value;


        for (var i = 0; i < rectStartXArray.length; i++) {
            if (rectStartXArray[i] != rect.startX && rectStartYArray[i] != rect.startY && rectWArray[i] != rect.w && rectHArray[i] != rect.h) {
                ctx.beginPath();
                ctx.fillStyle = rectColor[i];
                // ctx.rect(rectStartXArray[i], rectStartYArray[i], rectWArray[i], rectHArray[i]);

                switch (DrawType_ARR[i]) {
                    case "Border":
                        ctx.strokeStyle = "#" + Colors;
                        ctx.lineWidth = 10;
                        ctx.strokeRect(0, 0, canvas.width, canvas.height)
                    case "Images":

                        imageObj.src = ImageNames[i];
                        ctx.drawImage(imageObj, rectStartXArray[i], rectStartYArray[i], rectWArray[i], rectHArray[i]);
                        //  ctx.drawImage(imageObj, rectStartXArray[i], rectStartYArray[i], stickerWidth, stickerHeight);
                        break;
                    case "DrawText":
                        ctx.font = '40pt Calibri';

                        ctx.fillText(Text_ARR[i], rectStartXArray[i], rectStartYArray[i]);

                        break;


                }

                if (DrawBorder == "YES") {
                    ctx.strokeStyle = "#" + Colors;
                    ctx.lineWidth = 10;
                    ctx.strokeRect(0, 0, canvas.width, canvas.height)
                }
              
                ctx.fill();
                // ctx.stroke();
            }
        }
    }


    //new Canvas Drawing
    function ClearAll() {
        var m = confirm("Are you sure to clear All ");
        if (m) {
            DrawingTypes = "ClearAll";
            rectStartXArray.length = 0;
            rectStartYArray.length = 0;
            rectWArray.length = 0;
            rectHArray.length = 0;
          
            DrawBorder = "No";
            rectColor.length = 0;
            DrawType_ARR.length = 0
            radius_ARR.length = 0;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
        }
    }

    function takePhoto() {
        // take your photo and add the photo as canvas Background Image
        Webcam.snap(function (data_uri) {
            imageObj_BG.src = data_uri;
            init('BG', '');
        });
    }


    //Add alll Effects which we need to change for image
    function Effects() {

        if (isEffectadded == 'YES') {
            var imgd = ctxEffect.getImageData(0, 0, canvas.width, canvas.height);
            var pix = imgd.data;
            switch (EffectType) {
                case "black":
                    for (var i = 0, n = pix.length; i < n; i += 4) {
                        var grayscale = pix[i] * .3 + pix[i + 1] * .59 + pix[i + 2] * .11;
                        pix[i] = grayscale;   // red          
                        pix[i + 1] = grayscale;   // green          
                        pix[i + 2] = grayscale;   // blue    

                        // alpha       
                    }

                    ctxEffect.putImageData(imgd, 0, 0);

                    break;

                case "contrast":
                    var contrast = 40;
                    var factor = (259 * (contrast + 255)) / (255 * (259 - contrast));
                    for (var i = 0; i < pix.length; i += 4) {

                        pix[i] = factor * (pix[i] - 128) + 128;
                        pix[i + 1] = factor * (pix[i + 1] - 128) + 128;
                        pix[i + 2] = factor * (pix[i + 2] - 128) + 128;
                    }
                    // overwrite original image
                    ctxEffect.putImageData(imgd, 0, 0);
                    break;

                case "invertColors":
                    for (var i = 0; i < pix.length; i += 4) {
                        // red
                        pix[i] = 255 - pix[i];
                        // green
                        pix[i + 1] = 255 - pix[i + 1];
                        // blue
                        pix[i + 2] = 255 - pix[i + 2];
                    }
                    // overwrite original image
                    ctxEffect.putImageData(imgd, 0, 0);
                    break;

                case "OriginalImage":
                    for (var i = 0; i < pix.length; i += 4) {
                        // red
                        pix[i] = pix[i];
                        // green
                        pix[i + 1] = pix[i + 1];
                        // blue
                        pix[i + 2] = pix[i + 2];
                    }
                    // overwrite original image
                    ctxEffect.putImageData(imgd, 0, 0);
                    break;
            }
        }
    }




    function sendEmail() {
        var m = confirm("Are you sure to Save ");
        if (m) {

            var image_NEW = document.getElementById("canvas").toDataURL("image/png");
            image_NEW = image_NEW.replace('data:image/png;base64,', '');
            $("#<%=hidImage.ClientID%>").val(image_NEW);
            alert('Image saved to your root Folder and email send !');
        }

    }
    function sendtoFB() {
        var m = confirm("Are you sure Post in FaceBook ");
        if (m) {


            $.getScript('//connect.facebook.net/en_US/all.js', function () {
                // Load the APP / SDK
                FB.init({
                    appId: '398343823690176', // App ID from the App Dashboard
                    cookie: true, // set sessions cookies to allow your server to access the session?
                    xfbml: true, // parse XFBML tags on this page?
                    frictionlessRequests: true,
                    oauth: true
                });
                FB.login(function (response) {
                    if (response.authResponse) {
                        window.authToken = response.authResponse.accessToken;
                        PostImageToFacebook(window.authToken)
                    } else {
                    }
                }, {
                    scope: 'publish_actions'
                });
            });

        }

    }


    // Post a BASE64 Encoded PNG Image to facebook
    function PostImageToFacebook(authToken) {
        var canvas = document.getElementById("canvas");
        var imageData = canvas.toDataURL("image/png");
        try {
            blob = dataURItoBlob(imageData);
        } catch (e) {
            console.log(e);
        }
        var fd = new FormData();
        fd.append("access_token", authToken);
        fd.append("source", blob);
        fd.append("message", "Shanu Photo Editing Tool now you can send Email and share to FB :)");
        try {
            $.ajax({
                url: "https://graph.facebook.com/me/photos?access_token=" + authToken,
                type: "POST",
                data: fd,
                processData: false,
                contentType: false,
                cache: false,
                success: function (data) {
                    console.log("success " + data);
                    $("#poster").html("Posted Canvas Successfully");
                },
                error: function (shr, status, data) {
                    console.log("error " + data + " Status " + shr.status);
                },
                complete: function () {
                    alert("Posted to facebook");
                }
            });

        } catch (e) {
            console.log(e);
        }
    }

    // Convert a data URI to blob
    function dataURItoBlob(dataURI) {
        var byteString = atob(dataURI.split(',')[1]);
        var ab = new ArrayBuffer(byteString.length);
        var ia = new Uint8Array(ab);
        for (var i = 0; i < byteString.length; i++) {
            ia[i] = byteString.charCodeAt(i);
        }
        return new Blob([ab], {
            type: 'image/png'
        });
    }


</script>
    <style type="text/css">
        .style1
        {
            border-top: 1px solid #b8cfe5;
            border-bottom: 1px solid #b8cfe5;
            border-right: 1px solid #C7C7C7;
            border-left: 1px solid #C7C7C7;
            background: #E7EFF7 no-repeat right top;
            padding: 3px 9px 2px 9px;
            font-size: 12px;
            width: 111px;
        }
    </style>
</head>
<body >
     <form id="form" name="form" runat="server" enctype="multipart/form-data">
     <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
 <table width="99%" class="search">          
    <tr>
    <td class="search_es1" align="center">
    <h2>SHANU - > Web Photo Editing TOOL using HTML 5 CANVAS</h2>
    </td>
    </tr>
    </table>

    <table width="99%">
    <tr>
        <td  class="style1" >
            <table>
                <tr>

    <td class="style1" width="40px">
          New Draw
    </td>
    <td class="form_es">
    <img src="images/New.png"  onClick="ClearAll()" />
        <%-- <INPUT TYPE ="Button" VALUE=" Clear ALL " onClick="ClearAll()">--%>
    </td>

         <td class="search_es">Select Color</td>
        <td class="form_es">
            <%--  <input type="color" id="favcolor"> --%>
           <input class="color" value="FF1251" id="SelectColor">
        </td>

         <td class="search_es">Border</td>
          <td class="form_es">
                 <img src="images/rect.png"  onClick="init('Border','')" />
              
           </td>

             <td class="search_es">Filtters</td>
             <td class="form_es">
            <input type=button value="Black&White"  onClick="init('Effects','black')"/>
              <input type=button value="Contrast"  onClick="init('Effects','contrast')"/>
            <input type=button value="Invert Color"  onClick="init('Effects','invertColors')"/>
            <input type=button value="Original Image"  onClick="init('Effects','OriginalImage')"/>
             </td>

             <td class="search_es">Text</td>
             <td class="form_es">
                     <input type="text" id="txtInput" value="SHANU" />
                     </td>
                     <td class="form_es">
                     <img src="images/Font.png"  onClick="init('DrawText','')" />
                         <%-- <INPUT TYPE ="Button" id="btnText" VALUE=" Text " onClick="init('DrawText')">--%>
             </td>
             </tr>
            </table>
        </td>
        <td rowspan="3" class="style1">
                <table>
                <tr>
                <td class="search_es">
                 Save / Send Image
                         </td>
                         </tr>
                         <tr>
                         
                    <td class="form_es" >
 
 
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">

                 <ContentTemplate>

                <span> 

                <asp:Button ID="btnImage" runat="server" Text="Send Email" 
                 OnClientClick = "sendEmail();return true;" onclick="btnImage_Click" />
                  <INPUT TYPE ="Button" id="btnFB" VALUE=" Send to FB " onClick="sendtoFB()">
                </span>

                 </ContentTemplate>

                </asp:UpdatePanel>


                    </td>
                    
                    </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <table>
    <tr>

                <td class="style1">Add Sticker</td>
                <td colspan="10">
                    <img src="images/smily8.png" width="36" height="36" onClick="init('Images','images/smily8.png')"/>
                     <img src="images/smily9.png" width="36" height="36" onClick="init('Images','images/smily9.png')"/>
                     <img src="images/smily10.png" width="36" height="36" onClick="init('Images','images/smily10.png')"/>
                     <img src="images/smily11.png" width="36" height="36" onClick="init('Images','images/smily11.png')"/>                 
                     <img src="images/smily13.png" width="36" height="36" onClick="init('Images','images/smily13.png')"/>
                     <img src="images/smily14.png" width="36" height="36" onClick="init('Images','images/smily14.png')"/>
                     <img src="images/smily15.png" width="36" height="36" onClick="init('Images','images/smily15.png')"/>
                     <img src="images/smily16.png" width="36" height="36" onClick="init('Images','images/smily16.png')"/>
                     <img src="images/smily17.png" width="36" height="36" onClick="init('Images','images/smily17.png')"/>
                     <img src="images/smily19.png" width="36" height="36" onClick="init('Images','images/smily19.png')"/>

                     <img src="images/flower1.png" width="36" height="36" onClick="init('Images','images/flower1.png')"/>
                     <img src="images/flower2.png" width="36" height="36" onClick="init('Images','images/flower2.png')"/>
                     <img src="images/flower3.png" width="36" height="36" onClick="init('Images','images/flower3.png')"/>
                     <img src="images/flower4.png" width="36" height="36" onClick="init('Images','images/flower4.png')"/>

                     <img src="images/Cake.png" width="36" height="36" onClick="init('Images','images/Cake.png')"/>
                     <img src="images/Cake1.png" width="36" height="36" onClick="init('Images','images/Cake1.png')"/>

                       <img src="images/cap.png" width="36" height="36" onClick="init('Images','images/cap.png')"/>
                     <img src="images/cap1.png" width="36" height="36" onClick="init('Images','images/cap1.png')"/>

                    <img src="images/animel1.png" width="36" height="36" onClick="init('Images','images/animel1.png')"/>
                     <img src="images/animel2.png" width="36" height="36" onClick="init('Images','images/animel2.png')"/>
                    <img src="images/animel3.png" width="36" height="36" onClick="init('Images','images/animel3.png')"/>
                     <img src="images/animel4.png" width="36" height="36" onClick="init('Images','images/animel4.png')"/>
                    <img src="images/animel5.png" width="36" height="36" onClick="init('Images','images/animel5.png')"/>
                    <img src="images/animel6.png" width="36" height="36" onClick="init('Images','images/animel6.png')"/>
                     <img src="images/animel7.png" width="36" height="36" onClick="init('Images','images/animel7.png')"/>
                       <img src="images/bike.png" width="36" height="36" onClick="init('Images','images/bike.png')"/>
                     <img src="images/gift1.png" width="36" height="36" onClick="init('Images','images/gift1.png')"/>
                     <img src="images/Kiss.png" width="36" height="36" onClick="init('Images','images/Kiss.png')"/>
                </td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
    <td class="style1">
        <table>
         <tr>

                <td class="style1">From Email:</td>
                <td>
                <asp:TextBox ID="txtFromEmail" runat="server" Text="syedshanumcain@gmail.com" 
                        Width="194px"></asp:TextBox>
                </td>
                 <td class="search_es">To Email:</td>
                <td>
                 <asp:TextBox ID="txtToEmail" runat="server" Text="syedshanumcain@gmail.com" 
                        Width="184px"></asp:TextBox>
                </td>
                  <td class="search_es">Subject:</td>
                <td>
                 <asp:TextBox ID="txtSub" runat="server" Text="Shanu Photo Ediditng Tool Photo" 
                        TextMode="MultiLine" Width="220px"></asp:TextBox>
                </td>
                  <td class="search_es">Message:</td>
                <td colspan="4">
                 <asp:TextBox ID="txtMessage" runat="server" 
                        Text="Thank you for Using Shanu Photo Ediditng Tool.Your Edited Photo has been attached in this mail.Thank You :)" 
                        Height="50px" TextMode="MultiLine" Width="399px"></asp:TextBox>
                 </td>
                </tr>
        </table>
    </td>
    </tr>
    </table>

      <div style="width:980px;margin: 0px auto;">
             <div style="width:260px;float:left;padding-left:10px">

           
       <table >
                            <tr>
                                <td align="center">
                                      <div id="my_camera"></div>
                                    <!-- Configure a few settings and attach camera -->
	<script language="JavaScript">
	    Webcam.set({
	        width: 320,
	        height: 240,
	        image_format: 'jpeg',
	        jpeg_quality: 90
	    });
	    Webcam.attach('#my_camera');
	</script>
	
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <input type=button value="Captuer Photo" onClick="takePhoto()">
                                </td>
                            </tr>
                        </table>
      </div>
             <div style="width:600px;float:right;padding-right:10px"">

            

         
<SECTION style="border-style: solid; border-width: 2px; width: 600px;">

<CANVAS HEIGHT="452" WIDTH="600px" ID="canvas">
Your browser is not supporting HTML5 Canvas .Upgrade Browser to view this program or check with Chrome or in Firefox.
</CANVAS>

</SECTION>

          </div>
          </div>
<input type="hidden" name="imageData" id="imageData" runat="server" />
<asp:HiddenField ID="hidImage" runat="server" />

</form>
</body>
</html>