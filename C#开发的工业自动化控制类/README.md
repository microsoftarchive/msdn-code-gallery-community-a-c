# C#开发的工业自动化控制类
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
## Topics
- C#
## Updated
- 07/08/2019
## Description

<p><strong><span style="font-size:large">目前下载量已经超过2K，为了纪念。如果你认为此代码有所帮助，请扫码赞赏，这是对我付出的认可，这也是我更新代码的动力。谢谢！</span></strong></p>
<p><img id="223798" src="https://i1.code.msdn.s-msft.com/windowsdesktop/c-9c21ed84/image/file/223798/1/%e5%be%ae%e4%bf%a1%e5%9b%be%e7%89%87_20190708202914.png" alt="" width="691" height="691"></p>
<p>&nbsp;</p>
<p><span>C#开发的工业自动化控制类，大部分已经写完且验证过:</span></p>
<p><span>一、EPSON Robot Remote TCP/IP Control: 用于对EPSON机械手进行远程以太网控制，建立以太网通讯后发送命令给爱普生机械手控制器，然后依照返回的命令处理相应结果;</span></p>
<p><span>二、Motion Control(GoogolTech/LeadShine):【二次封装】固高GTS系列运动控制卡运动卡控制类：初始化运动卡和更新IO,控制固高运动控制器轴运动;这是对固高和雷赛运动控制卡的DLL文件中的函数进行第二次封装，使在实际编程的时候更加方便、快捷；</span></p>
<p><span>三、Advantech:</span></p>
<p><span>PCI1752:研华数据采集卡PCI1752更新输出及输出状态回读;</span></p>
<p><span>PCI1754:研华数据采集卡PCI1754更新输入信号;</span></p>
<p><span>四、Keyence Laser:基恩士激光读取数据;</span></p>
<p><span>五、RS232C:RS232C串口通讯，包括界面类；</span></p>
<p><span>六、RS485:RS485串口通讯，还没有完成；</span></p>
<p><span>七、TCP/IP Server/Client(Sync/Async)：以太网通讯客户端和服务器端，支持同步和异步通讯;</span></p>
<p><span>八、OPC Client/Server：还没有完成；</span></p>
<p><span>九、CAN, EtherCAT：还没有完成；</span></p>
<p><span>十、XML：XML文件操作，包括写和读取的相关实用函数；</span></p>
<p><span>十一、Excel：Excel文件的相关操作，包括快速写大量数据到EXCEL文件；其中处理条件&#26684;式的代码还在调试中；</span></p>
<p><span>十二、MYSQL/ACCESS Database：数据库操作；</span></p>
<p><span>十三、Common functions：操作系统和文件相关操作、获取TcpClient连接的本地/对方IP地址和端口、通用TCP/IP函数、跨线程安全的委托、进制转换、通用RS232C函数；</span></p>
<p><span>十四、Delay(time)：延时计时器，等待指定时间，如果计算机不支持高性能计数器，则只支持整数秒的时间</span></p>
<p><span>十五、ListView：针对ListView控件的各项增加、删除、查找操作；</span></p>
<p>&nbsp;</p>
<p><span>一、EPSON Robot Remote TCP/IP Control: 用于对EPSON机械手进行远程以太网控制，建立以太网通讯后发送命令给爱普生机械手控制器，然后依照返回的命令处理相应结果;<br>
二、Motion Control(GoogolTech/LeadShine):【二次封装】固高GTS系列运动控制卡运动卡控制类：初始化运动卡和更新IO,控制固高运动控制器轴运动;这是对固高和雷赛运动控制卡的DLL文件中的函数进行第二次封装，使在实际编程的时候更加方便、快捷；<br>
三、Advantech:<br>
PCI1752:研华数据采集卡PCI1752更新输出及输出状态回读;<br>
PCI1754:研华数据采集卡PCI1754更新输入信号;<br>
四、Keyence Laser:基恩士激光读取数据;<br>
五、RS232C:RS232C串口通讯，包括界面类；<br>
六、RS485:RS485串口通讯，还没有完成；<br>
七、TCP/IP Server/Client(Sync/Async)：以太网通讯客户端和服务器端，支持同步和异步通讯;<br>
八、OPC Client/Server：还没有完成；<br>
九、CAN, EtherCAT：还没有完成；<br>
十、XML：XML文件操作，包括写和读取的相关实用函数；<br>
十一、Excel：Excel文件的相关操作，包括快速写大量数据到EXCEL文件；其中处理条件&#26684;式的代码还在调试中；<br>
十二、MYSQL/ACCESS Database：数据库操作；<br>
十三、Common functions：操作系统和文件相关操作、获取TcpClient连接的本地/对方IP地址和端口、通用TCP/IP函数、跨线程安全的委托、进制转换、通用RS232C函数；<br>
十四、Delay(time)：延时计时器，等待指定时间，如果计算机不支持高性能计数器，则只支持整数秒的时间<br>
十五、ListView：针对ListView控件的各项增加、删除、查找操作；<br>
</span></p>
