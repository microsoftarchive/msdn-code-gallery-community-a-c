# ASP.NET MVC- Angular UIGrid Paging
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET MVC 4
- AngularJS
## Topics
- ASP.NET MVC
- GridView
## Updated
- 07/04/2016
## Description

<p>Angular UI Grid is a data grid for AngularJS without JQuery that can perform with large data, which is part of the Angular UI suite.</p>
<p><strong>Background:</strong></p>
<p>Recently I was searching for a data table that have component like sorting, filtering, pagination, inline editor, responsive and other advance facilities. I have tried to integrate &amp; use Jquery datatable(Angular), but the problem arise while I was trying
 to pass entire row passing while row click/row selected button click.</p>
<p>It fails to pass angular object (only can pass int, string, boolean) while render, this was a big issue to me as I was using angularJS in application frontend.</p>
<p>I decided to change the entire table, I found&nbsp;<strong>Angular UI Grid.</strong></p>
<p><strong>Let&rsquo;s Get Into It:</strong></p>
<p>As we know&nbsp;<strong>Angular UI Grid&nbsp;</strong>is a part of Angular UI, so we have some facilities. We need to download/install package before we are going to use in our application.</p>
<p>To download the package, go to URL:&nbsp;<a href="http://ui-grid.info/">http://ui-grid.info</a></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig1.png"><img class="alignnone size-large x_wp-image-2904" src="http://shashangka.com/wp-content/uploads/2016/05/uig1-1024x377.png" alt="uig1" width="646" height="238"></a></p>
<p><strong>MVC Application:</strong></p>
<p>Let&rsquo;s create a new demo application with visual studio 2015. Select MVC and Web API below. Click&nbsp;<strong>OK.</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig2.png"><img class="alignnone size-full x_wp-image-2905" src="http://shashangka.com/wp-content/uploads/2016/05/uig2.png" alt="uig2" width="787" height="611"></a></p>
<p>Fig: 2</p>
<p>After loading the initial application template, we need to install the script packages. We need to install two package using NuGet Package installer.</p>
<p>First we will install AngularJS and after that we need to add Angular-Ui-Grid. In package manager console write&nbsp;<strong><em>Install-Package angularjs</em></strong><em>.</em>&nbsp;After successfully installation write<strong><em>Install-Package angular-ui-grid</em></strong><em>.</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig3.png"><img class="alignnone size-full x_wp-image-2906" src="http://shashangka.com/wp-content/uploads/2016/05/uig3.png" alt="uig3" width="861" height="125"></a></p>
<p>Fig: 3</p>
<p>Or we can install packages using NuGet package manager</p>
<p><strong>AngularJS</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig4.png"><img class="alignnone size-full x_wp-image-2907" src="http://shashangka.com/wp-content/uploads/2016/05/uig4.png" alt="uig4" width="1023" height="342"></a></p>
<p>Fig: 4</p>
<p><strong>AngularJS-uigrid</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig5.png"><img class="alignnone size-full x_wp-image-2908" src="http://shashangka.com/wp-content/uploads/2016/05/uig5.png" alt="uig5" width="1001" height="353"></a></p>
<p>Fig: 5</p>
<p>Our packages are installed, now we need to add a new controller and generate view to the application. In our master layout we need to add reference of script library.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig6.png"><img class="alignnone size-full x_wp-image-2924" src="http://shashangka.com/wp-content/uploads/2016/05/uig6.png" alt="uig6" width="835" height="291"></a></p>
<p>Fig: 6</p>
<p>In the head section add the ui style reference</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig7.png"><img class="alignnone size-full x_wp-image-2910" src="http://shashangka.com/wp-content/uploads/2016/05/uig7.png" alt="uig7" width="891" height="169"></a></p>
<p>Fig:7</p>
<p><strong>&nbsp;</strong><strong>AngularJS</strong></p>
<p>Let&rsquo;s add folder&rsquo;s to create angular script.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig8.png"><img class="alignnone size-full x_wp-image-2911" src="http://shashangka.com/wp-content/uploads/2016/05/uig8.png" alt="uig8" width="269" height="223"></a></p>
<p>Fig: 8</p>
<p><strong>&nbsp;</strong><strong>JS-Module</strong></p>
<div class="crayon-syntax x_crayon-theme-classic x_crayon-font-monaco x_crayon-os-pc x_print-yes x_notranslate" id="crayon-577a93a2ed788501703724">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a93a2ed788501703724-1"><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">app</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-2">
<span class="crayon-sy">(</span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-3"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'use strict'</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-4">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">app</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">angular</span><span class="crayon-sy">.</span><span class="crayon-e">module</span><span class="crayon-sy">(</span><span class="crayon-s">'UIGrid_App'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-5"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">[</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-6">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ngAnimate'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//
 support for CSS-based animations</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-7"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ngTouch'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//for
 touch-enabled devices</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-8">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid for AngularJS</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-9"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.pagination'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-c">//data grid Pagination</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.resizeColumns'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid Resize column</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.moveColumns'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid Move column</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-12">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.pinning'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid Pin column Left/Right</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.selection'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid Select Rows</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.autoResize'</span><span class="crayon-sy">,</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-c">//data grid Enabled auto column Size</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'ui.grid.exporter'</span><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//data
 grid Export Data</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed788501703724-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">]</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed788501703724-17"><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>JS-Controller</strong></p>
<div class="crayon-syntax x_crayon-theme-classic x_crayon-font-monaco x_crayon-os-pc x_print-yes x_notranslate" id="crayon-577a93a2ed78c992399369">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
<div class="crayon-num x_crayon-striped-num">18</div>
<div class="crayon-num">19</div>
<div class="crayon-num x_crayon-striped-num">20</div>
<div class="crayon-num">21</div>
<div class="crayon-num x_crayon-striped-num">22</div>
<div class="crayon-num">23</div>
<div class="crayon-num x_crayon-striped-num">24</div>
<div class="crayon-num">25</div>
<div class="crayon-num x_crayon-striped-num">26</div>
<div class="crayon-num">27</div>
<div class="crayon-num x_crayon-striped-num">28</div>
<div class="crayon-num">29</div>
<div class="crayon-num x_crayon-striped-num">30</div>
<div class="crayon-num">31</div>
<div class="crayon-num x_crayon-striped-num">32</div>
<div class="crayon-num">33</div>
<div class="crayon-num x_crayon-striped-num">34</div>
<div class="crayon-num">35</div>
<div class="crayon-num x_crayon-striped-num">36</div>
<div class="crayon-num">37</div>
<div class="crayon-num x_crayon-striped-num">38</div>
<div class="crayon-num">39</div>
<div class="crayon-num x_crayon-striped-num">40</div>
<div class="crayon-num">41</div>
<div class="crayon-num x_crayon-striped-num">42</div>
<div class="crayon-num">43</div>
<div class="crayon-num x_crayon-striped-num">44</div>
<div class="crayon-num">45</div>
<div class="crayon-num x_crayon-striped-num">46</div>
<div class="crayon-num">47</div>
<div class="crayon-num x_crayon-striped-num">48</div>
<div class="crayon-num">49</div>
<div class="crayon-num x_crayon-striped-num">50</div>
<div class="crayon-num">51</div>
<div class="crayon-num x_crayon-striped-num">52</div>
<div class="crayon-num">53</div>
<div class="crayon-num x_crayon-striped-num">54</div>
<div class="crayon-num">55</div>
<div class="crayon-num x_crayon-striped-num">56</div>
<div class="crayon-num">57</div>
<div class="crayon-num x_crayon-striped-num">58</div>
<div class="crayon-num">59</div>
<div class="crayon-num x_crayon-striped-num">60</div>
<div class="crayon-num">61</div>
<div class="crayon-num x_crayon-striped-num">62</div>
<div class="crayon-num">63</div>
<div class="crayon-num x_crayon-striped-num">64</div>
<div class="crayon-num">65</div>
<div class="crayon-num x_crayon-striped-num">66</div>
<div class="crayon-num">67</div>
<div class="crayon-num x_crayon-striped-num">68</div>
<div class="crayon-num">69</div>
<div class="crayon-num x_crayon-striped-num">70</div>
<div class="crayon-num">71</div>
<div class="crayon-num x_crayon-striped-num">72</div>
<div class="crayon-num">73</div>
<div class="crayon-num x_crayon-striped-num">74</div>
<div class="crayon-num">75</div>
<div class="crayon-num x_crayon-striped-num">76</div>
<div class="crayon-num">77</div>
<div class="crayon-num x_crayon-striped-num">78</div>
<div class="crayon-num">79</div>
<div class="crayon-num x_crayon-striped-num">80</div>
<div class="crayon-num">81</div>
<div class="crayon-num x_crayon-striped-num">82</div>
<div class="crayon-num">83</div>
<div class="crayon-num x_crayon-striped-num">84</div>
<div class="crayon-num">85</div>
<div class="crayon-num x_crayon-striped-num">86</div>
<div class="crayon-num">87</div>
<div class="crayon-num x_crayon-striped-num">88</div>
<div class="crayon-num">89</div>
<div class="crayon-num x_crayon-striped-num">90</div>
<div class="crayon-num">91</div>
<div class="crayon-num x_crayon-striped-num">92</div>
<div class="crayon-num">93</div>
<div class="crayon-num x_crayon-striped-num">94</div>
<div class="crayon-num">95</div>
<div class="crayon-num x_crayon-striped-num">96</div>
<div class="crayon-num">97</div>
<div class="crayon-num x_crayon-striped-num">98</div>
<div class="crayon-num">99</div>
<div class="crayon-num x_crayon-striped-num">100</div>
<div class="crayon-num">101</div>
<div class="crayon-num x_crayon-striped-num">102</div>
<div class="crayon-num">103</div>
<div class="crayon-num x_crayon-striped-num">104</div>
<div class="crayon-num">105</div>
<div class="crayon-num x_crayon-striped-num">106</div>
<div class="crayon-num">107</div>
<div class="crayon-num x_crayon-striped-num">108</div>
<div class="crayon-num">109</div>
<div class="crayon-num x_crayon-striped-num">110</div>
<div class="crayon-num">111</div>
<div class="crayon-num x_crayon-striped-num">112</div>
<div class="crayon-num">113</div>
<div class="crayon-num x_crayon-striped-num">114</div>
<div class="crayon-num">115</div>
<div class="crayon-num x_crayon-striped-num">116</div>
<div class="crayon-num">117</div>
<div class="crayon-num x_crayon-striped-num">118</div>
<div class="crayon-num">119</div>
<div class="crayon-num x_crayon-striped-num">120</div>
<div class="crayon-num">121</div>
<div class="crayon-num x_crayon-striped-num">122</div>
<div class="crayon-num">123</div>
<div class="crayon-num x_crayon-striped-num">124</div>
<div class="crayon-num">125</div>
<div class="crayon-num x_crayon-striped-num">126</div>
<div class="crayon-num">127</div>
<div class="crayon-num x_crayon-striped-num">128</div>
<div class="crayon-num">129</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-1"><span class="crayon-v">app</span><span class="crayon-sy">.</span><span class="crayon-e">controller</span><span class="crayon-sy">(</span><span class="crayon-s">'ProductsCtrl'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-sy">[</span><span class="crayon-s">'$scope'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-s">'CRUDService'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-s">'uiGridConstants'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-2">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">CRUDService</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">uiGridConstants</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-3"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">[</span><span class="crayon-sy">]</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-4">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-5"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//Pagination</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-6">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-7"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">paginationPageSizes</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">[</span><span class="crayon-cn">15</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-cn">25</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-cn">50</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-cn">75</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-cn">100</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-s">&quot;All&quot;</span><span class="crayon-sy">]</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-8">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ddlpageSize</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-cn">15</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-9"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">pageNumber</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-cn">1</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">pageSize</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-cn">15</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">totalItems</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-cn">0</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-12">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">getTotalPages</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-v">Math</span><span class="crayon-sy">.</span><span class="crayon-e">ceil</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">totalItems</span><span class="crayon-h">
</span><span class="crayon-o">/</span><span class="crayon-h"> </span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageSize</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">pageSizeChange</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-17"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">ddlpageSize</span><span class="crayon-h">
</span><span class="crayon-o">==</span><span class="crayon-h"> </span><span class="crayon-s">&quot;All&quot;</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-18">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageSize</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">totalItems</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-19"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">else</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-20">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageSize</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-e">ddlpageSize</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-21">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-22">
<span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-cn">1</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-23"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-24">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-25"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">firstPage</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-26">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">&gt;</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-27"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-cn">1</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-28">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-29"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-30">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-31"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">nextPage</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-32">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">&lt;</span><span class="crayon-h"> </span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-e">getTotalPages</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-33"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-o">&#43;&#43;</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-34">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-35"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-36">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-37"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">previousPage</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-38">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">&gt;</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-39"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-o">--</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-40">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-41"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-42">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-43"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">lastPage</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-44">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">&gt;=</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-45"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-e">getTotalPages</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-46">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-47"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-48">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-49"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-50">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-51"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//ui-Grid Call</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-52">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">GetProducts</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-53"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">loaderMore</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">true</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-54">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">lblMessage</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-s">'loading please wait....!'</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-55"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">result</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-s">&quot;color-green&quot;</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-56">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-57"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">highlightFilteredHeader</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">row</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">rowRenderIndex</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">col</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">colRenderIndex</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-58">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">if</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">col</span><span class="crayon-sy">.</span><span class="crayon-v">filters</span><span class="crayon-sy">[</span><span class="crayon-cn">0</span><span class="crayon-sy">]</span><span class="crayon-sy">.</span><span class="crayon-v">term</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-59"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-s">'header-filtered'</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-60">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-h">
</span><span class="crayon-st">else</span><span class="crayon-h"> </span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-61"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-s">''</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-62">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-63"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-64">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-65"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">useExternalPagination</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-66">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">useExternalSorting</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-67"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableFiltering</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-68">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableSorting</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-69"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableRowSelection</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-70">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableSelectAll</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-71"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableGridMenu</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">true</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-72">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-73"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">columnDefs</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">[</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-74">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-h">
</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;ProductID&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">displayName</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Product ID&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">width</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'10%'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">headerCellClass</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-i">highlightFilteredHeader</span><span class="crayon-h">
</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-75"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-h">
</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;ProductTitle&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Product Title&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">width</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'40%'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">headerCellClass</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-i">highlightFilteredHeader</span><span class="crayon-h">
</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-76">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-h">
</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Type&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Type&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">headerCellClass</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-i">highlightFilteredHeader</span><span class="crayon-h">
</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-77"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-78">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Price&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Price&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">cellFilter</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'number'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-79"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">filters</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">[</span><span class="crayon-sy">{</span><span class="crayon-h">
</span><span class="crayon-v">condition</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-v">uiGridConstants</span><span class="crayon-sy">.</span><span class="crayon-v">filter</span><span class="crayon-sy">.</span><span class="crayon-v">GREATER_THAN</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">placeholder</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'Minimum'</span><span class="crayon-h"> </span>
<span class="crayon-sy">}</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-sy">{</span><span class="crayon-h"> </span><span class="crayon-v">condition</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-v">uiGridConstants</span><span class="crayon-sy">.</span><span class="crayon-v">filter</span><span class="crayon-sy">.</span><span class="crayon-v">LESS_THAN</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">placeholder</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'Maximum'</span><span class="crayon-h"> </span>
<span class="crayon-sy">}</span><span class="crayon-sy">]</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-80">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">headerCellClass</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-i">highlightFilteredHeader</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-81"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-82">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-h">
</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;CreatedOn&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">displayName</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">&quot;Created On&quot;</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">cellFilter</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'date:&quot;short&quot;'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">headerCellClass</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-i">highlightFilteredHeader</span><span class="crayon-h">
</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-83"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-84">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">name</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'Edit'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-85"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableFiltering</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">false</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-86">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableSorting</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">false</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-87"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">width</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'5%'</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-88">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">enableColumnResizing</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-t">false</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-89"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">cellTemplate</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-s">'&lt;span class=&quot;label label-warning label-mini&quot;&gt;'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-90">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'&lt;a
 href=&quot;&quot; style=&quot;color:white&quot; title=&quot;Select&quot; ng-click=&quot;grid.appScope.GetByID(row.entity)&quot;&gt;'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-91"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'&lt;i
 class=&quot;fa fa-check-square&quot; aria-hidden=&quot;true&quot;&gt;&lt;/i&gt;'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-92">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'&lt;/a&gt;'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-93"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-s">'&lt;/span&gt;'</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-94">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-95"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">]</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-96">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">exporterAllDataFn</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-97"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-e">getPage</span><span class="crayon-sy">(</span><span class="crayon-cn">1</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-sy">.</span><span class="crayon-v">totalItems</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-v">paginationOptions</span><span class="crayon-sy">.</span><span class="crayon-v">sort</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-98">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">.</span><span class="crayon-e">then</span><span class="crayon-sy">(</span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-99"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-sy">.</span><span class="crayon-v">useExternalPagination</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">false</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-100">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-sy">.</span><span class="crayon-v">useExternalSorting</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">false</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-101"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">getPage</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">null</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-102">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-103"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-104">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-105">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-106">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">NextPage</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-sy">(</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-h">
</span><span class="crayon-o">-</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-o">*</span><span class="crayon-h"> </span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">pageSize</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-107"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">NextPageSize</span><span class="crayon-h"> </span>
<span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">pageSize</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-108">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">apiRoute</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-s">'api/Product/GetProducts/'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span><span class="crayon-h"> </span><span class="crayon-v">NextPage</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span><span class="crayon-h"> </span><span class="crayon-s">'/'</span><span class="crayon-h">
</span><span class="crayon-o">&#43;</span><span class="crayon-h"> </span><span class="crayon-v">NextPageSize</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-109"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">var</span><span class="crayon-h">
</span><span class="crayon-v">result</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-v">CRUDService</span><span class="crayon-sy">.</span><span class="crayon-e">getProducts</span><span class="crayon-sy">(</span><span class="crayon-v">apiRoute</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-110">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">result</span><span class="crayon-sy">.</span><span class="crayon-e">then</span><span class="crayon-sy">(</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-111"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">response</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-112">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">totalItems</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">response</span><span class="crayon-sy">.</span><span class="crayon-v">data</span><span class="crayon-sy">.</span><span class="crayon-v">recordsTotal</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-113"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">gridOptions</span><span class="crayon-sy">.</span><span class="crayon-v">data</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">response</span><span class="crayon-sy">.</span><span class="crayon-v">data</span><span class="crayon-sy">.</span><span class="crayon-v">productList</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-114">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">loaderMore</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">false</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-115"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">,</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-116">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">error</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-117"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">console</span><span class="crayon-sy">.</span><span class="crayon-e">log</span><span class="crayon-sy">(</span><span class="crayon-s">&quot;Error:
 &quot;</span><span class="crayon-h"> </span><span class="crayon-o">&#43;</span><span class="crayon-h">
</span><span class="crayon-v">error</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-118">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-119"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-120">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-121"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//Default Load</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-122">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-123">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-124">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//Selected Call</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-125"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">GetByID</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">model</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-126">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">$</span><span class="crayon-v">scope</span><span class="crayon-sy">.</span><span class="crayon-v">SelectedRow</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">model</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-127"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed78c992399369-128">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a93a2ed78c992399369-129"><span class="crayon-sy">]</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>JS-Service</strong></p>
<div class="crayon-syntax x_crayon-theme-classic x_crayon-font-monaco x_crayon-os-pc x_print-yes x_notranslate" id="crayon-577a93a2ed792129544841">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_crayon-striped-num">6</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a93a2ed792129544841-1"><span class="crayon-v">app</span><span class="crayon-sy">.</span><span class="crayon-e">service</span><span class="crayon-sy">(</span><span class="crayon-s">'CRUDService'</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-e">function</span><span class="crayon-h"> </span><span class="crayon-sy">(</span><span class="crayon-sy">$</span><span class="crayon-v">http</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed792129544841-2">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-c">//**********----Get Record----***************</span></div>
<div class="crayon-line" id="crayon-577a93a2ed792129544841-3"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-r">this</span><span class="crayon-sy">.</span><span class="crayon-v">getProducts</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-e">function</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">apiRoute</span><span class="crayon-sy">)</span><span class="crayon-h">
</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed792129544841-4">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-sy">$</span><span class="crayon-v">http</span><span class="crayon-sy">.</span><span class="crayon-st">get</span><span class="crayon-sy">(</span><span class="crayon-v">apiRoute</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed792129544841-5"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed792129544841-6">
<span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>Ui-Grid</strong></p>
<p>In index.cshtml page add ui-grid directive</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig9.png"><img class="alignnone size-full x_wp-image-2912" src="http://shashangka.com/wp-content/uploads/2016/05/uig9.png" alt="uig9" width="631" height="103"></a></p>
<p>Fig: 9</p>
<p>The loader which will show a loading messaging while data is loading from server.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig10.png"><img class="alignnone size-full x_wp-image-2913" src="http://shashangka.com/wp-content/uploads/2016/05/uig10.png" alt="uig10" width="521" height="105"></a></p>
<p>Fig: 10</p>
<p>At bottom end, add angular reference to the page</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig11.png"><img class="alignnone size-full x_wp-image-2914" src="http://shashangka.com/wp-content/uploads/2016/05/uig11.png" alt="uig11" width="675" height="75"></a></p>
<p>Fig: 11</p>
<p><strong>&nbsp;</strong><strong>Complete Ui Code:</strong></p>
<div class="crayon-syntax x_crayon-theme-classic x_crayon-font-monaco x_crayon-os-pc x_print-yes x_notranslate" id="crayon-577a93a2ed797803815197">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
<div class="crayon-num x_crayon-striped-num">18</div>
<div class="crayon-num">19</div>
<div class="crayon-num x_crayon-striped-num">20</div>
<div class="crayon-num">21</div>
<div class="crayon-num x_crayon-striped-num">22</div>
<div class="crayon-num">23</div>
<div class="crayon-num x_crayon-striped-num">24</div>
<div class="crayon-num">25</div>
<div class="crayon-num x_crayon-striped-num">26</div>
<div class="crayon-num">27</div>
<div class="crayon-num x_crayon-striped-num">28</div>
<div class="crayon-num">29</div>
<div class="crayon-num x_crayon-striped-num">30</div>
<div class="crayon-num">31</div>
<div class="crayon-num x_crayon-striped-num">32</div>
<div class="crayon-num">33</div>
<div class="crayon-num x_crayon-striped-num">34</div>
<div class="crayon-num">35</div>
<div class="crayon-num x_crayon-striped-num">36</div>
<div class="crayon-num">37</div>
<div class="crayon-num x_crayon-striped-num">38</div>
<div class="crayon-num">39</div>
<div class="crayon-num x_crayon-striped-num">40</div>
<div class="crayon-num">41</div>
<div class="crayon-num x_crayon-striped-num">42</div>
<div class="crayon-num">43</div>
<div class="crayon-num x_crayon-striped-num">44</div>
<div class="crayon-num">45</div>
<div class="crayon-num x_crayon-striped-num">46</div>
<div class="crayon-num">47</div>
<div class="crayon-num x_crayon-striped-num">48</div>
<div class="crayon-num">49</div>
<div class="crayon-num x_crayon-striped-num">50</div>
<div class="crayon-num">51</div>
<div class="crayon-num x_crayon-striped-num">52</div>
<div class="crayon-num">53</div>
<div class="crayon-num x_crayon-striped-num">54</div>
<div class="crayon-num">55</div>
<div class="crayon-num x_crayon-striped-num">56</div>
<div class="crayon-num">57</div>
<div class="crayon-num x_crayon-striped-num">58</div>
<div class="crayon-num">59</div>
<div class="crayon-num x_crayon-striped-num">60</div>
<div class="crayon-num">61</div>
<div class="crayon-num x_crayon-striped-num">62</div>
<div class="crayon-num">63</div>
<div class="crayon-num x_crayon-striped-num">64</div>
<div class="crayon-num">65</div>
<div class="crayon-num x_crayon-striped-num">66</div>
<div class="crayon-num">67</div>
<div class="crayon-num x_crayon-striped-num">68</div>
<div class="crayon-num">69</div>
<div class="crayon-num x_crayon-striped-num">70</div>
<div class="crayon-num">71</div>
<div class="crayon-num x_crayon-striped-num">72</div>
<div class="crayon-num">73</div>
<div class="crayon-num x_crayon-striped-num">74</div>
<div class="crayon-num">75</div>
<div class="crayon-num x_crayon-striped-num">76</div>
<div class="crayon-num">77</div>
<div class="crayon-num x_crayon-striped-num">78</div>
<div class="crayon-num">79</div>
<div class="crayon-num x_crayon-striped-num">80</div>
<div class="crayon-num">81</div>
<div class="crayon-num x_crayon-striped-num">82</div>
<div class="crayon-num">83</div>
<div class="crayon-num x_crayon-striped-num">84</div>
<div class="crayon-num">85</div>
<div class="crayon-num x_crayon-striped-num">86</div>
<div class="crayon-num">87</div>
<div class="crayon-num x_crayon-striped-num">88</div>
<div class="crayon-num">89</div>
<div class="crayon-num x_crayon-striped-num">90</div>
<div class="crayon-num">91</div>
<div class="crayon-num x_crayon-striped-num">92</div>
<div class="crayon-num">93</div>
<div class="crayon-num x_crayon-striped-num">94</div>
<div class="crayon-num">95</div>
<div class="crayon-num x_crayon-striped-num">96</div>
<div class="crayon-num">97</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a93a2ed797803815197-1"><span class="crayon-sy">@</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-2">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ViewBag</span><span class="crayon-sy">.</span><span class="crayon-v">Title</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-s">&quot;Products&quot;</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-3"><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-4">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-5"><span class="crayon-o">&lt;</span><span class="crayon-v">h3</span><span class="crayon-o">&gt;</span><span class="crayon-e">Products
</span><span class="crayon-e">with </span><span class="crayon-e">UI </span><span class="crayon-v">Grid</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">h3</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-6">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-7"><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;row&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-8">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;col-md-12&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">controller</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ProductsCtrl&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-9"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">=</span><span class="crayon-s">&quot;gridOptions&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">resize</span><span class="crayon-o">-</span><span class="crayon-e">columns</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-11"><span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">move</span><span class="crayon-o">-</span><span class="crayon-e">columns</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-12">
<span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-e">exporter</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-13"><span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-e">selection</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-14">
<span class="crayon-e">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-e">pinning
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;grid&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-15">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;loadmore&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-17"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">show</span><span class="crayon-o">=</span><span class="crayon-s">&quot;loaderMore&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;result&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-18">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">img
</span><span class="crayon-v">src</span><span class="crayon-o">=</span><span class="crayon-s">&quot;~/Content/ng-loader.gif&quot;</span><span class="crayon-h">
</span><span class="crayon-o">/</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-19"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">lblMessage</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-20">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-21"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-22">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-23"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;contentinfo&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-panel ng-scope&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-24">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;navigation&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-container&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-25"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;menubar&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-control&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-26">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-e">Start </span><span class="crayon-v">Page</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-27"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">button
</span><span class="crayon-v">type</span><span class="crayon-o">=</span><span class="crayon-s">&quot;button&quot;</span><span class="crayon-h">
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;menuitem&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-first&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageToFirst&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-28">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageToFirst&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-29"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">click</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.firstPage()&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-30">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;cantPageBackward()&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page to first&quot;</span><span class="crayon-h">
</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page to first&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-31"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;disabled&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-32">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;first-triangle&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-33"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;first-bar&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-34">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-35"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">button</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-36">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-37"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-e">Prev </span><span class="crayon-v">Page</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-38">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">button
</span><span class="crayon-v">type</span><span class="crayon-o">=</span><span class="crayon-s">&quot;button&quot;</span><span class="crayon-h">
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;menuitem&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-previous&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-39"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageBack&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageBack&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-40">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">click</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.previousPage()&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-41"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;cantPageBackward()&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page back&quot;</span><span class="crayon-h">
</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page back&quot;</span><span class="crayon-h">
</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;disabled&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-42">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;first-triangle prev-triangle&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-43"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">button</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-44">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-45"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">input
</span><span class="crayon-v">type</span><span class="crayon-o">=</span><span class="crayon-s">&quot;number&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageSelected&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageSelected&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-46">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-control-input ng-pristine ng-untouched ng-valid ng-not-empty ng-valid-min ng-valid-max ng-valid-required&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-47"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">model</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.pageNumber&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-48">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">min</span><span class="crayon-o">=</span><span class="crayon-s">&quot;1&quot;</span><span class="crayon-h">
</span><span class="crayon-v">max</span><span class="crayon-o">=</span><span class="crayon-s">&quot;{{pagination.getTotalPages()}}&quot;</span><span class="crayon-h">
</span><span class="crayon-v">required</span><span class="crayon-o">=</span><span class="crayon-s">&quot;&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Selected page&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-49"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Selected page&quot;</span><span class="crayon-h">
</span><span class="crayon-v">disabled</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-50">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-51"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">span
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-max-pages-number ng-binding&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-52">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">show</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.getTotalPages()
 &gt; 0&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-53"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">abbr
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;paginationOf&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;of&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-h">
</span><span class="crayon-o">/</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">abbr</span><span class="crayon-o">&gt;</span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-e">getTotalPages</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-54">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">span</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-55">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-56">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-e">Next </span><span class="crayon-v">Page</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-57"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">button
</span><span class="crayon-v">type</span><span class="crayon-o">=</span><span class="crayon-s">&quot;button&quot;</span><span class="crayon-h">
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;menuitem&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-next&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageForward&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-58">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageForward&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-59"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">click</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.nextPage()&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-60">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;cantPageForward()&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-61"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page
 forward&quot;</span><span class="crayon-h"> </span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page forward&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-62">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;last-triangle next-triangle&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-63"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">button</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-64">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-65"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-e">Last </span><span class="crayon-v">Page</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-66">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">button
</span><span class="crayon-v">type</span><span class="crayon-o">=</span><span class="crayon-s">&quot;button&quot;</span><span class="crayon-h">
</span><span class="crayon-v">role</span><span class="crayon-o">=</span><span class="crayon-s">&quot;menuitem&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-last&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-67"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageToLast&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;aria.pageToLast&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-68">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">click</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.lastPage()&quot;</span><span class="crayon-h">
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">disabled</span><span class="crayon-o">=</span><span class="crayon-s">&quot;cantPageToLast()&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page to last&quot;</span><span class="crayon-h">
</span><span class="crayon-v">aria</span><span class="crayon-o">-</span><span class="crayon-v">label</span><span class="crayon-o">=</span><span class="crayon-s">&quot;Page to last&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-69"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;last-triangle&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;last-bar&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-70">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">button</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-71"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-v">ngIf</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-v">grid</span><span class="crayon-sy">.</span><span class="crayon-v">options</span><span class="crayon-sy">.</span><span class="crayon-v">paginationPageSizes</span><span class="crayon-sy">.</span><span class="crayon-v">length</span><span class="crayon-h">
</span><span class="crayon-o">&gt;</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-72">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-73"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-row-count-picker ng-scope&quot;</span><span class="crayon-h">
</span><span class="crayon-sy">@</span><span class="crayon-o">*</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-st">if</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.ddlpageSize.length
 &gt; 1&quot;</span><span class="crayon-o">*</span><span class="crayon-sy">@</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-74">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">select
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">model</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.ddlpageSize&quot;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-75"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">options</span><span class="crayon-o">=</span><span class="crayon-s">&quot;o
 as o for o in pagination.paginationPageSizes&quot;</span><span class="crayon-h"> </span>
<span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">change</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.pageSizeChange()&quot;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-76">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ng-pristine
 ng-untouched ng-valid ng-not-empty&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">select</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-77"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">span
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-row-count-label ng-binding&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-o">&amp;</span><span class="crayon-v">nbsp</span><span class="crayon-sy">;</span><span class="crayon-e">items
</span><span class="crayon-e">per </span><span class="crayon-v">page</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">span</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-78">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-79"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-e">end </span><span class="crayon-v">ngIf</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-v">grid</span><span class="crayon-sy">.</span><span class="crayon-v">options</span><span class="crayon-sy">.</span><span class="crayon-v">paginationPageSizes</span><span class="crayon-sy">.</span><span class="crayon-v">length</span><span class="crayon-h">
</span><span class="crayon-o">&gt;</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-80">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">!</span><span class="crayon-o">--</span><span class="crayon-h">
</span><span class="crayon-v">ngIf</span><span class="crayon-o">:</span><span class="crayon-h">
</span><span class="crayon-v">grid</span><span class="crayon-sy">.</span><span class="crayon-v">options</span><span class="crayon-sy">.</span><span class="crayon-v">paginationPageSizes</span><span class="crayon-sy">.</span><span class="crayon-v">length</span><span class="crayon-h">
</span><span class="crayon-o">&lt;=</span><span class="crayon-h"> </span><span class="crayon-cn">1</span><span class="crayon-h">
</span><span class="crayon-o">--</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-81"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-v">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-82">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-count-container&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-83"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">div
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ui-grid-pager-count&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-84">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">span
</span><span class="crayon-v">ng</span><span class="crayon-o">-</span><span class="crayon-v">show</span><span class="crayon-o">=</span><span class="crayon-s">&quot;pagination.totalItems &gt; 0&quot;</span><span class="crayon-h">
</span><span class="crayon-t">class</span><span class="crayon-o">=</span><span class="crayon-s">&quot;ng-binding&quot;</span><span class="crayon-h">
</span><span class="crayon-v">style</span><span class="crayon-o">=</span><span class="crayon-s">&quot;&quot;</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-85"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">pageNumber</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span><span class="crayon-o">&lt;</span><span class="crayon-e">abbr
</span><span class="crayon-v">ui</span><span class="crayon-o">-</span><span class="crayon-v">grid</span><span class="crayon-o">-</span><span class="crayon-v">one</span><span class="crayon-o">-</span><span class="crayon-v">bind</span><span class="crayon-o">-</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;paginationThrough&quot;</span><span class="crayon-h">
</span><span class="crayon-v">title</span><span class="crayon-o">=</span><span class="crayon-s">&quot;through&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-h">
</span><span class="crayon-o">-</span><span class="crayon-h"> </span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">abbr</span><span class="crayon-o">&gt;</span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">ddlpageSize</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span><span class="crayon-h">
</span><span class="crayon-e">of</span><span class="crayon-h"> </span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">pagination</span><span class="crayon-sy">.</span><span class="crayon-v">totalItems</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span><span class="crayon-h">
</span><span class="crayon-e">items</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-86">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">span</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-87"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-88">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-89"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-90">
&nbsp;</div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-91"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-e">p</span><span class="crayon-o">&gt;</span><span class="crayon-sy">{</span><span class="crayon-sy">{</span><span class="crayon-v">SelectedRow</span><span class="crayon-sy">}</span><span class="crayon-sy">}</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">p</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-92">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-93"><span class="crayon-o">&lt;</span><span class="crayon-o">/</span><span class="crayon-e">div</span><span class="crayon-o">&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-94">
<span class="crayon-sy">@</span><span class="crayon-e">section</span><span class="crayon-h">
</span><span class="crayon-e">AngularScript</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-95"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-ta">&lt;script
</span><span class="crayon-e">src</span><span class="crayon-o">=</span><span class="crayon-s">&quot;~/ScriptsNg/Controllers/ProductsCtrl.js&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-ta">&lt;/script&gt;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed797803815197-96">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-ta">&lt;script
</span><span class="crayon-e">src</span><span class="crayon-o">=</span><span class="crayon-s">&quot;~/ScriptsNg/Service/CRUDService.js&quot;</span><span class="crayon-o">&gt;</span><span class="crayon-ta">&lt;/script&gt;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed797803815197-97"><span class="crayon-sy">}</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>Model</strong>: Our Ui is ready Let&rsquo;s create a new model in our demo application.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig12.png"><img class="alignnone size-full x_wp-image-2915" src="http://shashangka.com/wp-content/uploads/2016/05/uig12.png" alt="uig12" width="941" height="573"></a></p>
<p>Fig: 12</p>
<p>I have used api controller to get data from server, which will get called while pagination operate.</p>
<p><strong>Api-Controller</strong>:</p>
<div class="crayon-syntax x_crayon-theme-classic x_crayon-font-monaco x_crayon-os-pc x_print-yes x_notranslate" id="crayon-577a93a2ed79c893489154">
<div class="crayon-plain-wrap"></div>
<div class="crayon-main">
<table class="crayon-table">
<tbody>
<tr class="crayon-row">
<td class="crayon-nums">
<div class="crayon-nums-content">
<div class="crayon-num">1</div>
<div class="crayon-num x_crayon-striped-num">2</div>
<div class="crayon-num">3</div>
<div class="crayon-num x_crayon-striped-num">4</div>
<div class="crayon-num">5</div>
<div class="crayon-num x_crayon-striped-num">6</div>
<div class="crayon-num">7</div>
<div class="crayon-num x_crayon-striped-num">8</div>
<div class="crayon-num">9</div>
<div class="crayon-num x_crayon-striped-num">10</div>
<div class="crayon-num">11</div>
<div class="crayon-num x_crayon-striped-num">12</div>
<div class="crayon-num">13</div>
<div class="crayon-num x_crayon-striped-num">14</div>
<div class="crayon-num">15</div>
<div class="crayon-num x_crayon-striped-num">16</div>
<div class="crayon-num">17</div>
<div class="crayon-num x_crayon-striped-num">18</div>
<div class="crayon-num">19</div>
<div class="crayon-num x_crayon-striped-num">20</div>
<div class="crayon-num">21</div>
<div class="crayon-num x_crayon-striped-num">22</div>
<div class="crayon-num">23</div>
<div class="crayon-num x_crayon-striped-num">24</div>
<div class="crayon-num">25</div>
<div class="crayon-num x_crayon-striped-num">26</div>
<div class="crayon-num">27</div>
<div class="crayon-num x_crayon-striped-num">28</div>
<div class="crayon-num">29</div>
<div class="crayon-num x_crayon-striped-num">30</div>
</div>
</td>
<td class="crayon-code">
<div class="crayon-pre">
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-1"><span class="crayon-sy">[</span><span class="crayon-e">RoutePrefix</span><span class="crayon-sy">(</span><span class="crayon-s">&quot;api/Product&quot;</span><span class="crayon-sy">)</span><span class="crayon-sy">]</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-2">
<span class="crayon-m">public</span><span class="crayon-h"> </span><span class="crayon-t">class</span><span class="crayon-h">
</span><span class="crayon-v">ProductController</span><span class="crayon-h">
</span><span class="crayon-o">:</span><span class="crayon-h"> </span><span class="crayon-e">ApiController</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-3"><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-4">
<span class="crayon-m">private</span><span class="crayon-h"> </span><span class="crayon-e">dbUIGrid_Entities
</span><span class="crayon-v">_ctx</span><span class="crayon-h"> </span><span class="crayon-o">=</span><span class="crayon-h">
</span><span class="crayon-t">null</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-5">&nbsp;</div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-6">
<span class="crayon-sy">[</span><span class="crayon-v">HttpGet</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-e">ResponseType</span><span class="crayon-sy">(</span><span class="crayon-r">typeof</span><span class="crayon-sy">(</span><span class="crayon-v">tblProduct</span><span class="crayon-sy">)</span><span class="crayon-sy">)</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-e">Route</span><span class="crayon-sy">(</span><span class="crayon-s">&quot;GetProducts/{pageNumber:int}/{pageSize:int}&quot;</span><span class="crayon-sy">)</span><span class="crayon-sy">]</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-7"><span class="crayon-m">public</span><span class="crayon-h">
</span><span class="crayon-e">IHttpActionResult </span><span class="crayon-e">GetProducts</span><span class="crayon-sy">(</span><span class="crayon-t">int</span><span class="crayon-h">
</span><span class="crayon-v">pageNumber</span><span class="crayon-sy">,</span><span class="crayon-h">
</span><span class="crayon-t">int</span><span class="crayon-h"> </span><span class="crayon-v">pageSize</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-8">
<span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-9"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">List</span><span class="crayon-o">&lt;</span><span class="crayon-v">tblProduct</span><span class="crayon-o">&gt;</span><span class="crayon-h">
</span><span class="crayon-v">productList</span><span class="crayon-h"> </span>
<span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-t">null</span><span class="crayon-sy">;</span><span class="crayon-h">
</span><span class="crayon-t">int</span><span class="crayon-h"> </span><span class="crayon-v">recordsTotal</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-cn">0</span><span class="crayon-sy">;</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-10">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">try</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-11"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-12">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">using</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">_ctx</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-r">new</span><span class="crayon-h">
</span><span class="crayon-e">dbUIGrid_Entities</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">)</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-13"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-14">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">recordsTotal</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">_ctx</span><span class="crayon-sy">.</span><span class="crayon-v">tblProducts</span><span class="crayon-sy">.</span><span class="crayon-e">Count</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-15"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">productList</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-h"> </span><span class="crayon-v">_ctx</span><span class="crayon-sy">.</span><span class="crayon-v">tblProducts</span><span class="crayon-sy">.</span><span class="crayon-e">OrderBy</span><span class="crayon-sy">(</span><span class="crayon-v">x</span><span class="crayon-h">
</span><span class="crayon-o">=</span><span class="crayon-o">&gt;</span><span class="crayon-h">
</span><span class="crayon-v">x</span><span class="crayon-sy">.</span><span class="crayon-v">ProductID</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-16">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">.</span><span class="crayon-e">Skip</span><span class="crayon-sy">(</span><span class="crayon-v">pageNumber</span><span class="crayon-sy">)</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-17"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">.</span><span class="crayon-e">Take</span><span class="crayon-sy">(</span><span class="crayon-v">pageSize</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-18">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">.</span><span class="crayon-e">ToList</span><span class="crayon-sy">(</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-19"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-20">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-21"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">catch</span><span class="crayon-h">
</span><span class="crayon-sy">(</span><span class="crayon-v">Exception</span><span class="crayon-sy">)</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-22">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-23"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-24">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-st">return</span><span class="crayon-h">
</span><span class="crayon-e">Json</span><span class="crayon-sy">(</span><span class="crayon-r">new</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-25"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">{</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-26">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-v">recordsTotal</span><span class="crayon-sy">,</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-27"><span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-i">productList</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-28">
<span class="crayon-h">&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="crayon-sy">}</span><span class="crayon-sy">)</span><span class="crayon-sy">;</span></div>
<div class="crayon-line" id="crayon-577a93a2ed79c893489154-29"><span class="crayon-sy">}</span></div>
<div class="crayon-line x_crayon-striped-line" id="crayon-577a93a2ed79c893489154-30">
<span class="crayon-sy">}</span></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><strong>Final Output:</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig13.png"><img class="alignnone size-large x_wp-image-2916" src="http://shashangka.com/wp-content/uploads/2016/05/uig13-1024x476.png" alt="uig13" width="646" height="300"></a></p>
<p>Fig: 13</p>
<p><strong>Filter Data:</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/05/uig14.png"><img class="alignnone size-large x_wp-image-2917" src="http://shashangka.com/wp-content/uploads/2016/05/uig14-1024x223.png" alt="uig14" width="646" height="141"></a></p>
<p>Fig: 14</p>
<p>Hope this will help&nbsp;<img class="wp-smiley" src="http://shashangka.com/wp-includes/images/smilies/simple-smile.png" alt=":)"></p>
