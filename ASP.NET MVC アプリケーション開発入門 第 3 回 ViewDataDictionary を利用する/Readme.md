# ASP.NET MVC アプリケーション開発入門: 第 3 回 ViewDataDictionary を利用する
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
- 08/31/2011
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
 img,#lspAdd img{border:none;}#lspDontShow{margin:0;padding:0;position:absolute;top:111px;left:8px;float:left;}#lspDontShow a{color:#48819c;font-family:Tahoma;text-decoration:underline;}#lspDontShow a:active,#lspDontShow a:hover{cursor:pointer;}#cps{position:relative;z-index:1001;}#cpsPosCss{height:24px;}.Stoteaserhidden{display:none;height:0;}.internav{background-position:top
 right;background-repeat:no-repeat;float:left;font-family:'Segoe UI Semibold','Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif;font-size:14px;height:32px;margin:0 0 0 8px;max-width:936px;overflow:hidden;padding:0 37px 0 0;position:relative;white-space:nowrap;}.leftcap{height:32px;left:-29px;position:absolute;width:37px;}.internav
 a{float:left;margin:0;padding:6px 9px;white-space:nowrap;}.internav a:hover{height:20px;margin:1px 0;padding:6px 9px 4px 9px;}.internav a.active,.internav a.active:hover{background:url('../../images/common.png') 0 -43px no-repeat;height:20px;margin:1px 0;padding:5px
 9px;}.LocalNavigation{display:inline-block;font-size:12px;margin:2px 0 0 -17px;padding:0 0 1px 0;white-space:nowrap;width:996px;}.HeaderTabs{margin:0 0 0 25px;width:948px;}.LocalNavigation .TabOff{float:left;white-space:nowrap;}.LocalNavigation .TabOff a{float:left;margin-top:1px;padding:4px
 6px;cursor:pointer;}.LocalNavigation .TabOff a:hover{padding:5px 6px 3px 6px;}.LocalNavigation .TabOn{float:left;margin-top:1px;padding:4px 6px;white-space:nowrap;}.LocalNavigation .TabOn a,.LocalNavigation .TabOn a:hover,.LocalNavigation .TabOn a:visited{cursor:default;text-decoration:none;}.LocalNavBottom{display:none;}.cleartabstrip{clear:both;height:0;}div.ShareThis2{white-space:nowrap;display:block;position:relative;}div.ShareThis2
 a{display:inline-block;background:#fff;}div.ShareThis2 a span.Icon,div.ShareThis2 ul li a span span.Icon{display:inline-block;background-image:url('../../images/headlinesprites.png');background-repeat:no-repeat;width:16px;height:16px;}div.ShareThis2 a span.Label{color:#858585;font-size:85%;position:relative;bottom:4px;}div.ShareThis2
 ul{display:none;background:#fff;padding:5px;position:absolute;left:-9px;list-style:none;margin:0;padding:5px 10px 5px 10px;border:1px solid #ddd;}div.ShareThis2Up ul{bottom:25px;}div.ShareThis2Down ul{top:25px;}div.ShareThis2 ul li{position:relative;list-style:none;padding:3px
 3px 3px 3px;margin:0;}div.ShareThis2 ul li a span{display:inline-block;}div.ShareThis2 ul li a span span.Label{display:inline-block;font-size:90%;position:relative;bottom:3px;padding-left:1px;}div.ShareThis2 a span.Icon{background-position:-89px 0;}div.ShareThis2
 ul li a span span.ShareThisEmail{background-position:-241px 0;}div.ShareThis2 ul li a span span.ShareThisFacebook{background-position:-122px 0;}div.ShareThis2 ul li a span span.ShareThisTwitter{background-position:-138px 0;}div.ShareThis2 ul li a span span.ShareThisDigg{background-position:-154px
 0;}div.ShareThis2 ul li a span span.ShareThisTechnorati{background-position:-170px 0;}div.ShareThis2 ul li a span span.ShareThisDelicious{background-position:-186px 0;}div.ShareThis2 ul li a span span.ShareThisGoogle{background-position:-202px 0;}div.ShareThis2
 ul li a span span.ShareThisMessenger{background-position:-218px 0;}.SearchBox{background-color:#fff;border:solid 1px #346b94;float:left;margin:0 0 12px 0;width:314px;}.TextBoxSearch{border:none;color:#000;float:left;font-size:13px;font-style:normal;margin:0;padding:4px
 0 0 5px;vertical-align:top;width:232px;}.Bing{background:#fff url('../../images/common.png') 0 -20px no-repeat;display:inline-block;float:right;height:22px;overflow:hidden;text-align:right;width:47px;}.SearchButton{background:#fff url('../../images/common.png')
 -48px -19px no-repeat;display:inline-block;border-width:0;cursor:pointer;float:right;height:21px;margin:0;padding:0;text-align:right;vertical-align:top;width:21px;}#SuggestionContainer li{list-style:none outside none;}div.DivRatingsOnly{border:solid 0 red;margin-top:5px;margin-bottom:5px;}.ratingStar{font-size:0;width:16px;height:16px;margin:0;padding:0;cursor:pointer;display:block;background-repeat:no-repeat;}.filledRatingStar{background:url('/Areas/Sto/Content/Theming/Images/LibC.gif')
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
 div.Items .ShareThis2{float:right;position:relative;top:-4px;}div.HeadlineList a.Item .Description,div.HeadlineList a.Item span.Description:hover,div.HeadlineList a.Item span.Description:active{display:inline-block;color:#000;margin-bottom:10px;}.FooterLinks{padding:6px
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
 solid #aaa;border-bottom:1px solid #fff;bottom:2px;}html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,font,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td{border:0;font-weight:inherit;font-style:inherit;font-family:inherit;margin:0;outline:0;padding:0;}table{border-collapse:separate;border-spacing:0;}html{font-size:100.01%;}body{color:#333;font-family:'Segoe
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
 2px 10px 2px;}p.NoP{margin:0;}.Container p{margin:0;display:block;}div.NoBrandLogo A{background:transparent;color:#fff;height:auto;width:auto;}div.NoBrandLogo span{display:inline;}.RightAdRail2{background-color:#fafafa;}div.PaddedMainColumnContent{padding-left:5px;}h1,.title{margin:5px
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
 .h3,.fullwidth .h3,.MainColumn .h3,.maincolumn .h3,.MiddleColumn .h3,.middlecolumn .h3,.RightColumn .h3,.rightcolumn .h3,.ColumnFifty .h3,.columnfifty .h3{font-size:125%!important;height:26px;padding:5px 0 0 0;}.h3 .rssfeed,.h3 .opmlfeed{position:absolute;right:0;top:4px;}
 ﻿#BodyBackground{background:#ced5db url('../images/logos_and_bg.png') repeat-x 0 -100px;}.BrandLogo,.BrandLogo a,.BrandLogo a:link,.BrandLogo a:visited,.BrandLogo a:hover,.BrandLogo a:active,.GlobalBar,.PassportScarab,.PassportScarab a,.PassportScarab a:link,.PassportScarab
 a:visited,.PassportScarab a:hover,.PassportScarab a:active,.UserName,.UserName a,.UserName a:link,.UserName a:visited,.UserName a:hover,.UserName a:active,a.LocaleManagementFlyoutStaticLink,a:link.LocaleManagementFlyoutStaticLink,a:visited.LocaleManagementFlyoutStaticLink,a:hover.LocaleManagementFlyoutStaticLink,a:active.LocaleManagementFlyoutStaticLink{color:#313131;}.NetworkLogo
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
<p>更新日: 2011 年 1 月 14 日</p>
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
<p><a href="#02">2. ViewData プロパティはどこに使われている?</a></p>
<p><a href="#03">3. メッセージを変えてみる</a></p>
<p><a href="#04">4. ViewData を使わずに Model だけで書くと</a></p>
</div>
<div style="float:right; width:250px">
<p><a href="#05">5. カテゴリ名を表示させる</a></p>
<p><a href="#06">6. エラー メッセージを表示させる</a></p>
<p><a href="#07">7. ViewData プロパティの注意点</a></p>
<p><a href="#08">8. おわりに</a></p>
</div>
</div>
<div style="clear:both"></div>
<hr>
<h2 id="01">1. はじめに</h2>
<p>連載の第 3 回目は、コントローラー (Controller) からビュー (View) に直接データを渡すための ViewData プロパティ (ViewDataDictionary クラス) についてお話していきましょう。</p>
<p>MVC パターンでは、各コンポーネントの独立性を保つためにコントローラーからビューにデータを渡す場合は、モデルを使うことになっています。コントローラーでモデルに値を設定し、ビューがモデルを参照して画面に表示する手順になります。</p>
<p>このパターンを使うと、厳密にコンポーネントの独立性が高まる利点とともに、実際にプログラミングをするときに若干コードが冗長になってしまう欠点をあわせ持ってしまいます。</p>
<p>この弱点を補うための仕組みが ASP.NET MVC では、ViewData プロパティとして組み込まれています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17166-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="02">2. ViewData プロパティはどこに使われている?</h2>
<p>では、早速 ViewData プロパティがどこに使われているのかを調べていきましょう。</p>
<p>実は、すでに知っていらっしゃる読者もおられると思いますが、Visual Studio 2010 で ASP.NET MVC 2 Web アプリケーションを作成すると、トップページ (Home/Index.aspx) には ViewData プロパティが使われています。</p>
<p>ASP.NET MVC 2 アプリケーションを作成して、ソリューション エクスプローラーで、Views/Home/Index.aspx というファイルを開いてみてください。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">csharp</span>
<pre class="hidden"><code class="xml">&lt;%@ Page Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData[&quot;Message&quot;] %&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="csharp"><code class="xml">&lt;%@ Page Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData[&quot;Message&quot;] %&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">&lt;%@ Page Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;indexTitle&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;indexContent&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData(&quot;Message&quot;) %&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">&lt;%@ Page Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;indexTitle&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;indexContent&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData(&quot;Message&quot;) %&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
</div>
</div>
</div>
</div>
<p>ビューの中で、ViewData[&quot;Message&quot;] (VB の場合は、ViewData(&quot;Message&quot;)) と記述されています。これが、ViewData プロパティを使って、コレクションから「Message」という名前で値を取り出しているところです。</p>
<p>同じように、ソリューション エクスプローラーで、Controllers/HomeController.cs (VB の場合は、HomeController.vb) を開いてみてください。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
{
    ViewData[&quot;Message&quot;] = &quot;ASP.NET MVC へようこそ&quot;;

    return View();
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;ASP.NET&nbsp;MVC&nbsp;へようこそ&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;ASP.NET MVC へようこそ&quot;

    Return View()
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;ASP.NET MVC へようこそ&quot;

    Return View()
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>Index メソッドで、ViewData プロパティに「Message」という名前で値を代入していることがわかります。</p>
<p>これを実行すると、以下の図になります。</p>
<p><img src="17167-image.png" alt=""></p>
<p><strong>図 1. 実行結果</strong></p>
<p>結果は見てわかるとおりです。「ASP.NET MVC へようこそ」というメッセージが出てきました。</p>
<p>ViewData プロパティの使い方は非常に簡単で、ViewData[ 名前 ] (VBasic では ViewData(名前)) という形式で、値を保存しておきます。コントローラーに値を入れておいて、ビューで同じ名前で値を取り出すという使い方になります。</p>
<p>もう少し詳しく MSDN のヘルプを使って調べてみましょう。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/system.web.mvc.viewdatadictionary" target="_blank">ViewDataDictionary クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/system.web.mvc.viewpage.viewdata" target="_blank">ViewPage.ViewData プロパティ</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/system.web.mvc.controllerbase.viewdata" target="_blank">ControllerBase.ViewData プロパティ</a>
</li></ul>
<p>コントローラーの ViewData プロパティに値を入れておくと、ビューの ViewData プロパティに値がコピーされて、ビューから参照できるという仕組みになります。</p>
<p><img src="17168-image.png" alt=""></p>
<p><strong>図 2. 値のコピーの図</strong></p>
<p>ASP.NET アプリケーションを作る方法として、もうひとつ Web フォーム ベースで作るアプリケーションがあります。Web フォーム ベースのアプリケーションでは、ビューと動作のコード (コード ビハイド) が同じクラスに属しているので、クラスにプロパティを作ることによってコードからビューへの値の受け渡しが簡単にできます。</p>
<p>ASP.NET MVC アプリケーションでは、ビュー (View) とモデル (Model) が別のクラスになるために、Web フォーム ベースのようにはいきませんが、上記のように ViewData プロパティを使うことにより、フォーム ベースと同じように値を渡すことが可能になっています。</p>
<p style="margin-top:20px"><a href="#top"><img src="17169-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="03">3. メッセージを変えてみる</h2>
<p>では、Index.aspx で表示するメッセージを変えてみましょう。</p>
<p>定番の「Hello ASP.NET MVC 2 World.」を表示させる場合は、次のようにコントローラーを書き換えます。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
{
    ViewData[&quot;Message&quot;] = &quot;Hello ASP.NET MVC 2 World.&quot;;

    return View();
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Hello&nbsp;ASP.NET&nbsp;MVC&nbsp;2&nbsp;World.&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;Hello ASP.NET MVC 2 World.&quot;

    Return View()
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;Hello ASP.NET MVC 2 World.&quot;

    Return View()
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>ビューのソース コードはそのままです。</p>
<p>これを Visual Studio 2010 で実行すると次の図になります。</p>
<p><img src="17170-image.png" alt=""></p>
<p><strong>図 3. 実行結果</strong></p>
<p>これも予想通り、ViewData プロパティの値がうまく引き渡されていますね。</p>
<p>試しに Index.aspx の VIewData プロパティに指定している名前を「Message」から「MessageMiss」に変えてみましょう。名前が見つからないときには ViewData プロパティはどのような動作をするのでしょうか?</p>
<p><img src="17171-image.png" alt=""></p>
<p><strong>図 4. 実行結果 (Miss)</strong></p>
<p>結果は、空白になります。「MessageMiss」のようにコントローラーで設定されていない名前をビューで指定してしまった時には、ViewData プロパティは null (VB の場合は Nothing) を返します。ここでは、「&lt;%: ... %&gt;」の表記の中で、自動で空白に変換されています。</p>
<p>このように、ViewData プロパティを使うと名前を間違ったときに、ミスが起こりやすいので注意してください。</p>
<p style="margin-top:20px"><a href="#top"><img src="17172-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="04">4. ViewData を使わずに Model だけで書くと</h2>
<p>今度は、あえて ViewData プロパティを使わずに、モデルを使ってメッセージを引き渡してみましょう。</p>
<p>まずは、HomeModels.cs (VB の場合は HomeModel.vb) を追加します。</p>
<p>モデルを追加する場合は、ソリューション エクスプローラーで Models フォルダーを右クリックして、「追加」&rarr;「クラス」を選択してください。クラス名は「HomeModels」にします。</p>
<p><img src="17173-image.png" alt=""></p>
<p><strong>図 5. モデルの追加</strong></p>
<p>HomeModels クラスは以下のように Message プロパティだけを持つ簡単なクラスにします。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace MvcApplication1.Models
{
    public class MessageModels
    {
        public string Message { get; set; }
    }
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MvcApplication1.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MessageModels&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Public Class HomeModels
    Public Property Message As String
End Class</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Public Class HomeModels
    Public Property Message As String
End Class</code></pre>
</div>
</div>
</div>
</div>
<p>次のコントローラーで、HomeModel クラスの Message プロパティを使った方法を追記します。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
{
    ViewData[&quot;Message&quot;] = &quot;Hello ASP.NET MVC 2 World.&quot;;

    Models.HomeModels model = new Models.HomeModels();
    model.Message = &quot;これはモデルを使ったメッセージです&quot;;

    return View(model);
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Hello&nbsp;ASP.NET&nbsp;MVC&nbsp;2&nbsp;World.&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Models.HomeModels&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Models.HomeModels();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;model.Message&nbsp;=&nbsp;<span class="cs__string">&quot;これはモデルを使ったメッセージです&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;Hello ASP.NET MVC 2 World.&quot;

    Dim model As New HomeModels
    model.Message = &quot;これはモデルを使ったメッセージです&quot;

    Return View(model)
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function Index() As ActionResult
    ViewData(&quot;Message&quot;) = &quot;Hello ASP.NET MVC 2 World.&quot;

    Dim model As New HomeModels
    model.Message = &quot;これはモデルを使ったメッセージです&quot;

    Return View(model)
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>HomeModels オブジェクトを作成して、Message プロパティにメッセージを代入しておきます。<br>
モデルを使うために、アクション メソッドの戻り値の View クラスには model を渡しています。</p>
<p>最後に、ビューを書き換えて、HomeModels クラスの Message プロパティの内容を表示させます。<br>
Views/Home/Index.aspx を削除して、ビューを追加してもよいですし、元の Index.aspx を手動で修正してもよいでしょう。</p>
<p><br>
ビューを追加する場合は、「厳密に型指定されたビューを作成する」にチェックを入れて、ビュー データ クラスで「MvcApplication1.HomeModels」を選択してください。</p>
<p><img src="17174-image.png" alt=""></p>
<p><strong>図 6. ビューの追加</strong></p>
<p>ビューを追加する場合は、「厳密に型指定されたビューを作成する」にチェックを入れて、ビュー データ クラスで「MvcApplication1.HomeModels」を選択してください。</p>
<p>コントローラーでビューを作成する処理 (return View(model)) の部分で、ビューに引き渡すモデルの型を指定します。ここで指定されたモデルは、ビューの先頭部分にある
<br>
Inherits=&quot;System.Web.Mvc.ViewPage&lt;MvcApplication1.Models.HomeModels&gt;&quot; <br>
(VB の場合は、Inherits=&quot;System.Web.Mvc.ViewPage(Of <br>
MvcApplication1.HomeModels)&quot;)<br>
に記述されます。</p>
<p>これは、ビューで使う Model プロパティの型が「MvcApplication1.Models.HomeModels」であることを示しています。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;%@ Page Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;MvcApplication1.Models.HomeModels&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData[&quot;Message&quot;] %&gt;&lt;/h2&gt;
    &lt;h2&gt;&lt;%: Model.Message %&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;MvcApplication1.Models.HomeModels&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ホーム&nbsp;ページ&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;%&gt;&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;&lt;%:&nbsp;Model.Message&nbsp;%&gt;&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASP.NET&nbsp;MVC&nbsp;の詳細については、&lt;a&nbsp;href=<span class="cs__string">&quot;http://asp.net/mvc&quot;</span>&nbsp;title=<span class="cs__string">&quot;ASP.NET&nbsp;MVC&nbsp;Website&quot;</span>&gt;http:<span class="cs__com">//asp.net/mvc&lt;/a&gt;&nbsp;を参照してください。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="xml">&lt;%@ Page Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of MvcApplication1.HomeModels)&quot; %&gt;

&lt;asp:Content ID=&quot;indexTitle&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;indexContent&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData(&quot;Message&quot;) %&gt;&lt;/h2&gt;
    &lt;h2&gt;&lt;%: Model.Message%&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="xml">&lt;%@ Page Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of MvcApplication1.HomeModels)&quot; %&gt;

&lt;asp:Content ID=&quot;indexTitle&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
    ホーム ページ
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;indexContent&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;
    &lt;h2&gt;&lt;%: ViewData(&quot;Message&quot;) %&gt;&lt;/h2&gt;
    &lt;h2&gt;&lt;%: Model.Message%&gt;&lt;/h2&gt;
    &lt;p&gt;
        ASP.NET MVC の詳細については、&lt;a href=&quot;http://asp.net/mvc&quot; title=&quot;ASP.NET MVC Website&quot;&gt;http://asp.net/mvc&lt;/a&gt; を参照してください。
    &lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
</div>
</div>
</div>
</div>
<p>「&lt;%: Model.Message %&gt;」の行を追加して、ViewData プロパティとの表示と並べておきます。</p>
<p>これを実行した結果が次の図になります。</p>
<p><img src="17175-image.png" alt=""></p>
<p><strong>図 7. 実行結果</strong></p>
<p>このようにビューにメッセージを表示するたびに、モデルを変更するとだんだんとモデル自体が肥大化してしまいます。例えば、同じモデルを複数のビューで扱う場合、他のビューで使われないメッセージがプロパティとしてモデルに加わり見通しが悪くなります。</p>
<p>ビュー特有のメッセージなどは ViewData プロパティを通して表示し、ビューとは別の独立性の高いデータをモデルとするとコードの保守性がよくなります。</p>
<p style="margin-top:20px"><a href="#top"><img src="17176-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="05">5. カテゴリ名を表示させる</h2>
<p>ViewData プロパティの利点を更に紹介していきます。</p>
<p>モデルに Entity Data Model を直接利用している場合や自作のモデルに手を加えたくない場合にも ViewData プロパティは有効に働きます。</p>
<p>例えば、ショッピング サイトで、指定したカテゴリにある商品の一覧を表示させてみましょう。</p>
<p>まずは、ソリューション エクスプローラーを使って、モデルのクラスを作ります。<br>
ソリューション エクスプローラーの「Models」フォルダーを右クリックし、「追加」&rarr;「新しい項目」を選択して、「新しい項目の追加」ダイアログを開きます。</p>
<p>このダイアログで、「インストールされたテンプレート」から「データ」を選択して、「ADO.NET Entity Data Model」を追加します。</p>
<p>ここで利用するデータベースは、日経 BP 社より<a href="http://ec.nikkeibp.co.jp/nsp/dl/09438/index.shtml" target="_blank">サンプル プログラム</a>に入っています。サンプルをダウンロードして mvcdb.sql のスクリプトを使って、あらかじめ SQL Server 上にデータベースを作成しておいてください。</p>
<p><img src="17177-image.png" alt=""></p>
<p><strong>図 8. 新しい項目の追加ダイアログ ボックス</strong></p>
<p>ここでは「Entity Data Model ウィザード」を使って、データベースから直接クラスを生成しました。</p>
<p><img src="17178-image.png" alt=""></p>
<p><strong>図 9. Entity Data Model ウィザード</strong></p>
<p>正常に完了すると、モデルで使えるクラスが自動的に作られます。ここで一度ビルドをしておいてください。このビルドは、あとでコントローラーやビューでモデル参照を作るときに必要なものです。</p>
<p>ビルドが終わったら、Controllers/HomeController.cs (VB の場合は HomeController.vb) を開き Category アクション メソッドを作成します。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Category( int id)
{
    mvcdbEntities ent = new mvcdbEntities();
    // 指定したカテゴリ内の商品を取得
    var model = from t in ent.TProduct
                where t.cateid == id
                select t;
    // カテゴリの名称を取得
    var name = (from c in ent.TCategory
                where c.id == id
                select c.name).Single();
    // ViewData に保存
    ViewData[&quot;CategoryName&quot;] = name;

    return View(model);
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Category(&nbsp;<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;指定したカテゴリ内の商品を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;from&nbsp;t&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TProduct&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;t.cateid&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;t;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;カテゴリの名称を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;(from&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TCategory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;c.id&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;c.name).Single();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ViewData&nbsp;に保存</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;CategoryName&quot;</span>]&nbsp;=&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function Category(ByVal id As Integer) As ActionResult
    Dim ent As New mvcdbEntities
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname

    Return View(model)
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function Category(ByVal id As Integer) As ActionResult
    Dim ent As New mvcdbEntities
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname

    Return View(model)
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>ビューに引き渡す model には、データベースから検索した商品の一覧を設定しています。<br>
追加の情報として、カテゴリの名称を ViewData プロパティを使ってビューに表示させることにします。</p>
<p>最後に、商品一覧を表示させる Views/Home/Category.aspx を作成します。<br>
ビューの追加ダイアログ ボックスで、ビュー コンテンツから「List」を選択すると、一覧の表示が簡単にできます。</p>
<p><img src="17179-image.png" alt=""></p>
<p><strong>図 10. ビューの追加</strong></p>
<p>ビューのタイトルには、カテゴリの名称を「&lt;%: ViewData[&quot;CategoryName&quot;] %&gt;」で表示できるようにしておきます。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">&lt;%@ Page Title=&quot;&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;MvcApplication1.Models.TProduct&gt;&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Category
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData[&quot;CategoryName&quot;] %&gt;&lt;/h2&gt;

    &lt;table&gt;
        &lt;tr&gt;
            &lt;th&gt;&lt;/th&gt;
            &lt;th&gt;
                id
            &lt;/th&gt;
            &lt;th&gt;
                name
            &lt;/th&gt;
            &lt;th&gt;
                price
            &lt;/th&gt;
            &lt;th&gt;
                cateid
            &lt;/th&gt;
        &lt;/tr&gt;

    &lt;% foreach (var item in Model) { %&gt;
    
        &lt;tr&gt;
            &lt;td&gt;
                &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, new { id=item.id }) %&gt; |
                &lt;%: Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, new { id=item.id })%&gt; |
                &lt;%: Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, new { id=item.id })%&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.id %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.name %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.price %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.cateid %&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
    
    &lt;% } %&gt;

    &lt;/table&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;) %&gt;
    &lt;/p&gt;

&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;MvcApplication1.Models.TProduct&gt;&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Category&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;CategoryName&quot;</span>]&nbsp;%&gt;&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;price&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cateid&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;Model)&nbsp;{&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Edit&quot;</span>,&nbsp;<span class="cs__string">&quot;Edit&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id=item.id&nbsp;})&nbsp;%&gt;&nbsp;|&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Details&quot;</span>,&nbsp;<span class="cs__string">&quot;Details&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id=item.id&nbsp;})%&gt;&nbsp;|&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Delete&quot;</span>,&nbsp;<span class="cs__string">&quot;Delete&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id=item.id&nbsp;})%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;item.id&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;item.name&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;item.price&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;item.cateid&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;}&nbsp;%&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%:&nbsp;Html.ActionLink(<span class="cs__string">&quot;Create&nbsp;New&quot;</span>,&nbsp;<span class="cs__string">&quot;Create&quot;</span>)&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.TProduct))&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Category
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData(&quot;CategoryName&quot;) %&gt;&lt;/h2&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;)%&gt;
    &lt;/p&gt;
    
    &lt;table&gt;
        &lt;tr&gt;
            &lt;th&gt;&lt;/th&gt;
            &lt;th&gt;
                id
            &lt;/th&gt;
            &lt;th&gt;
                name
            &lt;/th&gt;
            &lt;th&gt;
                price
            &lt;/th&gt;
            &lt;th&gt;
                cateid
            &lt;/th&gt;
        &lt;/tr&gt;

    &lt;% For Each item In Model%&gt;
    
        &lt;tr&gt;
            &lt;td&gt;
                &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, New With {.id = item.id})%&gt; |
                &lt;%: Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, New With {.id = item.id})%&gt; |
                &lt;%: Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, New With {.id = item.id})%&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.id %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.name %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.price %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.cateid %&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
    
    &lt;% Next%&gt;

    &lt;/table&gt;

