# Bluetooth Connection Sample
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- Visual Basic .NET
- .NET Micro Framework
## Topics
- Embedded
## Updated
- 09/09/2015
## Description

<h1>Introduction</h1>
<p>このサンプルはBluetoothシリアル変換ができるSBDBTを使ってPCからモーターを遠隔操作するサンプルです。</p>
<p>このサンプルを起動してBletooth接続してから１バイトのデータ送ると、その数値に応じてモーターの速度が変わります。</p>
<p>-----------------------------------------------------------------------------------------------</p>
<h1><span>Building the Sample</span></h1>
<p>このサンプルの実行には以下のソフトウェアが必要です。</p>
<ul>
<li>Visual Studio 2015 or Visual Studio Community 2015 </li><li>.NET Micro Framework SDK v4.3.1 </li><li>Netduino SDK v4.3.1 </li></ul>
<p>このサンプルは、以下のハードウェアとファームウェア上で動作します。</p>
<ul>
<li>Netduino Plus 2 (Framework v4.3.1) </li><li>MP4207 </li><li>FA130 Motor </li><li>SBDBT </li><li>BT-Micro 4 </li></ul>
<p>このサンプルを動作させるには、SBDBTとNetduinoの間を次のように配線します。</p>
<p>SBDBT---------------Netduino</p>
<p>1</p>
<p>2----------------------3.3V</p>
<p>3----------------------GND</p>
<p>4</p>
<p>5</p>
<p>6----SBDBT 9</p>
<p>7----------------------D0</p>
<p>8----------------------D1</p>
<p>9----SBDBT 6</p>
<p>10</p>
<p>このサンプルをVisual Studioで実行すると自動的にNetduinoに転送され実行が始まります。</p>
<p>本サンプルについての詳しい説明は、<a href="http://www.buildinsider.net/small/netduino/11">http://www.buildinsider.net/small/netduino/11</a>&nbsp;をご覧ください。</p>
<p><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>本サンプルコードをVisual Studio 2013でビルドするのであれば何も考慮はいりません。</p>
<p>もし、Visual Studio 2015でビルドするのであれば次のような対応が必要です。</p>
<p>C#でエラーが発生した場合は、MetaDataProcessor.exeが.NET Framework v3.5で作られているために発生するので、configでv4.0で&#31292;働するように切り替えれば動きます。</p>
<p>Visual Basicでエラーが発生した場合は、BuildInsiderの記事を参考にvbProjファイルを書き直してください。</p>
<p><em>&nbsp;</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
