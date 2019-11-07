# ASP.NET MVC アプリケーション開発入門: 第 2 回 アクション メソッドについて
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- ASP.NET MVC
## Topics
- ASP.NET MVC アプリケーション
- 連載! ASP.NET MVC
## Updated
- 02/15/2011
## Description
<style><!-- ﻿.showRatings{border-bottom:silver 1px solid;background-color:#f0f0f0;text-align:left;width:100%;height:28px;vertical-align:bottom;}.showRatings_right{z-index:99;float:right;} ﻿.CodeHighlighter{word-wrap:break-word;}pre{white-space:pre-wrap;white-space:-moz-pre-wrap;white-space:o-pre-wrap;}
 ﻿.ShareThisMainPanel{text-align:left;float:left;}.ShareThis_RootButton{cursor:pointer;border:solid 0 #000;display:inline;margin-top:5px;margin-bottom:15px;margin-right:10px;}.ShareThis_BtnLink{vertical-align:middle;color:#000;font-weight:700;}.ShareThis_RootButton_Image{padding-left:5px;vertical-align:middle;}.ShareThis_ChildRootPanel{top:211px;left:6px;color:#000;width:auto;height:auto;padding:2px;z-index:1000;text-align:left;}.ShareThisBrand_X
 img{vertical-align:bottom;}.TierOneButtons1{border:solid 0 blue;cursor:pointer;min-width:135px;}.tierTwoPanel{border:solid 0 blue;cursor:pointer;min-width:135px;border-top:solid 1px #999;clear:both;width:140px;}.tierTwoHorizontal{border:solid 0 blue;cursor:pointer;float:left;min-width:135px;width:140px;}.tierTwoRowPanel{border:solid
 0 blue;cursor:pointer;float:left;min-width:135px;display:inline;}.buttonPanel{border-bottom:solid 0 orange;padding:4px 0 4px 4px;margin-bottom:2px;vertical-align:top;float:left;}.buttonPanelHyperLink{margin-left:4px;}.iconsOnPanel{height:16px;width:16px;vertical-align:bottom;}.STMain{text-align:left;float:left;}
 ﻿.VCR_Container{position:relative;}.VCR_GroupLabel{color:#333;font-weight:bold;padding:5px 0 1px;}.VCR_GroupLabel:first-child{padding-top:0;}.VCR_Label{border-left:1px solid #fff;border-bottom:1px solid #fff;color:#06d;cursor:pointer;margin:2px 0 0 0;padding:1px
 0 2px 4px;}.VCR_Label_Focussed{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px solid #c2c2c2;border-bottom:1px solid #c2c2c2;color:#f60;}.VCR_Label_Selected{background:#e3e3e3 url('../../images/common.png') 0 -74px repeat-x;border-left:1px
 solid #c2c2c2;border-bottom:1px solid #c2c2c2;}.VCR_ContentItem{background-color:#fff;display:none;padding-left:12px;overflow:hidden;position:absolute;top:13px;right:0;bottom:0;left:0;}.VCR_CheckBox{cursor:pointer;position:absolute;top:0;right:4px;}.VCR_CheckBoxImage{background:#260859
 url('../../images/common.png') -37px -1px no-repeat;display:block;height:17px;width:15px;}.VCR_CheckBoxHover .VCR_CheckBoxImage{background-color:#0072bc;}.VCR_CheckBoxPlaying .VCR_CheckBoxImage{background-position:-51px -1px;}.VCR_CheckBoxImage{background-color:#260859;}.VCR_CheckBoxHover
 .VCR_CheckBoxImage{background-color:#0072bc;}.StoTeaserHolder{height:26px;}.Stotickler{background-color:#f1f1f1;border-bottom:solid 1px #aaa;height:26px;position:absolute;top:0;width:100%;z-index:14;}.cpsPosCss{margin:0 auto;max-width:0;padding:0 483px;width:0;}#lspLink{background-image:url('../../images/gsfx_eie_icon_dkbg.png');background-repeat:no-repeat;height:24px;margin:0
 -477px;position:absolute;white-space:nowrap;}#lspLink a{font-size:12px;color:#333;text-decoration:none;position:relative;left:32px;top:4px;}#lspLink a:active,#lspLink a:hover{cursor:pointer;color:#333;text-decoration:underline;}#lspTile{background-image:url('../../images/cps_ie_canvas.png');background-repeat:no-repeat;background-color:Transparent;border:solid
 1px #ccc;display:none;float:left;height:133px;left:0;margin:0 -470px;padding:0;position:relative;top:5px;width:423px;z-index:15;}#lspAdd{position:absolute;left:270px;bottom:2px;margin:0;padding:0;float:left;}#lspClose{width:13px;height:13px;position:relative;left:406px;top:4px;margin:0;padding:0;cursor:pointer;float:left;}#lspClose
 img,#lspAdd img{border:none;}#lspDontShow{margin:0;padding:0;position:absolute;top:111px;left:8px;float:left;}#lspDontShow a{color:#48819c;font-family:Tahoma;text-decoration:underline;}#lspDontShow a:active,#lspDontShow a:hover{cursor:pointer;}#cps{position:relative;z-index:1001;}#cpsPosCss{height:24px;}.Stoteaserhidden{display:none;height:0;}#lspTile{filter:progid:DXImageTransform.Microsoft.Alpha(opacity=1,scale=3);}.internav{background-position:top
 right;background-repeat:no-repeat;float:left;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;height:32px;margin:0 0 0 8px;max-width:936px;overflow:hidden;padding:0 37px 0 0;position:relative;white-space:nowrap;}.leftcap{height:32px;left:-29px;position:absolute;width:37px;}.internav
 a{float:left;margin:0;padding:6px 9px;white-space:nowrap;}.internav a:hover{height:20px;margin:1px 0;padding:6px 9px 4px 9px;}.internav a.active,.internav a.active:hover{background:url('../../images/common.png') 0 -43px no-repeat;height:20px;margin:1px 0;padding:5px
 9px;}.LocalNavigation{display:inline-block;font-size:12px;margin:2px 0 0 -17px;padding:0 0 1px 0;white-space:nowrap;width:996px;}.HeaderTabs{margin:0 0 0 25px;width:948px;}.LocalNavigation .TabOff{float:left;white-space:nowrap;}.LocalNavigation .TabOff a{float:left;margin-top:1px;padding:4px
 6px;cursor:pointer;}.LocalNavigation .TabOff a:hover{padding:5px 6px 3px 6px;}.LocalNavigation .TabOn{float:left;margin-top:1px;padding:4px 6px;white-space:nowrap;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{cursor:default;text-decoration:none;}.LocalNavBottom{display:none;}.cleartabstrip{clear:both;height:0;}div.ShareThis2{white-space:nowrap;display:block;position:relative;}div.ShareThis2
 a{display:inline-block;background:#fff;}div.ShareThis2 a span.Icon,div.ShareThis2 ul li a span span.Icon{display:inline-block;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:16px;height:16px;}div.ShareThis2 a span.Label{color:#858585;font-size:85%;position:relative;bottom:4px;}div.ShareThis2
 ul{display:none;background:#fff;padding:5px;position:absolute;left:-9px;list-style:none;margin:0;padding:5px 10px 5px 10px;border:1px solid #ddd;}div.ShareThis2Up ul{bottom:25px;}div.ShareThis2Down ul{top:25px;}div.ShareThis2 ul li{position:relative;list-style:none;padding:3px
 3px 3px 3px;margin:0;}div.ShareThis2 ul li a span{display:inline-block;}div.ShareThis2 ul li a span span.Label{display:inline-block;font-size:90%;position:relative;bottom:3px;padding-left:1px;}div.ShareThis2 a span.Icon{background-position:-89px 0;}div.ShareThis2
 ul li a span span.ShareThisEmail{background-position:-241px 0;}div.ShareThis2 ul li a span span.ShareThisFacebook{background-position:-122px 0;}div.ShareThis2 ul li a span span.ShareThisTwitter{background-position:-138px 0;}div.ShareThis2 ul li a span span.ShareThisDigg{background-position:-154px
 0;}div.ShareThis2 ul li a span span.ShareThisTechnorati{background-position:-170px 0;}div.ShareThis2 ul li a span span.ShareThisDelicious{background-position:-186px 0;}div.ShareThis2 ul li a span span.ShareThisGoogle{background-position:-202px 0;}div.ShareThis2
 ul li a span span.ShareThisMessenger{background-position:-218px 0;}div.ShareThis2 a span.Icon{position:relative;left:-2px;top:-3px;}.SearchBox{background-color:#fff;border:solid 1px #346b94;float:left;margin:0 0 12px 0;width:314px;}.TextBoxSearch{border:none;color:#000;float:left;font-size:13px;font-style:normal;margin:0;padding:4px
 0 0 5px;vertical-align:top;width:232px;}.Bing{background:#fff url('../../images/common.png') 0 -20px no-repeat;display:inline-block;float:right;height:22px;overflow:hidden;text-align:right;width:47px;}.SearchButton{background:#fff url('../../images/common.png')
 -48px -19px no-repeat;display:inline-block;border-width:0;cursor:pointer;float:right;height:21px;margin:0;padding:0;text-align:right;vertical-align:top;width:21px;}#SuggestionContainer li{list-style:none outside none;}.TextBoxSearchIE7{padding:2px 2px 0 5px;border:solid
 1px #fff;}div.DivRatingsOnly{border:solid 0 red;margin-top:5px;margin-bottom:5px;}.ratingStar{font-size:0;width:16px;height:16px;margin:0;padding:0;cursor:pointer;display:block;background-repeat:no-repeat;}.filledRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif')
 -288px 0;float:left;}.emptyRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif') -304px 0;float:left;}.savedRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif') -272px 0;float:left;}.tbFont{white-space:nowrap;}* html .tbfont,*+html
 .tbfont{font-size:70%;}.tableCss{border-collapse:collapse;}.tableCellRateCss{text-align:left;line-height:70%;}.tableCellRateControlCss{width:85px;}.LocaleManagementFlyoutPopup{background-color:#fff;color:#000;border:1px solid #b8b8b8;text-align:left;z-index:1000;padding:3px;display:none;position:absolute;}.LocaleManagementFlyoutPopup
 A,.LocaleManagementFlyoutPopup A:visited{font-size:10px;color:#000;height:15px;text-align:left;text-decoration:none;white-space:nowrap;display:block;padding:1px 3px;}.LocaleManagementFlyoutPopup A:hover,.LocaleManagementFlyoutPopup A:active{background-color:#f0f7fd;height:15px;text-decoration:none;white-space:nowrap;display:block;padding:1px
 3px;}.LocaleManagementFlyoutPopupHr{height:1px;background:#d0e0f0;margin:0 11px 21px;}.LocaleManagementFlyoutPopArrow{background:transparent url('/Areas/Sto/Content/Images/arrow_dn_white.gif') no-repeat;padding-bottom:4px;padding-left:5px;margin-right:10px;}.LocaleManagementFlyoutStatic,.LocaleManagementFlyoutStaticHover{white-space:nowrap;text-decoration:none;cursor:default;display:inline;margin:1px;padding:1px
 3px;}A.LocaleManagementFlyoutStaticLink,A:visited.LocaleManagementFlyoutStaticLink,A:active.LocaleManagementFlyoutStaticLink{white-space:nowrap;text-decoration:none;display:inline;}A:hover.LocaleManagementFlyoutStaticLink{text-decoration:underline;}div.HeadlineRotator{clear:both;}div.HeadlineRotator
 span.Items{display:inline-block;position:relative;cursor:default;}div.HeadlineRotator span.Items .Item{position:absolute;margin:0;}div.HeadlineRotator span.Items span.Title{display:none;}div.HeadlineRotator div.Controls{display:inline-block;height:32px;background:#fff;}div.HeadlineRotator
 div.Controls a.Control{background-color:#919999;position:relative;display:inline-block;cursor:pointer;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:24px;margin:9px 2px 0 2px;height:21px;float:left;}div.HeadlineRotator
 div.Controls a.ControlRight{background-position:-48px 0;margin-right:18px;}div.HeadlineRotator div.Controls a.Control:hover{background-color:#4d6c97;}div.HeadlineRotator div.Controls span.ControlDots{float:left;display:block;margin:11px 0 0 4px;}div.HeadlineRotator
 div.Controls a.ControlDot{width:17px;height:17px;margin:0;background-position:-72px 0;background-color:#e2e8ed;}div.HeadlineRotator div.Controls a.ControlDot:hover{background-color:#8dace7;}div.HeadlineRotator div.Controls a.ControlDotSelected,.HeadlineRotator
 div.Controls a.ControlDotSelected:hover{background-color:#6d8ca7;}div.HeadlineViewer div.Controls div.RightControls{display:block;float:right;display:inline-block;margin:12px 4px 0 0;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss,div.HeadlineViewer
 div.Controls div.RightControls div.ShareThis2{display:block;float:right;}div.HeadlineViewer div.Controls div.RightControls div.ShareThis2 span.Icon{margin-right:4px;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss span.Icon,div.HeadlineNews
 a.ControlRss span.Icon{position:relative;bottom:1px;margin-left:16px;display:inline-block;background-image:url('../../images/headlinesprites.png');background-position:-105px 0;width:17px;height:17px;}div.HeadlineNews a.ControlRss span.Icon{bottom:-1px;margin-left:11px;}div.HeadlineNews{margin-right:-30px;}div.HeadlineNews
 div.ItemCont{background:#f3f3f7;margin-bottom:25px;margin-right:29px;float:left;}div.HeadlineNews a.Item{display:inline-block;height:206px;overflow:hidden;margin-bottom:5px;}div.HeadlineNews h2.NewsTitle{padding:0 0 10px 4px;font-weight:100;}div.HeadlineNews
 h2.NewsTitle span.Last{font-family:"Segoe UI Light","Segoe UI","Lucida Grande",Verdana,Arial,Helvetica,sans-serif;font-weight:200;}div.HeadlineNews span.Image{display:block;overflow:hidden;margin-bottom:6px;}div.HeadlineNews span.Title{display:block;padding:5px
 5px 6px 5px;font-size:120%;}div.HeadlineNews span.Description,div.HeadlineNews span.Description:hover,div.HeadlineNews span.Description:active{display:block;padding:0 5px 4px 5px;color:#000;line-height:16px;}div.HeadlineList{display:inline-block;margin-bottom:10px;}div.HeadlineList
 div.Items{display:inline-block;}div.HeadlineList div.ItemsWithHeaderImage{padding:13px 21px 0 13px;}div.HeadlineList a.Item{width:100%;}div.HeadlineList a.Item span{display:inline-block;}div.HeadlineList div.Items .ShareThis2Cont{margin-bottom:20px;}div.HeadlineList
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}div.HeadlineNews
 div.ItemCont{margin-bottom:25px;margin-right:20px;}div.HeadlineNews{margin-right:0;}div.HeadlineViewer div.Controls div.RightControls a.ControlRss span.Icon,div.HeadlineNews a.ControlRss span.Icon{top:-3px;left:16px;}div.HeadlineList div.Items .ShareThis2{float:right;position:relative;top:0;}.FooterLinks{padding:6px
 0 12px 8px;}.FooterLinks A{color:#03c;font-weight:normal;}A.FooterLinks:hover{color:#f60;}.FooterCopyright{color:#333;font-weight:normal;padding-right:8px;}.Pipe{color:#000;font-size:125%;padding:0 4px;}.FeedViewerBasicIdentification{display:none;}.MtpsFeedViewerBasicRootPanelClass{clear:left;margin:0
 5px 5px 0;padding:0 5px 5px 0;vertical-align:top;width:auto;}.MtpsFeedViewerBasicHeaderStylePanel{vertical-align:middle;margin-bottom:10px;}.FVB_HeaderStyle_One,.FVB_HeaderStyle_Two,.FVB_HeaderStyle_Three,.FVB_HeaderStyle_Four,.FVB_HeaderStyle_Five{font-weight:900;}.FVB_HeaderStyle_One{font-size:200%;}.FVB_HeaderStyle_Two{font-size:175%;}.FVB_HeaderStyle_Three{font-size:150%;}.FVB_HeaderStyle_Four{font-size:125%;}.FVB_HeaderStyle_Five{font-size:100%;}A.TitleRSSButtonCssClass{vertical-align:middle;}A.TitleRSSButtonCssClass
 img{margin:0 0 0 5px;}.BasicHeadlinesItemPanelCssClass{float:left;margin-bottom:10px;padding:0 1% 0 0;vertical-align:top;}.BasicListItemPanelCssClass{float:left;margin-bottom:15px;padding:0 0 0 1%;vertical-align:top;}.FeedViewerBasicBulletListLI{margin-bottom:5px;}.FeatureHeadlinesTitle{margin-top:0;padding-top:0;vertical-align:top;}.TitleBold{font-weight:700;}.FeaturedHeadlinesItemPanelCssClass{float:left;padding:0
 1% 0 0;vertical-align:top;}.ImageHeadlineTabelCell{padding:0 5px 0 0;text-align:left;vertical-align:top;width:1%;}.ImageHeadlineTabelCell A IMG{border:solid 0 transparent;}.FeaturedRssItemTableCell{vertical-align:top;padding-bottom:12px;text-align:left;}.FVBAuthorLabel{font-weight:900;color:#555;font-size:smaller;padding:0
 5px 0 0;}.FVBPubDateLabel{font-style:italic;color:#555;font-size:smaller;}.FVB_ImageHeadlinesDiv{margin-bottom:10px;vertical-align:top;}.LimitedListItemPanelCssClass{float:left;vertical-align:top;margin-bottom:15px;padding:0 1% 0 0;}.ItemDiv{float:left;padding:0
 1% 0 0;}.ColumnDiv{clear:both;margin-top:15px;}.OverflowAuto{overflow:auto;}.OPMLImgDiv{float:left;margin-bottom:12px;padding:3px 10px 9px 0;}.OPMLTextDiv{vertical-align:top;min-height:30px;margin:0 0 12px 65px;}.OPMLFriendlyName{font-size:small;font-weight:bold;}.OPMLSubtitle{font-size:small;font-weight:normal;}.OPMLFriend{text-decoration:none;color:#555;}.FVBForumListLI{margin-bottom:10px;}.FVBForumDescriptionCssClass{width:auto;vertical-align:top;margin-bottom:15px;}.ListColumnPanel{float:left;padding-right:1%;}.EmptyPanel{clear:both;}.ListPanelMarginTop{margin-top:15px;}.TitleHidden{visibility:hidden;height:0;}.FR_Thumb
 .FR_Thumb_Border1{margin-left:5px;padding:1px;border:1px solid #ccc;background:#eee;}.FR_Thumb .FR_Thumb_Border2{border:2px solid #eee;}.FR_Thumb_Focussed .FR_Thumb_Border1{background:#ccc;}.FR_Thumb_Selected .FR_Thumb_Border1{background:#999;}.FR_Image .FR_Image_Border1{padding:2px;border:1px
 solid #ccc;background:#eee;margin-left:25px;}.FR_Image .FR_Image_Border2{border:1px solid #eee;position:relative;}.FR_Text{text-align:right;position:absolute;bottom:0;left:0;right:0;}.FR_Text_Left{text-align:left;}.FR_Background{position:absolute;bottom:0;left:0;right:0;background-color:#000;-moz-opacity:.5;filter:alpha(opacity=50);opacity:.5;z-index:0;}.FR_TextContainer{padding:8px;z-index:10;}.FR_Title{font-family:'Segoe
 UI Bold','Segoe Bold','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;font-weight:bold;color:#fff;}.FR_Description{font-size:12px;color:#fff;}.BP_Home_Renew{margin:10px 10px 10px 0;}.BP_Home_Renew table{margin:0 auto;}.BP_Home_ExpirationText{text-align:center;}.BP_Home_RenewLink{padding-right:10px;text-align:center;}.BP_Home_Table
 ul{padding:10px 0 0 15px;font-size:14px;margin:0;}.BP_Home_Table ul li{list-style-image:none;list-style-type:none;padding-bottom:2px;}.BP_Home_Renew * input{padding:4px;vertical-align:middle;}#GutterNavigation{margin:-8px 0 0 0;text-align:left;width:180px;z-index:1;}.GutterTitle{font-size:12px;font-weight:bold;padding:8px
 0 0 7px;}.BostonNavCtrlButton,.BostonNavCtrlButton:active,.BostonNavCtrlButton:link,.BostonNavCtrlButton:visited{display:block;padding:1px 2px 1px 14px;text-decoration:none;}.BostonNavCtrlButton:hover{background-color:#ededed;color:#333;}.MoreCentersLink:active,.MoreCentersLink:visited,.MoreCentersLink:link{display:block;text-decoration:none;text-align:right;}.ratingsPopup{background-color:#fff;border:#7a7a7a
 1px solid;margin:0;width:450px;height:220px;vertical-align:middle;position:absolute;z-index:100;display:none;}.ratingsPopup .OptionalText{margin-top:10px;margin-bottom:10px;float:left;margin-left:25px;font-size:10pt;}.ratingsPopup .ratingsComment{width:396px;display:block;margin-bottom:10px;margin-left:25px;height:132px;}.ratingsPopup
 .RatingsCloseButton,.ratingsPopup .RatingsSubmitButton{float:right;margin-left:25px;padding-top:.2em;}.ratingsPopup .RatingsCloseButton{margin-right:25px;}.Rotate90{-webkit-transform:rotate(90deg);-moz-transform:rotate(90deg);-o-transform:rotate(90deg);-khtml-transform:rotate(90deg);width:0;height:0;}.AlternatePages{position:absolute;left:964px;white-space:nowrap;}span.AlternatePageTab{cursor:pointer;display:inline-block;padding:5px;margin:3px;background-color:transparent;border:1px
 solid #ddd;border-bottom:1px solid transparent;position:relative;bottom:2px;color:#000;}span.AlternatePageTabHover{background:#eee;border:1px solid #888;border-bottom:1px solid #eee;}span.AlternatePageTabSelected{cursor:default;background-color:#fff;border:1px
 solid #aaa;border-bottom:1px solid #fff;bottom:2px;}.Rotate90{writing-mode:tb-rl;}span.AlternatePageTab{border:1px solid #ddd;border-left:1px solid transparent;bottom:0;left:2px;}span.AlternatePageTabSelected{border:1px solid #aaa;border-left:1px solid transparent;bottom:0;left:2px;}html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,font,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td{border:0;font-weight:inherit;font-style:inherit;font-family:inherit;margin:0;outline:0;padding:0;}table{border-collapse:separate;border-spacing:0;}html{font-size:100.01%;}body{color:#333;font-family:'Segoe
 UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:80%;line-height:130%;}a,a:link,a:visited{color:#06d;cursor:pointer;text-decoration:none;}a:hover,a:active{color:#f60;text-decoration:none;}.bold,strong{font-weight:bold;}code{font-family:'Courier
 New',Courier,monospace;}em{font-style:italic;}h1,.title,h2,h3,h4,h5,h6{color:#3a3e43;font-weight:bold;line-height:125%;}h1,.title{font-size:175%;}h2{font-size:160%;margin:4px 0;}h3{font-size:140%;line-height:140%;margin:3px 0;}h4{font-size:125%;margin:2px
 0;}h5{font-size:110%;}h6{font-size:105%;}.Clear{clear:both;height:0;}.ClearBreak{clear:both;padding-bottom:1px;}.Clearleft{clear:left;height:0;}.ClearRight{clear:right;height:0;}.ClearRightBreak{clear:right;height:16px;}.clearnone{clear:none;}.Left{float:left;}.Right{float:right;}.Center{text-align:center;}.no_wrap{white-space:nowrap;}p{margin:0
 0 12px 0;}.absolute{position:absolute;}ol,ul{line-height:150%;margin:12px 0 12px 24px;}li{padding:0 0 3px 0;}ul li,ol>ul li{list-style-image:url('../../images/bullet.gif');}ol li,ul>ol li{list-style-image:none;}.bulletedlist,.BulletList{line-height:150%;list-style-type:disc;margin:12px
 0 12px 24px;}.NumberList{margin:12px 0 12px 24px;}.DropDownArrow{padding-bottom:2px;padding-left:5px;}a:hover .DropDownArrow{text-decoration:none;}.hidden{display:none;visibility:hidden;}.pre{margin:10px;padding:10px;}.code{background:#ddd;display:block;font-family:'Lucida
 Console','Courier New';font-size:100%;line-height:100%;margin:10px;padding:10px;}#BodyBackground{padding:0 483px;}#JelloSizer{margin:0 auto;max-width:0;padding:0;width:0;}#JelloExpander{margin:0 -483px;min-width:966px;position:relative;}#JelloWrapper{width:100%;}.skipnav
 a{position:absolute;left:-10000px;overflow:hidden;}.skipnav a:focus,.skipnav a:active{position:static;left:0;overflow:visible;}table.multicol{border-collapse:collapse;}.innercol{padding:0 12px 0 0;}.BostonPostCard{margin:0 0 12px 0;overflow:hidden;width:100%;}.BostonPostCard
 h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{height:26px;margin:0 0 10px 0;overflow:hidden;position:relative;white-space:nowrap;}.MainColumn .BostonPostCard,.maincolumn .BostonPostCard,.MiddleColumn .BostonPostCard,.middlecolumn
 .BostonPostCard{margin:0 -12px 12px 0;padding:0 12px 0 0;}.RightAdRail .BostonPostCard{margin:0 0 12px 0;}.BostonPostCard h1{font-size:160%;height:31px;}.BostonPostCard h2{font-size:140%;height:28px;padding:3px 0 0 0;}.BostonPostCard h3{font-size:125%;}.BostonPostCard
 h4{font-size:110%;height:24px;}.BostonPostCard h5{font-size:105%;height:23px;}.BostonPostCard h6{font-size:100%;height:31px;line-height:100%;}.rssfeed,.rssfeed:hover{background:transparent url('../../images/common.png') -19px -1px no-repeat;display:inline-block;height:17px;position:relative;width:17px;}.opmlfeed,.opmlfeed:hover{background:transparent
 url('../../images/common.png') -1px -1px no-repeat;display:inline-block;height:17px;position:relative;width:17px;}.RightAdRail .BostonPostCard h1 .rssfeed,.RightAdRail .BostonPostCard h1 .opmlfeed,.RightAdRail .BostonPostCard h2 .rssfeed,.RightAdRail .BostonPostCard
 h2 .opmlfeed,.BostonPostCard h3 .rssfeed,.BostonPostCard h3 .opmlfeed,.BostonPostCard h4 .rssfeed,.BostonPostCard h4 .opmlfeed,.BostonPostCard h5 .rssfeed,.BostonPostCard h5 .opmlfeed,.BostonPostCard h6 .rssfeed,.BostonPostCard h6 .opmlfeed{position:absolute;right:0;top:4px;}td.headlines_td_text{padding:0
 0 12px 10px;}td.headlines_td_text strong{font-size:14px;font-weight:normal;margin-bottom:3px;}td.headlines_td_image{padding:3px 0 12px 0;}table.headlines_table{padding-bottom:12px;}td.noimages_td{}.RightAdRail .linklist{margin-top:-12px;}.linklist h3{font-size:14px;font-weight:bold;}.BostonPostCard
 .linklist h3{font-size:14px;font-weight:bold;margin-bottom:0;}.expressWrapper{margin-left:15px;margin-top:15px;width:790px;}.expressQPWrapper{margin-left:645px;margin-top:25px;}.expressQPCell{height:43px;padding-left:20px;}table.grid{border:solid #666 1px;}.grid
 td{padding:5px;border:solid #333 1px;}.CollapseRegionLink,.CollapseRegionLink:link,.CollapseRegionLink:hover,.CollapseRegionLink:visited{font-size:inherit!important;}Div.miniRatings{height:auto!important;vertical-align:middle!important;padding-bottom:5px!important;padding-top:5px!important;}div.miniRatings_left{padding-top:0!important;padding-bottom:0!important;position:inherit!important;background-color:Transparent!important;}div.miniRatings_left
 a{padding-top:0!important;padding-bottom:0!important;}div.clsNote{background-color:#eee;margin-bottom:4px;padding:2px;}.bookbox{clear:none;float:right;text-align:center;width:300px;}.bookpublisherlogocontainer{margin-top:5px;}.BreadCrumb{font-size:90%;padding:5px
 0 10px;}.EyebrowElement{font-weight:bold;}.SmallTitle{font-size:140%;}.clearfix:after{content:".";display:block;clear:both;visibility:hidden;line-height:0;height:0;}.clearfix{display:inline-block;}html[xmlns] .clearfix{display:block;}* html .clearfix{height:1%;}.AlternativeLocales{padding:10px
 2px 10px 2px;}p.NoP{margin:0;}.Container p{margin:0;display:block;}div.NoBrandLogo A{background:transparent;color:#fff;height:auto;width:auto;}div.NoBrandLogo span{display:inline;}.RightAdRail2{background-color:#fafafa;}div.PaddedMainColumnContent{padding-left:5px;}ol{padding-left:10px;}table.multicol{border-collapse:collapse;}.FullWidth,.fullwidth{overflow:hidden;}.MainColumn,.maincolumn{overflow:hidden;}.MiddleColumn,.middlecolumn{overflow:hidden;}.RightColumn,.rightcolumn{overflow:hidden;}.LeftNavigation,.leftnavigation{overflow:hidden;}.ColumnFifty,.columnfifty,.RightAdRail{overflow:hidden;}h1,.title{margin:5px
 0;}h1,.title,h2,h3,h4,h5,h6{clear:both;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;}.Masthead{padding:12px 0 0 0;}.BrandLogo{cursor:pointer;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:19px;float:left;line-height:125%;margin:0
 0 0 8px;width:312px;}.GlobalBar{float:right;font-size:12px;margin:-4px 11px 0 0;text-align:right;width:305px;}.GlobalBar a:hover{text-decoration:underline;}.PassportScarab{float:right;padding:0;white-space:nowrap;}.UserName{float:right;font-size:13px;font-weight:bold;overflow:hidden;white-space:nowrap;width:283px;}.LocaleManagementFlyoutStaticLink{margin-right:16px;}LocaleManagementFlyoutStaticLink
 a,LocaleManagementFlyoutStaticLink a:visited,LocaleManagementFlyoutStaticLink a:active{white-space:nowrap;text-decoration:none;display:inline;}LocaleManagementFlyoutStaticLink a:hover{text-decoration:underline;}.NetworkLogo{font-family:'Segoe UI Semibold','Segoe
 UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:19px;line-height:150%;position:absolute;right:12px;}.NetworkLogo a{display:inline-block;height:21px;width:79px;}.alley{background:url('../images/contentpanemiddle.png') repeat-y left;padding-left:19px;}.wrapper{padding-right:21px;}.topleftcorner{background:transparent
 url('../images/contentpane.png') 0 0 no-repeat;height:17px;margin-top:-2px;margin-right:21px;}.toprightcorner{background:transparent url('../images/contentpane.png') 100% 0 no-repeat;float:right;height:17px;margin-top:-17px;width:21px;}.inner{min-height:768px;padding:1px;}.bottomleftcorner{background:transparent
 url('../images/contentpane.png') 0 -17px no-repeat;height:21px;margin-right:21px;}.bottomrightcorner{background:transparent url('../images/contentpane.png') 100% -17px no-repeat;float:right;height:21px;margin-top:-21px;width:21px;}.BostonPostCard h1 a,.BostonPostCard
 h2 a,.BostonPostCard h3 a,.BostonPostCard h4 a,.BostonPostCard h5 a,.BostonPostCard h6 a{color:#260859;}.BostonPostCard h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{background:url('../../images/headers.gif')
 0 0 no-repeat;}.BostonPostCard h2{padding:3px 0 0 0;}.BostonPostCard h3{padding:5px 0 0 0;}.BostonPostCard h4{padding:7px 0 0 0;}.BostonPostCard h5{padding:8px 0 0 0;}.FullWidth .BostonPostCard h1,.fullwidth .BostonPostCard h1,.FullWidth .BostonPostCard h2,.fullwidth
 .BostonPostCard h2,.MainColumn .BostonPostCard h1,.maincolumn .BostonPostCard h1,.MainColumn .BostonPostCard h2,.maincolumn .BostonPostCard h2,.MiddleColumn .BostonPostCard h1,.middlecolumn .BostonPostCard h1,.MiddleColumn .BostonPostCard h2,.middlecolumn
 .BostonPostCard h2,.LeftNavigation .BostonPostCard h1,.leftnavigation .BostonPostCard h1,.LeftNavigation .BostonPostCard h2,.leftnavigation .BostonPostCard h2,.RightColumn .BostonPostCard h1,.rightcolumn .BostonPostCard h1,.RightColumn .BostonPostCard h2,.rightcolumn
 .BostonPostCard h2,.ColumnFifty .BostonPostCard h1,.columnfifty .BostonPostCard h1,.ColumnFifty .BostonPostCard h2,.columnfifty .BostonPostCard h2{background:none;}.FullWidth .BostonPostCard h3,.fullwidth .BostonPostCard h3,.FullWidth .BostonPostCard h4,.fullwidth
 .BostonPostCard h4,.FullWidth .BostonPostCard h5,.fullwidth .BostonPostCard h5,.FullWidth .BostonPostCard h6,.fullwidth .BostonPostCard h6{background-position:-1px -98px;}.MainColumn .BostonPostCard h3,.maincolumn .BostonPostCard h3,.MainColumn .BostonPostCard
 h4,.maincolumn .BostonPostCard h4,.MainColumn .BostonPostCard h5,.maincolumn .BostonPostCard h5,.MainColumn .BostonPostCard h6,.maincolumn .BostonPostCard h6{background-position:-302px -66px;}.MiddleColumn .BostonPostCard h3,.middlecolumn .BostonPostCard h3,.MiddleColumn
 .BostonPostCard h4,.middlecolumn .BostonPostCard h4,.MiddleColumn .BostonPostCard h5,.middlecolumn .BostonPostCard h5,.MiddleColumn .BostonPostCard h6,.middlecolumn .BostonPostCard h6{background-position:-483px -34px;}.LeftNavigation .BostonPostCard h3,.leftnavigation
 .BostonPostCard h3,.LeftNavigation .BostonPostCard h4,.leftnavigation .BostonPostCard h4,.LeftNavigation .BostonPostCard h5,.leftnavigation .BostonPostCard h5,.LeftNavigation .BostonPostCard h6,.leftnavigation .BostonPostCard h6{background-position:-302px
 -34px;}.RightColumn .BostonPostCard h3,.rightcolumn .BostonPostCard h3,.RightColumn .BostonPostCard h4,.rightcolumn .BostonPostCard h4,.RightColumn .BostonPostCard h5,.rightcolumn .BostonPostCard h5,.RightColumn .BostonPostCard h6,.rightcolumn .BostonPostCard
 h6{background-position:-1px -130px;}.ColumnFifty .BostonPostCard h3,.columnfifty .BostonPostCard h3,.ColumnFifty .BostonPostCard h4,.columnfifty .BostonPostCard h4,.ColumnFifty .BostonPostCard h5,.columnfifty .BostonPostCard h5,.ColumnFifty .BostonPostCard
 h6,.columnfifty .BostonPostCard h6{background-position:-1px -34px;}.RightAdRail .BostonPostCard h1,.RightAdRail .BostonPostCard h2,.RightAdRail .BostonPostCard h5{background-position:-1px -34px;}.RightAdRail .BostonPostCard h3,.RightAdRail .BostonPostCard
 h4,.RightAdRail .BostonPostCard h6{background-position:-1px -66px;text-align:right;}.RightAdRail .BostonPostCard h3{padding:5px 7px 0 0;}.RightAdRail .BostonPostCard h4{padding:7px 7px 0 0;}.RightAdRail .BostonPostCard h6{padding:0 31px 0 0;}.RightAdRail .BostonPostCard
 h6 .rssfeed,.RightAdRail .BostonPostCard h6 .opmlfeed{right:7px;top:7px;}.RightAdRail .BostonPostCard h3 .rssfeed,.RightAdRail .BostonPostCard h3 .opmlfeed,.RightAdRail .BostonPostCard h4 .rssfeed,.RightAdRail .BostonPostCard h4 .opmlfeed{position:static;}.pasco_wrapper{background:#fff
 url('../images/pasco_wrapper.gif') -300px -0 repeat-y;margin:0 0 12px 0;overflow:hidden;width:300px;}.RightAdRail .pasco_wrapper h3{background:#fff url('../images/pasco_wrapper.gif') -0 -0 no-repeat;font-size:0;height:36px;margin:0;overflow:hidden;padding:0;}.RightAdRail
 .pasco_wrapper h5{background:#fff url('../images/pasco_wrapper.gif') -0 -36px no-repeat;height:34px;overflow:hidden;}.RightAdRail .pasco_container{padding:0 11px 22px 17px;}.pasco_container ul li{list-style-image:url('../../images/bullet.gif')!important;}.FullWidth
 .h3,.fullwidth .h3{background:url('../../images/headers.gif') -1px -98px no-repeat!important;}.MainColumn .h3,.maincolumn .h3{background:url('../../images/headers.gif') -302px -66px no-repeat!important;}.MiddleColumn .h3,.middlecolumn .h3{background:url('../../images/headers.gif')
 -483px -34px no-repeat!important;}.RightColumn .h3,.rightcolumn .h3{background:url('../../images/headers.gif') -1px -130px no-repeat!important;}.ColumnFifty .h3,.columnfifty .h3{background:url('../../images/headers.gif') -1px -34px no-repeat!important;}.FullWidth
 .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty .h3,.columnfifty .h3{font-size:125%!important;height:26px;padding:5px 0 0 0;}.h3 .rssfeed,.h3 .opmlfeed{position:absolute;right:0;top:4px;}ol{padding-left:10px;}.BostonPostCard
 h1{line-height:130%;}.BostonPostCard h6{font-size:95%;line-height:120%;padding:0 0 1px 0;} ﻿#BodyBackground{background:#ced5db url('../images/logos_and_bg.png') repeat-x 0 -100px;}.BrandLogo,.BrandLogo a,.BrandLogo a:link,.BrandLogo a:visited,.BrandLogo a:hover,.BrandLogo
 a:active,.GlobalBar,.PassportScarab,.PassportScarab a,.PassportScarab a:link,.PassportScarab a:visited,.PassportScarab a:hover,.PassportScarab a:active,.UserName,.UserName a,.UserName a:link,.UserName a:visited,.UserName a:hover,.UserName a:active,a.LocaleManagementFlyoutStaticLink,a:link.LocaleManagementFlyoutStaticLink,a:visited.LocaleManagementFlyoutStaticLink,a:hover.LocaleManagementFlyoutStaticLink,a:active.LocaleManagementFlyoutStaticLink{color:#313131;}.NetworkLogo
 a{background:url('../images/logos_and_bg.png') no-repeat 0 0;}.leftcap{background:url('../images/tabstrip.png') no-repeat -997px 0;}.rightcap{background:url('../images/tabstrip.png') no-repeat right top;}.internav{background:url('../images/tabstrip.png') no-repeat
 right top;}.internav a,.internav a:link,.internav a:visited,.internav a:hover{color:#260859;}.internav a:hover{background-color:#fff;}.internav a.active,.internav a.active:link,.internav a.active:hover,.internav a.active:visited,.internav a.active:active{background-color:#becbd7;color:#313131;}.LocalNavigation{background:url('../images/tabstrip.png')
 repeat-y left top;}.LocalNavigation .TabOn,.LocalNavigation .TabOn:hover{background-color:#046cb6;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{color:#fff;}.LocalNavigation .TabOff a{color:#313131;}.LocalNavigation
 .TabOff a:hover{background-color:#e8e8e8;}.BostonPostCard h1,.BostonPostCard h2,.BostonPostCard h3,.BostonPostCard h4,.BostonPostCard h5,.BostonPostCard h6{background-color:#e8e8e8;color:#260859;}.RightAdRail .BostonPostCard h1,.RightAdRail .BostonPostCard
 h2,.RightAdRail .BostonPostCard h5{color:#260859;}.RightAdRail .BostonPostCard h3,.RightAdRail .BostonPostCard h4,.RightAdRail .BostonPostCard h6{color:#260859;}.RightAdRail .BostonPostCard h1 a,.RightAdRail .BostonPostCard h2 a,.RightAdRail .BostonPostCard
 h3 a,.RightAdRail .BostonPostCard h4 a,.RightAdRail .BostonPostCard h5 a,.RightAdRail .BostonPostCard h6 a{color:#260859;}.FullWidth .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty
 .h3,.columnfifty .h3{background-color:#e8e8e8!important;}.top1,.boxheader{background:#e8e8e8;color:#260859!important;}.boxcontent{border-bottom:1px solid #e8e8e8!important;border-left:1px solid #e8e8e8!important;border-right:1px solid #e8e8e8!important;} body{font-family:Verdana,Arial,Helvetica,sans-serif;color:#000;font-size:68.75%}a{text-decoration:none;color:#03c}a:link{color:#03c}a:visited{color:#800080}a:hover{color:#f60}a:active{color:#800080}a
 img{border:none}H1{font-size:210%;font-weight:400}H1.heading{font-size:120%;font-family:Verdana,Arial,Helvetica,sans-serif;font-weight:bold;line-height:120%}H2{font-size:115%;font-weight:700}H2.subtitle{font-size:180%;font-weight:400;margin-bottom:.6em}H3{font-size:110%;font-weight:700}H4,H5,H6{font-size:100%;font-weight:700}h4.subHeading{font-size:100%}dl{margin:0
 0 10px;padding:0 0 0 1px}dt{font-style:normal;margin:0}li{margin-bottom:3px;margin-left:0}ol{line-height:140%;list-style-type:decimal;margin-bottom:15px}ol ol{line-height:140%;list-style-type:lower-alpha;margin-bottom:4px;margin-top:3px}ol ol ol{line-height:140%;list-style-type:lower-roman;margin-bottom:4px;margin-top:3px}ol
 ul,ul ol{line-height:140%;margin-bottom:15px;margin-top:15px}p{margin:0 0 10px;padding:0}div.section p{margin-bottom:15px;margin-top:0}ul{line-height:140%;list-style-position:outside;list-style-type:disc;margin-bottom:15px}ul ul{line-height:140%;list-style-type:disc;margin-bottom:4px;margin-left:17px;margin-top:3px}.heading{font-weight:700;margin-bottom:8px;margin-top:18px}.subHeading{font-size:100%;font-weight:700;margin:0}div.hr1{background:#c8cdde;font-size:1px;height:1px;margin:0;padding:0;width:100%}div.hr2{background:#d4dfff;font-size:1px;height:1px;margin:0;padding:0;width:100%}div.hr3{background:#eef;font-size:1px;height:1px;margin:0;padding:0;width:100%}div#header{background-color:#d4dfff;padding:0;width:100%}div#header
 table td{color:#00f;margin-bottom:0;margin-top:0;padding-right:20px}div#header table tr#headerTableRow3 td{padding-bottom:2px;padding-top:5px}div#header table#bottomTable{border-top-color:#fff;border-top-style:solid;border-top-width:1px;text-align:left}div#footer{font-size:90%;margin:0;padding:2px
 2px 6px 5px;width:100%}div#mainSection table{border:1px solid #ddd;font-size:100%;margin-bottom:5px;margin-left:5px;margin-top:5px;margin-right:10px;width:97%}div#mainSection table tr{vertical-align:top}div#mainSection table th{border-bottom:1px solid #c8cdde;color:#006;padding-left:5px;padding-right:5px;text-align:left}div#mainSection
 table td{border-right:1px solid #d5d5d3;margin:1px;padding-left:5px;padding-right:5px;overflow:auto}div#mainSection table td.imageCell{white-space:nowrap}DIV#mainSection TABLE.MtpsTableLayout{BORDER:0}DIV#mainSection TABLE.MtpsTableLayout TD{PADDING-RIGHT:5px;PADDING-LEFT:5px;MARGIN:1px;BORDER:0}div.ContentArea
 table th,div.ContentArea table td{background:#fff;border:0 solid #ccc;font-family:Verdana;padding:5px;text-align:left;vertical-align:top}.ContentArea .topic table td{border:1px solid #ccc;margin:1px;padding-left:5px;padding-right:5px}div.ContentArea table
 th{background:#ccc none repeat scroll 0% 50%;vertical-align:bottom}div.ContentArea table{border-collapse:collapse;width:auto}.ContentArea .topic table{border-width:1px;border-style:solid}.media img{vertical-align:top}.HeaderCaptionText,.title{color:#000;font-family:Arial,Helvetica,sans-serif;font-size:190%;font-style:normal;font-variant:normal;font-weight:bold;line-height:normal;margin:0
 0 10px}div#mainBody div.alert,div#mainBody div.code{width:98.9%}div#mainBody div.alert{padding-bottom:.82em;clear:both}span.selflink{font-weight:700}span.code{font-family:Monospace,Courier New,Courier;font-size:105%;color:#006}span.label,span.ui{font-family:"Segoe
 UI",\2018 Lucida Grande\2019 ,Verdana,Arial,Helvetica,sans-serif;font-weight:bold}span.code{font-family:Monospace,Courier New,Courier;font-size:105%;color:#006}div.caption{font-weight:bold;font-size:100%;color:#039}.procedureSubHeading{font-size:110%;font-weight:bold}span.sub{vertical-align:sub}span.sup{vertical-align:super}span.big{font-size:larger}span.small{font-size:smaller}span.tt{font-family:Courier,"Courier
 New",Consolas,monospace}.ContentArea .topic table#topTable{border-width:0;width:100%}.ContentArea .topic table #runningHeaderText{color:#000}.parameter{font-family:"Segoe UI",\2018 Lucida Grande\2019 ,Verdana,Arial,Helvetica,sans-serif;font-size:100%;font-style:italic;margin:0}div.clsNote{background-color:#eee;margin-bottom:4px;padding:2px}.bookbox{float:right;clear:none;width:300px;text-align:center}.bookPublisherLogoContainer{margin-top:5px}.uml{list-style:none!important;margin-left:20px}.uml
 li{list-style-image:none!important}.umlNumber{position:relative;width:150px;left:-154px;text-align:right;padding-right:2px}.umlContent{position:relative;top:-15px} --></style>
<div class="topic" id="topic">
<div id="top">
<div class="Clear"></div>
<div class="Clear"></div>
<div>
<p>更新日: 2010 年 12 月 24 日</p>
</div>
<p style="text-indent:-3.5em; padding-left:3.5em">執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#masuda" target="_blank">
moonmile solutions、増田 智明</a></p>
<div style="margin:0; background-color:#d9e8ec; border:2px #46689a solid; margin-bottom:20px">
<div style="background-color:#d9e8ec; border:1px #ffffff solid">
<div style="padding:5px; font-size:100%; border:1px #46689a solid">
<p style="margin:0; padding:0">本連載では、日経 BP 社から発売された<a href="http://ec.nikkeibp.co.jp/item/books/P94380.html" target="_blank">「ひと目でわかる ASP.NET MVC アプリケーション開発入門」</a>をもとにして、執筆時に気づいたことや紙面の都合で書ききれなかった技術を紹介します。</p>
</div>
</div>
</div>
<h2>目次</h2>
<div style="width:530px">
<div style="float:left; width:280px; margin-bottom:0">
<p><a href="#01">1. はじめに</a></p>
<p><a href="#02">2. URL ルーティングとは何か</a></p>
<p><a href="#03">3. URL ルーティングとアクション メソッドの関係</a></p>
<p><a href="#04">4. 仕組みを追う</a></p>
</div>
<div style="float:right; width:250px">
<p><a href="#05">5. 新しい URL ルーティングを追加する</a></p>
<p><a href="#06">6. 動作確認</a></p>
<p><a href="#07">7. URL ルーティングのパターンの注意点</a></p>
<p><a href="#08">8. おわりに</a></p>
</div>
</div>
<div style="clear:both"></div>
<hr>
<h2 id="01">1. はじめに</h2>
<p>連載の第 2 回目は、ASP.NET 4 で導入された「URL ルーティング」と、ASP.NET MVC 2 で必ず理解が必要な「アクション メソッド」についてお話ししましょう。</p>
<p>「URL ルーティング」と「アクション メソッド」は、ASP.NET MVC アプリケーションを作る上で必須な機能です。ですが、複雑な仕組みは既に ASP.NET MVC のフレームワークに織り込まれているために、Visual Studio 2010 を使うと自然と「URL ルーティング」と「アクション メソッド」が関連づけられるようになっています。<a href="http://msdn.microsoft.com/ja-jp/asp.net/gg490411">前回</a>の記事のように Visual
 Studio 2010 上からコントローラーを作ることで、自動的に必要なアクション メソッドが作られる仕掛けも組み込まれています。</p>
<p>今回は、もう一歩踏み込んで、この URL ルーティングがどのように ASP.NET MVC のアクション メソッドに繋がるのかを具体的に追ってみます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17097-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="02">2. URL ルーティングとは何か</h2>
<p>さて、URL ルーティングとは何でしょうか?</p>
<p>ブラウザーで WWW サーバーに接続するときに URL という文字列を入力しますが、この時「/」(スラッシュ) で区切られた文字列だけでなく、「?」や「=」が含まれた文字列がアドレスに表示されることがあります。これを「クエリ文字列」と言います。しかし、クエリ文字列自体は人が覚えやすいものではありません。見た目も分かり辛く、メールなどでアドレスを他人に送る場合にも長くなり過ぎて使いづらいものです。</p>
<p>実はこのクエリ文字列の部分を、あたかもフォルダーを指定しているように「/」で区切る形式にできます。一定のルールで URL をクエリ文字列の形式に直すのが「URL ルーティング」になります。</p>
<p>例えば、ショッピング サイトで商品の ID が「A0001」のページを開くときに次のような URL を指定するとしましょう。</p>
<p>http://servername/Home/Item/A0001</p>
<p>この URL を内部では、次のようなクエリ文字列と同じように扱えるようにします。</p>
<p>http://servername/Home/Item/?id=A0001</p>
<p>この機能は、Apache の mod_rewrite や IIS の <a title="新しいウィンドウで開きます" href="http://www.iis.net/download/URLRewrite" target="_blank">
URL Rewrite モジュール (英語)</a> によって実現されている定番な機能です。URL ルーティングを用いることによって、簡素化された URL を使うことができます。</p>
<p><img src="17098-image.png" alt=""></p>
<p><strong>図 1. IIS 7 の URL rewrite</strong></p>
<p>具体的には、書籍<a title="新しいウィンドウで開きます" href="http://ec.nikkeibp.co.jp/item/books/P94380.html" target="_blank">「ひと目でわかるASP.NET MVCアプリケーション入門」</a>のサンプル プログラムを動かしてみると、どちらも同じ動きとなり商品の詳細情報の表示になることが分かります。</p>
<p><img src="17099-image.png" alt=""></p>
<p><strong>図 2. URL ルーティングを使った場合と使わない場合</strong></p>
<p>実は Visual Studio 2010 を使って、ASP.NET MVC アプリケーションの枠組みを作ると、既に URL ルーティングの機能が使われています。ASP.NET MVC が使っている URL ルーティングは、ASP.NET 3.5 SP1 以降のフレームワークとして実装されているもので、IIS や Apache のモジュールと違い、ソース コードで URL ルーティングの設定を行います。</p>
<p style="margin-top:20px"><a href="#top"><img src="17100-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="03">3. URL ルーティングとアクション メソッドの関係</h2>
<p>次に URL ルーティングとアクション メソッドの関係を考えていきましょう。</p>
<p>アクション メソッドは、ASP.NET MVC のコントローラーに含まれるメソッドです。URL が指定されると、ルールに従って特定のコントローラー クラスの特定のメソッドが呼び出される仕組みになっています。アクション メソッドにより、どのビューを表示するという MVC パターンの要となる仕組みで、URL ルーティングとワンセットで動作します。</p>
<p>先ほどの URL をコントローラー名やアクション メソッドに分けて見直してみましょう。</p>
<p>http://servername/Home/Item/A0001</p>
<p>この URL は既定で次のように分解されます。</p>
<p>http://servername/＜コントローラー名＞/＜アクション メソッド名＞/＜パラメーター＞</p>
<p>サーバー名 (servername) に続き、コントローラーの名前 (Home)、アクション メソッドの名前 (Item)、パラメーターである商品 ID (A0001) となります。</p>
<p>実際のコントローラーのクラス名は、「Home」＋「Controller」となり、「HomeController」というクラス名になります。コントローラー名は、URL で指定されたコントローラーの名前に「Controller」を付ける、というルールになっているのです。</p>
<p>パラメーターの値は「A0001」となっていますが、実は「?id=A0001」のクエリ文字列と同じ動きをする URL ルーティングの設定なので、パラメーターの名前が「id」、パラメーターの値が「A0001」になります。<br>
URL を分解する順番を表すと次の図になります。</p>
<p><img src="17101-image.png" alt=""></p>
<p><strong>図 3. 概要図</strong></p>
<ol>
<li>コントローラー名を取り出す。 </li><li>「コントローラー名」＋「Controller」のクラスを呼び出す。 </li><li>指定されたアクション メソッドを呼び出す。 </li><li>パラメーターを引き渡す。 </li><li>アクション メソッドが指定のビューを表示する。 </li></ol>
<p style="margin-top:20px"><a href="#top"><img src="17102-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="04">4. 仕組みを追う</h2>
<p>具体的に URL ルーティングとアクション メソッドの仕組みを追っていきましょう。</p>
<p>Visual Studio 2010 で ASP.NET MVC アプリケーションを作成して、ソリューション エクスプローラーで、Global.asax というファイルを開いてみてください。</p>
<p>このファイルの中に、先ほど説明した URL ルーティングのパターンが記述されています。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="xml">public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;);

    routes.MapRoute(
        &quot;Default&quot;, // ルート名
        &quot;{controller}/{action}/{id}&quot;, // パラメーター付きの URL
        new { controller = &quot;Home&quot;, action = &quot;Index&quot;, id = UrlParameter.Optional } // パラメーターの既定値
    );
}</code></pre>
<pre id="codePreview" class="csharp"><code class="xml">public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;);

    routes.MapRoute(
        &quot;Default&quot;, // ルート名
        &quot;{controller}/{action}/{id}&quot;, // パラメーター付きの URL
        new { controller = &quot;Home&quot;, action = &quot;Index&quot;, id = UrlParameter.Optional } // パラメーターの既定値
    );
}</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;)

    ' MapRoute は次のパラメーターを順番に受け取ります:
    ' (1) ルート名
    ' (2) パラメーター付きの URL
    ' (3) パラメーターの既定値
    routes.MapRoute( _
        &quot;Default&quot;, _
        &quot;{controller}/{action}/{id}&quot;, _
        New With {.controller = &quot;Home&quot;, .action = &quot;Index&quot;, .id = UrlParameter.Optional} _
    )
End Sub</code></pre>
<pre id="codePreview" class="vb"><code class="xml">Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;)

    ' MapRoute は次のパラメーターを順番に受け取ります:
    ' (1) ルート名
    ' (2) パラメーター付きの URL
    ' (3) パラメーターの既定値
    routes.MapRoute( _
        &quot;Default&quot;, _
        &quot;{controller}/{action}/{id}&quot;, _
        New With {.controller = &quot;Home&quot;, .action = &quot;Index&quot;, .id = UrlParameter.Optional} _
    )
End Sub</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Global.asax は、アプリケーションの起動が開始するときに実行されるモジュールです。このファイルに URL ルーティングのパターンが記述されているのです。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&quot;{controller}/{action}/{id}&quot;, // パラメーター付きの URL</p>
</div>
<p>この部分が、ASP.NET MVC の URL ルーティングの設定です。中括弧で囲まれた名前はプレースホルダーと呼び、URL ルーティングの処理を行ったときに分解される名前が書かれています。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr style="background-color:#eff3f7">
<td>名前</td>
<td>意味</td>
</tr>
<tr>
<td>controller&nbsp;</td>
<td>コントローラー名</td>
</tr>
<tr>
<td>action</td>
<td>アクション メソッド名</td>
</tr>
<tr>
<td>id</td>
<td>id という名前のパラメーター</td>
</tr>
</tbody>
</table>
<p>見て分かる通り、コントローラー名とアクション メソッド名の場所が指定され、後ろにパラメーターの名前が指定されています。単純に固定ページを開くだけであれば、この「id」は必要ありませんが、商品の詳細ページのように指定した商品だけを表示するようなページの場合は、識別子 (identify) として利用できる準備が既にできているのです。</p>
<p>商品の詳細ページを表示する例と見比べてみましょう。</p>
<p>http://servername/Home/Item/A0001 は次のようにマッピングできます。</p>
<table class="grid" border="1" cellspacing="0" cellpadding="5" style="border-collapse:collapse; margin-bottom:10px">
<tbody>
<tr style="background-color:#eff3f7">
<td>名前</td>
<td>値</td>
</tr>
<tr>
<td>controller</td>
<td>Home</td>
</tr>
<tr>
<td>action</td>
<td>Item</td>
</tr>
<tr>
<td>id</td>
<td>A0001</td>
</tr>
</tbody>
</table>
<p>では、Item アクション メソッドを作ってみましょう。パラメーターに「id」を持ち、この商品番号 (id) にマッチングする商品をビューで表示するアクション メソッドです。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Item( string id )
{
    if (id == null)
    {
	return Redirect(&quot;/Home/Error&quot;);
    }
    else
    {
        ViewData[&quot;message&quot;] = string.Format(&quot;商品番号:{0}&quot;, id);
        Models.mvcdbEntities ent = new Models.mvcdbEntities();
        var model = from t in ent.TProduct
                    where t.id == id
                    select t;
        return View(model.First());
    }
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Item(&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Redirect(<span class="cs__string">&quot;/Home/Error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;message&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;商品番号:{0}&quot;</span>,&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Models.mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Models.mvcdbEntities();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;from&nbsp;t&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TProduct&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;t.id&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;t;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model.First());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">Function Item(ByVal id As String) As ActionResult
    If id Is Nothing Then
	Return Redirect(&quot;/Home/Error&quot;)
    Else
        ViewData(&quot;message&quot;) = String.Format(&quot;商品番号:{0}&quot;, id)
        Dim ent As New mvcdbEntities
        Dim model = From t In ent.TProduct
                    Where t.id = id
                    Select t
        Return View(model.First)
    End If
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="xml">Function Item(ByVal id As String) As ActionResult
    If id Is Nothing Then
	Return Redirect(&quot;/Home/Error&quot;)
    Else
        ViewData(&quot;message&quot;) = String.Format(&quot;商品番号:{0}&quot;, id)
        Dim ent As New mvcdbEntities
        Dim model = From t In ent.TProduct
                    Where t.id = id
                    Select t
        Return View(model.First)
    End If
End Function</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>ここで使っているデータベースは、日経BP社より<a title="新しいウィンドウで開きます" href="http://ec.nikkeibp.co.jp/nsp/dl/09438/index.shtml" target="_blank">サンプル プログラム</a>としてダウンロードできますので、活用してみてください。書籍で使われるプログラムが全て入っているものです。<br>
TProduct テーブルは、商品の情報が入ったテーブルになります。</p>
<p>最初の if 文では、「http://servername/Home/Item」のように id を指定せずに呼び出された時のチェックをしています。id を指定しなかった時には、値が null (VB では Nothing) となるためです。実際にサイトを作る時には、指定された id の商品が TPrduct テーブルに無かった場合もチェックする必要がありますが、ここでは省略しています。</p>
<p>次に、商品を表示するためのビューを作成しましょう。Visual Studio 2010 でビューの追加ダイアログ ボックスを使うと、詳細ページを表示するコードを自動生成してくれますので、これを活用します。</p>
<p><img src="17103-image.png" alt=""></p>
<p><strong>図 4. ビューの追加ダイアログ ボックス</strong></p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;%@ Page Title=&quot;&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;MvcApplication1.Models.TProduct&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Item
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Item&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData[&quot;message&quot;] %&gt;&lt;/p&gt;

    &lt;fieldset&gt;
        &lt;legend&gt;Fields&lt;/legend&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;id&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.id%&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;name&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.name%&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;price&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.price%&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;cateid&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.cateid%&gt;&lt;/div&gt;
        
    &lt;/fieldset&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id = Model.id })%&gt; |
        &lt;%: Html.ActionLink(&quot;Back to List&quot;, &quot;Index&quot;)%&gt;
    &lt;/p&gt;

&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;MvcApplication1.Models.TProduct&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Item&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Item&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;message&quot;</span>]&nbsp;%&gt;&lt;/p&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;fieldset&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;legend&gt;Fields&lt;/legend&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;id&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.id%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;name&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.name%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;price&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.price%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-label&quot;</span>&gt;cateid&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;display-field&quot;</span>&gt;&lt;%:&nbsp;Model.cateid%&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/fieldset&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Edit&quot;</span>,&nbsp;<span class="cs__string">&quot;Edit&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id&nbsp;=&nbsp;Model.id&nbsp;})%&gt;&nbsp;|&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Back&nbsp;to&nbsp;List&quot;</span>,&nbsp;<span class="cs__string">&quot;Index&quot;</span>)%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of MvcApplication1.TProduct)&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Item
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Item&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;message&quot;) %&gt;&lt;/p&gt;
    &lt;fieldset&gt;
        &lt;legend&gt;Fields&lt;/legend&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;id&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.id %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;name&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.name %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;price&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.price %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;cateid&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.cateid %&gt;&lt;/div&gt;
        
    &lt;/fieldset&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, New With {.id = Model.id})%&gt; |
        &lt;%: Html.ActionLink(&quot;Back to List&quot;, &quot;Index&quot;) %&gt;
    &lt;/p&gt;

&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of MvcApplication1.TProduct)&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Item
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Item&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;message&quot;) %&gt;&lt;/p&gt;
    &lt;fieldset&gt;
        &lt;legend&gt;Fields&lt;/legend&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;id&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.id %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;name&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.name %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;price&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.price %&gt;&lt;/div&gt;
        
        &lt;div class=&quot;display-label&quot;&gt;cateid&lt;/div&gt;
        &lt;div class=&quot;display-field&quot;&gt;&lt;%: Model.cateid %&gt;&lt;/div&gt;
        
    &lt;/fieldset&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, New With {.id = Model.id})%&gt; |
        &lt;%: Html.ActionLink(&quot;Back to List&quot;, &quot;Index&quot;) %&gt;
    &lt;/p&gt;

&lt;/asp:Content&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>商品番号 (id) が指定されない時には、Redirect メソッドを使い、エラー表示のための /Home/Error ページを表示させます。エラー表示をするための、コントローラー (Errorメソッド) とビュー (Error.aspx) は、別途作成しておきます。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Error()
{
    ViewData[&quot;message&quot;] = &quot;商品番号が指定されていません&quot;;
    return View();
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Error()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;商品番号が指定されていません&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>
<pre class="hidden">Function [Error]() As ActionResult
    ViewData(&quot;message&quot;) = &quot;商品番号が指定されていません&quot;
    Return View()
End Function</pre>
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Function</span>&nbsp;[<span class="visualBasic__keyword">Error</span>]()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData(<span class="visualBasic__string">&quot;message&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;商品番号が指定されていません&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;%@ Page Title=&quot;&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Error
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Error&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData[&quot;message&quot;] %&gt;&lt;/p&gt;

&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Error&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;Error&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;message&quot;</span>]&nbsp;%&gt;&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Error
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Error&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;message&quot;) %&gt;&lt;/p&gt;

&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Error
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Error&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;message&quot;) %&gt;&lt;/p&gt;

&lt;/asp:Content&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>実行すると次の画面になります。</p>
<p><img src="17104-image.png" alt=""></p>
<p><strong>図 5. 実行結果</strong></p>
<p>この動きを URL ルーティングのパターンとアクション メソッドの対応で示すと次の図になります。</p>
<p><img src="17105-image.png" alt=""></p>
<p><strong>図 6. URL ルーティングのパターンとアクション メソッドの対応</strong></p>
<ol>
<li>URL ルーティングのパターンにより、コントローラー「Home」、アクション メソッド「Item」、引数「id」を分解する。 </li><li>Home コントローラー (HomeController クラス) が呼び出される。 </li><li>Item アクション メソッドが呼び出される。 </li><li>アクション メソッドに引数 (id) が渡される。 </li><li>処理をした後、Item.aspx ビューを表示する。 </li></ol>
<p>これで URL ルーティングの具体的な動きがつかめたと思います。</p>
<p>URL ルーティングに記述されているパターンと、コントローラー、アクション メソッドの関係が理解できたら、次は新しい URL ルーティングのパターンを追加してみましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17106-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="05">5. 新しい URL ルーティングを追加する</h2>
<p>Visual Studio 2010 では、ASP.NET MVC アプリケーションのひな型を作ると、Global.asax に id という引数を持った URL ルーティングが自動的に作成されます。これを利用すると、先ほどの商品番号 (id) を利用したページのように、ひとつだけ識別子 (identify) を持ったページが作れます。</p>
<p>ですが、もっと複雑な条件が指定したい時があります。2 つ以上のパラメーターを持つような URL ルーティングはどのように設定するのでしょうか?</p>
<p>このルーティングの追加を具体的にやってみます。</p>
<p>例えば、特定の月の新着商品を表示するページを作るとしましょう。通常は、次のように「New」だけ URL に指定して、当月の新着の商品を表示させることにします。</p>
<p>http://servername/Home/New</p>
<p>もうひとつ、「2010 年 12 月の新着商品」のように過去の履歴も表示できるようにしましょう。「New」に続いて、年と月をパラメーターとして指定できるようにします。</p>
<p>http://servername/Home/New/2010/12</p>
<p>この URL ルーティングのパターンを新たに追加します。<br>
Global.asax.cs (VB の場合は Global.asax.vb) のファイルを開いて新着情報を開くときのパターンを追加しましょう。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">// 新着情報
routes.MapRoute(
    &quot;New&quot;,
    &quot;Home/New/{year}/{month}&quot;,
    new
    {
        controller = &quot;Home&quot;,
        action = &quot;New&quot;,
        year = UrlParameter.Optional,
        month = UrlParameter.Optional
    }
);</pre>
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;新着情報</span>&nbsp;
routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;New&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Home/New/{year}/{month}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;controller&nbsp;=&nbsp;<span class="cs__string">&quot;Home&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;action&nbsp;=&nbsp;<span class="cs__string">&quot;New&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;year&nbsp;=&nbsp;UrlParameter.Optional,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;month&nbsp;=&nbsp;UrlParameter.Optional&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
);&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">routes.MapRoute(
    &quot;New&quot;,
    &quot;Home/New/{year}/{month}&quot;,
    New With {.controller = &quot;Home&quot;, 
              .action = &quot;New&quot;,
              .year = UrlParameter.Optional,
              .month = UrlParameter.Optional}
          )</code></pre>
<pre id="codePreview" class="vb"><code class="xml">routes.MapRoute(
    &quot;New&quot;,
    &quot;Home/New/{year}/{month}&quot;,
    New With {.controller = &quot;Home&quot;, 
              .action = &quot;New&quot;,
              .year = UrlParameter.Optional,
              .month = UrlParameter.Optional}
          )</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>ルーティングを追加する時には、MapRoute メソッドを使います。</p>
<p>MapRoute メソッドの 1 つ目の引数は、ルーティングの名前です。</p>
<p>2 つ目の引数は、URL ルーティングのパターンになります。ASP.NET MVC の URL のルールに従って「{controller}」をコントローラー名の「Home」に、「{action}」をアクション メソッド名の「New」に置き換えます。続けて「year」と「month」というパラメーターを付けます。これがそのままアクション メソッドのパラメーターの名前になります。</p>
<p>パラメーターを汎用的に使う場合には「{controller}」と「{action}」のようにプレースホルダーを使うところですが、ここでは、Home コントローラーの New アクション メソッドに限った動作にさせるために、明示的に指定しています。</p>
<p>そして、3 つ目の引数がパラメーターのデフォルト値です。ASP.NET MVC の URL ルーティングでは、controller と action の値が必須となるため、それぞれ「Home」と「New」と指定しています。</p>
<p>次に、Home コントローラーに New メソッドを記述します。年 (year) と月 (month) が渡されるために、2 つの引数を持つアクション メソッドになります。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult New(int year = 0, int month = 0 )
{
    if (year == 0)
    {
        ViewData[&quot;date&quot;] = &quot;今月&quot;;
        DateTime now = DateTime.Now;
    }
    else
    {
        ViewData[&quot;date&quot;] = string.Format(&quot;{0}年{1}月&quot;, year, month);
    }
	return View();
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;New(<span class="cs__keyword">int</span>&nbsp;year&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">int</span>&nbsp;month&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(year&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;date&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;今月&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;now&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;date&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}年{1}月&quot;</span>,&nbsp;year,&nbsp;month);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="xml">Function [New](Optional ByVal year As Integer = 0,
               Optional ByVal month As Integer = 0) As ActionResult
    If year = 0 Then
        ViewData(&quot;date&quot;) = &quot;今月&quot;
    Else
        ViewData(&quot;date&quot;) = String.Format(&quot;{0}年{1}月&quot;, year, month)
    End If
    Return View()
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="xml">Function [New](Optional ByVal year As Integer = 0,
               Optional ByVal month As Integer = 0) As ActionResult
    If year = 0 Then
        ViewData(&quot;date&quot;) = &quot;今月&quot;
    Else
        ViewData(&quot;date&quot;) = String.Format(&quot;{0}年{1}月&quot;, year, month)
    End If
    Return View()
End Function</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>「http://servername/Home/New」のように年月を指定しなかた場合は、引数の year がデフォルト値である「0」になります。この時は、ViewData コレクションに「今月」という文字列を代入しておきます。</p>
<p>「http://servername/Home/New/2010/12」のように年月を指定した場合は、同様に指定した年月を ViewData コレクションに入れて、ビューで確認できるようにしておきます。</p>
<p>実際に作成する場合は、データベースから指定の年月のデータを検索する処理を入れることになります。商品の新着情報だけでなく、指定した年月の月次情報である在庫情報や販売情報などの帳票を作成するときに使えます。</p>
<p>最後に New のビューを作成して、コントローラーで設定した ViewData コレクションの値を表示させましょう。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;New&lt;/h2&gt;

    &lt;%: ViewData[&quot;date&quot;] %&gt;の新着情報です。

&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;New&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;date&quot;</span>]&nbsp;%&gt;の新着情報です。&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong>＜ソース (VB)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">Visual Basic</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">vb</span>
<pre class="hidden"><code class="visual basic">&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;New&lt;/h2&gt;

    &lt;%: ViewData(&quot;date&quot;) %&gt;の新着情報です。

&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;New&lt;/h2&gt;

    &lt;%: ViewData(&quot;date&quot;) %&gt;の新着情報です。

&lt;/asp:Content&gt;</code></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>これで準備は整いました。Visual Studio 2010 でデバッグ実行をして、動作を確認してみましょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17107-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="06">6. 動作確認</h2>
<p>ブラウザーを開いた後に、アドレスに「http://servername/Home/New」を指定します。すると、「今月の新着情報です。」と表示されます。</p>
<p>アドレスに年月を入れて「http://localohst/Home/New/2010/12」のように指定した場合は「2010 年 12 月の新着情報です。」と表示されます。</p>
<p><img src="17108-image.png" alt=""></p>
<p><strong>図 7. 新着商品</strong></p>
<p>また、URL ルーティングを使わずに次のようにクエリ文字列として指定しても同じ結果が得られます。</p>
<p>http://servername/Home/New/?year=2010&amp;month=12</p>
<p><img src="17109-image.png" alt=""></p>
<p><strong>図 8. クエリ指定の場合</strong></p>
<p>このように URL ルーティングを使うと、コントローラーのアクション メソッドに引数を渡すことができ、クエリ文字列よりも短くて済むので簡素に表せます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17110-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="07">7. URL ルーティングのパターンの注意点</h2>
<p>URL ルーティングのパターンは、MapRoute メソッドで登録した順番でルーティングが行われます。順番に注意しないと、思った通りにマッチングできなくなります。</p>
<p>例えば、Visual Studio 2010 で作成した ASP.NET MVC アプリケーションの既定のルーティングは、次のように記述されています。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>&quot;{controller}/{action}/{id}&quot;</p>
</div>
<p>これは引数がひとつである全てのアクション メソッドで使われます。<br>
例えば、商品の詳細情報を表示するための Item メソッドと、指定したカテゴリ内の商品を表示させる Category メソッドの 2 つのアクション メソッドを作ったとしましょう。</p>
<p>http://servername/Home/Item/A0001</p>
<p>この URL は、次の Item アクション メソッドを呼び出します。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>public ActionResult Item( string id )</p>
</div>
<p>次に、「book」というカテゴリを指定する URL を次のようにします。</p>
<p>http://localohst/Home/Category/book</p>
<p>この URL は、次の Category アクション メソッドを呼び出します。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>public ActionResult Category( string id )</p>
</div>
<p>Item メソッドと Category メソッドは同じ「id」という名前を付ける必要があります。<br>
これは、同じ URL ルーティングのパターンによって、メソッドの引数に割り当てられるためです。</p>
<div style="margin:20px 0px; padding:10px 10px 3px 10px; background-color:#dedede">
<p>public ActionResult Category( string categoryName )</p>
</div>
<p>このように引数の名前を、「categoryName」に変えたい場合は次のように URL ルーティングを設定します。</p>
<ol>
<li>&quot;/Home/Category/{categoryName}&quot; </li><li>&quot;{controller}/{action}/{id}&quot; </li></ol>
<p>先に Category メソッドのルーティングを終えた後で、全体のアクション メソッドの処理を行うという順番に変更します。</p>
<p style="margin-top:20px"><a href="#top"><img src="17111-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>いかがだったでしょうか。URL ルーティングとアクション メソッドの関係、URL ルーティングのパターンの記述の仕方がご理解いただけたでしょうか。</p>
<p>URL ルーティングの記述をすることによって、ブラウザーで指定するアドレスが短くなるだけでなく、ASP.NET MVC では URL で指定した文字列とアクション メソッドがより密接なことが分かったと思います。パターンに設定した名前によって、メソッドの引数に値が割り当てられます。</p>
<ol>
<li>URL ルーティング (controller、action、引数) により分解 </li><li>コントローラーが呼び出される。 </li><li>指定したアクション メソッドが呼び出される。 </li><li>アクション メソッドに引数が渡される。 </li><li>処理をしてビューを作成する。 </li></ol>
<p><img src="17112-image.png" alt=""></p>
<p><strong>図 9. URL ルーティングとアクション メソッドの関係</strong></p>
<p>この順番を覚えておけば、簡単に URL ルーティングとアクション メソッドのパターンが掴めると思います。</p>
<p>次回は、今回のサンプル コードの中でも少し使った ViewData コレクションを解説しましょう。モデルを通さずにコントローラーからビューに値を引き渡す仕掛けになります。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/" target="_blank"><img src="-ff950935.asp_net_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="ASP.NET デベロッパーセンター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net/gg490787" target="_blank">
連載! ASP.NET MVC アプリケーション開発入門一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと ASP.NET の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net" target="_blank">
ASP.NET デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
</div>
</div>