&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.TProduct))&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Category
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData(&quot;CategoryName&quot;) %&gt;&lt;/h2&gt;

    &lt;p&gt;
        &lt;%: Html.ActionLink(&quot;Create New&quot;, &quot;Create&quot;)%&gt;
    &lt;/p&gt;
    
    &lt;table&gt;
        &lt;tr&gt;
            &lt;th&gt;&lt;/th&gt;
            &lt;th&gt;
                id
            &lt;/th&gt;
            &lt;th&gt;
                name
            &lt;/th&gt;
            &lt;th&gt;
                price
            &lt;/th&gt;
            &lt;th&gt;
                cateid
            &lt;/th&gt;
        &lt;/tr&gt;

    &lt;% For Each item In Model%&gt;
    
        &lt;tr&gt;
            &lt;td&gt;
                &lt;%: Html.ActionLink(&quot;Edit&quot;, &quot;Edit&quot;, New With {.id = item.id})%&gt; |
                &lt;%: Html.ActionLink(&quot;Details&quot;, &quot;Details&quot;, New With {.id = item.id})%&gt; |
                &lt;%: Html.ActionLink(&quot;Delete&quot;, &quot;Delete&quot;, New With {.id = item.id})%&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.id %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.name %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.price %&gt;
            &lt;/td&gt;
            &lt;td&gt;
                &lt;%: item.cateid %&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
    
    &lt;% Next%&gt;

    &lt;/table&gt;

