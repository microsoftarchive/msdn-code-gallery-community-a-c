# Bluetooth Connection Sample (PC)
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- Visual Basic .NET
- universal windows app
## Topics
- Bluetooth
- Netduino
## Updated
- 09/14/2015
## Description

<h1>Introduction</h1>
<p>このサンプルは、Bluetooth通信を使ってNetduinoに１バイトのバイナリデータを送信するためのサンプルコードです。<br>
本サンプルはUWPアプリとして作成しており、UWP対応のプラットフォームであれば&#31292;働可能です。</p>
<p>----------------------------------------------------------------------------------------------------------------</p>
<h1><span>Building the Sample</span></h1>
<p>このサンプルの実行には以下のソフトウェアが必要です。</p>
<ul>
<li>Windows 10 </li><li>Visual Studio 2015 or Visual Studio Community 2015&nbsp; </li></ul>
<p>このサンプルは、以下のハードウェアとファームウェア上で動作します。</p>
<ul>
<li>Bluetoothデバイス<span><br>
</span></li></ul>
<p>本サンプルの実行には、対抗側になるNetduinoサンプルコードが必要です。</p>
<p>Netduino側のサンプルコードは、https://code.msdn.microsoft.com/Bluetooth-Connection-Sample-d4840baf になります。</p>
<p>本サンプルについての詳しい説明は、<a href="http://www.buildinsider.net/small/netduino/11">http://www.buildinsider.net/small/netduino/11</a>&nbsp;をご覧ください。<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>----------------------------------------------------------------------------------------------------------------<span>&nbsp;</span><strong></strong><em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<ol>
<li>本サンプルを実行する場合、Netduino側の電源を事前に入れてNetduino側のBluetoothデバイスを&#31292;働状態にします。 </li><li>Windows 10の設定でNetduino側のBluetoothデバイスとペアリングします。Netduino側でSBDBTを使っている場合のパスコードは「0000」&nbsp;&nbsp;になります。
</li><li>本サンプルを実行すると画面にBluetoothデバイス名が表示されるので、その名前をペアリングしたBluetoothデバイス名に変更します。 </li><li>[100%][20%][0%]のいずれかのボタンをクリックすると、その都度、Bluetoothの接続を確認しデータを送信します。 </li><li>最初の接続時にBluetoothデバイスの接続許可が表示されるので[OK]をクリックします。 </li><li>あとは、ボタンに応じてNetduino側のモーターの回転数が変化します。 </li></ol>
<p>&nbsp;</p>
<p><strong>&nbsp;</strong><em></em></p>