&lt;/asp:Content&gt;</code></pre>
</div>
</div>
</div>
</div>
<p>カテゴリ ID を指定して実行すると、次の図のようになります。<br>
アドレスは、http://localhost/Home/Category/1 のように指定します。</p>
<p><img src="17180-image.png" alt=""></p>
<p><strong>図 11. 実行結果</strong></p>
<p>商品の一覧とカテゴリの名称を同時に表示させたい場合、本来ならば新しいモデルを作成して、検索した商品の結果 (TProduct オブジェクトのリスト) とカテゴリの名称をビューに引き渡すところです。しかし、カテゴリの名称のような追加情報であれば、ViewData プロパティを使ったほうがコードが見やすくなります。</p>
<p style="margin-top:20px"><a href="#top"><img src="17181-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="06">6. エラー メッセージを表示させる</h2>
<p>もうひとつ、ViewData プロパティの使いどころを解説しておきます。</p>
<p>前回の記事で、商品の詳細ページを表示するときに商品 ID が指定されなかったときは、Redirect メソッドを使って指定のエラー メッセージを表示させていました。しかし、間違った商品番号などを指定した時には、エラー メッセージを変えたほうが利用者にとって便利ですよね。</p>
<p>今回は、カテゴリ内の商品を表示するときに、カテゴリ ID を指定しなかったり、間違えていたりしたときのメッセージを ViewData プロパティを使って変えていきましょう。</p>
<p>先ほど作成した、Category アクション メソッドを以下のように書き換えます。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Category(int id = -1)
{
    if (id == -1 )
    {
        // カテゴリを指定しなかった場合
        ViewData[&quot;ErrorMessage&quot;] = &quot;カテゴリIDを指定してください&quot;;
        return View(&quot;Error&quot;);
    }
    mvcdbEntities ent = new mvcdbEntities();
     // カテゴリの名称を取得
    var count = (from c in ent.TCategory
                 where c.id == id
                 select c.name).Count();
    if ( count == 0 ) 
    {
        // カテゴリIDが範囲を超えている場合
        ViewData[&quot;ErrorMessage&quot;] =
            string.Format(&quot;カテゴリID({0})が正しくありません&quot;, id);
        return View(&quot;Error&quot;);
    }
    // 指定したカテゴリ内の商品を取得
    var model = from t in ent.TProduct
                where t.cateid == id
                select t;
    var name = (from c in ent.TCategory
                 where c.id == id
                 select c.name).Single();
    // ViewData に保存
    ViewData[&quot;CategoryName&quot;] = name;

    return View(model);
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Category(<span class="cs__keyword">int</span>&nbsp;id&nbsp;=&nbsp;-<span class="cs__number">1</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;==&nbsp;-<span class="cs__number">1</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;カテゴリを指定しなかった場合</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;ErrorMessage&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;カテゴリIDを指定してください&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;Error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;カテゴリの名称を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;count&nbsp;=&nbsp;(from&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TCategory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;c.id&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;c.name).Count();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(&nbsp;count&nbsp;==&nbsp;<span class="cs__number">0</span>&nbsp;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;カテゴリIDが範囲を超えている場合</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;ErrorMessage&quot;</span>]&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;カテゴリID({0})が正しくありません&quot;</span>,&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(<span class="cs__string">&quot;Error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;指定したカテゴリ内の商品を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;from&nbsp;t&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TProduct&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;t.cateid&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;t;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;(from&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TCategory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;c.id&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;c.name).Single();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ViewData&nbsp;に保存</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;CategoryName&quot;</span>]&nbsp;=&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function Category(Optional ByVal id As Integer = -1) As ActionResult
    If id = -1 Then
        ' カテゴリを指定しなかった場合
        ViewData(&quot;ErrorMessage&quot;) = &quot;カテゴリIDを指定してください&quot;
        Return View(&quot;Error&quot;)
    End If
    Dim ent As New mvcdbEntities
    ' カテゴリ名称を取得
    Dim count = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Count
    If count = 0 Then
        ' カテゴリIDが範囲を超えている場合
        ViewData(&quot;ErrorMessage&quot;) =
            String.Format(&quot;カテゴリID({0})が正しくありません&quot;, id)
        Return View(&quot;Error&quot;)
    End If
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname

    Return View(model)
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function Category(Optional ByVal id As Integer = -1) As ActionResult
    If id = -1 Then
        ' カテゴリを指定しなかった場合
        ViewData(&quot;ErrorMessage&quot;) = &quot;カテゴリIDを指定してください&quot;
        Return View(&quot;Error&quot;)
    End If
    Dim ent As New mvcdbEntities
    ' カテゴリ名称を取得
    Dim count = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Count
    If count = 0 Then
        ' カテゴリIDが範囲を超えている場合
        ViewData(&quot;ErrorMessage&quot;) =
            String.Format(&quot;カテゴリID({0})が正しくありません&quot;, id)
        Return View(&quot;Error&quot;)
    End If
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname

    Return View(model)
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>このアクション メソッドでは、通常の表示のほかに、以下のエラーをチェックします。</p>
<ul>
<li>カテゴリ ID が指定されなかった場合、<br>
http://localhost/Home/Category </li><li>カテゴリ ID が範囲を超えている場合<br>
http://localhost/Home/Category/9999 </li></ul>
<p>Category アクション メソッドでは、カテゴリ ID が指定されなかったときは、id の値が「-1」になります。データベースでは、カテゴリ ID は、0 以上としていますので、これでカテゴリ ID が指定されなかったときの判別がつきます。</p>
<p>カテゴリを指定しなかった場合と、カテゴリ ID が範囲を超えていた場合 (データベースにマッチする ID が見つからなかった場合) は、ViewData プロパティにエラー メッセージを設定して、エラー ページを表示させています。</p>
<p>エラー ページを表示する場合は、View(&quot;Error&quot;) のように直接ページ名を指定できます。</p>
<p>エラー ページは、Views/Home/Error.aspx として作成しておきます。</p>
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

    &lt;p&gt;&lt;%: ViewData[&quot;ErrorMessage&quot;] %&gt;&lt;/p&gt;
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
&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;ErrorMessage&quot;</span>]&nbsp;%&gt;&lt;/p&gt;&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Error
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Error&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;ErrorMessage&quot;) %&gt;&lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	Error
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;Error&lt;/h2&gt;

    &lt;p&gt;&lt;%: ViewData(&quot;ErrorMessage&quot;) %&gt;&lt;/p&gt;
&lt;/asp:Content&gt;</code></pre>
</div>
</div>
</div>
</div>
<p>エラー ページのビューで、コントローラーで設定した ViewData[&quot;ErrorMessage&quot;] を表示させます。</p>
<p>これを実行した結果が次の図になります。</p>
<p><img src="17182-image.png" alt=""></p>
<p><img src="17183-image.png" alt=""></p>
<p><strong>図 12. 実行結果</strong></p>
<p>このように、ひとつの Category アクション メソッドから、通常のビュー (Category.aspx) と、エラー用のビュー (Error.aspx) を切り分けて表示させることができます。</p>
<p>ViewData プロパティを使うことによって、不必要なモデルの拡張を防ぐことができます。</p>
<p style="margin-top:20px"><a href="#top"><img src="17184-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="07">7. ViewData プロパティの注意点</h2>
<p>ViewData プロパティを使うとコントローラーからビューに、手軽にデータを渡すことができます。その反面で ViewData プロパティを使いすぎてしまうと、コントローラーとビューが密接にかかわり過ぎて、本来の MVC (Model-View-Controller) の利点が失われてしまいます。</p>
<p>次の例では、本来はモデルを使ってビューを表示するところを、あえて ViewData プロパティを使っています。ビューのコードが、かえって複雑になってしまうことが分かります。</p>
<p><strong>＜ソース (C#)＞</strong></p>
<div class="CodeHighlighter">
<div style="clear:both">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">// ViewData だけを使って渡す例
public ActionResult CategoryBad(int id)
{
    mvcdbEntities ent = new mvcdbEntities();
    // 指定したカテゴリ内の商品を取得
    var model = from t in ent.TProduct
                where t.cateid == id
                select t;
    // カテゴリの名称を取得
    var name = (from c in ent.TCategory
                where c.id == id
                select c.name).Single();
    // ViewData に保存
    ViewData[&quot;CategoryName&quot;] = name;
    ViewData[&quot;TProduct&quot;] = model;

    return View();
}</pre>
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;ViewData&nbsp;だけを使って渡す例</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;CategoryBad(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mvcdbEntities&nbsp;ent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;mvcdbEntities();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;指定したカテゴリ内の商品を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;from&nbsp;t&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TProduct&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;t.cateid&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;t;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;カテゴリの名称を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;(from&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;ent.TCategory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;c.id&nbsp;==&nbsp;id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;c.name).Single();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ViewData&nbsp;に保存</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;CategoryName&quot;</span>]&nbsp;=&nbsp;name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;TProduct&quot;</span>]&nbsp;=&nbsp;model;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
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
<pre class="hidden"><code class="visual basic">Function CategoryBad(ByVal id As Integer) As ActionResult
    Dim ent As New mvcdbEntities
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname
    ViewData(&quot;TProduct&quot;) = model

    Return View()
End Function</code></pre>
<pre id="codePreview" class="vb"><code class="visual basic">Function CategoryBad(ByVal id As Integer) As ActionResult
    Dim ent As New mvcdbEntities
    ' 指定したカテゴリ内の商品を取得
    Dim model = From t In ent.TProduct
                Where t.cateid = id
                Select t
    ' カテゴリ名称を取得
    Dim cname = (From c In ent.TCategory
                Where c.id = id
                Select c.name).Single
    ' ViewData に保存
    ViewData(&quot;CategoryName&quot;) = cname
    ViewData(&quot;TProduct&quot;) = model

    Return View()
End Function</code></pre>
</div>
</div>
</div>
</div>
<p>ViewData プロパティだけを使ってビューを作成します。</p>
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
	CategoryBad
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData[&quot;CategoryName&quot;] %&gt;&lt;/h2&gt;

    &lt;table&gt;
        &lt;tr&gt;
			&lt;th&gt;id&lt;/th&gt;
            &lt;th&gt;name&lt;/th&gt;
            &lt;th&gt;price&lt;/th&gt;
            &lt;th&gt;cateid&lt;/th&gt;
        &lt;/tr&gt;
    &lt;%
        var model = ViewData[&quot;TProduct&quot;] as IEnumerable&lt;MvcApplication1.Models.TProduct&gt;;
        foreach ( var item in model ) {
         %&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;%: item.id %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.name %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.price %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.cateid %&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;% } %&gt;
    &lt;/table&gt;

&lt;/asp:Content&gt;</pre>
<pre id="codePreview" class="csharp">&lt;%@&nbsp;Page&nbsp;Title=<span class="cs__string">&quot;&quot;</span>&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=<span class="cs__string">&quot;~/Views/Shared/Site.Master&quot;</span>&nbsp;Inherits=<span class="cs__string">&quot;System.Web.Mvc.ViewPage&lt;dynamic&gt;&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content1&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;TitleContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CategoryBad&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
&lt;asp:Content&nbsp;ID=<span class="cs__string">&quot;Content2&quot;</span>&nbsp;ContentPlaceHolderID=<span class="cs__string">&quot;MainContent&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h2&gt;&lt;%:&nbsp;ViewData[<span class="cs__string">&quot;CategoryName&quot;</span>]&nbsp;%&gt;&lt;/h2&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;id&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;name&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;price&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;cateid&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;ViewData[<span class="cs__string">&quot;TProduct&quot;</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;IEnumerable&lt;MvcApplication1.Models.TProduct&gt;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(&nbsp;var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;model&nbsp;)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;%:&nbsp;item.id&nbsp;%&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;%:&nbsp;item.name&nbsp;%&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;%:&nbsp;item.price&nbsp;%&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&lt;%:&nbsp;item.cateid&nbsp;%&gt;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%&nbsp;}&nbsp;%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;
&lt;/asp:Content&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
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
	CategoryBad
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData(&quot;CategoryName&quot;)%&gt;&lt;/h2&gt;

    &lt;table&gt;
        &lt;tr&gt;
			&lt;th&gt;id&lt;/th&gt;
            &lt;th&gt;name&lt;/th&gt;
            &lt;th&gt;price&lt;/th&gt;
            &lt;th&gt;cateid&lt;/th&gt;
        &lt;/tr&gt;
    &lt;%
        For Each item In ViewData(&quot;TProduct&quot;)
         %&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;%: item.id %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.name %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.price %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.cateid %&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;% Next%&gt;
    &lt;/table&gt;

&lt;/asp:Content&gt;</code></pre>
<pre id="codePreview" class="vb"><code class="xml">&lt;%@ Page Title=&quot;&quot; Language=&quot;VB&quot; MasterPageFile=&quot;~/Views/Shared/Site.Master&quot; Inherits=&quot;System.Web.Mvc.ViewPage&quot; %&gt;

&lt;asp:Content ID=&quot;Content1&quot; ContentPlaceHolderID=&quot;TitleContent&quot; runat=&quot;server&quot;&gt;
	CategoryBad
&lt;/asp:Content&gt;

&lt;asp:Content ID=&quot;Content2&quot; ContentPlaceHolderID=&quot;MainContent&quot; runat=&quot;server&quot;&gt;

    &lt;h2&gt;&lt;%: ViewData(&quot;CategoryName&quot;)%&gt;&lt;/h2&gt;

    &lt;table&gt;
        &lt;tr&gt;
			&lt;th&gt;id&lt;/th&gt;
            &lt;th&gt;name&lt;/th&gt;
            &lt;th&gt;price&lt;/th&gt;
            &lt;th&gt;cateid&lt;/th&gt;
        &lt;/tr&gt;
    &lt;%
        For Each item In ViewData(&quot;TProduct&quot;)
         %&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;%: item.id %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.name %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.price %&gt;&lt;/td&gt;
            &lt;td&gt;&lt;%: item.cateid %&gt;&lt;/td&gt;
        &lt;/tr&gt;
        &lt;% Next%&gt;
    &lt;/table&gt;

&lt;/asp:Content&gt;</code></pre>
</div>
</div>
</div>
</div>
<p>次の図が実行結果になります。</p>
<p><img src="17185-image.png" alt=""></p>
<p><strong>図 13. 実行結果</strong></p>
<p>このような使い方でも、モデルを使った場合と同じ画面が作れはしますが、それぞれのコンポーネントの独立性は低くなってしまいます。データの受け渡しのために ViewData コレクションでの名前 (CategoryName、TProduct) を統一する必要もあり、ビュー側では ViewData から指定の型へのキャストが発生しています。この程度の数ならば ViewData プロパティでも可能ですが、実際にはもっと多くの連携が発生してしまうでしょう。</p>
<p>ViewData プロパティを使う場面は、追加の情報をビューに表示させたいときや、エラー メッセージを別のビューに表示するときなどに限っておくとよいでしょう。</p>
<p style="margin-top:20px"><a href="#top"><img src="17186-image.png" alt="" style="border:0"> ページのトップへ</a></p>
<hr>
<h2 id="08">8. おわりに</h2>
<p>いかがだったでしょうか。</p>
<p>ViewData プロパティを使うと、手軽にコントローラーからビューに値を渡せます、しかし、使いすぎると MVC パターンのよいところが失われてしまいます。もろ刃の剣であることがご理解頂けたでしょうか。</p>
<p><img src="17187-image.png" alt=""></p>
<p><strong>図 14. 使いどころの図</strong></p>
<p>使いどころによってはコードを整理した形で作成することができます。エラー メッセージなどの簡単な部分は、ViewData プロパティを使って表示し、商品一覧などの主要な部分は MVC パターンのモデル (Model) を使うといった、使い分けをするとすっきりとしたコードになります。</p>
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
